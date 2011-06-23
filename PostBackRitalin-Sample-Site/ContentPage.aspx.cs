using System;

public partial class Default2 : System.Web.UI.Page
{
  protected void Button1_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(2000);
    Literal1.Text = DateTime.Now.ToString();
  }

  protected void Button2_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(2000);
    Literal2.Text = DateTime.Now.ToString();
  }

  protected void Button3_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(2000);
    Literal3.Text = DateTime.Now.ToString();
  }

  protected void Button4_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(2000);
    Literal3.Text = DateTime.Now.ToString();
  }
}
