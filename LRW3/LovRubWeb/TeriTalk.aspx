<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" Title="LovRub - Teri Talk" %>

<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead id="MastHead1" runat="server">
    </uc1:MastHead>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="ID1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
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
    <!--
    <div class="righticol" style="background: url(images/bi-letstalk.jpg) no-repeat top right;">
 
        <div class="imagedContent">
        <h1 class="pagetitle">Teri Talk</h1>
			<p style="padding: 10px 0; margin: -20px 0 20px 0; border-top: 1px dotted #E5E5E5; border-bottom: 1px dotted #E5E5E5;">Email Teri at <a href="mailto:teri@lovrub.com?subject=Teri Talk">teri@lovrub.com</a>.</p>
            <p class="teri">
                <span>TERI:</span> A big shout-out to all of you who have tried our products, and experienced 
                the amazing pleasure and excitement LovRub adds to lovemaking. This column is for 
                all of you to tell me your feelings about LovRub, share some juicy secrets (not too 
                juicy), and ask me any questions you have about this or any of our products.  
                
            </p>
            <p class="teri">
                So don&#39t be shy, c&#39mon, talk to Teri.  You can tell me anything. I want to hear 
                from you, and give you whatever facts you need to get the most from our products. 
                I promise to tell you what you need to know&nbsp;.&nbsp;.&nbsp;.and possibly give you a few ideas you 
                never considered.      
            </p> 
            <div class="letter">
                <span class="opener">YO, TERI&nbsp;.&nbsp;.&nbsp;.</span>
                <p>
                    &#34My girlfriend and I have been using K-Y for a 
                    while - is it different than LovRub, and how?&#34
                </p>
                <span class="sig">S-DOG from Manhattan</span>
                <p class="teri">
                    <span>OH BOY, IS IT EVER DIFFERENT!</span>
                    First of all, K-Y is merely a lubricant, while LovRub is a sexual stimulant.  
                    And believe me, that makes a big difference 
                    all by itself.  Even more important is the fact that K-Y and other 
                    products like it can contain Methyl Salicylate, a dangerous substance that 
                    accumulates in the body, and can become damaging to your body over time. 
                    LovRub is a safe, all-natural, scientifically-formulated sexual enhancer 
                    that makes the entire lovemaking experience more exciting and satisfying for 
                    both men and women. So not only are most lubricants potentially dangerous, 
                    they do no more for you than if you covered your bodies in Crisco.  
                    Try LovRub instead, and you will definitely not be disappointed! <br />
                    Oh, and I hope the &#34S&#34 in S-DOG stands for sex.
                </p>
            </div> 
            <div class="letter">
                <span class="opener">HI, TERI&nbsp;.&nbsp;.&nbsp;.</span>
                <p>
                    &#34I was just wondering&nbsp;.&nbsp;.&nbsp;.what&#39s up with the two LovRubs?  Is there really a 
                    difference between, or can they be used interchangeably?&#34
                </p>
                <span class="sig">FREESPIRIT.COM</span>
                <p class="teri">
                    <span>THERE ARE TWO VERSIONS BECAUSE THERE ARE TWO TYPES OF HUMAN BEINGS&nbsp;.&nbsp;.&nbsp;.</span>
                    While LovRub For Women and LovRub For Men can be combined, please be aware that 
                    the sexual and physiological differences between men and women are the reasons 
                    for the two varieties. The skin in and around the vaginal and clitoral regions 
                    is more sensitive than a man&#39s sexual organs, and therefore requires a lesser 
                    concentration of the ingredients in LovRub. They&#39re basically the same 
                    formulations; LovRub For Men is just more concentrated than its gentler 
                    female counterpart. 
                </p>
            </div> 
            <div class="letter">
                <span class="opener">HEY, TERI&nbsp;.&nbsp;.&nbsp;.</span>
                <p>
                    &#34I noticed I&#39m going through my tube of LovRub faster than my wife. Is that 
                    normal, or am I overdoing it.?&#34 
                </p>
                <span class="sig">HOTROD from AZ</span>
                <p class="teri">
                    <span>Hey, big man&nbsp;.&nbsp;.&nbsp;.</span>
                    you can&#39t overdose on LovRub, anymore than you can OD on love. Listen, it&#39s 
                    like I said to the last writer, the male sexual organ simply covers more 
                    ground than a woman&#39s. So it takes a bit more LovRub to cover you up and 
                    get you started. The general rule of thumb is a dime-size amount for a woman, 
                    and a quarter for you. But again, all men are not created equal, so just 
                    use whatever comes naturally, H-Rod! 
                </p>
            </div> 
            <div class="letter">
                <span class="opener">HI, TERI&nbsp;.&nbsp;.&nbsp;.</span>
                <p>
                    &#34Is it okay if the two LovRub varieties mix together during intercourse? 
                    Are there any potential problems if they do?&#34
                </p>
                <span class="sig">SUSIEQ@yahoo.com</span>
                <p class="teri">
                    <span>IS IT OK? <strong>HONEY, IT&#39S INCREDIBLE!</strong></span>
                    The two are scientifically-designed to work together. Many customers have 
                    written to tell me that they never before experienced such intense pleasure 
                    during intercourse, or had such strong orgasms before. 
                </p>
            </div> 
            <div class="letter">
                <span class="opener">WHAT&#39S UP, TERI?&nbsp;.&nbsp;.&nbsp;.</span>
                <p>
                    "I understand that LovRub is all-natural, which is great, but what are the major 
                    ingredients and what do they do?&#34 
                </p>
                <span class="sig">Rob & Amanda H., CA</span>
                <p class="teri">
                    <span>GOOD QUESTION</span>
                    Well, one of the major ingredients is Aloe Vera, the same stuff that keeps babies 
                    skin so soft and touchable. However, what allows LovRub to stimulate so well is a 
                    chemical found naturally in the skin on grapes&nbsp;.&nbsp;.&nbsp;.Trans-Resveratrol. It&#39s a wonderful 
                    antioxidant found in red wine, as well, so you won&#39t be surprised when I tell you 
                    it helps relax your body. What it also does is increase blood flow, which is always 
                    good for getting a rise out of a man. The greater the flow of blood to the 
                    bodies erogenous zones, the more sensitive the nerve ends become, and the greater 
                    your pleasure. So next time you find yourself peeling grapes, you may want to 
                    save the skin. We do&nbsp;.&nbsp;.&nbsp;.which is why LovRub is so good at what it does for you and 
                    your partner.  
                </p>
            </div> 
            <div class="letter">
                <span class="opener"></span>
                <p>
                    
                </p>
                <span class="sig"></span>
                <p class="teri">
                    <span></span>
                </p>
            </div>
           
              
           
            
                
            
        </div>
    </div>
