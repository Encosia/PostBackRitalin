using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace Encosia
{
  public class MonitoredUpdatePanel
  {
    private string _updatePanelID;
    private string _waitText;
    private string _waitImage;

    [Description("The ID of an UpdatePanel to monitor")]
    public string UpdatePanelID
    {
      get { return _updatePanelID; }
      set { _updatePanelID = value; }
    }

    [Description("The WaitText to use for Buttons in this monitored UpdatePanel.")]
    public string WaitText
    {
      get { return _waitText; }
      set { _waitText = value; }
    }

    [UrlProperty()]
    [Description("The WaitImage to use for ImageButtons in this monitored UpdatePanel.")]
    public string WaitImage
    {
      get { return _waitImage; }
      set { _waitImage = value; }
    }
  }

  public class MonitoredUpdatePanelCollection : List<MonitoredUpdatePanel>
  {
    /// <summary>
    /// Gets a JavaScript Array declaration representing the ClientIDs in the collection.
    /// </summary>
    /// <returns>Ex: var PBR_MonitoredUpdatePanels = new Array('UpdatePanel1','UpdatePanel2');</returns>
    internal string GetMonitoredPanelsArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("var PBR_MonitoredUpdatePanels = new Array(");

      foreach (MonitoredUpdatePanel pnl in this)
        sb.AppendFormat("'{0}',", pnl.UpdatePanelID);

      sb.Remove(sb.Length - 1, 1);

      sb.Append(");");

      return sb.ToString();
    }

    /// <summary>
    /// Gets a JavaScript Array declaration representing the WaitTexts in the collection.
    /// </summary>
    /// <returns>Ex: var PBR_WaitTexts = new Array('Submitting...','Processing...');</returns>
    internal string GetWaitTextsArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("var PBR_WaitTexts = new Array();");

      foreach (MonitoredUpdatePanel pnl in this)
        if (!string.IsNullOrEmpty(pnl.WaitText))
          sb.AppendFormat("PBR_WaitTexts['{0}'] = '{1}';", pnl.UpdatePanelID, pnl.WaitText);

      return sb.ToString();
    }

    /// <summary>
    /// Gets a JavaScript Array declaration representing the WaitImages in the collection.
    /// </summary>
    /// <returns>Ex: var PBR_MonitoredUpdatePanels = new Array('waitimage1.jpg','waitimage2.jpg');</returns>
    internal string GetWaitImagesArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("var PBR_WaitImages = new Array();");

      foreach (MonitoredUpdatePanel pnl in this)
        if (!string.IsNullOrEmpty(pnl.WaitImage))
          sb.AppendFormat("PBR_WaitImages['{0}'] = '{1}';", pnl.UpdatePanelID,
                                                            VirtualURLHelper(pnl.WaitImage));

      return sb.ToString();
    }

    private string VirtualURLHelper(string URL)
    {
      if (URL.StartsWith("~"))
        return System.Web.VirtualPathUtility.ToAbsolute(URL);
      else
        return URL;
    }
  }
}
