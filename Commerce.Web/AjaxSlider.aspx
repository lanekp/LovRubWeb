<%@ Page Language="C#" MasterPageFile="~/site.master" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <h2 style="text-align: center">Slide Show Extender Control</h2>
        
        
        <div style="text-align: center">
        
        
<script runat="Server" type="text/C#">
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[3];

            slides[0] = new AjaxControlToolkit.Slide("images/CouplePhoto4.gif", "Blue Hills", "Go Blue");
            slides[1] = new AjaxControlToolkit.Slide("images/CouplePhoto5.gif", "Sunset", "Setting sun");
            slides[2] = new AjaxControlToolkit.Slide("images/CouplePhoto6.gif", "Winter", "Wintery...");
            return(slides);
        }

</script>

<!--
            <asp:AdRotator ID="AdRotator1" 
                            runat="server" 
                            AdvertisementFile="~/Photos.xml" 
                            Height="327px" 
                            Width="243px" />
-->            
            <br />
            <br />
            
            <asp:Image ID="Image1" runat="server" Height="327px" Width="243px" /><br />
            <br />
            
            
            <cc1:SlideShowExtender ID="SlideShowExtender1" 
                    PlayInterval="6000"
                    AutoPlay="true" 
                    ImageDescriptionLabelID="lblImageDescription"
                    Loop="true" 
                    SlideShowServiceMethod="GetSlides" 
                    StopButtonText="Stop"
                    TargetControlID="Image1" runat="server">
            </cc1:SlideShowExtender>       
        </div>

</asp:Content>

