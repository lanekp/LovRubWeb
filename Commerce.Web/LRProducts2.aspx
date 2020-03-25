<%@Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="LRProducts2.aspx.cs" Inherits="LRProducts2" Title="LovRub Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table width="733" bgcolor="black" border="0" align="center" cellpadding="8" cellspacing="0">
    <tr>
        <!-- <td colspan="5"><a href="default.aspx"><img src="images/products_r2_c2.gif" border="0" width="289" height="107" alt="LovRub&#153; Home" /></a></td> -->
        <td colspan="5"><a href="default.aspx"><img src="images/lovrubweblogo.gif" border="0"  alt="LovRub&#153; Home" /></a></td>
        <td rowspan="3"><img src="images/CouplePhoto5.gif" width="243" height="327" border="0" id="Img2" alt="" /></td>
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
        <td>
            <p>
                <span class="maleRedLogoProduct">&nbsp;LovRub<sup>&#153</sup> for Men</span><br /><br />
                <span class="defaultText">
                    Improve your sexual experiences.  LovRub for Men<sup>&#153</sup>
                    will dramatically increase your feeling of firmness, sexual sensation and pleasure.<br /> Try It and See!
                </span>
            </p>
        </td>
        <td rowspan="2"><img src="images/LRProductMale2.gif" alt="" /></td>        
    </tr>
    <tr>
        <td>
            <!-- <img src="images/productPricingMale.gif" border="0" id="Img3" alt="" /> -->
            <img src="images/middle_banner_male.gif" border="0" id="Img3" alt="" />
        </td>
    </tr>
    <tr>
        <td>
            <table cellspacing="5">
                <tr>
                   <td>
                        <!-- ImageURL="images/Male1Jan22.gif" -->
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
                        <!-- ImageURL="images/Male2Jan21.gif" -->
                        <asp:ImageButton ID="btnMen2222" runat="server" 
                        Height="124" 
                        Width="148"
                        OnClick="btnMen2_Click" 
                        ImageURL="images/btn_male_29.98.gif"
                        AlternateText="LovRub for Men 2 for $29.98" 
                        />
                    </td>        
                    <td>
                        <!-- ImageURL="images/Male3Jan21.gif" -->
                        <!-- ImageURL="images/btn_male_53.85.gif" -->                        
                        <asp:ImageButton ID="btnMen333" runat="server" 
                        Height="124" 
                        Width="148"
                        OnClick="btnMen3_Click" 
                        ImageURL="images/btn_male_39.97.gif"
                        AlternateText="LovRub for Men 3 for $39.97" 
                        />
                    </td>        
                </tr>
            </table>
        </td>
        <td align="center"><img src="images/AllNatural.gif" border="0" alt="Natural Sex Enhancement Gel"/></td>
    </tr>
    <tr>
        <td align="center" colspan="5"><img src="images/MadeInUSA.gif"   alt="LovRub Sex Cream is Made in USA""/></td>
    </tr>    
    
    <tr><td align="center" colspan="8"><img src="images/LineSpacer2.gif" height="58" alt="" /></td></tr>
    
    <tr>
        <td>
            <p>
                <span class="lrProdFemaleParagraph">
                    <span class="femaleRedLogoProduct">&nbsp;LovRub<sup>&#153</sup> for Women</span><br /><br />
                </span>
                <span class="defaultText">
                    Improve your sexual experiences.  LovRub for Women<sup>&#153</sup>
                    will dramatically increase your sense of feeling, pleasure and satisfaction. <br />Try It and See!
                </span>
                <br />
            </p>
        </td>
        <td rowspan="2"><img src="images/LRProductFemale2.gif" alt="" /></td>        
    </tr>
    <tr>
        <td>
            <!-- <img src="images/productPricingFemale.gif" border="0" id="Img10" alt="" /> -->
            <img src="images/middle_banner_female.gif" border="0" id="Img1" alt="" />
        </td>
    </tr>
    
    <tr>
        <td>
            <table cellspacing="5">
                <tr align="center">
                   <td>
                        <!-- ImageURL="images/Female1Jan21.gif" -->
                        <!-- ImageURL="images/btn_female_19.95.gif" -->
                        <asp:ImageButton ID="btnWomen111" runat="server" 
                        Height="124" 
                        Width="148"
                        OnClick="btnWomen1_Click" 
                        ImageURL="images/btn_female_19.99.gif"
                        AlternateText="LovRub for Women 1 for $19.99" 
                        />
                    </td>
                    
                    <td>
                        <!--ImageURL="images/btn_female_35.90.gif" -->
                        <asp:ImageButton ID="btnWomen222" runat="server" 
                        Height="124" 
                        Width="148"
                        OnClick="btnWomen2_Click" 
                        ImageURL="images/btn_female_29.98.gif"
                        AlternateText="LovRub for Women 2 for $29.98" 
                        />
                    </td>        
                    <td>
                    <!--ImageURL="images/btn_female_53.85.gif" -->
                        <asp:ImageButton ID="btnWomen333" runat="server" 
                            Height="124" 
                            Width="148"
                            OnClick="btnWomen3_Click" 
                            ImageURL="images/btn_female_39.97.gif"
                            AlternateText="LovRub for Women. 3 for $39.97" 
                        />
                    </td>        
                </tr>
            </table>
        </td>
        <td align="center"><img src="images/AllNatural.gif" border="0" alt="Natural Sex Enhancement Gel"/></td>
    </tr>
    <tr>
        <td align="center" colspan="5"><img src="images/MadeInUSA.gif"   alt="LovRub Sex Cream is Made in USA""/></td>
    </tr>    
                
    <tr><td align="center" colspan="8"><img src="images/LineSpacer2.gif" height="58" alt="" /></td></tr>
<!--
    <tr>
        <td background="images/products_r11_c3.gif">
            <p>
                <span class="lrProdFemaleParagraph">
                    <span class="femaleRedLogo">LovRub<sup>&#153</sup> for Women</span> <br /><br />
                </span>
                <span class="defaultText">
                    When topically applied it increases
                    sexual sensation, pleasure and satisfaction.
                </span>
            </p>
        </td>
        <td rowspan="2"><img src="images/LRProductFemale2.gif" alt="" /></td>        

    </tr>
    <tr>
        <td><img src="images/products_r13_c3.gif" width="113" height="78" alt="" /></td>
        <td><img src="images/products_r13_c6.gif" width="113" height="78" alt="" /></td>            
        <td><img src="images/products_r13_c9.gif" width="113" height="78" alt="" /></td>    
    </tr>
    <tr><td align="center" colspan="8"><img src="images/LineSpacer2.gif" height="58" alt="" /></td></tr>    
-->
</table>



</asp:Content>

