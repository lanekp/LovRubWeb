#region dCPL Version 1.1.1
/*
The contents of this file are subject to the dashCommerce Public License
Version 1.1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.dashcommerce.org

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is dashCommerce.

The Initial Developer of the Original Code is Mettle Systems LLC.
Portions created by Mettle Systems LLC are Copyright (C) 2007. All Rights Reserved.
*/
#endregion

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Commerce.Messaging;

public partial class Admin_Admin_Mailers : System.Web.UI.Page {
  private void Page_Load(object sender, System.EventArgs e) {
    if (!Page.IsPostBack)
      LoadGrid();
  }

  #region Grid Functions
  void LoadGrid() {
    ToggleGrid(true);
    dg.DataSource = Commerce.Messaging.Email.FetchAll();
    dg.DataBind();
  }

  void ToggleGrid(bool show) {
    pnlGrid.Visible = show;
    pnlEdit.Visible = !show;
  }


  #endregion

  #region Add Loader
  void LoadAddForm() {
    lblID.Visible = false;
    LoadDropDowns();
    btnDelete.Visible = false;
    btnSave.Text = "Add";
    ToggleGrid(false);
  }

  #endregion
  void LoadDropDowns() {

  }
  #region Editor Loader
  void LoadEditor(string editID) {
    //load the drops
    ToggleGrid(false);
    btnDelete.Visible = true;
    btnDelete.Attributes.Add("onclick", "return CheckDelete();");
    btnSave.Text = "Update";

    //load the rest
    lblID.Text = editID;
    LoadEditData(editID);
    LoadDropDowns();
  }

  void LoadEditData(string editID) {
    Email mail = new Email(int.Parse(editID));
    LoadDropDowns();
    lblID.Text = editID;
    txtMailerName.Text = mail.MailerName;
    txtToList.Text = mail.ToList;
    txtCcList.Text = mail.CcList;
    txtFromName.Text = mail.FromName;

    txtFromEmail.Text = mail.FromEmail;
    txtSubject.Text = mail.Subject;
    txtMessageBody.Text = mail.MessageBody;
    bool bIsHTML = mail.IsHTML;
    if (bIsHTML) {
      chkIsHTML.Checked = true;
    }
    chkIsSystemMailer.Checked = mail.IsSystemMailer;
    btnDelete.Visible = !mail.IsSystemMailer;
  }
  #endregion

  #region DB Methods

  void Delete() {

    bool isError = false;
    try {
      Email.Delete(int.Parse(lblID.Text));
    }
    catch (Exception x) {
      isError = true;
      ThrowError(x.Message);
    }
    if (!isError)
      Response.Redirect(Request.Url.PathAndQuery, false);

  }
  #endregion
  #region Event Handlers

  protected void GridEdit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {
    //the id is the second column
    string sEditID = e.Item.Cells[1].Text;
    LoadEditor(sEditID);
  }

  protected void btnAdd_Click(object sender, System.EventArgs e) {
    LoadAddForm();
  }
  protected void btnDelete_Click(object sender, EventArgs e) {
    this.Delete();
  }
  protected void btnSave_Click(object sender, System.EventArgs e) {

    Email mail = null;
    if (lblID.Text != string.Empty) {
      mail = new Email(int.Parse(lblID.Text));
    }
    else {
      mail = new Email();
    }


    mail.CcList = txtCcList.Text;
    mail.FromEmail = txtFromEmail.Text;
    mail.FromName = txtFromName.Text;
    mail.IsHTML = chkIsHTML.Checked;
    mail.MailerName = txtMailerName.Text;
    mail.MessageBody = txtMessageBody.Text;
    mail.Subject = txtSubject.Text;
    mail.ToList = txtToList.Text;


    bool isError = false;
    try {
      mail.Save(Utility.GetUserName());
    }
    catch (Exception x) {
      isError = true;
      ThrowError(x.Message);
    }
    if (!isError)
      Response.Redirect(Request.Url.PathAndQuery, false);

  }
  #endregion

  #region Error Handling
  void ThrowError(string message) {
    uResult.ShowFail(message);
  }


  #endregion
}
