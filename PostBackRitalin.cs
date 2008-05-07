using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
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
    [Description("Progress indication message to show in disabled buttons during partial postback.")]
    public string WaitText
    {
      get { return _waitText; }
      set { _waitText = value; }
    }
    
    [UrlProperty()]
    [Description("Progress indication image URL to replace ImageButtons with during partial postbacks.")]
    public string WaitImage
    {
      get { return _waitImage; }
      set { _waitImage = value; }
    }

    protected override void OnPreRender(EventArgs e)
    {
      base.OnPreRender(e);

      if (ScriptManagerHelper.IsMicrosoftAjaxAvailable)
      {
        ScriptManagerHelper.RegisterClientScriptResource(
          this,
          typeof(PostBackRitalin),
          "PostBackRitalin.PostBackRitalin.js");

        StringBuilder script = new StringBuilder();
        
        script.Append("Sys.Application.add_init(PBR_ApplicationInit);");
        
        if (!string.IsNullOrEmpty(_waitText))
          script.AppendFormat("var PBR_WaitText = '{0}';", _waitText);
        
        if (!string.IsNullOrEmpty(_waitImage))
          script.AppendFormat("var PBR_WaitImage = '{0}';", ResolveUrl(_waitImage));

        if (_monitoredUpdatePanels.Count > 0)
          script.Append(_monitoredUpdatePanels.GetMonitoredPanelsArray());

        script.Append(_monitoredUpdatePanels.GetWaitTextsArray());

        script.Append(_monitoredUpdatePanels.GetWaitImagesArray());

        ScriptManagerHelper.RegisterStartupScript(
          this,
          typeof(PostBackRitalin),
          "PBR_Initialize",
          script.ToString(),
          true);
      }
      else
        throw new Exception("Unable to acquire a ScriptManager reference.  PostBack");
    }
  }
}