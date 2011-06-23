using System;

public partial class ImageButton : System.Web.UI.Page
{
  protected void ImageButton1_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(2000);
    Literal1.Text = DateTime.Now.ToString();
  }
}
