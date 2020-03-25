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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Security;


public partial class _Install : System.Web.UI.Page {

  #region Constants

  private const string SCRIPT_TABLES = "~/Install/InstallScripts/Tables.sql";
  private const string SCRIPT_FUNCTIONS = "~/Install/InstallScripts/Functions.sql";
  private const string SCRIPT_VIEWS = "~/Install/InstallScripts/Views.sql";
  private const string SCRIPT_SPS = "~/Install/InstallScripts/SPs.sql";
  private const string SCRIPT_BASE_DATA = "~/Install/InstallScripts/BaseData.sql";
  private const string SCRIPT_MEMBERSHIP_SCHEMA = "~/Install/InstallScripts/MembershipSchema.sql";
  private const string SCRIPT_BASE_MEMBERSHIP_DATA = "~/Install/InstallScripts/BaseMembershipData.sql";
  private const string SCRIPT_SAMPLE_DATA = "~/Install/InstallScripts/SampleData.sql";
  private const string SCRIPT_DROP = "~/Install/InstallScripts/Drop.sql";

  #endregion

  protected void Page_Load(object sender, EventArgs e) {
    lblMessage.Text = string.Empty;
    imgMessage.ImageUrl = string.Empty;
    imgMessage.Visible = false;
  }

  protected void next_Click(object sender, EventArgs e) {
  }

  protected void finish_Click(object sender, EventArgs e) {
    Response.Redirect("~/default.aspx", true);
  }

  protected void activeStepChanged(object sender, EventArgs e) {
    switch (wizInstaller.ActiveStepIndex) {
      case 1:

        break;

      case 2:
        try {
          Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
          if (config == null) {
            throw new InvalidOperationException("Configuration file not available.");
          }
          AppSettingsSection appSettingsSection = config.GetSection("appSettings") as AppSettingsSection;
          KeyValueConfigurationCollection appSettings = appSettingsSection.Settings;
          if (appSettingsSection.SectionInformation.IsLocked) {
            throw new InvalidOperationException("Configuration Section is locked. Unable to modify.");
          }
          config.AppSettings.Settings.Add("test", "test");
          config.Save();
          config.AppSettings.Settings.Remove("test");
          config.Save();
        }
        catch (UnauthorizedAccessException ex) {
          wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
          ShowError(ex.Message);
        }
        break;

      case 3:
        ViewState["DbServer"] = txtDbServer.Text.Trim();
        ViewState["TrustedConnection"] = chkTrustedConnection.Checked;
        if (!chkTrustedConnection.Checked) {
          if (string.IsNullOrEmpty(txtDbUserName.Text.Trim())) {
            throw new InvalidOperationException("Username cannot be null or empty string.");
          }
          if (string.IsNullOrEmpty(txtDbPassword.Text.Trim())) {
            throw new InvalidOperationException("Password cannot be null or empty string.");
          }
          ViewState["DbUserName"] = txtDbUserName.Text.Trim();
          ViewState["DbPassword"] = txtDbPassword.Text.Trim();
        }
        try {
          BindDbList();
        }
        catch (Exception ex) {
          wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
          ShowError(ex.Message);
        }
        break;

      case 4:
        bool dbCreated = false;
        if ((ddlDbList.SelectedValue == "-1") && (string.IsNullOrEmpty(txtCreateDb.Text.Trim()))) {
          wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
          ShowError("Please select a database or supply a new database name.");
        }
        string dbName = string.Empty;
        if (ddlDbList.SelectedValue != "-1") {
          dbName = ddlDbList.SelectedValue;
        }
        if ((ddlDbList.SelectedValue == "-1") && (!string.IsNullOrEmpty(txtCreateDb.Text.Trim()))) {
          try {
            dbName = txtCreateDb.Text.Trim();
            dbCreated = CreateDb();
          }
          catch (Exception ex) {
            wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
            ShowError(ex.Message);
          }
        }
        if ((ddlDbList.SelectedValue != "-1") || (dbCreated)) {
          try {
            ViewState["dbName"] = dbName;
            if (chkDropObjects.Checked) {
              DropObects(dbName);
            }
            RunScripts(dbName);
            WriteConnectionStringsToConfig();
          }
          catch (Exception ex) {
            wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
            ShowError(ex.Message);
          }
        }
        break;

      case 5:
        try {
          MembershipCreateStatus status = MembershipCreateStatus.UserRejected;
          Membership.CreateUser(txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim(), txtSecurityQuestion.Text.Trim(), txtSecurityAnswer.Text.Trim(), true, out status);
          if (status == MembershipCreateStatus.Success) {
            Roles.AddUserToRole(txtUsername.Text.Trim(), "Administrator");
          }
        }
        catch (Exception ex) {
          wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
          ShowError(ex.Message);
        }
        break;

      case 6:
        try {
          if (rdoYes.Checked) {
            RunSampleDataScripts(ViewState["dbName"].ToString());
          }
        }
        catch (Exception ex) {
          wizInstaller.ActiveStepIndex = wizInstaller.ActiveStepIndex - 1;
          ShowError(ex.Message);
        }
        break;

      case 7:

        break;
    }
  }

