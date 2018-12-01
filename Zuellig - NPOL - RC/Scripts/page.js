///<reference path="jquery-1.3.2-vsdoc2.js" />
///<reference path="jquery.ribbon.js" />
 
//$().ready(function() {
//   });
jQuery(document).ready(function($) {
// code ở đây ta có thể sử dụng $ như thường!
 $().Ribbon({ theme: 'windows7' });

    $('ul.ribbon-theme li').click(function() { $().Ribbon({ theme: $(this).attr('class').substring(7) }); });

});