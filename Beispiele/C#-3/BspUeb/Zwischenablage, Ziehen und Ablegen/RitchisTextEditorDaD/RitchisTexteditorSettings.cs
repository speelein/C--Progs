using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

class RitchisTexteditorSettings : ApplicationSettingsBase {

	[UserScopedSettingAttribute()]
    [DefaultSettingValueAttribute("True")]
    public bool WordWrap {
        get {
            return ((bool)(this["WordWrap"]));
        }
        set {
            this["WordWrap"] = value;
        }
    }

	[UserScopedSettingAttribute()]
	[DefaultSettingValueAttribute("Both")]
	public RichTextBoxScrollBars ScrollBars {
		get {
			return ((RichTextBoxScrollBars)(this["ScrollBars"]));
		}
		set {
			this["ScrollBars"] = value;
		}
	}
    
    [UserScopedSettingAttribute()]
    [DefaultSettingValueAttribute("1")]
    public float ZoomFactor {
        get {
            return ((float)(this["ZoomFactor"]));
        }
        set {
            this["ZoomFactor"] = value;
        }
    }
    
	[UserScopedSettingAttribute()]
	[DefaultSettingValueAttribute("White")]
	public Color BackColor {
		get {
			return ((Color)(this["BackColor"]));
		}
		set {
			this["BackColor"] = value;
		}
	}

	[UserScopedSettingAttribute()]
	[DefaultSettingValueAttribute("400, 300")]
	public Size ClientSize {
		get {
			return ((Size)(this["ClientSize"]));
		}
		set {
			this["ClientSize"] = value;
		}
	}

	[UserScopedSettingAttribute()]
	[DefaultSettingValueAttribute("100, 100")]
	public Point Location {
		get {
			return ((Point)(this["Location"]));
		}
		set {
			this["Location"] = value;
		}
	}

	[ApplicationScopedSettingAttribute()]
	public string AppName {
		get {
			return ((string)(this["AppName"]));
		}
	}
}

