<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VidPlayer.ascx.cs" Inherits="LovRubWeb.Controls.WebParts.VidPlayer" %>
<div id="flashcontent">

	<strong>You need to upgrade your Flash Player to version 9 or newer.</strong>
</div>

<script type="text/javascript">
	
	var so = new SWFObject("flvPlayer.swf?imagePath=<%= this.ThumbPath %>&videoPath=<%= this.VidPath %>&autoStart=false&autoHide=false&autoHideTime=5&hideLogo=true&volAudio=60&newWidth=320&newHeight=240&disableMiddleButton=false&playSounds=true&soundBarColor=0x0066FF&barColor=0x0066FF&barShadowColor=0x91BBFB&subbarColor=0xffffff", "sotester", "320", "240", "9", "#efefef");
	so.addParam("allowFullScreen", "true");
	so.write("flashcontent");
	
</script>