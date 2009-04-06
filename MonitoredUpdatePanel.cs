using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using PostBackRitalin;

namespace Encosia
{
  public class MonitoredUpdatePanel
  {
    private string _waitImage;

    [Description("The ID of an UpdatePanel to monitor")]
    public string UpdatePanelID { get; set; }

    [Localizable(true)]
    [Description("The WaitText to use for Buttons in this monitored UpdatePanel.")]
    public string WaitText { get; set; }

    [UrlProperty]
    [Localizable(true)]
    [Description("The WaitImage to use for ImageButtons in this monitored UpdatePanel.")]
    public string WaitImage
    {
      get { return _waitImage; }
      set { _waitImage = Utilities.VirtualURLHelper(value); }
    }

    [Description("Should all elements within this UpdatePanel be disabled when it triggers a partial postback?")]
    [DefaultValue(false)]
    public bool DisableAllElements { get; set; }
  }

  public class MonitoredUpdatePanelCollection : List<MonitoredUpdatePanel>
  {
  }
}
