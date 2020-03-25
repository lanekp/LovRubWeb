<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e) {

        if (!Page.IsPostBack) {
            string[] tableList = SubSonic.DataService.GetTables();
            foreach (string s in tableList) {
                ListItem item = new ListItem(s, s);
                item.Selected = true;
                chkTables.Items.Add(item);
            }
        }

    }

    protected void btnGo_Click(object sender, EventArgs e) {
        try {
            foreach (ListItem item in chkTables.Items) {
                if (item.Selected) {
                    string tableName=item.Value.ToLower().Replace(" ","");
                    string filePath = Server.MapPath("~/_Dev/Scaffolds/" + tableName+"_scaffold.aspx");
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(filePath)) {
                        string sCode = SubSonic.CodeGeneration.GenerateScaffold(item.Value);
                        sw.Write(sCode);
                    }
                }
            }
            lblResult.Text = "Finished";
        } catch (Exception x) {
            lblResult.Text = "Error: "+x.Message;
        }

    }
    public void WriteToFile(string AbsoluteFilePath, string fileText) {
        System.IO.StreamWriter sw = new System.IO.StreamWriter(AbsoluteFilePath,false);
        sw.Write(fileText);
        sw.Close();

    }
    public string GetProperName(string sIn) {
        string propertyName = sIn;
        string leftOne = propertyName.Substring(0, 1).ToUpper();
        propertyName = propertyName.Substring(1, propertyName.Length - 1);
        propertyName = leftOne + propertyName;

        if (propertyName.EndsWith("TypeCode")) propertyName = propertyName.Substring(0, propertyName.Length - 4);

        return propertyName;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Batch Scaffold Generator</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Batch Scaffold Generator</h3>
    Create a folder called "Dev" in your web site; then select the tables below. For each table selected, a Scaffold page will
    be created for you and put into the "Dev" folder. The page will be named [tablename]_scaffold.aspx. To add this page to your
    solution, select the folder and then click the "Show All Files" button in the command bar above your solution. Select the pages
    and then click "Add To Project". Also, make sure that the ASPNET worker process has write access to your web site.
    
    <br /><br />
    Select the Tables:
        <br />
        <br />
        <asp:CheckBoxList ID="chkTables" runat="server" RepeatColumns="3">
        </asp:CheckBoxList><br />
        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
        <asp:Label ID="lblResult" runat="server"></asp:Label>
        
   </div>
    </form>
</body>
</html>
