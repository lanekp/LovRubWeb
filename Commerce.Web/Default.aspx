<%@ Page ValidateRequest="false" EnableViewState="false" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" 
    CodeFile="Default.aspx.cs" 
    Inherits="_Default" 
    Title="LovRub Sexual Enhancement Gel with Aloe Vera" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>    

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
    <tr >
        <td colspan="5">
            <!-- <a href="default.aspx"><img src="images/products_r2_c2.gif" border="0" width="290" height="107" alt="LovRub&#153; Home" /></a> -->
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
                    <td><a href="faq.aspx"><img src="images/index_r4_c5.gif" width="136" height="80" border="0" id="Img3" alt=""/></a></td>
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
  
    <table bgcolor="#3A3A3C" width="733" align="center" cellpadding="7" cellspacing="0">
        <tr>
            <td align="center" colspan="3"><img src="images/love-in-a-tubenew-color.gif" alt=""/></td>
        </tr>
        <!-- 
        <tr>
            <td align="center" colspan="3"><img src="images/top_male_banner.gif" alt=""/></td>
        </tr>
        -->
        <tr >
            <td align="center" colspan="3"><span class="maleRedLogoProduct">&nbsp;LovRub<sup>&#153</sup> Sexual Enhancement Gel for Men & Women</span></td>
        </tr>                    
        <tr>
            <td align="center" colspan="3">
                <img src="images/middle_banner_male.gif" border="0" id="Img1" alt="Buy 1 for $19.99 and Get Each Additional Tube for Only $9.99 Each" />
            </td>
        </tr>
        <tr>
            <td style="width: 312px">
                <img src="images/lips3.gif"   alt="lips" style="vertical-align:top; width: 300px;"/>
                <p class="defaultText">
                    LovRub<sup>&#153</sup> is a unique, natural herbal sexual enhancement gel designed to help you experience
                    the <span class="defaultBestSex">BEST SEX EVER!</span>
                </p><br />
                <center>
                    <img src="images/MadeInUSA.gif"   alt="LovRub Sex Cream is Made in USA""/>
                    <!-- 
                    <fieldset style="background-color:#CCCCCC;  border:#D50B8C; padding-top:4px; padding-bottom:4px">            
                        <p class="femaleRedLogo">Made in the USA</p>
                    </fieldset>
                    -->
                </center>
            </td>
            <td rowspan="7">
                <img src="images/male1.gif"  alt=""/>
            </td>
            <td rowspan="7" style="vertical-align:top">
                <p>
                    <span class="maleRedLogo"><br />LovRub<sup>&#153</sup> for Men</span><br /><br />
                        <span class="defaultText">
                            When topically applied, improves sexual pleasure, the feeling of firmness, enhanced sensation
                            and satisfaction.
                        </span>
                </p>
                <center>
                    <!--
                    <a href="LRProducts2.aspx"><img src="images/ClickToOrderMale.gif" border="0" alt="Click Here to Order"/></a>
                    -->
                    
                    <a href="LRProducts2.aspx"><img src="images/ClickHereToOrderNow.gif" border="0" alt="Click Here to Order"/></a>                    
                    <br />
                    <a href="LRProducts2.aspx"><img src="images/AllNatural.gif" border="0" alt="Natural Sex Enhancement Gel"/></a>
                    <!-- 
                    <fieldset style="background-color:#CCCCCC;  border:#B20838; padding-top:4px; padding-bottom:4px">
                        <a href="LRProducts2.aspx" class="defaultClickHere17">All Natural!<br />No Chemicals!<br />Condom Safe!</a>
                    </fieldset>                          
                    -->
                </center>
            </td>                        
       </tr>
   </table>

<table bgcolor="#3A3A3C" width="733" align="center" cellpadding="9" cellspacing="0">       
    <tr>
        <!-- <td colspan="14" align="center"><img style="border-width:0" src="images/GrayLineSpacer2.gif" alt=""/></td> -->
        <!-- <td colspan="14" align="center"><img style="border-width:0" src="images/LineSpacer2.gif" alt=""/></td>         -->
        <td colspan="3" align="center"><img src="images/youhaventexperienced.gif" alt=""/></td>
    </tr>
    <tr>
        <!-- <td align="center" colspan="3"><img src="images/top_banner_female.gif" alt=""/></td> -->
        <td align="center" colspan="3"><img src="images/top_female_banner.gif" alt=""/></td>
    </tr>
    
    <tr>
        <td align="center" colspan="3"><span class="femaleRedLogoProduct">&nbsp;LovRub<sup>&#153</sup> Sexual Enhancement Gel for Women</span>
        </td>
    </tr>
    <tr>
        <td style="width: 335px; vertical-align:top; height: 272px;">
           <p class="defaultText">
                LovRub<sup>&#153</sup> maximizes your pleasure,<br />
                making every sexual experience stronger.<br />
                <br />Recommended by a leading sex therapist.<br />
                <br />LovRub<sup>&#153</sup> was formulated by scientists<br />
                and sex health experts in two unique<br />
                specifically targeted formulas for men and women.<br />
            </p>
            <br />
            <fieldset style="background-color:#CCCCCC;  border:#D50B8C; padding-top:4px; padding-bottom:4px">            
                <center>
                    <p class="prodReview">
                        <span class="defaultBestSex">
                            <em>...Lovrub is incredible, my sex life has improved 100%...&#34</em>
                            <br />
                            - Karla A
                        </span>
                    </p>
                </center>            
            </fieldset> 
            
            
                      
        </td>
        <td style="width: 176px; height: 272px;"><img src="images/female1.gif"  alt=""/></td>
        <td align="center" style="vertical-align:top; height: 272px;">
             <p>
                <span class="style4">
                    <span class="femaleRedLogo">LovRub<sup>&#153</sup> for Women</span> <br />
                </span>
                <span class="defaultText">
                    When topically applied, increases sexual sensation, pleasure <br />and satisfaction.
                </span>
             </p>
             <center>
                 <a href="LRProducts2.aspx"><img src="images/ClickToOrderFemale.gif" border="0" alt="Click Here to Order"/></a>
                 <br /><br />
                 
                 <a href="LRProducts2.aspx"><img src="images/clickToGetAFreeTube.gif" border="0" alt="Click Here for Free Tube"/></a>
                 <!--
                 <fieldset style="background-color:#CCCCCC;  border:#D50B8C; padding-top:4px; padding-bottom:4px">
                    <a href="LRProducts2.aspx" class="defaultFemaleClickHere">Click Here <br />See How You Can Get a Free Tube!</a>
                 </fieldset>                          
                 -->
             </center>
        </td>                        
    </tr>
   
