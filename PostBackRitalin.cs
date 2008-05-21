using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Encosia
{
  [ToolboxData("<{0}:PostBackRitalin runat=\"server\"></{0}:PostBackRitalin>")]
  [ParseChildren(true)]
  [PersistChildren(false)]
  [NonVisualControl]
  [ToolboxBitmap(typeof(Button))]
  public class PostBackRitalin : Control
  {
    private MonitoredUpdatePanelCollection _monitoredUpdatePanels = new MonitoredUpdatePanelCollection();
    private string _waitText = "Processing...";
    private string _waitImage;
  
    [PersistenceMode(PersistenceMode.InnerProperty)]
    [NotifyParentProperty(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public MonitoredUpdatePanelCollection MonitoredUpdatePanels
    {
      get { return _monitoredUpdatePanels; }
    }


    [DefaultValue("Processing...")]
    [Localizable(true)]
    [Description("Progress indication message to show in disabled buttons during partial postback.")]
    public string WaitText
    {
      get { return _waitText; }
      set { _waitText = value; }
    }
    
    [UrlProperty()]
    [Localizable(true)]
    [Description("Progress indication image URL to replace ImageButtons with during partial postbacks.")]
    public string WaitImage
    {
      get { return _waitImage; }
      set { _waitImage = value; }
    }

    protected override void OnPreRender(EventArgs e)
    {
      Page.ClientScript.RegisterClientScriptResource(this.GetType(), "PostBackRitalin.PostBackRitalin.js");

      string waitText, waitImage, monitoredUpdatePanels, waitTexts, waitImages;


      if (!string.IsNullOrEmpty(_waitText))
        waitText = string.Format("'{0}'", _waitText);
      else
        waitText = "null";
      
      if (!string.IsNullOrEmpty(_waitImage))
        waitImage = string.Format("'{0}'", ResolveUrl(_waitImage));
      else
        waitImage = "null";

      if (_monitoredUpdatePanels.Count > 0)
      {
        monitoredUpdatePanels = _monitoredUpdatePanels.GetMonitoredPanelsArray();

        waitTexts = _monitoredUpdatePanels.GetWaitTextsArray();

        if (string.IsNullOrEmpty(waitTexts))
          waitTexts = "null";

        waitImages = _monitoredUpdatePanels.GetWaitImagesArray();

        if (string.IsNullOrEmpty(waitImages))
          waitImages = "null";
      }
      else
      {
        monitoredUpdatePanels = "null";
        waitTexts = "null";
        waitImages = "null";
      }

      string script = string.Format("var pbr = new PostBackRitalin({0}, {1}, {2}, {3}, {4}, true);",
        waitText, waitImage, monitoredUpdatePanels, waitTexts, waitImages);

      Page.ClientScript.RegisterStartupScript(Page.GetType(), "PostBackRitalin_Init", script, true);
    }
  }
}