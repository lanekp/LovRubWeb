html {
  margin: 0px;
  padding: 0px;
}

body {
  margin: 0px;
  padding: 0px;
  color: #000000;
  background: #fff;
  font: .7em Verdana, Arial, Helvetica, sans-serif;
  background-image: url(images/background.gif);
  background-repeat: repeat-x;
}

/* basic selectors */
a.adtext {
  color: #666666;
  text-decoration: none;
}
a.adtext:hover {
  color: #666666;
  text-decoration: none;
}
a:link {
  color: #666666;
  text-decoration: none;
}
a:visited {
  color: #666666;
  text-decoration: none;
}
a:active, a:hover {
  color: #000099;
  text-decoration: none;
}
th {
  vertical-align: top;
}
td {
  vertical-align: top;
}
h1 {
  color: #5b626c;
  font: bold 130% Verdana, Arial, Helvetica, sans-serif;
}

h2 {
  color: #5b626c;
  font: bold 120% Verdana, Arial, Helvetica, sans-serif;
}

h3 {
  color: #5b626c;
  font: bold 110% Verdana, Arial, Helvetica, sans-serif;
}

h4 {
  color: #5b626c;
  font: bold 100% Verdana, Arial, Helvetica, sans-serif;
}

h5 {
  color: #000;
  font: bold 100% Verdana, Arial, Helvetica, sans-serif;
}

h6 {
  color: #000;
  font: bold italic 100% Verdana, Arial, Helvetica, sans-serif;
}

img {
  border: 0px;
}
hr {
  color: #ccc;
  height: 1px;
}
table {
  font-size: 100%;
}
code {
  color: #6c0;
  font: 100% "Courier New" , Courier, monospace;
}
form {
  margin: 0px;
  padding: 0px;
}
input, textarea, select {
  font: 100% Verdana, Arial, Helvetica, sans-serif;
  border: 1px solid #666666;
}

#bar {
  /* styles for horizontal top bar */
  background: #d4d9de;
  height: 37px;
  padding: 7px 20px 3px 20px;
  font-size: 110%; /* box model hack */
  voice-family: "\"}\"";
  voice-family: inherit;
  height: 27px;
  z-index: 100;
}
html > body #bar {
  height: 27px;
}

/* layout styles */
#header {
  height: 109px;
  z-index: 100;
}

#logo {
  position: absolute;
  left: 15px;
  top: 15px;
  z-index: 100;
}

#menu1 {
  /* styles for top menu */
  position: absolute;
  top: 10px;
  right: 10px;
  z-index: 100;
}
#menu1 ul {
  list-style: none;
  padding: 0px;
  margin: 0px;
}
#menu1 li {
  padding: 0px;
  margin: 0px;
  display: inline;
  border-left: solid 1px #000;
}
#menu1 li.first {
  border-left: none;
}
#menu1 li a:link, #menu1 li a:visited {
  padding: 0px 2px 0px 5px;
  color: #000;
  text-decoration: none;
}
#menu1 li a:active, #menu1 li a:hover {
  color: #000;
  text-decoration: underline;
}

#mainmenu {
  /* styles for section or tab menu */
  position: absolute;
  top: 82px;
  left: 200px;
  width: 500px;
  z-index: 100;
}
html > body #mainmenu {
  position: relative; /* Necessary for menu to position in Opera */
}
#mainmenu ul {
  list-style: none;
  padding: 0px;
  margin: 0px;
}
#mainmenu li {
  display: inline;
}
#mainmenu li a:link, #mainmenu li a:visited {
  background: url( 'images/tab.gif' ) no-repeat 0px 1px;
  display: block;
  float: left;
  margin-right: 1px;
  width: 116px;
  height: 27px;
  color: #737685;
  font-weight: bold;
  text-decoration: none;
  text-align: center;
  padding-top: 6px; /* box model hack */
  voice-family: "\"}\"";
  voice-family: inherit;
  height: 21px;
  width: 115px;
}
html > body #mainmenu li a:link, html > body #mainmenu li a:visited {
  width: 115px;
  height: 21px;
}
#mainmenu li a:active, #mainmenu li a:hover, #mainmenu li a.selected {
  background: url( 'images/tab.gif' ) no-repeat 0px -92px;
}


#leftcontent {
  position: absolute;
  top: 159px;
  left: 10px;
  width: 180px;
  background: #fff;
  z-index: 100;
}

#rightcontent {
  position: absolute;
  right: 5px;
  top: 179px;
  width: 180px;
  background: #fff;
  margin-right: 10px;
  z-index: 100;
}
#centercontent {
  margin-top: 60px;
  voice-family: "\"}\"";
  voice-family: inherit;
  margin-left: 200px;
  margin-right: 205px;
  z-index: 100;
}

html > body #centercontent {
  margin-left: 200px;
  margin-right: 205px;
  z-index: 100;
}
#centercontentwide {
  margin-top: 20px;
  background: #fff;
  voice-family: "\"}\"";
  voice-family: inherit;
  margin-left: 200px;
  margin-right: 10px;
  z-index: 100;
}

html > body #centercontentwide {
  margin-left: 200px;
  margin-right: 10px;
  z-index: 100;
}

.subtotal {
  text-align: right;
  border-top: 1px solid #c9c9c9;
  margin-top: 5px;
}

.sectionheader {
  border-bottom: #dcdcdc 1px dotted;
  color: #65738E;
  font-size: 8pt;
  padding-bottom: 5px;
  font-weight: bold;
}

.admin-header {
  background-color: #6190CD;
  height: 40px;
  padding-left: 10px;
  border-bottom: solid 4px #B4CCEB;
}
.admin-header h1 {
  color: white;
}

