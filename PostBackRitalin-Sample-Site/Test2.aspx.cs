using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test2 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  protected void btn_Delete_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(1500);
    lbl_Text.Text = "Delete";
    return;
  }
  protected void btn_Save_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(1500);
    lbl_Text.Text = "Save";
    return;
  }
  protected void btn_Post_Click(object sender, EventArgs e)
  {
    System.Threading.Thread.Sleep(1500);
    lbl_Text.Text = "Post";
    return;
  }

}