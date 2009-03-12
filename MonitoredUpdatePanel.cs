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

    [Localizable(true)]
    [Description("The WaitText to use for Buttons in this monitored UpdatePanel.")]
    public string WaitText
    {
      get { return _waitText; }
      set { _waitText = value; }
    }

    [UrlProperty]
    [Localizable(true)]
    [Description("The WaitImage to use for ImageButtons in this monitored UpdatePanel.")]
    public string WaitImage
    {
      get { return _waitImage; }
      set { _waitImage = value; }
    }

    [Description("Should all elements within this UpdatePanel be disabled when it triggers a partial postback?")]
    [DefaultValue(false)]
    public bool DisableAllElements
    {
      get; set;
    }
  }

  public class MonitoredUpdatePanelCollection : List<MonitoredUpdatePanel>
  {
    /// <summary>
    /// Gets a JavaScript Array declaration representing the ClientIDs in the collection.
    /// </summary>
    /// <returns>Ex: ['UpdatePanel1','UpdatePanel2']</returns>
    internal string GetMonitoredPanelsArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("[");

      foreach (MonitoredUpdatePanel pnl in this)
        sb.AppendFormat("'{0}',", pnl.UpdatePanelID);

      sb.Remove(sb.Length - 1, 1);

      sb.Append("]");

      return sb.ToString();
    }

    /// <summary>
    /// Gets a JavaScript Array declaration representing the WaitTexts in the collection.
    /// </summary>
    /// <returns>Ex: {'UpdatePanel1':'Submitting...', 'UpdatePanel2':'Processing...'}</returns>
    internal string GetWaitTextsArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("{");

      foreach (MonitoredUpdatePanel pnl in this)
        if (!string.IsNullOrEmpty(pnl.WaitText))
          sb.AppendFormat("'{0}':'{1}',", pnl.UpdatePanelID, pnl.WaitText);

      if (sb.Length > 2)
      {
        sb.Remove(sb.Length - 1, 1);

        sb.Append("}");

        return sb.ToString();
      }

      // Else
      return null;
    }

    /// <summary>
    /// Gets a JavaScript Array declaration representing the WaitImages in the collection.
    /// </summary>
    /// <returns>Ex: {'UpdatePanel1':'waitimage1.jpg','UpdatePanel2':'waitimage2.jpg'}</returns>
    internal string GetWaitImagesArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("{");

      foreach (MonitoredUpdatePanel pnl in this)
      {
        if (!string.IsNullOrEmpty(pnl.WaitImage))
        {
          sb.AppendFormat("'{0}':'{1}',", pnl.UpdatePanelID, VirtualURLHelper(pnl.WaitImage));
        }
      }

      // If items have been added, remove the extraneous trailing comma.
      if (sb.Length > 2)
      {
        sb.Remove(sb.Length - 1, 1);

        sb.Append("}");

        return sb.ToString();
      }
      
      // Else
      return null;
    }

    internal string GetDisableAllArray()
    {
      StringBuilder sb = new StringBuilder();

      sb.Append("{");

      foreach (MonitoredUpdatePanel pnl in this)
      {
        sb.AppendFormat("'{0}':'{1}',", pnl.UpdatePanelID, pnl.DisableAllElements);
      }

      // If items have been added, remove the extraneous trailing comma.
      if (sb.Length > 2)
      {
        sb.Remove(sb.Length - 1, 1);

        sb.Append("}");

        return sb.ToString();
      }

      // Else
      return null;
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
