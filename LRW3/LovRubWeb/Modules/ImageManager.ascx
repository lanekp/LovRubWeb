<%@ Control Language="C#" ClassName="ImageManager" AutoEventWireup="true" CodeFile="ImageManager.ascx.cs" Inherits="ImageManager"%>
<script runat="server">

</script>
<input name="<%=ClientID%>_imgHolder" type="hidden" value="<%=GetImage()%>" />
<asp:Image runat="server" ID="imgPic" ImageUrl="~/images/1pix.gif"/><br />
<input type="button" 
       onclick="showPopWin('<%=Page.ResolveUrl("~/Modules/ImagePicker.aspx")%>?&ct=<%=ClientID%>_imgHolder&cn=<%=imgPic.ClientID%>&rif=<%=ImageFolder%>&cif=<%=ImageFolder%>', 800, 550, null);" 
       value="..." 
/>
