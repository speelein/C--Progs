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

	[ApplicationScopedSettingAttribute()]
	[DefaultSettingValueAttribute("Ritchis Tecksteditor")]
	public string AppName {
		get {
			return ((string)(this["AppName"]));
		}
	}
}

