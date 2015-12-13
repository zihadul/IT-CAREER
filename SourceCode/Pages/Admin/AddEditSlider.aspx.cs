using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;



public partial class Pages_Admin_AddEditSlider : System.Web.UI.Page
{
    int ID
    {
        set { ViewState["ID"] = value; }
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["ID"].ToString());
            }
            catch
            {
                return 0;
            }
        }
    }

    bllSlider objSlider = new bllSlider();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.Identity.Name != "")
            {
                if (Roles.GetRolesForUser()[0] != "Admin" && Roles.GetRolesForUser()[0] != "SystemAdmin")
                    Response.Redirect("~/Login.aspx", true);
            }
            else
                Response.Redirect("~/Login.aspx", true);
            if (Request.QueryString["ID"] != null)
            {
                ID = Convert.ToInt32(Request.QueryString["ID"].ToString());

                Populate();
            }
            else
            {
                btnRemoveDisplayImage.Visible = false;
                btnImg.Visible = false;
            }
        }
    }
    private void Populate()
    {
        DataTable dt = objSlider.GetByID(ID);
        if (dt.Rows.Count > 0)
        {
            reqFilePhotograph.Enabled = false;
            hdnAttachmentName.Value = dt.Rows[0]["ImageName"].ToString();
            imgDisplay.Visible = false;
            tbxDescription.Text = dt.Rows[0]["Description"].ToString();
            rblActive.Text = dt.Rows[0]["Active"].ToString() == "True" ? "1" : "0";
            lblImage.Text = dt.Rows[0]["ImageName"].ToString();
            if (lblImage.Text != "")
            {
                btnRemoveDisplayImage.Visible = true;
                btnRemoveDisplayImage.ForeColor = System.Drawing.Color.Green;
                lblImage.Visible = false;
                btnImg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblImage.Visible = false;
            }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        saveData();
    }
    private void saveData()
    {
        string FileName = hdnAttachmentName.Value;

        if (filePhotograph.HasFile)
            FileName = filePhotograph.FileName;

        if (ID == 0)
        {

            if (!filePhotograph.HasFile)
                return;

            ID = objSlider.Insert(FileName, Convert.ToInt32(rblActive.Text), tbxDescription.Text);

            FileName = filePhotograph.FileName;
            MessageController.Show(MessageCode._SaveSucceeded,MessageType.Information, Page);
            ID = 0;
            ClearAll();

        }
        else
        {
            if (filePhotograph.HasFile)
            {
                if (hdnAttachmentName.Value != "")
                {
                    Common.DeleteFile(Server.MapPath("~/Resources/UserFile/Slider/" + hdnAttachmentName.Value));
                    Common.DeleteFile(Server.MapPath("~/Resources/UserFile/Slider/thumbs/" + hdnAttachmentName.Value));
                }

                FileName = filePhotograph.FileName;
            }


            objSlider.Update(ID, FileName, Convert.ToInt32(rblActive.Text), tbxDescription.Text);
            MessageController.Show(MessageCode._SaveSucceeded, MessageType.Information, Page);
            ClearAll();

        }


        if (filePhotograph.HasFile)
        {
            filePhotograph.SaveAs(MapPath("~/Resources/UserFile/Slider/") + FileName);
            System.Drawing.Image imageX = Common.GetThumsImage(MapPath("~/Resources/UserFile/Slider/") + FileName, 685, 310);
            imageX.Save(MapPath("~/Resources/UserFile/Slider/thumbs/") + FileName);
        }

        if (ID == 0)
        {
            tbxDescription.Text = "";
        }
    }

    public void ClearAll()
    {
        tbxDescription.Text = "";
        hdnAttachmentName.Value = "";
        hdnAttachmentName.Visible = false;
        imgDisplay.Visible = false;
    }
    protected void btnImg_Command(object sender, CommandEventArgs e)
    {

        imgPhoto.ImageUrl = "~/Resources/Userfile/Slider/" + hdnAttachmentName.Value;
        Popup1.Show();
    }
    protected void btnRemoveDisplayImage_Click(object sender, EventArgs e)
    {
        if (lblImage.Text != "")
        {
            Common.DeleteFile(Server.MapPath("~/Resources/Userfile/Slider/" + lblImage.Text));
            Common.DeleteFile(Server.MapPath("~/Resources/Userfile/Slider/Thumbs/" + hdnAttachmentName.Value));
            hdnAttachmentName.Value = "";
            hdnAttachmentName.Visible = false;
            imgDisplay.Visible = false;
        }

        lblImage.Text = "";
        Populate();
        btnRemoveDisplayImage.Visible = false;

        lblError.Text = "Display image removed";
        lblError.ForeColor = System.Drawing.Color.Green;
    }
}