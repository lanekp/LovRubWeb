<%@ Control Language="C#" ClassName="AcceptedPayment" %>
    <div class="twentypixspacer"></div>
    <img src="<%=Page.ResolveUrl("~/images/visa.gif") %>" alt="We accept Visa"/>
    <img src="<%=Page.ResolveUrl("~/images/mc.gif")%>" alt="We accept Mastercard"/>
    <img src="<%=Page.ResolveUrl("~/images/amex.gif")%>" alt="We accept American Express"/><br />
    <img src="<%=Page.ResolveUrl("~/images/discover.gif")%>" alt="We accept Discover"/>
    <img src="<%=Page.ResolveUrl("~/images/echeck.gif")%>" alt="We accept eCheck"/>
    <a href="https://www.paypal.com/cgi-bin/webscr?cmd=xpt/popup/OLCWhatIsPayPal-outside" target="_blank">
    <img src="<%=Page.ResolveUrl("~/images/paypal.gif")%>" alt="We accept PayPal"/>
    </a>