-->  

 <div class="righticol" style="background: url(images/bi-letstalk.jpg) no-repeat top right;">
        <div class="imagedContent">
        <h1 class="pagetitle">Teri Talks Blog</h1>
			<p style="padding: 10px 0; margin: -20px 0 20px 0; border-top: 1px dotted #E5E5E5; border-bottom: 1px dotted #E5E5E5;">Email Teri at <a href="mailto:teri@lovrub.com?subject=Teri Talk">teri@lovrub.com</a>.</p>
         
            <div class="letter">
                <p class="teri">
                    <!--
                    <span>Visit Teri&#39s new blog at <a href="http://teritalks.com" target: "_blank">TeriTalks.com</a>,</span> where Teri will continue to answer all your questions, talk about ways to improve your sex life and even brig up some real-life stories into the mix.</p>
                    <span class="opener">Visit <a href="http://teritalks.com" target: "_blank">TeriTalks.com</a>!</span>
                    -->

                <!-- 
                <p>
                    Some exerpts from <a href="http://teritalks.com" target: "_blank">TeriTalks.com</a>:<br />
                </p>
                -->
                
                <h2>What&#39s Your OQ (Orgasm Quotient)?</h2>
                <p>
                    <em>&quot;Finally&#133I get to talk about one of my absolute favorite subjects: 
                    the female orgasm. It&#39s just one more area, ladies, 
                    where we outshine the male of the species. 
                    Naturally, most men are close to clueless about the subject; 
                    unfortunately, far too many women are also less&#45;than&#45;fully informed 
                    as to the pleasure their own bodies can provide.&quot;</em>
                </p>
                
                <p>
                    <em>&quot;For example, how many of you know that women can achieve 
                    both a clitoral (external) and vaginal 
                    (internal, which involves stimulating the fabled &quot;G&quot; spot) 
                    orgasm, either separately or together? 
                    Or that, unlike our brothers, many women can 
                    achieve multiple orgasms&#133;I&#39;ve heard that some men can also, 
                    but I&#39ve yet to meet one. 
                    Either one is highly pleasurable (duh!), 
                    however, for most women, 
                    the clitoral orgasm is easier to achieve and more intense.&quot;</em>
                </p>
                <p>
                    <em>&quot;Now, since I&#39ve read that as many as 25% of women 
                    (some say even more) don&#39t frequently &#45; or have never &#45; experienced orgasm, 
                    I urge these women to explore their own sexuality, 
                    as well as ask their therapist or gynecologist for guidance. 
                    Also, I recommend any woman seeking greatly sexual pleasure in her life 
                    seek one of the many quality books on the subject of female sexuality. 
                    Very often, the inability of a woman to reach orgasm is emotional or 
                    psychological, not physical, so there&#39s no reason to deny yourself 
                    all the pleasure your body can bring when help is easy to come by (
                    no pun intended). Female sexuality is strong, beautiful, and freakin&#39 
                    incredible&#133don&#39t go through life without it.&quot;</em>
                </p>
                
                <h2>Lubricants vs. Stimulants: No Contest!</h2>
                <p>
                    <em>&quot;The other night I was out with some girlfriends, 
                    and after a couple of stiff ones (drinks, that is), 
                    the subject of personal lubrication came up (no pun intended). 
                    It was amazing to me how many of them didn&#39t know the difference between 
                    an ordinary lubricant and one that&#39s a sexual stimulant. 
                    Duh&#133;it&#39s only about the same as night and day!&quot;</em>
                </p>
                
                <p>
                    <em>&quot;Virtually anything wet and/or viscous can be a lubricant: 
                    cooking oil, Crisco (for those of you mature enough to remember it), 
                    peanut butter (non-chunky, of course), jam, cod liver oil, 
                    even axle grease. But I don&#39t think many people 
                    would want to smear any of these (well, maybe peanut butter and jam) 
                    all over their bodies&#133;or in them! 
                    Even the most desirable of plain lubricants 
                    (chocolate and whipped cream come to mind) don&#39t 
                    provide the physiological excitement derived from a good sexual stimulant.&quot;</em>
                </p>
                
                <p>
                    <em>&quot;The dictionary defines a stimulant as something that causes 
                    physical activity in something, such as a nerve or 
                    bodily organ (got any particular one in mind at the moment?).  
                    Such a substance creates tactile sensations on the skin 
                    that send electrical impulses to the brain, and 
                    chemical changes that generate arousal within our 
                    individual pleasure centers. In other words, stimulants 
                    trigger both electrical and chemical reactions that, by 
                    themselves, make us feel good. Excited. Sexual. 
                    Stimulated! No way engine grease or velvetta is going to do all that.&quot;</em>
               </p>
                
                <p>
                    <em>&quot;It&#39s this huge difference that led me to LovRub, 
                    as opposed to traditional, ordinary sexual lubricants like 
                    K-Y.  LovRub is all-natural &#45; without potentially harmful ingredients like methyl salicilate, 
                    which is found in several lubricant products today &#45; and almost instantly gives you a 
                    warm, sexy feeling all over. Now let me tell you&#133;I&#39
                    ve rubbed plenty of chocolate and oils over my body in my time, 
                    but nothing ever gave me the sensations and stimulation from a little dab of LovRub 
                    where it counts. When it&#39s a choice between a 
                    sexual stimulant and a lubricant, there&#39s really no need to choose&#133;
                    LovRub let&#39s you enjoy it all. I mean, really enjoy it!&quot;</em>
                </p>
                
                <h2>Lip Service As It Was Meant To Be</h2>
                
                <p><em>&quot;One of the things I love most about gay men is their willingness 
                    to be sexually adventurous. My friend of 20 years has 
                    been in a steady, happy relationship since the millennium, 
                    but recently told me his sex life could use some new 
                    stimulation. So I immediately whipped out my 
                    stick&#133;of LipLov. &#39Chapstick?&#39 he asked&#133;&#39that&#39s your secret for a better sex life?&#39 
                    Aahhh&#133;not mere Chapstick, I assured him. 
                    For while it looks like an ordinary balm stick, and is applied the same way, 
                    the results are anything but.&quot;</em>
                </p>
                
                <p><em>&quot;It&#39s quite possible LipLov is the ultimate oral 
                    pleasure enhancer&#133;and since it&#39s hard (no pun intended) 
                    to improve something as perfectly pleasurable as oral sex, 
                    you know this stuff is really good. I ran into him a 
                    couple of weeks later, and try as he might, he couldn&#39t stop smiling as we talked. 
                    He told me how much he and Greg (his partner) enjoyed LipLov, 
                    and that it&#39s added the missing spark to their lovemaking. 
                    As he puts it, it never fails to get a rise out of both of them. 
                    I quickly reminded him that it causes wonderful sensations 
                    wherever the lip-bearer puts them on his partner&#39s body&#133;but 
                    he told me neither of them could wait for the other to 
                    &#39get down&#39 to business to find that out. Oh well&#133;maybe in a few months.&quot;</em>
                </p>
            </div> 
        </div>
    </div>    
</asp:Content>
