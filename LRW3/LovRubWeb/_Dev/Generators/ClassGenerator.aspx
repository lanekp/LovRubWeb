<%@ Page Language="C#" %>
<script runat="server">
     
    string tableName="";
    protected void Page_Load(object sender, EventArgs e)
    {

       if (!Page.IsPostBack)
        {
            ddlTables.DataSource = SubSonic.DataService.GetTables();
            ddlTables.DataBind();
        }   

        if (Request.QueryString["t"] != null)
        {
            tableName = Request.QueryString["t"].ToString();
        }


    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.CurrentExecutionFilePath + "?t=" + ddlTables.SelectedValue);
    }
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Code Generator</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Class Generator</h3>
    To use this tool, create a class file. Select the table below, then copy and paste completely
    into your newly-created class.<br /><br />
    Select the Table:<asp:DropDownList ID="ddlTables" runat="server"></asp:DropDownList>
        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
        
   </div>
    <br />
    
<%if(tableName!=string.Empty){ %>
<textarea cols="90" rows="30">
<%=SubSonic.CodeGeneration.GenerateClasses(tableName)%>
</textarea>
<%} %>

    </form>
</body>
</html>
