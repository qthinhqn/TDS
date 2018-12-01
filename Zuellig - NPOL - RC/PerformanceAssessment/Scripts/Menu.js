function Ajax_GetList() {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:27918/test/getOfficeList.aspx',
        dataType: 'html',
         success: function(data) {
         ParseOfficeList(data);
        }
       
    });
}
function ParseOfficeList(xml) {
     //String.prototype.format.regex = new RegExp("{-?[0-9]+}", "g");
  
    xmlDoc = $.parseXML(xml);
    $xml = $(xmlDoc);
    $OfficeName = $xml.find("Office > Name");

    var officelist = '<ajaxToolkit:Accordion ID="Accordion1" runat="server" SelectedIndex="0" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected" ContentCssClass="accordionContent" FadeTransitions="true" FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true" Width="167"><Panes> <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" ToolTip="Click this" CssClass="panecss"><Header><img  src="images/Inbox.gif" height="10" width="10"  /><a ID="link" runat="server"  CssClass="selectedbutton">Chi nhánh hồ chí minh</a></Header><Content>';
    var Number=1;
    for (var i = 0; i < $OfficeName.length; i++) {

        $Name = $OfficeName[i];
        if ($Name.tagName == 'Name') {

            var value = Number.toString();
            officelist += ' <a href="lehaiha.aspx" ID="link' + value + '" runat="server">' + $Name.textContent + '</a><br />';


        }
        Number = Number + 1;

    }
    officelist += '</Content></ajaxToolkit:AccordionPane></Panes></ajaxToolkit:Accordion>';
    $('#officelist').html(officelist);
       
        
       
            

 
}
