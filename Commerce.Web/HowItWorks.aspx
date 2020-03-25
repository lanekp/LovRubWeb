<%@ Page ValidateRequest="false" EnableViewState="false" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" 
    Title="LovRub Sexual Enhancement Gel with Aloe Vera" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>    

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<script runat="Server" type="text/C#">
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[3];

            slides[0] = new AjaxControlToolkit.Slide("images/CouplePhoto4.gif", "", "");
            slides[1] = new AjaxControlToolkit.Slide("images/CouplePhoto5.gif", "", "");
            slides[2] = new AjaxControlToolkit.Slide("images/CouplePhoto6.gif", "", "");
            return(slides);
        }

</script>

<table width="733" bgcolor="black" border="0" align="center" cellpadding="8" cellspacing="0">
    <tr >
        <td colspan="5">
            <!-- <a href="default.aspx"><img src="images/products_r2_c2.gif" border="0" width="289" height="107" alt="LovRub&#153; Home" /></a> -->
            <a href="default.aspx"><img src="images/lovrubweblogo.gif" border="0"  alt="LovRub&#153; Home" /></a>                        
        </td>
        <!-- <td colspan="3"><a href="default.aspx"><img src="images/index_r2_c2.gif" width="276" height="157" border="0" id="index_r2_c2" alt="" /></a></td> -->
        <!-- <td rowspan="3"><img src="images/CouplePhoto4.gif" width="288" height="310" border="0" id="index_r2_c1" alt="" /></td> -->
        <td rowspan="3">
            <!-- <img src="images/CouplePhoto4.gif" width="243" height="327" border="0" id="Img1" alt="" /> -->
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
                    <td><a href="LRProducts2.aspx"><img src="images/index_r4_c2.gif" width="138" height="80"  border="0" id="Img2" alt="" /></a></td>
                    <td><a href="faq.aspx"><img src="images/how_r4_c5.gif" width="136" height="80" border="0" id="Img3" alt="" /></a></td>
                    <td><img src="images/index_r4_c8.gif" width="136" height="80" border="0" id="Img4" alt="" /></td>
                </tr>
                <tr>
                   <td><a href="reviews.aspx"><img src="images/index_r5_c2.gif" width="138" height="73"  border="0" id="Img5" alt="" /></a></td>
                   <td><a href="LRProducts2.aspx"><img src="images/index_r5_c5.gif" width="136" height="73"   border="0" id="Img6" alt="" /></a></td>
                   <td><a href="HowItWorks.aspx"><img src="images/how_r5_c8.gif" width="136" height="73"  border="0" id="Img7" alt="" /></a></td>
                </tr>
            </table>
        </td>        
    </tr>
</table>
  
<table  bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="20" cellspacing="0">
    <tr>
        <td align="center" colspan="100" style="height: 18px"><h4>How It Works</h4></td>
    </tr>
    <tr>
        <td colspan="7" valign="top">
         <span class="femaleRedLogo">LovRub<sup>&#153</sup> for Women</span> <br />
         <p class="faqParagraph">
            LovRub<sup>&#153</sup> feminine arousal gel is topically applied. The gentle application of LovRub<sup>&#153</sup> with Aloe Vera becomes a natural part of foreplay that actively contributes to female sexual pleasure and satisfaction. 
            <br /><br />A blend of all natural herbs and extracts in LovRub<sup>&#153</sup> naturally stimulates the body&#39;s own sensory nerve conduction, heightening sexual sensation and pleasure. 
            <br /><br />Squeeze a few drops of LovRub<sup>&#153</sup> from the tube and apply with tender massage to the clitoris, underneath the clitoral hood, labia and vaginal opening for 5 minutes prior to intercourse. 
            <br /><br />From the very first use, LovRub&#39;s<sup>&#153</sup> unique effects tend to pleasantly surprise most women. Since you are in complete control of your desired intensity, women wishing to enjoy more intense pleasurable sensations can simply use more LovRub<sup>&#153</sup> per each sexual encounter. Use the amount that suits you best.
            <br /><br />For best effects ... don&#39;t rush. During foreplay, you or your partner should gradually apply the oil with gentle massage onto the clitoris. Massage in tenderly. The effects generally begin in about 4 to 5 minutes, with a feeling of genital warming that will build to a pleasurable level and plateau within about 10 minutes. You may also experience heightened genital sensation to touch and /or sexual intercourse, heightened arousal and increased sexual pleasure. The effects generally last 30-45 minutes with a single application. Repeat as often as desired. To remove, simply wash off. Many women report that when using LovRub<sup>&#153</sup> during intercourse, their male partner also experiences greater sexual satisfaction.
         </p>
         <br />
       </td>
       <td rowspan="2" colspan="2">
            <img src="images/faqCenterLine.gif" width="45" height="660" border="0" id="Img1" alt="" />
       </td>
       <td colspan="7" valign="top">
        <span class="maleRedLogo">LovRub<sup>&#153</sup> for Men</span><br />       
        <p class="faqParagraph">
            LovRub<sup>&#153</sup> male enhancement gel is topically applied. This unique formulation is made with Aloe Vera and also includes L-Arginine.  Aloe Vera is well known to revitalize skin in the area most involved in arousal. LovRub<sup>&#153</sup> improves level of desire, satisfaction with level of sexual arousal, genital sensation, and sexual pleasure.  
            <br /><br />The gentle application of LovRub<sup>&#153</sup> with Aloe Vera will become a natural part of foreplay that actively contributes to male sexual pleasure, stimulation and satisfaction.
             <br /><br />A blend of all natural herbs and extracts in LovRub<sup>&#153</sup> naturally stimulates the body&#39;s own sensory nerve conduction, heightening sexual sensation and pleasure. You will see and feel a difference instantly starting with their very first application, and be amazed how LovRub<sup>&#153</sup> maximizes pleasure making every sexual experience stronger.

            <br /><br />For best effects ... don&#39;t rush. You and your partner should gradually apply the LovRub<sup>&#153</sup> gel with gentle massage. The physiology of the male erectile tissue provides numerous points of interaction in which stimulation may be used to overcome a decline in erectile responsiveness. LovRub<sup>&#153</sup> is aimed at taking advantage of enhancing stimulation regularly through use of targeted topical delivery. Massage it tenderly in the area most involved in arousal. The effect generally begins immediately with feeling of warming effect that will build to a pleasurable level and plateau within about 5 to 10 minutes. You will feel heightened arousal and increased sexual pleasure. The effect will generally last 30-45 minutes with a single application. Repeat as often as desired. To remove simply wash off with water.
        
         </p>
        <br />
    </td>         
       
    </tr>      

</table>



</asp:Content>