  private void DropObects(string dbName) {
    string[] dropStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_DROP), new System.Text.UTF8Encoding()));
    ExecuteStatements(dropStatements, dbName);
  }

  private void WriteConnectionStringsToConfig() {
    Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
    if (config == null) {
      throw new InvalidOperationException("Configuration file not available.");
    }
    ConnectionStringsSection connectionStringsSection = config.ConnectionStrings;
    ConnectionStringSettings commerceTemplate = new ConnectionStringSettings("CommerceTemplate", GetConnString(ViewState["dbName"].ToString()), "System.Data.SqlClient");
    connectionStringsSection.ConnectionStrings.Clear();
    connectionStringsSection.ConnectionStrings.Add(commerceTemplate);
    config.Save();
  }

  private void ShowError(string message) {
    lblMessage.Text = message;
    imgMessage.ImageUrl = "~/images/icons/icon_error.gif";
    imgMessage.Visible = true;
  }

  private void RunSampleDataScripts(string dbName) {
    //SampleData
    string[] sampleDataStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_SAMPLE_DATA), new System.Text.UTF8Encoding()));
    ExecuteStatements(sampleDataStatements, dbName);
  }

  private void RunScripts(string dbName) {
    //Tables
    string[] tableStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_TABLES), new System.Text.UTF8Encoding()));
    ExecuteStatements(tableStatements, dbName);
    //Functions
    string[] functionStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_FUNCTIONS), new System.Text.UTF8Encoding()));
    ExecuteStatements(functionStatements, dbName);
    //Views
    string[] viewStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_VIEWS), new System.Text.UTF8Encoding()));
    ExecuteStatements(viewStatements, dbName);
    //Stored Procedures
    string[] storedProcedureStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_SPS), new System.Text.UTF8Encoding()));
    ExecuteStatements(storedProcedureStatements, dbName);
    //Base Data
    string[] baseDataStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_BASE_DATA), new System.Text.UTF8Encoding()));
    ExecuteStatements(baseDataStatements, dbName);
    //Membership
    string[] membershipStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_MEMBERSHIP_SCHEMA), new System.Text.UTF8Encoding()));
    ExecuteStatements(membershipStatements, dbName);
    //Base Membership Data
    string[] baseMembershipDataStatements = GetScriptStatements(File.ReadAllText(Server.MapPath(SCRIPT_BASE_MEMBERSHIP_DATA), new System.Text.UTF8Encoding()));
    ExecuteStatements(baseMembershipDataStatements, dbName);
  }

  private void ExecuteStatements(string[] tableStatements, string dbName) {
    if (tableStatements.Length > 0) {
      using (SqlConnection conn = new SqlConnection()) {
        conn.ConnectionString = GetConnString(dbName);
        conn.Open();
        using (SqlCommand command = new SqlCommand(string.Empty, conn)) {
          foreach (string statement in tableStatements) {
            command.CommandText = statement;
            command.ExecuteNonQuery();
          }
        }
      }
    }
  }

  private string[] GetScriptStatements(string p) {
    string[] statements = p.Split(new string[] { "GO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    return statements;
  }

  private bool CreateDb() {
    int rowsAffected = -1;
    bool dbCreated = false;
    using (SqlConnection conn = new SqlConnection()) {
      string sql = "CREATE DATABASE " + txtCreateDb.Text.Trim();
      conn.ConnectionString = GetConnString("master");
      conn.Open();
      using (SqlCommand cmd = new SqlCommand(sql, conn)) {
        rowsAffected = cmd.ExecuteNonQuery();
        dbCreated = true;
      }
    }
    return dbCreated;
  }

  private void BindDbList() {
    using (SqlConnection conn = new SqlConnection()) {
      string sql = "SELECT * FROM sysdatabases WHERE name NOT IN ('master','tempdb','model','msdb') ORDER BY [NAME]";
      conn.ConnectionString = GetConnString("master");
      conn.Open();
      using (SqlCommand cmd = new SqlCommand(sql, conn)) {
        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
          ddlDbList.DataSource = rdr;
          ddlDbList.DataTextField = "name";
          ddlDbList.DataValueField = "name";
          ddlDbList.DataBind();
          ddlDbList.Items.Insert(0, new ListItem("-- Select --", "-1"));
          rdr.Close();
        }
      }
    }
  }

  string GetConnString(string databaseName) {
    string connString = "Server=" + ViewState["DbServer"].ToString() + ";Initial Catalog=" + databaseName + ";";
    if ((bool)ViewState["TrustedConnection"]) {
      connString += "Integrated Security=true;";
    }
    else {
      connString += "user id=" + ViewState["DbUserName"].ToString() + "; Password=" + ViewState["DbPassword"].ToString() + ";";
    }
    return connString;
  }

  protected void chkTrusted_CheckedChanged(object sender, EventArgs e) {
    pnlSqlMode.Visible = !chkTrustedConnection.Checked;
  }

}
