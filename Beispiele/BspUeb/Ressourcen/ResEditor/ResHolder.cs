namespace ResEditorComponents 
{
    
   using System;
   using System.Drawing;
   using System.ComponentModel;
   using System.Windows.Forms;
   using System.Resources; 
   using System.Collections; 

                                 
   //ResHolder is a component that holds the resources read out of a resources file
   //by implementing ICustomTypeDescriptor we make the shape of this component 
   //dynamic based on the contents resource file. This allows us to edit the 
   //resources in the PropertyGrid
   [TypeConverter((typeof(ExpandableObjectConverter)))]
   public class ResHolder : Component, ICustomTypeDescriptor {
        
      PropertyDescriptorCollection propsCollection;
      internal bool dirty = false ;

      public ResHolder() : base() {
         propsCollection = new PropertyDescriptorCollection(null);
      }

      public bool IsDirty
      {
         get { return dirty ; }
         set { dirty = value ; }
      }

      public ResHolder(IResourceReader rrdr) : this() {

         IDictionaryEnumerator resEnum = rrdr.GetEnumerator();
         while (resEnum.MoveNext()) 
         {

            string name = (string)resEnum.Key;
            object value = resEnum.Value;
            Console.WriteLine(name + " = " + value);

            ((IList)(propsCollection)).Add(new ResourceDescriptor(this,name,value));
         }
      }

      public void Add(string name, Type type) {
         if ((propsCollection[name] != null) | (CheckProperties(name) == true)){
            throw new ApplicationException("Bad Name");
         }
         ((IList)(propsCollection)).Add(new ResourceDescriptor(this,name,type));
         dirty=true;
      }

      public void Rename(string name) {
         if ((propsCollection[name] != null) | (CheckProperties(name) == true)){
            throw new ApplicationException("Bad Name");
         }
         dirty=true;
      }

      public void Delete(PropertyDescriptor pd) {
         Console.WriteLine("removing " + ResCount);

         //IndexOf fails - why - check with sb
         Console.WriteLine("index is " + ((IList)(propsCollection)).IndexOf(pd));

         //Use brute force
         PropertyDescriptorCollection oldprops = propsCollection;
         propsCollection = new PropertyDescriptorCollection(null);

         IEnumerator pcEnum = oldprops.GetEnumerator();
         while (pcEnum.MoveNext()) {
            object pCurrent = pcEnum.Current;
            if (pCurrent != pd) {
               ((IList)(propsCollection)).Add(pcEnum.Current);
            }
         }

         Console.WriteLine("removed " + ResCount);
         dirty=true;
      }

      public void Rebuild() {
         PropertyDescriptorCollection oldprops = propsCollection;
         propsCollection = new PropertyDescriptorCollection(null);

         IEnumerator pcEnum = oldprops.GetEnumerator();
         while (pcEnum.MoveNext()) {
            object pCurrent = pcEnum.Current;
            ((IList)(propsCollection)).Add(pcEnum.Current);
         }
         dirty=true;
      }
	    
      public int ResCount {
         get {
            return ((IList)(propsCollection)).Count;
         }
      }

	   public bool CheckProperties(string lookfor) 
	   {
		   IEnumerator pcEnum = propsCollection.GetEnumerator();
		   while (pcEnum.MoveNext()) 
		   {
			   ResourceDescriptor p = (ResourceDescriptor)(pcEnum.Current);
			   if (p.ResourceName.ToLower() == lookfor.ToLower()) 
			   {
				   return true;
			   }
		   }
		   return false;
	   }

	   public void DumpResources() 
	   {
         IEnumerator pcEnum = propsCollection.GetEnumerator();
         while (pcEnum.MoveNext()) {
            ResourceDescriptor p = (ResourceDescriptor)(pcEnum.Current);
            if (null != p.ResourceValue) {
               MessageBox.Show("Dumping " + p.ResourceName + " " + p.ResourceValue);
            }
         }
      }

      public void WriteResources(IResourceWriter rwtr) {
         try {
            IEnumerator pcEnum = propsCollection.GetEnumerator();
            while (pcEnum.MoveNext()) {
               ResourceDescriptor p = (ResourceDescriptor)(pcEnum.Current);
               if (null != p.ResourceValue) 
               {
                  Console.WriteLine("Adding " + p.ResourceName + " " + p.ResourceValue);
                  rwtr.AddResource (p.ResourceName, p.ResourceValue) ;
               }
            }
         } 
         finally {
            //rwtr.Write();
            dirty=false;
         }
      }

      AttributeCollection ICustomTypeDescriptor.GetAttributes() 
      {
         return new AttributeCollection(null);
      }

      string ICustomTypeDescriptor.GetClassName() 
      {
         return null;
      }

      string ICustomTypeDescriptor.GetComponentName() 
      {
         return null;
      }

      TypeConverter ICustomTypeDescriptor.GetConverter() 
      {
         return null;
      }

      EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() 
      {
         return null;
      }


      PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() 
      {
         return null;
      }

      object ICustomTypeDescriptor.GetEditor(Type editorBaseType) 
      {
         return null;
      }

      EventDescriptorCollection ICustomTypeDescriptor.GetEvents() 
      {
         return new EventDescriptorCollection(null);
      }

      EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) 
      {
         return new EventDescriptorCollection(null);
      }

      PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() 
      {
         return propsCollection;
         //return((ICustomTypeDescriptor)this).GetProperties(null);
      }

      PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes) 
      {
         return propsCollection;
      }

      object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd) 
      {
         return this;
      }
   }

   public class ResourceDescriptor : PropertyDescriptor 
   {

      private ResHolder rh = null ;
      private string name = null ;
      private object value = null ;
      private Type type = null ; 

      public ResourceDescriptor(ResHolder rh, string name, object value) : this(rh, name, value.GetType()) 
      {
         this.value = value;
      }

      public ResourceDescriptor(ResHolder rh, string name, Type type) : base(name, null) 
      {
         this.rh = rh ;
         this.name = name;
         this.type = type;
      }


      public override string Category 
      { 
         get 
         {
            return this.type.Name;
         }
      }
  
      public string ResourceName 
      {
         get { return name ; }
         set { name = value ; }
      }

      public object ResourceValue 
      {
         get { return value ; }
      }


      public override string DisplayName { 
	get {
           return name;
        }
      }

      public override Type ComponentType 
      {
         get 
         {
            return typeof(ResHolder);
         }
      }

      public override bool IsReadOnly 
      {
         get 
         {
            return false;
         }
      }

      public override Type PropertyType 
      {
         get 
         {
            return type;
         }
      }

      public override bool CanResetValue(object component) 
      {
         return false ;
      }

      public override object GetValue(object component) 
      {
         return value;
      }

      public override void ResetValue(object component) 
      {
         this.value = null;
      }

      public override void SetValue(object component, object value) 
      {
         this.value = value;
         rh.dirty = true ;
      }

      public override bool ShouldSerializeValue(object component) 
      {
         return false;
      }
   }   
}