.admintable {
  margin: 5px;
  padding: 0;
  width: 700px;
  border: 1px dashed #cccccc;
}
.adminlabel {
  font-size: 8pt;
  font-family: verdana;
  width: 120px;
  margin-bottom: 3px;
  vertical-align: top;
}
.adminitem {
  border-width: 0px;
  background-color: #ffffff;
  margin-bottom: 3px;
}

.ourprice {
  font-weight: bold;
  font-size: 10pt;
  color: #b22222;
  font-family: verdana;
}

.retailprice {
  font-weight: bold;
  font-size: 10pt;
  color: #000000;
  font-family: verdana;
  text-decoration: line-through;
}

.totalbox {
  text-align: center;
  color: #990000;
  font-weight: bold;
}

.adbox {
  padding: 10px;
  font-size: 9pt;
  margin-bottom: 10px;
  border: 1px solid gainsboro;
}
a.editme {
  text-decoration: none;
  color: #4a4d5c;
}
.commandbar {
  padding: 3px;
  font-size: 8pt; /*	background-color: blue;*/
  border: 1px solid gainsboro;
}


#footer {
  clear: both;
  border-top: solid 1px #d4d9de;
  padding: 5px;
  text-align: center;
  margin-top: 20px;
}
.mainproductimage {
  width: 220px;
  text-align: center;
  float: left;
  padding-bottom: 10px;
}

.productdata {
  border: none;
  border-collapse: collapse;
}
.productdata td, .productdata th {
  font-weight: normal;
  padding: 2px;
  text-align: left;
}
.price {
  font-weight: bold;
  color: #c00;
}
del.price {
  color: #000;
  text-decoration: line-through;
}

.productsection {
  padding: 10px;
  border-top: 1px dashed #cccccc;
}

.browsebox {
}
.browsebox h1 {
  font-family: Verdana;
  font-weight: bold;
  font-size: 12px;
  color: #3973b5;
  border-bottom: 1px dashed #cccccc;
}
.browsebox h1 a {
  color: #3973b5;
}


h1.accent {
  font-size: 12px;
  font-weight: bold;
  color: #990000;
  margin: 0px;
  margin-bottom: 5px;
}
.smalltext {
  font-size: 8pt;
  color: #666666;
  font-family: verdana;
}
.adbox h3 {
  font-weight: bold;
  font-size: 10pt;
  font-family: verdana;
  color: #C7C030;
  margin-top: 1px;
  margin-bottom: 3px;
}
.loginheader {
  height: 30px;
  font-weight: bold;
  font-size: 10pt;
  color: #666666;
  font-family: verdana;
  background-color: #f5f5f5;
  text-align: center;
}
.logincell {
  background-color: #ffffff;
  vertical-align: middle;
  text-align: center;
  padding: 20px;
}
.logtable {
  border: 1px solid #cccccc;
  background-color: #cccccc;
}
.subcategory {
  margin-left: 10px;
}
.productbox {
  height: 300px;
  width: 220px;
  border: 1px solid #c5c5c5;
  margin: 5px;
}
.productimage {
  width: 125px;
}
.productsummarydisplaywrapper {
  width: 200px;
  padding-top: 20px;
}
.productsummaryimageholder {
  height: 135px;
  text-align: center;
  vertical-align: middle;
}
.productsummarytext {
  padding-left: 20px;
  height: 55px;
}
.retailprice {
  font-weight: bold;
  color: black;
  text-decoration: line-through;
}
.yousave {
  font-weight: bold;
  color: #336600;
}
.hookline {
  font-size: larger;
  color: #5b626c;
  font-style: italic;
}
.coreboxbody {
  background-image: url(images/core_box_bg.gif);
  width: 140px;
  padding-left: 20px;
  padding-right: 20px;
}
.coreboxtop {
  background-image: url(images/core_box_top.gif);
  height: 22px;
  width: 180px;
}
.coreboxbottom {
  width: 180px;
  background-image: url(images/core_box_bottom.gif);
  height: 22px;
}
.coreboxheader {
  width: 180px;
  background-image: url(images/core_box_bg.gif);
  font-weight: bold;
  padding-top: 5px;
  padding-bottom: 10px;
  text-align: center;
}
.tenpixspacer {
  height: 10px;
}
.twentypixspacer {
  height: 20px;
}
.sectionoutline {
  border: 1px solid #cccccc;
  padding: 15px;
}

checkout-visited {
  font-size: 16pt;
  color: #dcdcdc;
  font-family: verdana;
}
checkout-current {
  font-size: 16pt;
  color: #990000;
  font-family: verdana;
}
/* Rating */
.ratingstar {
  font-size: 0pt;
  width: 13px;
  height: 12px;
  margin: 0px;
  padding: 0px;
  cursor: pointer;
  display: block;
  background-repeat: no-repeat;
}

.filledratingstar {
  background-image: url(Images/FilledStar.png);
}

.emptyratingstar {
  background-image: url(Images/EmptyStar.png);
}

.savedratingstar {
  background-image: url(Images/SavedStar.png);
}
fieldset {
  padding: 10px;
  -moz-border-radius: 1em;
  border-radius: 1em;
}
.loadingbox {
  position: absolute;
  top: 40%;
  left: 40%;
  border: 1px solid lightsteelblue;
  background-color: #ffffff;
  height: 50px;
  width: 250px;
  text-align: center;
  padding-top: 20px;
}

.selected {
  color: #E03300;
  font-weight: bold;
}

.notselected {
  color: #CCC;
  font-weight: bold;
}

.payPalLink {
  color: #E03300;
  text-decoration: underline;
  font-weight: bold;
  font-size: 1em;
}

.adminHeader {
  position: absolute;
  color: #004A78;
  font-size: 1.5em; 
  left: 110px; 
}

