<%@ Page ValidateRequest="false" EnableViewState="false" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" 
    Title="LovRub&#153 Sexual Enhancement Gel with Aloe Vera" %>
    
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
                    <td><a href="faq.aspx"><img src="images/index_r4_c5.gif" width="136" height="80" border="0" id="Img3" alt="" /></a></td>
                    <td><img src="images/index_r4_c8.gif" width="136" height="80" border="0" id="Img4" alt="" /></td>
                </tr>
                <tr>
                   <td><a href="reviews.aspx"><img src="images/reviews_r5_c2.gif" width="138" height="73"  border="0" id="Img5" alt="" /></a></td>
                   <td><a href="LRProducts2.aspx"><img src="images/index_r5_c5.gif" width="136" height="73"   border="0" id="Img6" alt="" /></a></td>
                   <td><a href="HowItWorks.aspx"><img src="images/index_r5_c8.gif" width="136" height="73"  border="0" id="Img7" alt="" /></a></td>
                </tr>
            </table>
        </td>        
    </tr>
</table>
  
<table  bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="20" cellspacing="0">
    <tr>
        <td valign="top">
            <br />        
            <p class="prodReview">
                        &#34Thanks for the great product! 
                        After only 5 days, 
                        <span class="prodReview14Bold"><em>I'm already noticing a huge difference.</em></span>
                        &nbsp;Great job!&#34<br />
                        - Kevin L.<br />
            </p>
            <br />
            <br />        
             <p class="prodReview">
                    &#34After my 50th birthday, my love life fizzled a 
                   little. I found your website. Let me tell you, 
                   this stuff really works.<span class="prodReview14Bold">&nbsp;<em>Now, sex with my wife is amazing!&#34</em></span>
                <br />
                - Brian W.<br />
             </p>
            <br />
            <br />        
            
             <p class="prodReview">
                &#34I have been searching for a natural, sexual enhancer for a while. I have tried other products and none have been effective. I never wanted to 
                take any pills. <span class="prodReview14Bold"><em>&nbsp;I have been using Lovrub regularly for three months and I can tell you the sex has 
                been amazing!&#34</em></span>
                <br />- Joe A.
             </p>
            <br />
            <br />        
            <p class="prodReview">
                &#34It has really surprised me was how much better 
                 the sex has been with Lovrub for women. 
                <span class="prodReview14Bold">
                    <em>&nbsp;My orgasms have been intensely more satisfying since using Lovrub.</em></span>&#34<br />
                - Gina F.
            </p>
            <br />
            <br />        
       </td>
       <td>
            <img src="images/faqCenterLine.gif" width="45" height="660" border="0" id="Img1" alt="" />
       </td>
       
       <td valign="top">
            <br />
            <p class="prodReview">
                            &#34I usually don't believe anything I read online,
                            as a general rule. A friend of mine told me about Lovrub and I thought I'd try it just to see if it
                            really worked.&nbsp; 
                            <span class="prodReview14Bold">
                                <em>Am I glad I did! Lovrub for
                                men is awesome! I will always make sure I
                                have an adequate supply on hand.&#34</em>
                            </span>
                        <br />- Arnie G.<br />
            </p>
            <br />
            <br />        
            <p class="prodReview">
                &#34I recently purchased Lovrub for women, 
                originally as a goof, not expecting much. I was 
                so wrong. 
                <span class="prodReview14Bold">
                    <em>Lovrub is incredible, my sex life has improved 100%.&#34</em>
                </span><br />
                - Karla A
            </p>
            <br />
            <br />        
             <p class="prodReview">&#34I'm writing on behalf of myself and my husband... I bought him Lovrub for men as 
               a birthday present and purchased the Lovrub 
               for women for myself. 
               <span class="prodReview14Bold">
                    <em>Sex is a lot more fun and satisfying!&#34</em>
               </span><br />
               - Maria D.<br />
             </p>
            <br />
            <br />        
        </td>       
    </tr>      

</table>

</asp:Content>
