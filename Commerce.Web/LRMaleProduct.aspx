<%@Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="LRMaleProduct.aspx.cs" Inherits="LRMaleProduct" Title="LovRub Male Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>    

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script runat="Server" type="text/C#">
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[4];

            slides[0] = new AjaxControlToolkit.Slide("images/CouplePhoto4.gif", "", "");
            slides[1] = new AjaxControlToolkit.Slide("images/CouplePhoto5.gif", "", "");
            slides[2] = new AjaxControlToolkit.Slide("images/CouplePhoto6.gif", "", "");
            slides[3] = new AjaxControlToolkit.Slide("images/CouplePhoto7.gif", "", "");
            return(slides);
        }
</script>


<table width="733" bgcolor="black" border="0" align="center" cellpadding="8" cellspacing="0">
<!--<tr>
        <td colspan="5"><a href="default.aspx"><img src="images/products_r2_c2.gif" border="0" width="289" height="107" alt="LovRub&#153; Home" /></a></td>
        <td rowspan="3"><img src="images/CouplePhoto5.gif" width="243" height="327" border="0" id="Img2" alt="" /></td>
    </tr>
-->    
    <tr>
        <td colspan="5">
            <!-- <a href="default.aspx"><img src="images/products_r2_c2.gif" border="0" width="289" height="107" alt="LovRub&#153; Home" /></a> -->
            <a href="default.aspx"><img src="images/lovrubweblogo.gif" border="0"  alt="LovRub&#153; Home" /></a>                        
        </td>
        <td rowspan="3">
            <asp:Image ID="Image2" runat="server" Height="327px" Width="243px" />
            <cc1:SlideShowExtender ID="SlideShowExtender1" 
                    PlayInterval="10000"
                    AutoPlay="true" 
                    Loop="true" 
                    SlideShowServiceMethod="GetSlides" 
                    TargetControlID="Image2" 
                    runat="server">
            </cc1:SlideShowExtender>       
            
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <tr>
                    <td><a href="LRProducts2.aspx"><img src="images/products_r4_c2.gif" width="138" height="80"  border="0" id="Img9" alt="" /></a></td>                    
                    <td><a href="faq.aspx"><img src="images/index_r4_c5.gif" width="136" height="80" border="0" id="Img4" alt="" /></a></td>
                    <td><img src="images/index_r4_c8.gif" width="136" height="80" border="0" id="Img5" alt="" /></td>
                </tr>
                <tr>
                   <td><a href="reviews.aspx"><img src="images/index_r5_c2.gif" width="138" height="73"  border="0" id="Img6" alt="" /></a></td>
                   <td><a href="LRProducts2.aspx"><img src="images/index_r5_c5.gif" width="136" height="73"   border="0" id="Img7" alt="" /></a></td>
                   <td><a href="HowItWorks.aspx"><img src="images/index_r5_c8.gif" width="136" height="73"  border="0" id="Img8" alt="" /></a></td>
                </tr>
            </table>
        </td>        
    </tr>
</table>

<table bgcolor="#3A3A3C" width="733" align="center" cellpadding="9" cellspacing="0">
    <tr>
        <!-- <td align="center" colspan="3"><img src="images/top_banner_male.gif" alt=""/></td> -->
        <td align="center" colspan="3"><img src="images/top_male_banner.gif" alt=""/></td>
    </tr>
    <tr>
        <td align="center">
            <p>
                <span class="maleRedLogoProduct">&nbsp;LovRub<sup>&#153</sup> Sexual Enhancement Gel for Men</span><br /><br />
                <span class="defaultText">
                     Improve your sexual experiences. When topically applied, improves sexual
                     pleasure, the feeling of firmness, 
                     enhanced sensation and satisfaction.<br />
                     Try It and See!<br /><br />
                </span>
            </p>
        </td>
        <td rowspan="2"><img src="images/LRProductMale2.gif" alt="" /></td>        
    </tr>
    <tr>
        <td align="center">
            <!-- <img src="images/productPricingMale.gif" border="0" id="Img3" alt="" /> -->
            <img src="images/middle_banner_male.gif" border="0" alt="" />
        </td>
    </tr>
    <tr>
        <td align="center">
            <table cellspacing="5" cellpadding="5">
                <tr>
                   <td>
                        <!--ImageURL="images/btn_male_19.95.gif" -->
                        <asp:ImageButton ID="btnMen111" runat="server"  
                            BackColor="#3A3A3C" 
                            BorderColor="#3A3A3C"
                            Height="124" 
                            Width="148"
                            OnClick="btnMen1_Click" 
                            ImageURL="images/btn_male_19.99.gif"
                            AlternateText="LovRub for Men 1 for $19.99" 
                        />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnMen2222" runat="server" 
                        Height="124" 
                        Width="148"
                        OnClick="btnMen2_Click" 
                        ImageURL="images/btn_male_29.98.gif"
                        AlternateText="LovRub for Men 2 for $29.98" 
                        />
                    </td>        
                    <td>
                        <asp:ImageButton ID="btnMen333" runat="server" 
                        Height="124" 
                        Width="148"
                        OnClick="btnMen3_Click" 
                        ImageURL="images/btn_male_39.97.gif"
                        AlternateText="LovRub for Men 3 for $39.97." 
                        />
                    </td>        
                </tr>
            </table>
            <td><img src="images/AllNatural.gif" border="0" alt="Natural Sex Enhancement Gel"/></td>            
        </td>            
    </tr>
    <tr>
        <td align=center colspan="5"><img src="images/MadeInUSA.gif"   alt="LovRub Sex Cream is Made in USA""/></td>
    </tr>    
    <tr><td align="center" colspan="8"><img src="images/LineSpacer2.gif" height="58" alt="" /></td></tr>

</table>

</asp:Content>

