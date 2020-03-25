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
                    <td><a href="LRProducts2.aspx"><img src="images/index_r4_c2.gif" width="138" height="80"  border="0" id="Img2" alt="" /></a></td>
                    <td><a href="faq.aspx"><img src="images/faq_r4_c5.gif" width="136" height="80" border="0" id="Img3" alt="" /></a></td>
                    <td><img src="images/index_r4_c8.gif" width="136" height="80" border="0" id="Img4" alt="" /></td>
                </tr>
                <tr>
                   <td><a href="reviews.aspx"><img src="images/index_r5_c2.gif" width="138" height="73"  border="0" id="Img5" alt="" /></a></td>
                   <td><a href="LRProducts2.aspx"><img src="images/index_r5_c5.gif" width="136" height="73"   border="0" id="Img6" alt="" /></a></td>
                   <td><a href="HowItWorks.aspx"><img src="images/index_r5_c8.gif" width="136" height="73"  border="0" id="Img7" alt="" /></a></td>
                </tr>
            </table>
        </td>        
    </tr>
</table>
  
<table  bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="20" cellspacing="0">
    <tr>
        <td colspan="7" valign="top">
        
         <p class="faqParagraph">
            <span class="faqQA">Q. </span>
            <strong><em>What is LovRub<sup>&#153</sup>?</em><br /></strong>
            <span class="faqQA">A.</span>
             LovRub<sup>&#153</sup> is a male and female sexual <br />
             arousal gel and is applied topically. LovRub<sup>&#153</sup> <br />
             was scientifically formulated by a scientist and sexual health expert for the specific purpose of improving the sexual pleasure and satisfaction of men and women. This unique formulation is made with Aloe Vera which is known to revitalize skin
             in the area most involved in arousal. &nbsp;
         </p>
         <br />
         <br />
             <p class="faqParagraph">
                <span class="faqQA">Q.</span>
                <strong><em> Can LovRub<sup>&#153</sup> &nbsp;be used with a condom?</em><br /></strong>
                <span class="faqQA">A.</span>
                Yes, LovRub<sup>&#153</sup> is &#34latex&#34 and &#34polyurethane&#34 condom compatible. Always practice safe sex.
             </p>
             <br />
             <br />
             <p class="faqParagraph">
                <span class="faqQA">Q.</span>
                <em><strong>Is LovRub<sup>&#153</sup> safe to use during oral sex?</strong></em><br />
                <span class="faqQA"><strong>A. </strong></span>
                 Yes, LovRub<sup>&#153</sup> is safe to use during oral sex.
             </p>
             <br />
             <p class="faqParagraph">
                <span class="faqQA">Q.</span>
                <em><strong>How is LovRub<sup>&#153</sup> different from other topical sexual enhancement products?</strong></em><br />
                <span class="faqQA"><strong>A. </strong></span>
                 Unlike other topical sexual enhancement products, LovRub<sup>&#153</sup> is 100% natural and is water soluble, so it is safe to use with condoms.
             </p>
             <br />
             <br />
       </td>
       <td rowspan="2" colspan="2">
            <img src="images/faqCenterLine.gif" width="45" height="660" border="0" id="Img1" alt="" />
       </td>
       <td colspan="7" valign="top">
        <p class="faqParagraph">
            <span class="faqQA">Q.</span>
            <em><strong> Are there any known side effects?</strong></em><br />
            <span class="faqQA"><strong>A. </strong></span>
             No, there are no known side effects associated with the use of LovRub<sup>&#153</sup>. However, everyone is unique, so if you experience any discomfort while using LovRub<sup>&#153</sup>, discontinue use and consult with a physician before using the product again.
         </p>
        <br />
         <p class="faqParagraph">
            <span class="faqQA">Q.</span>
            <em><strong> Is LovRub<sup>&#153</sup> different from sexual herbal pill supplements?</strong></em><strong><br />
            <span class="faqQA">A.</span>
            &nbsp; Y</strong>es, LovRub<sup>&#153</sup> is COMPLETELY DIFFERENT. Unlike a pill taken orally, LovRub&#39s<sup>&#153</sup> patented formula uses targeted topical release directly to the &quot;source&quot; for INSTANT SEXUAL ENHANCEMENT.
         </p>
         <br />
         <p class="faqParagraph">
            <span class="faqQA">Q.</span>
            <em><strong> What is the difference <br />between LovRub<sup>&#153</sup> for Men and <br />LovRub<sup>&#153</sup> for Women?</strong></em><br />
            <strong><span class="faqQA">A.</span> &nbsp;</strong>LovRub<sup>&#153</sup> for Men contains a combination <br />
            of ingredients that in many cases may be too intense for the female sex organs. LovRub<sup>&#153</sup> <br />
            for Women uses a similar formula, however the ingredients are gentle enough for a woman.
        </p>
         <p class="faqParagraph">
                <span class="faqQA">Q.</span><strong><em> Can LovRub<sup>&#153</sup> be shipped discretely ?</em><br /></strong>
                <span class="faqQA">A. </span>Absolutely! Your privacy is 100% guaranteed - all orders are shipped in unmarked packaging and credit cards are billed by HealthRockers, Inc.
         </p>
    </td>         
       
    </tr>      

</table>

</asp:Content>