</table>

<table bgcolor="#3A3A3C" width="733" align="center" cellpadding="9" cellspacing="0">       
    <tr align="center">
        <td style="width: 736px">
            <p class="defaultText16">Read what our customers are saying:</p>
            <fieldset>
            <blockquote>
            <p class="defaultText">
                <br /><em>&#34I have been searching for a natural, sexual enhancer for a while. I have
                 tried other products and none have
                been effective. I never wanted to take
                any pills. I have been using Lovrub regularly for three months and I can
                tell you the sex
                has been amazing!&#34</em><br />
                &#45 Joe A.
            </p>
            <p class="defClickProdReview">
                <a href="reviews.aspx" class="defClickProdReview">Click Here to Read More Product Reviews</a>
            </p>
            <p align="center" class="defaultFreeBottle">1 FREE TUBE WHEN YOU BUY 3 OR MORE! ORDER NOW!</p>
            <p align="center" class="defaultFreeBottle">CALL 1-877-956-8782</p>
            </blockquote>
            </fieldset>            
        </td>
    </tr>
</table>

<!--
    <table width="733" bgcolor="black" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="14" align="center"><img src="images/BlackLineSpacer.gif" alt="" /></td>
        </tr>
        <tr>
            <td>
                <a href="LRProducts2.aspx"><img src="images/index_r13_c2.gif" width="72" height="26" border="0" id="index_r13_c2" alt="" /></a>
            </td>
           <td><a href="reviews.aspx"><img src="images/index_r13_c4.gif" width="121" height="26" border="0" id="index_r13_c4" alt="" /></a></td>
           <td><a href="faq.aspx"><img src="images/index_r13_c6.gif" width="51" height="26" border="0" id="index_r13_c6" alt="" /></a></td>
           <td><a href="LRProducts2.aspx"><img src="images/index_r13_c7.gif" width="90" height="26" border="0" id="index_r13_c7" alt="" /></a></td>
           <td><img src="images/index_r13_c10.gif" width="70" height="26" border="0" id="index_r13_c10" alt="" /></td>
           <td><a href="HowItWorks.aspx"><img src="images/index_r13_c11.gif" width="107" height="26" border="0" id="index_r13_c11" alt="" /></a></td>
           <td><a href="about.htm"><img src="images/index_r13_c13.gif" width="78" height="26" border="0" id="index_r13_c13" alt="" /></a></td>
           <td><a href="about.htm"><img src="images/index_r13_c14.gif" width="80" height="26" border="0" id="index_r13_c14" alt="" /></a></td>
        </tr>
    <tr>
        <td colspan="3" valign="middle" align="center" style="height: 141px">
            <a href="http://www.rapidssl.com" target="_blank">
                <img src="images/rapidssl_ssl_certificate.gif" align="absmiddle" alt="Official RapidSSL Seal"/>
            </a>
        </td>                
        <td colspan="2" valign="middle" align="center" style="height: 141px"><img src="images/CreditCards.gif" alt=""/></td>
        <td colspan="3" valign="middle" align="center" style="height: 141px">
            <div class="AuthorizeNetSeal"> 
                <script type="text/javascript" language="javascript">
                    var ANS_customer_id="eeb314ba-c23a-48e3-8e45-32bd3b3a794c";
                </script> 
                <script type="text/javascript" language="javascript" src="//VERIFY.AUTHORIZE.NET/anetseal/seal.js" >
                    function Img3_onclick() { }
                </script>
                <a href="http://www.authorize.net/" id="AuthorizeNetText" target="_blank">Credit Card Processing</a> 
            </div> 
        </td>
    </tr>
        <tr >
            <td align="center" colspan="80%">
                <span class="disclaimer"> 
                    Individual results may vary. 
                    These statements have not been evaluated by the Food and Drug Administration. <br />
                    This product is not intended to diagnose, treat, cure, or prevent any disease. 
                </span>                    
            </td>
        </tr>
    </table>
-->
</asp:Content>
