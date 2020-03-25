<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Page_Load(object sender, EventArgs e) {

        if (!Page.IsPostBack) {
           
            
            string[] tableList = SubSonic.DataService.GetTables();
            string[] viewList = SubSonic.DataService.GetViews();
            
            foreach (string s in tableList) {
                //the only tables we want
                string genList = "CSK_Store_Category,CSK_Store_ProductReview,CSK_Store_ProductReviewFeedback,CSK_Store_Ad,CSK_Store_Image,CSK_Store_ProductDescriptor,CSK_Store_Product,CSK_Store_ProductRating,CSK_Store_OrderNote,CSK_Store_Order,CSK_Store_OrderItem,CSK_Store_AttributeTemplate,CSK_Store_Address,CSK_Store_Transaction,";
                string[] generateList = genList.Split(',');
                //don't want the aspnet tables, and we only want to generate stuff for the Store
                for(int i = 0;i < generateList.Length; i++) {
                  if(s.ToLower().Equals(generateList[i].ToLower())) {
                    ListItem item = new ListItem(s, s);
                    item.Selected = true;
                    chkTables.Items.Add(item);
                    break;
                  }
                }
            }


            foreach (string v in viewList) {
                if (!v.StartsWith("sys")) {
                    ListItem item = new ListItem(v, v);
                    item.Selected = true;
                    chkViews.Items.Add(item);
                }
            }      
                 
        }

    }

    protected void btnGo_Click(object sender, EventArgs e) {
        string dirPath = Server.MapPath("~/App_Code/DataAccess/Store/Generated/");
        string filePath = "";
        
        if (!System.IO.Directory.Exists(dirPath)) {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        try {
            if (chkDoTables.Checked) {
                foreach (ListItem item in chkTables.Items) {
                    if (item.Selected) {
                        string className = GetProperName(item.Value);

                        //********** CUSTOM FOR CSK
                        //we name our tables with the CSK_ prefix so that
                        //the names don't collide with other tables in your DB (for ISP hosting etc)
                        //so we'll want to remove that :)

                        className = className.Replace("CSK_Store_", "").Replace("_", "");

                        //*************************

                        className = className.Replace(" ", "");

                        filePath = System.IO.Path.Combine(dirPath, className + ".cs");
                        using (System.IO.StreamWriter sw = System.IO.File.CreateText(filePath)) {
                            string sCode = SubSonic.CodeGeneration.GenerateClass(item.Value, className, "Commerce.Common");
                            sw.Write(sCode);
                        }
                    }
                }
            }
            
            
            //SPs
            
            if (chkSPs.Checked) {
                string usings = SubSonic.CodeGeneration.GetUsingStatements();
                string spCode = SubSonic.CodeGeneration.GenerateSPs("Commerce.Common", "SPs","CSK_","");
                filePath = System.IO.Path.Combine(dirPath, "SPs\\StoredProcedures.cs");
                using (System.IO.StreamWriter sw = System.IO.File.CreateText(filePath)) {
                    string sCode = usings + "\r\n\r\n" + spCode;
                    sw.Write(sCode);
                }
            }
            
            //Views
            if (chkDoViews.Checked) {
                foreach (ListItem item in chkViews.Items) {
                    if (item.Selected) {
                        string className = GetProperName(item.Value);

                        className = className.Replace(" ", "").Replace("_", "");

                        filePath = System.IO.Path.Combine(dirPath, "Views\\" + className + ".cs");
                        string usings = SubSonic.CodeGeneration.GetUsingStatements();
                        using (System.IO.StreamWriter sw = System.IO.File.CreateText(filePath)) {
                            string sCode = usings + "\r\n\r\n" + SubSonic.CodeGeneration.GenerateView("Commerce.Common", item.Value);
                            sw.Write(sCode);
                        }
                    }
                }
            }

            lblResult.Text = "View your files: <a href='file://" + dirPath + "'>" + dirPath + "</a>";
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
    <title>Batch Class Generator</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>Batch Class Generator</h3>
    You can generate files straight to your hard drive using this utility. Just check the tables below, and specify 
    where you want the files dropped (make sure you give ASPNET write permissions to this file, or run this in debug mode).
    All of your class files will be dropped there (overwriting existing ones).
        <br />
    
    <br /> 
    All Files are output to the App_Code/DataAccess/Store/Generated folder<br />
     <br /> 
   <br />
 <div style="height:30px; vertical-align:center;background-color:whitesmoke;border:1px solid gainsboro; padding:10px"><b>Tables</b></div><br />
    <asp:CheckBox ID="chkDoTables" runat="server" Checked="true" Text="Generate?"/>      <br /><br />    
   Select:
        <br />
        <br />
        <asp:CheckBoxList ID="chkTables" runat="server" RepeatColumns="3">
        </asp:CheckBoxList><br />
    <br />
    <div style="height:30px; vertical-align:center;background-color:whitesmoke;border:1px solid gainsboro; padding:10px"><b>Views</b></div>
    <asp:CheckBox ID="chkDoViews" runat="server" Checked="true" Text="Generate?"/> <br /><br />           
   Select:
        <br />
        <br />
        <asp:CheckBoxList ID="chkViews" runat="server" RepeatColumns="3">
        </asp:CheckBoxList>
    <br />
    <div style="height:30px; vertical-align:center;background-color:whitesmoke;border:1px solid gainsboro; padding:10px"><b>Stored Procedures</b></div>
    <asp:CheckBox ID="chkSPs" runat="server" Checked="true" Text="Generate?"/> <br /><br />           
        <br />
        <br />
        <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" /><asp:Label ID="lblResult" runat="server"></asp:Label>
        
   </div>    
   </form>
</body>
</html>
