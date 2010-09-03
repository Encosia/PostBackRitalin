using System;
using System.ComponentModel;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.Design;

namespace Encosia
{
  [ToolboxData("<{0}:PostBackRitalin runat=\"server\"></{0}:PostBackRitalin>")]
  [Designer(typeof(PostBackRitalinDesigner))]
  [ParseChildren(true)]
  [PersistChildren(false)]
  [NonVisualControl]
  public class PostBackRitalin : Control
  {
    private MonitoredUpdatePanelCollection _monitoredUpdatePanels = new MonitoredUpdatePanelCollection();
    
    private string _waitText = "Processing...";
    private string _waitImage;
    private string _waitClass;

    private bool _preloadWaitImages = true;
  
    [PersistenceMode(PersistenceMode.InnerProperty)]
    [NotifyParentProperty(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public MonitoredUpdatePanelCollection MonitoredUpdatePanels
    {
      get { return _monitoredUpdatePanels; }
    }

    [DefaultValue("Processing...")]
    [Localizable(true)]
    [TypeConverter(typeof(StringConverter))]
    [Description("Progress indication message to show in disabled buttons during partial postback.")]
    public string WaitText
    {
      get { return _waitText; }
      set { _waitText = value; }
    }
    
    [UrlProperty]
    [Editor(typeof(ImageUrlEditor), typeof(System.Drawing.Design.UITypeEditor))]
    [Localizable(true)]
    [DefaultValue("")]
    [Description("Progress indication image URL to replace ImageButtons with during partial postbacks.")]
    public string WaitImage
    {
      get { return _waitImage; }
      set { _waitImage = value; }
    }

    [Description("This CSS class will be applied to disabled links during partial postbacks.")]
    public string WaitClass
    {
      get { return _waitClass; }
      set { _waitClass = value; }
    }

    [DefaultValue(true)]
    [Description("If true, WaitImages will be preloaded on the client side.")]
    public bool PreloadWaitImages
    {
      get { return _preloadWaitImages; }
      set { _preloadWaitImages = value; }
    }

    protected override void OnPreRender(EventArgs e)
    {
      // Only inject the object on initial page loads, IF partial rendering is enabled.
      if (!Page.IsPostBack && ScriptManager.GetCurrent(Page).EnablePartialRendering)
      {
        // Register the JavaScript class include.
        if (HttpContext.Current.IsDebuggingEnabled)
          Page.ClientScript.RegisterClientScriptResource(GetType(), "PostBackRitalin.PostBackRitalin.js");
        else
          Page.ClientScript.RegisterClientScriptResource(GetType(), "PostBackRitalin.PostBackRitalin.min.js");

        string waitText, waitImage, monitoredUpdatePanels, waitClass;

        if (!string.IsNullOrEmpty(_waitText))
          waitText = string.Format("'{0}'", _waitText);
        else
          waitText = "null";

        if (!string.IsNullOrEmpty(_waitImage))
          waitImage = string.Format("'{0}'", ResolveUrl(_waitImage));
        else
          waitImage = "null";

        if (!string.IsNullOrEmpty(_waitClass))
          waitClass = string.Format("'{0}'", _waitClass);
        else
          waitClass = "null";


        if (_monitoredUpdatePanels.Count > 0)
        {
          JavaScriptSerializer js = new JavaScriptSerializer();

          monitoredUpdatePanels = js.Serialize(_monitoredUpdatePanels);
        }
        else
        {
          monitoredUpdatePanels = "null";
        }

        string preload = _preloadWaitImages ? "true" : "false";

        // Inject JavaScript to create the PBR object, with parameters matching the properties of the
        //  server control.
        string script = string.Format("var pbr = new PostBackRitalin({0}, {1}, {2}, {3}, {4});",
                                      waitText, waitImage, monitoredUpdatePanels, preload,
                                      waitClass);

        Page.ClientScript.RegisterStartupScript(Page.GetType(), "PostBackRitalin_Init", script, true);
      }
    }
  }
}