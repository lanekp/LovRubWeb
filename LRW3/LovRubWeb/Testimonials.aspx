<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" Title="LovRub - Testimonials" %>

<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead id="MastHead1" runat="server">
    </uc1:MastHead>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li class="active"><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>			
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSubMenu" runat="server">

    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
    <!-- <div class="righticol" style="background: url(images/bi-testimonials.jpg) no-repeat top right;"> -->
    <div class="righticol" style="background: url(images/testimonials.gif) no-repeat top right;">
        <div class="imagedContent">
            <h1 class="pagetitle">Testimonials</h1>
            <div class="testimony">
                <p>
                    &quot;I always had my doubts about these types of <br />  
                    products and never really wanted to try any, because I've read 
                    about them being unsafe.  LovRub has changed my perspective completely.   
                    My wife and I love it, and it's really a comfort to know that it's made from natural ingredients.&quot
                </p>
                <p> - Anonymous, Rocky Point, NY</p>
            </div>
            <div class="testimony">
                <p>
                    &quot;I saw a TV commercial for LovRub, and was curious&#133OK, a little aroused, too. 
                    So I went online and ordered one tube each for me and my boyfriend. 
                    The fact that I&#39m writing this letter tells you how much we enjoyed it. 
                    I&#39ve already re-ordered. I can honestly say it was my pleasure using your product.&quot
                </p>
                <p> - Kaitlyn C., San Antonio, TX</p>
            </div>
            
            <div class="testimony">
                <p>&quot;Hot damn, that is one incredible product you put out. 
                    I originally got it for the Mrs., who hasn&#39t stopped thanking me yet. 
                    But it turns out that it gets me up quicker than Reveille in my army days. 
                    You weren&#39t lyin&#39 when you said it would be the best sex ever. 
                    At the price you charge, that&#39s quite a bargain!&quot;
                </p>
                <p> - Chet K., Boise, MN</p>
            </div>
            <div class="testimony">
                <p>&quot;What can you say about a product that has such a profound impact on your life. 
                    I know how strange that sounds, but using LovRub has made our lovemaking so amazing, 
                    there&#39s no other way to put it. We had fallen into a bit of a &quot;rut&quot; after 11 
                    years of marriage, and LovRub was just the spark our sex life needed. 
                    Thank you for creating it.&quot;
                </p>
                <p>Whitney and James W., Queens, NY</p>
            </div>
            <div class="testimony">
                <p>&quot;From the second my girlfriend spread LovRub For Men on me, 
                    the sensation was fantastic&#133and it just kept getting better. 
                    She had the same reaction when I gave her a sampling of LovRub For Women. 
                    But when we &quot;got together&quot;&#133;BAM! It was like nothing either of us had felt before. 
                    You were right&#133it was the best sex we&#39d ever had. 
                    Until the next time&#133and the next&#133you get the picture. 
                    We are one very gratified &#45; and satisfied &#45; couple thanks to your product.&quot;
                </p>
                <p>-	Grant and Margo T., Youngstown, OH</p>
            </div>
            <div class="testimony">
                <p>&quot;Your wonderful product is proof that you can teach an old &quot;dog&quot; a new trick. 
                    I may be over 60, but I&#39m certainly not over&#45;the&#45;hill when it comes to sex. 
                    My &quot;steady&quot; and I got a tube of both kinds of 
                    LovRub on his 65th birthday as a &quot;gag&quot; gift. 
                    Well, the joke was on the giver, because we&#39ve been having a ball with them&#133;literally! 
                    I&#39m enjoying sex like a teenager again&#133;who doesn&#39t want that?&quot;
                </p>
                <p>-	Vivian A., New Milford, CT</p>
            </div>
            <div class="testimony">
                <p>&quot;Thank you for making such a great product! 
                    Believe it or not, my mother thanks you, too. 
                    After I liked it so much, I ordered a tube for her. 
                    She&#39s never loved her daughter more.&quot;
                </p>
                <p>-	Amanda T., Saginaw, MI</p>
            </div>
            <div class="testimony">
                <p>&quot;I&#39ve spent quite a long time looking for a sexual enhancer 
                    without chemicals or artificial ingredients. 
                    When I saw your TV commercial, and then read about LovRub on your website, 
                    I was cautiously optimistic. After just one use, 
                    I knew I&#39d found the right product. 
                    My wife is reading this over my shoulder right now, 
                    and shaking her head very enthusiastically in agreement. 
                    Obviously, you have two new big-time LovRub fans.&quot;
                </p>
                <p>-	Peter J., Reading, PA</p>
            </div>
            <div class="testimony">
                <p>&quot;I never had trouble climaxing, and had orgasms that were pretty intense, 
                    so I didn&#39t think LovRub would do much for me. 
                    But my boyfriend wanted to try it, so we did. 
                    My God, I&#39ve never been so happy being wrong.  
                    My orgasms have been more intense than ever, 
                    and I&#39ve finished more satisfied using LovRub. It really does pay to try new things.&quot;
                </p>
                <p>-	Penelope N., Chevy Chase, MD</p>
            </div>
            <div class="testimony">
                <p>&quot;Most of the men I&#39ve dated are less than exceptional when it 
                    comes to oral sex. 
                    Now I have them put on LipLov first, and they pleasure me like experts. 
                    Thanks, Health Rockers!&quot;
                </p>
                <p>-	Sheila F., Piscataway, NJ</p>
            </div>
            <div class="testimony">
                <p>&quot;Love, love, love your new LipLov. I can&#39t imagine a guy who wouldn&#39t.&quot;
                </p>
                <p>-	Ron P., Long Island, NY</p>
            </div>
            <div class="testimony">
                <p>&quot;Who&#39d have thought you could improve on oral sex&#133that&#39s what I call progress.&quot;
                </p>
                <p>-	Michael I., Durham, NC</p>
            </div>
            <div class="testimony">
                <p>&quot;LipLov is definitely the head of the class.&quot;
                </p>
                <p>-	Paula S., Las Vegas, NV</p>
            </div>
            <div class="testimony">
                <p>&quot;Ladies, trust me, your man will be much more willing to perform oral sex, 
                and do a better job, with new LipLov. 
                He&#39ll like the cherry taste, and you&#39ll love what he does with it.&quot;
                </p>
                <p>-	Shannon B., Sacramento, CA</p>
            </div>
            <div class="testimony">
                <p>&quot;I&#39m lucky enough to have had quite a few mind-blowing oral experiences in my day, 
                but none was as intense as when my wife used LipLov. 
                The second her lips touched me, my eyes rolled back, 
                and my knees wobbled a little. From there, it was sheer bliss. 
                I don&#39t think I&#39ve ever been so satisfied by a product before&#133;and so anxious to use it again.&quot;
                </p>
                <p>-	Malcolm V., Dallas, TX</p>
            </div>                                                                                                        
                   
            <img src="images/productshot.jpg" alt="Personal Lubricants" />
        </div>
    </div>
</asp:Content>
