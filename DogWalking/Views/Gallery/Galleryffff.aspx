<%@ Page Language="C#" AutoEventWireup="true" Inherits="DogWalking.Contact%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- META tag for mobile gallery layout (REQUIRED; if not already included in page!!!) -->
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=0" />

<!-- Load jQuery (REQUIRED; if not already included in page!!!) -->
<script type="text/javascript" src="../../scripts/jquery.1.11.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery.migrate.1.2.1.min.js"></script>

<!-- Load Files for Fancybox Plugin (Please check and adjust Path Names if necessary!) -->
<link rel="stylesheet" type="text/css" href="../../plugins/fancybox/jquery.fancybox.min.css" />
<link rel="stylesheet" type="text/css" href="../../plugins/fancybox/Helpers/jquery.fancybox-buttons.min.css" />
<link rel="stylesheet" type="text/css" href="../../plugins/fancybox/Helpers/jquery.fancybox-thumbs.min.css" />
<script type="text/javascript" src="../../plugins/fancybox/jquery.fancybox.min.js"></script>
<script type="text/javascript" src="../../plugins/fancybox/helpers/jquery.fancybox-buttons.min.js"></script>
<script type="text/javascript" src="../../plugins/fancybox/helpers/jquery.fancybox-thumbs.min.js"></script>
<script type="text/javascript" src="../../plugins/fancybox/helpers/jquery.fancybox-media.min.js"></script>
<script type="text/javascript" src="../../plugins/fancybox/helpers/jquery.fancybox-easing.min.js"></script>

<!-- Load Files for Tooltip Plugin (Please check and adjust Path Names if necessary!) -->
<link rel="stylesheet" type="text/css" href="../../plugins/tooltipster/jquery.tooltipster.min.css" />
<script type="text/javascript" src="../../plugins/tooltipster/jquery.tooltipster.min.js"></script>

<!-- Load Files for Metafizzy Isotope Plugin (Please check and adjust Path Names if necessary!) -->
<script type="text/javascript" src="../../plugins/isotope/jquery.isotope1.min.js"></script>

<!-- Load Files for Facebook Gallery Plugin (Please check and adjust Path Names if necessary!) -->
<link rel="stylesheet" type="text/css" href="../../Content/FBGallery/jquery.fb-iconfont.min.css" />
<link rel="stylesheet" type="text/css" href="../../Content/FBGallery/jquery.fb-album.min.css" />
<script type="text/javascript" src="../../scripts/jquery.fb-album.min.js"></script>
</head>
<body>
    <!-- Put this DIV where you want the Gallery to appear on your Website -->
<div id="FB_Album_Frame" class="FB_Album_Frame"></div>

<!-- This Code will initialize the Gallery with your Settings (can also be inserted in HEAD Section) -->
<script type="text/javascript">
    jQuery(document).ready(function($){
        $("#FB_Album_Frame").FB_Album({
            facebookID: "1313401160",
            facebookToken: "1103152813043002|8VOT30PQ8kqCvVi_DZqqoqvN7os",
            responsiveGallery: true,
            responsiveWidth: 90,
            albumShowPaperClipL: false,
            albumShowPaperClipR: false,
            albumShowPushPin: false,
            albumShowSocialShare: true,
            albumThumbSocialShare: true,
            photoThumbSocialShare: true,
            photoShortSocialShare: true,
            albumsFilterAllow: false,
        });
    });
</script>

</body>
</html>
