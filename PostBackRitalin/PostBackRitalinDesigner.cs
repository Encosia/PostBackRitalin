using System.Web.UI.Design;

namespace Encosia
{
  public class PostBackRitalinDesigner : ControlDesigner
  {
    public override string GetDesignTimeHtml()
    {
      string template = @"<table style=""border:1px solid #CCCCCC;"" cellspacing=""0"" cellpadding=""0"">
<tr>
<td nowrap style=""font:messagebox;background-color:#ffffff;color:#444444;background-position:bottom;background-repeat:repeat-x;padding:4px;""><strong>PostBackRitalin</strong> - {0}</td>
</tr>
</table>";

      return string.Format(template, this.ID);
    }
  }
}