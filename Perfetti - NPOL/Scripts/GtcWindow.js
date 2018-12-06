// JScript File
var gctPopupWindow = null;
var gctPopupOverlay = null;
var GCTPopupWindow = new GCTPopupWINDOW();

var gctWindow = null;
var gctOverlay = null;
var GCTWindow = new GCTWINDOW();

//For alert
var cstAlertOver = null;
var cstAlertWin = null;

function GCTWINDOW()
{
    this.open = OpenWindow;
    this.close = closeGCTWindow ;
    
    this.openNew = OpenWindowNew;        
    this.openDashboard = OpenWindowDashboard;
    this.message = CustomizeAlertOpen;
    this.closeMessage = CustomizeAlertClose;
    this.MessageBox = CustomizeAlertOpen_NEW
    this.MessageBox_Language = CustomizeAlertOpen_Language;
    this.MessageBox_NotMove = CustomizeAlertOpen_NotMove;
    this.OpenConfirm = CustomizeAlertPassOpen;
    this.MessageBoxNoRecord = CustomizeAlertNoRecords;
    // open new popup standar
    this.jWindow = JOpenPopup;
    this.jWindow_Wrap = JOpenPopup_Wrap;
}
var ie = navigator.userAgent.indexOf("MSIE")>-1;
var ie6 = navigator.userAgent.indexOf("MSIE 6")>-1;
var ie7 = navigator.userAgent.indexOf("MSIE 7")>-1;
var safari = navigator.userAgent.indexOf("Safari")>-1;
var macintosh = navigator.userAgent.indexOf("Macintosh")>-1;
var fireFox = navigator.userAgent.indexOf("Firefox")>-1;

//isSubPage : true - url : ModalDailog
//            false - url: html           
function OpenWindow(url,title,width,height,isSubPage)
{
    try
    {
        var Pagesize = getPageSize();
        var gctOver = null;
        var gctwin = null;
        if($get('GCTOVERLAY') == null)
        {
            gctOver = document.createElement('div');
            document.body.appendChild(gctOver);
            gctwin = document.createElement('div');
            document.body.appendChild(gctwin);                        
        }
        else
        {
            gctOver = $get('GCTOVERLAY');
            gctwin = $get('GCTWINDOW');
        }
        
        $(gctOver).attr('id','GCTOVERLAY').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight});        
        $(gctwin).attr('id','GCTWINDOW').css({position:'absolute',width:width,height:height,border:'1px solid black',backgroundColor:'#d9e1f1',zIndex:160});
            
        gctWindow = 'GCTWINDOW';
        gctOverlay = 'GCTOVERLAY';         
                
        //var _top = Pagesize.height/2 - parseInt(height)/2 + Pagesize.scrollTop;
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        if($.browser.msie && parseFloat($.browser.version) >= 9.0)
        {
            var pagesize = getPageSize();
            _top = (pagesize.height - height)/2 + pagesize.scrollTop;
                     
        }     
        
        //if(url.indexOf('SelectIcon.aspx?') >= 0) // cai nay dung rieng cho trang select icon
        //    _top -= 30;         
        
        var _left = (Pagesize.width - width)/2;        
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 20;  
        
        var headClass = '';
        if(parseInt(width) < 410)
            headClass = 'MessageBox_325px';          
        else if(parseInt(width) >= 410 && parseInt(width) < 450)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) >= 450 && parseInt(width) < 500)
            headClass = 'MessageBox_450px'; 
        else if(parseInt(width) == 500)
            headClass = 'MessageBox_500px';
        else
            headClass = 'MessageBox_788px';
            
        sb.append("<table width='100%' cellSpacing=0 cellPadding=0 border=0><tr width='100%' class='"+headClass+"' style='border-bottom:1px solid black;'>");
        sb.append("<td style='width:"+_Wtd1+"px; padding-left:5px; cursor:move;' class='fontStylePopup_Header'>" + title +"</td>");
        sb.append("<td style='width:20px; text-align:center;' vAlign='middle'><img id='btnclose' onclick='closeGCTWindow(); return false;' src='../images/btn_close_panel.jpg'/></td></tr>");
        sb.append("<tr><td width='100%' colspan=2 >");   
        
        if (isSubPage) // Open ModalDailog
        {
            var _height = parseInt(height) - 24;    
            sb.append("<iframe  id='GCTIFrame' src='"+url+"' scrolling='auto' height='" + _height + "' width='" + width + "' frameborder='0'  />");
        } 
        else
        {
            sb.append(url); // HTML
        }
        
        sb.append("</td></tr></table>");       
        
        $(gctwin).html(sb.toString()).css({top:_top +'px', left: _left + 'px'}).draggable();
                
        // show pop up
        document.getElementById('GCTOVERLAY').style.display = '';
        document.getElementById('GCTWINDOW').style.display = ''; 
        
//        $(window).scroll(function () {
//            try
//            {
//                if(document.documentElement.scrollTop > Pagesize.height) return;
//                $('#GCTWINDOW').css({top:(Pagesize.height - height)/2 + 30 + parseInt(document.documentElement.scrollTop)}); 
//                $('#GCTOVERLAY').css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
//            }catch(e){}
//        });           
   }
    catch(e){}
}
function OpenWindowNew(url,title,width,height)
{
    try
    {
        var Pagesize = getPageSize();
        var gctOver = null;
        var gctwin = null;
        if($get('GCTOVERLAY') == null)
        {
            gctOver = document.createElement('div');
            document.body.appendChild(gctOver);
            gctwin = document.createElement('div');
            document.body.appendChild(gctwin);                        
        }
        else
        {
            gctOver = $get('GCTOVERLAY');
            gctwin = $get('GCTWINDOW');
        }
        
        $(gctOver).attr('id','GCTOVERLAY').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight});
        $(gctwin).attr('id','GCTWINDOW').css({position:'absolute',width:width,height:height,border:'1px solid #000000',backgroundColor:'white',zIndex:160});
            
        gctWindow = 'GCTWINDOW';
        gctOverlay = 'GCTOVERLAY';         
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left = (Pagesize.width - width)/2;        
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 50;
        sb.append("<table width='100%' style='background-color:#E1E7F5;' cellSpacing=0 cellPadding=0 border=0><tr class='GctTitleRow' style='background: url(../images/bg_popup_500.png) repeat-y;height:22px;background-repeat:repeat;'>");
        //sb.append("<td style='border:1px solid red;width:"+_Wtd1+"px'></td>");
        //sb.append("<td style='border:1px solid blue;width:50px'>aaaaa</td>");
        sb.append("<td  style='text-align:left; padding-left:5px;line-height:21px;position:relative;font-size:10.5pt;font-family:arial;font-weight:bold;border-bottom:1px solid #000000'><img src='../images/btn_close_panel.jpg' style='cursor:pointer;position:absolute;right:5px;top:5px;' onClick='closeGCTWindow();'/>"+ title +"</td></tr>");
        sb.append("<tr><td width='100%' colspan=2 style='padding-top:0px;background-color:#E1E7F5'>");  
        
        _height = parseInt(height) - 22 + 'px';
        sb.append("<iframe id='GCTIFrame' style='background-color:#E1E7F5;' src='"+url+"' height='" + _height + "' width='" + width + "' frameborder='0'  />");
        
        sb.append("</td></tr></table>");     
        
        $(window).scroll(function () {
            try
            {
                $(gctwin).css({top:(Pagesize.height - $('#GCTWINDOW').height())/2 + parseInt(document.documentElement.scrollTop)});                 
            }catch(e){}
        }); 
        
        
          var pTop = (Pagesize.height - $('#GCTWINDOW').height())/2 + Pagesize.scrollTop;
        var pLeft = (Pagesize.width - $('#GCTWINDOW').width())/2;   
        $(gctwin).html(sb.toString()).css({top:pTop, left: pLeft}).draggable();
        // show pop up
        document.getElementById('GCTOVERLAY').style.display = '';
        document.getElementById('GCTWINDOW').style.display = '';       
    }
    catch(e){}
}

function OpenWindowDashboard(url,title,width,height)
{
    try
    {
        var Pagesize = getPageSize();
        var gctOver = null;
        var gctwin = null;
        if($get('GCTOVERLAY') == null)
        {
            gctOver = document.createElement('div');
            document.body.appendChild(gctOver);
            gctwin = document.createElement('div');
            document.body.appendChild(gctwin);                        
        }
        else
        {
            gctOver = $get('GCTOVERLAY');
            gctwin = $get('GCTWINDOW');
        }
        
        $(gctOver).attr('id','GCTOVERLAY').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight});
        
        $(gctwin).attr('id','GCTWINDOW').css({position:'absolute',width:width,height:height,border:'2px solid #000000',backgroundColor:'white',zIndex:160});
            
        gctWindow = 'GCTWINDOW';
        gctOverlay = 'GCTOVERLAY';         
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop - 45;//(Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left =(Pagesize.width - width)/2;        
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 50;  
        sb.append("<table width='100%' style='background-color:#E1E7F5;' cellSpacing=0 cellPadding=0 border=0><tr class='GctTitleRow' style='background: url(../images/bg_popup_800.jpg) repeat-y;height:22px;'>");
        //sb.append("<td style='border:1px solid red;width:"+_Wtd1+"px'></td>");
        //sb.append("<td style='border:1px solid blue;width:50px'>aaaaa</td>");
        sb.append("<td  style='text-align:left; padding-left:5px;line-height:22px;position:relative;font-size:10.5pt;font-family:arial;font-weight:bold;'><img src='../images/btn_close_panel.jpg' style='cursor:pointer;position:absolute;right:5px;top:5px;' onClick='closeGCTWindow();'/>FACE SEARCH Dashboards - Detail</td></tr>");
        sb.append("<tr><td width='100%' colspan=2 style='background-color:#E1E7F5'>");  
        
        _height = parseInt(height) - 34 + 'px';
        sb.append("<iframe id='GCTIFrame' style='background-color:#E1E7F5;height:638px' src='"+url+"' height='" + _height + "' width='" + width + "' frameborder='0'  />");
        
        sb.append("</td></tr></table>");       
        
        $(gctwin).html(sb.toString()).css({top:_top + 50, left: _left}).draggable();
        // show pop up
        document.getElementById('GCTOVERLAY').style.display = '';
        document.getElementById('GCTWINDOW').style.display = '';       
    }
    catch(e){}
}


function closeGCTWindow()
{
   try
   {
       if(gctWindow != null)
       {    
            $get(gctOverlay).style.display = 'none';
            $get(gctWindow).style.display = 'none';            
       }
       
       AlertClick();
   }
   catch(e){}
}


function GCTPopupWINDOW()
{
    this.openPopup = OpenPopupWindow;
    this.closePopup = closeGCTPopupWindow ;    
}
// Show pop up
function OpenPopupWindow(html,title,width,height)
{
    try
    {          
        var Pagesize = getPageSize();
        var gctPopupOver = null;
        var gctPopupwin = null;
                
        if(gctPopupOverlay == null)
        {
            gctPopupOver = document.createElement('div');           
            document.body.appendChild(gctPopupOver);
            gctPopupwin = document.createElement('div');
            document.body.appendChild(gctPopupwin);                        
        }
        else
        {            
            gctPopupOver = document.getElementById('GCTPopupOVERLAY');
            gctPopupwin = document.getElementById('GCTPopupWINDOW');
        }

        $(gctPopupOver).attr('id','GCTPopupOVERLAY').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: window.parent.document.body.clientWidth, height: window.parent.document.body.clientHeight,zIndex:170});
        var _h = parseInt(height) + 10;
        
        $(gctPopupwin).attr('id','GCTPopupWINDOW').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({width:width});    
        gctPopupWindow = 'GCTPopupWINDOW';
        gctPopupOverlay = 'GCTPopupOVERLAY';         
        
        var _top = (document.body.clientHeight - height)/2;
        var _left = (document.body.clientWidth - width)/2;        
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 50;  
        
        var headClass = '';
        if(parseInt(width) < 410)
            headClass = 'MessageBox_325px';            
        else if(parseInt(width) >= 410 && parseInt(width) < 450)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) >= 450 && parseInt(width) < 500)
            headClass = 'MessageBox_450px'; 
        else if(parseInt(width) >= 500 && parseInt(width) < 788)
            headClass = 'MessageBox_500px';
        else
            headClass = 'MessageBox_788px';
        sb.append("<table width='100%' cellSpacing=0 cellPadding=0 border=0 style='z-index:200'>");
        sb.append("<tr class='"+headClass+"'><td width='"+_Wtd1+"' style='cursor:move; padding-left:5px;' onmousedown=\"fDragging('GCTPopupWINDOW', event, true, '')\"><span class='fontStylePopup_Header'>" + title +"</span></td>");
        sb.append("<td width='20' style='text-align:right; padding-right:5px;'><img src='../images/btn_close_panel.jpg' onclick='closeGCTPopupWindow(); return false;'/></td></tr>");
        sb.append("<tr><td width='100%' colspan=2 style='padding-top:10px;'>");            
        sb.append(html);
        sb.append("</td></tr></table>");       
                
        $(gctPopupwin).html(sb.toString()).css({top: Pagesize.height/2 - 50 + Pagesize.scrollTop, left: _left});
        
        // show pop up
        $get('GCTPopupOVERLAY').style.display = '';
        $get('GCTPopupWINDOW').style.display = '';
    }
    catch(e){}
}
function closeGCTPopupWindow()
{
   try
   {
        if(gctPopupOverlay != null)
        {    
            $get(gctPopupOverlay).style.display = 'none';
            $get(gctPopupWindow).style.display = 'none';            
        } 
   }
   catch(e){}
}

//Customize alert
// Tao cac button cho popup 
// var opt = [
//         {url:'images/buttons/OK_Normal.png',ImgNomal:'OK_Normal.png',ImgHover:'OK_Hover.png',ImgOff:'OK_Normal.png',fClick:CustomizeAlertClose},
//         {url:'images/buttons/Cancel_Normal.png',ImgNomal:'Cancel_Normal.png',ImgHover:'Cancel_Hover.png',ImgOff:'Cancel_Normal.png',fClick:CustomizeAlertClose}                    
//         ];
//     GCTWindow.message('Report access is restricted.','Confirm',350,120,opt);
function CustomizeAlertOpen(mess,title,width,height,option)
{
    try
    {          
        var Pagesize = getPageSize();                        
        if(cstAlertOver == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left = (Pagesize.width - width)/2;                                                   
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 50;  
        
        // set background cho header cua windown
        var headClass = '';
        if(parseInt(width) < 410)
            headClass = 'MessageBox_325px';   
                     
        else if(parseInt(width) >= 410 && parseInt(width) < 450)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) >= 450 && parseInt(width) < 500)
            headClass = 'MessageBox_450px'; 
            else if(parseInt(width) >= 500 && parseInt(width) < 550)
            headClass = 'MessageBox_500px'; 
        else if(parseInt(width) >= 550 && parseInt(width) < 570)
            headClass = 'MessageBox_550px'; 
        else if(parseInt(width) >= 570 && parseInt(width) < 788)
            headClass = 'MessageBox_570px';                   
        else
            headClass = 'MessageBox_788px';
            
        sb.append("<table width='100%' cellSpacing=0 cellPadding=0 border=0 style='z-index:200;'>");
        sb.append("<tr class='"+headClass+"' valign='middle'><td width='"+_Wtd1+"' style='cursor:move; padding-left:5px;' onmousedown=\"fDragging('pAlertWin', event, true, '')\"><span class='fontStylePopup_Header'>" + title +"</span></td>");        
        sb.append("<td width='20' style='text-align:center;'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        sb.append("<tr><td width='100%' colspan=2 style='font-size:10.5pt;padding-top:20px;padding-left:14px;padding-right:14px;text-align:center;color:#000000'>");            
        sb.append(mess);
        sb.append("</td></tr>");
        
        sb.append("<tr><td id='tdControlButton' width='100%' colspan=2 style='padding-top:15px; text-align:center; height:30px;padding-bottom:15px;' vAlign='middle'>");
                   
        sb.append("</td></tr>");    
        sb.append("</table>");       
                
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:170});                       
        $(cstAlertWin).attr('id','pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({minWidth:width,width:'auto !important',width:width,width:width, minHeight:height,height:'auto !important',height:height,top:_top,left:_left,zIndex:171}).html(sb.toString()); 
        
        $(window).scroll(function () {
            try
            {
                $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)}); 
                $(cstAlertOver).css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
            }catch(e){}
        });        
 		        
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }        
        
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}

//Customize alert
// Tao cac button cho popup 
// var opt = [
//         {url:'images/buttons/OK_Normal.png',ImgNomal:'OK_Normal.png',ImgHover:'OK_Hover.png',ImgOff:'OK_Normal.png',fClick:CustomizeAlertClose},
//         {url:'images/buttons/Cancel_Normal.png',ImgNomal:'Cancel_Normal.png',ImgHover:'Cancel_Hover.png',ImgOff:'Cancel_Normal.png',fClick:CustomizeAlertClose}                    
//         ];
//     GCTWindow.message('Report access is restricted.','Confirm',350,120,opt);
function JOpenPopup(mess,title,width,height,option)
{
    try
    {          
        var Pagesize = getPageSize();                        
        if(document.getElementById('pAlertWin') == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }                                                                                        
        
        // set background cho header cua windown
        var headClass = '';
        if(parseInt(width) <= 325)
            headClass = 'MessageBox_325px';   
                     
        else if(parseInt(width) > 325 && parseInt(width) <= 410)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) > 410 && parseInt(width) <= 450)
            headClass = 'MessageBox_450px'; 
            else if(parseInt(width) > 450 && parseInt(width) <= 500)
            headClass = 'MessageBox_500px'; 
        else if(parseInt(width) > 500 && parseInt(width) <= 550)
            headClass = 'MessageBox_550px'; 
        else if(parseInt(width) > 550 && parseInt(width) <= 570)
            headClass = 'MessageBox_570px';                   
        else
            headClass = 'MessageBox_788px';
            
        var HeadWidth = parseInt(width) - 30; 
        
        var sb = new Sys.StringBuilder(); 
        sb.append("<table width='100%' cellSpacing=0 cellPadding=0 border=0 style='z-index:200;'>");
        sb.append("<tr class='"+headClass+"' valign='middle'><td style='cursor:move; padding-left:10px; width:"+HeadWidth+"px' onmousedown=\"fDragging('pAlertWin', event, true, '')\"><span class='fontStylePopup_Header'>" + title +"</span></td>");        
        sb.append("<td class='j_Close_Button'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        if(title.indexOf('FACE SEARCH - Update Administrator') < 0)
            sb.append("<tr><td width='100%' colspan=2 class='j_Content'>");            
        else
            sb.append("<tr><td width='100%' colspan=2 class='j_ContentEditAdmin'>"); 
        sb.append(mess);
        sb.append("</td></tr>");
        
        sb.append("<tr><td id='tdControlButton' colspan=2 class='j_Button_Control' vAlign='middle'>");
                   
        sb.append("</td></tr>");    
        sb.append("</table>");       
                
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass')
        .css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:170});                       
        $(cstAlertWin).attr('id','pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight')
            .css({ minWidth:width,width:'auto !important',width:width,minHeight:height,height:'auto !important',
            height:height,zIndex:171}).html(sb.toString()); 
                
        $(window).scroll(function () {
            try
            {
                $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)});                 
            }catch(e){}
        });        
 		
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }  
        
        var pTop = (Pagesize.height - $('#pAlertWin').height())/2 + Pagesize.scrollTop;
        var pLeft = (Pagesize.width - $('#pAlertWin').width())/2; 
        
        $(cstAlertWin).css({top:pTop, left:pLeft})        
        
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}

function CustomizeAlertPassOpen(mess,title,width,height,option)
{
    try
    {          
        var Pagesize = getPageSize();                        
        if(cstAlertOver == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left = (Pagesize.width - width)/2;                                                   
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 50;  
        
        // set background cho header cua windown
        var headClass = '';
        if(parseInt(width) < 410)
            headClass = 'MessageBox_325px';            
        else if(parseInt(width) >= 410 && parseInt(width) < 450)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) >= 450 && parseInt(width) < 500)
            headClass = 'MessageBox_450px';
        else if(parseInt(width) >= 500 && parseInt(width) < 550)
            headClass = 'MessageBox_500px'; 
        else if(parseInt(width) >= 550 && parseInt(width) < 570)
            headClass = 'MessageBox_550px'; 
        else if(parseInt(width) >= 570 && parseInt(width) < 788)
            headClass = 'MessageBox_570px'; 
        else
            headClass = 'MessageBox_788px';
            
        sb.append("<table width='100%' cellSpacing=0 cellPadding=0 border=0 style='z-index:200;'>");
        sb.append("<tr class='"+headClass+"' valign='middle'><td width='"+_Wtd1+"' style='cursor:move; padding-left:5px;' onmousedown=\"fDragging('pAlertWin', event, true, '')\"><span class='fontStylePopup_Header'>" + title +"</span></td>");        
        sb.append("<td width='20' style='text-align:center;'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        sb.append("<tr><td width='100%' colspan=2 style='padding-top:20px;text-align:center;color:#000000;font-size:10.5pt;padding-left:15px;padding-right:15px;'>");            
        sb.append(mess);
        sb.append("</td></tr>");
        
        sb.append("<tr><td id='tdControlButton' width='100%' colspan=2 style='padding-top:15px; text-align:center; height:30px;padding-bottom:15px;' vAlign='middle'>");
                   
        sb.append("</td></tr>");    
        sb.append("</table>");       
                
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:170});                       
        $(cstAlertWin).attr('id','pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({minWidth:width,width:'auto !important',width:width,width:width, minHeight:height,height:'auto !important',height:height,top:_top,left:_left,zIndex:171}).html(sb.toString()); 
        
        $(window).scroll(function () {
            try
            {
                $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)}); 
                $(cstAlertOver).css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
            }catch(e){}
        });        
 		        
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }        
        
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}

function CustomizeAlertClose()
{
   try
   {
    
    if(cstAlertOver != null)
    {    
        document.getElementById('pAlertOver').style.display = 'none';        
        document.getElementById('pAlertWin').style.display = 'none';                   
    } 
   }
   catch(e){}
}

function CustomizeAlertOpen_NEW(mess,title,width,height,option)
{
    try
    {            
        var Pagesize = getPageSize();                        
        if(cstAlertOver == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left = (Pagesize.width - width)/2;                                                   
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 25;  
        var iHeight = height-10;
        sb.append("<table cellSpacing=0 cellPadding=0 border=0 style='z-index:10020; width:100%;height:"+iHeight+"px;'>");
        // set background cho header cua windown
        var headClass = '';
        if(parseInt(width) <= 325)
            headClass = 'MessageBox_325px';            
        else if(parseInt(width) > 325 && parseInt(width) <= 410)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) > 410 && parseInt(width) <= 450)
            headClass = 'MessageBox_450px'; 
        else if(parseInt(width) > 450 && parseInt(width) <= 500)
            headClass = 'MessageBox_500px';
        else if(parseInt(width) > 500 && parseInt(width) <= 550)
            headClass = 'MessageBox_550px';
        else
            headClass = 'MessageBox_788px';
        
        sb.append("<tr class="+ headClass +" valign='middle' style=\"width:100%\"><td style='cursor:move;width:"+_Wtd1+"px;'><span style='margin-left:5px;' class='fontStylePopup_Header'>" + title +"</span></td>");        
        sb.append("<td style='text-align:center;width: 24px;' valign='middle'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        sb.append("<tr><td id='bodyContains' width='100%' colspan=2 style='padding:16px 14px 0px;text-align:center;color:#000000;font-size:10.5pt'>"+mess+"</td></tr>");                            
        sb.append("<tr><td id='tdControlButton' width='100%' colspan=2 style='padding-top:11px;padding-bottom:15px; text-align:center; height:30px;' vAlign='middle'></td></tr>");  
        sb.append("</table>");                              
                
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:10009});                       
        $(cstAlertWin).attr('id','pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({minWidth:width,width:'auto !important',width:width,width:width, minHeight:height,height:'auto !important',height:height,top:_top,left:_left,border:'1px solid black',zIndex:10015,backgroundColor:'#D8E1F0'}).html(sb.toString()).draggable();                                  
 		
 		// add buttons        
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }   
        
        $('#btnCloseCustomPanel').click(function(){
            CustomizeAlertClose();
        }); 
        
        // scroll
//         $(window).scroll(function () {
//             try
//             {
//                 $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)}); 
//                 $(cstAlertOver).css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
//             }catch(e){}
//         });        
        // show window
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}

// For Multi Language - Duc An
function CustomizeAlertOpen_Language(mess, title, width, height, option, name, recognize) {
    try {
        var Pagesize = getPageSize();
        if (cstAlertOver == null) {
            cstAlertOver = document.createElement('div');
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);
        }
        else {
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }

        var _top = 0;
        if (recognize == '1')
            _top = (Pagesize.height - height) / 2 + Pagesize.scrollTop - 200;
        else
            _top = (Pagesize.height - height) / 2 + Pagesize.scrollTop;
        
        var _left = (Pagesize.width - width) / 2;

        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 25;
        var iHeight = height - 10;
        sb.append("<table cellSpacing=0 cellPadding=0 border=0 style='z-index:10020; width:100%;height:" + iHeight + "px;'>");
        // set background cho header cua windown
        var headClass = '';
        if (parseInt(width) <= 325)
            headClass = 'MessageBox_325px';
        else if (parseInt(width) > 325 && parseInt(width) <= 410)
            headClass = 'MessageBox_410px';
        else if (parseInt(width) > 410 && parseInt(width) <= 450)
            headClass = 'MessageBox_450px';
        else if (parseInt(width) > 450 && parseInt(width) <= 500)
            headClass = 'MessageBox_500px';
        else if (parseInt(width) > 500 && parseInt(width) <= 550)
            headClass = 'MessageBox_550px';
        else
            headClass = 'MessageBox_788px';

        sb.append("<tr class=" + headClass + " valign='middle' style=\"width:100%\"><td style='cursor:move;width:" + _Wtd1 + "px;'><span style='margin-left:5px;' class='fontStylePopup_Header'>" + title + "</span></td>");
        sb.append("<td style='text-align:center;width: 24px;' valign='middle'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        sb.append("<tr><td id='bodyContains' width='100%' colspan=2 style='padding:16px 14px 0px;text-align:center;color:#000000;font-size:10.5pt'>" + mess + "</td></tr>");
        sb.append("<tr><td id='tdControlButton' width='100%' colspan=2 style='padding-top:11px;padding-bottom:15px; text-align:center; height:30px;' vAlign='middle'></td></tr>");
        sb.append("</table>");

        $(cstAlertOver).attr('id', 'pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({ width: Pagesize.pageWidth, height: Pagesize.pageHeight, zIndex: 10009 });
        $(cstAlertWin).attr('id', 'pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({ minWidth: width, width: 'auto !important', width: width, width: width, minHeight: height, height: 'auto !important', height: height, top: _top, left: _left, border: '1px solid black', zIndex: 10015, backgroundColor: '#D8E1F0' }).html(sb.toString()).draggable();

        // add buttons        
        if (option == null) {
            try {
                var _btnOkCustomizeAlert = document.createElement('input');
                $(_btnOkCustomizeAlert).attr({ 'class': option[i].css, id: 'btnOkCustomizeAlert', 'value': name, type: 'button' }).click(CustomizeAlertClose);
                $('#tdControlButton').append(_btnOkCustomizeAlert);                
            }
            catch (e) { }
        }
        else if (option != null && option.length > 0) {
            try {
                var Ctrl = null;
                for (var i = 0; i < option.length; i++) {
                    Ctrl = document.createElement('input');
                    $(Ctrl).attr({ 'class': option[i].css, id: 'btnControl_' + i, value: option[i].name, type: 'button' }).click(option[i].fClick).css({ marginRight: '5px' });
                    $('#tdControlButton').append(Ctrl);                    
                }
            }
            catch (e) { }
        }

        $('#btnCloseCustomPanel').click(function() {
            CustomizeAlertClose();
        });
        
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';
    }
    catch (e) { }
}

function CustomizeAlertOpen_NotMove(mess, title, width, height, option) {
    try {            
        var Pagesize = getPageSize();                        
        if(cstAlertOver == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left = (Pagesize.width - width)/2;                                                   
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 25;  
        sb.append("<table cellSpacing=0 cellPadding=0 border=0 style='z-index:200; width:100%;'>");
        // set background cho header cua windown
        var headClass = '';
        
        if(parseInt(width) <= 325)
            headClass = 'MessageBox_325px';            
        else if(parseInt(width) > 325 && parseInt(width) <= 410)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) > 410 && parseInt(width) <= 450)
            headClass = 'MessageBox_450px'; 
        else if(parseInt(width) > 450 && parseInt(width) <= 500)
            headClass = 'MessageBox_500px';
        else if(parseInt(width) > 500 && parseInt(width) <= 550)
            headClass = 'MessageBox_550px';
        else
            headClass = 'MessageBox_788px';
        
        sb.append("<tr class="+ headClass +" valign='middle' style=\"width:100%\"><td style='width:"+_Wtd1+"px;'><span style='margin-left:5px;' class='fontStylePopup_Header'>" + title +"</span></td>");        
        sb.append("<td style='text-align:center;width: 20px;' valign='middle'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        sb.append("<tr><td id='bodyContains' width='100%' colspan=2 style='padding-top:20px;text-align:center;color:#000000;font-size:10.5pt'>"+mess+"</td></tr>");                            
        sb.append("<tr><td id='tdControlButton' width='100%' colspan=2 style='padding-top:15px;padding-bottom:15px; text-align:center; height:30px;' vAlign='middle'></td></tr>");  
        sb.append("</table>");                              
                
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:170});                       
        $(cstAlertWin).attr('id','pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({minWidth:width,width:'auto !important',width:width,width:width, minHeight:height,height:'auto !important',height:height,top:_top,left:_left,border:'1px solid black',zIndex:171,backgroundColor:'#D8E1F0'}).html(sb.toString());                                  
 		
 		// add buttons        
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }   
        
        $('#btnCloseCustomPanel').click(function(){
            CustomizeAlertClose();
        }); 
        
        // scroll
        $(window).scroll(function () {
            try
            {
                $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)}); 
                $(cstAlertOver).css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
            }catch(e){}
        });        
        // show window
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}
   
function getPageSize()
{
    var iebody = document.compatMode && document.compatMode != "BackCompat"
        ? document.documentElement : document.body;   
    var b = document.body;
    var xScroll = (window.innerWidth && window.scrollMaxX)
            ? window.innerWidth + window.scrollMaxX :
                (b.scrollWidth > b.offsetWidth ? b.scrollWidth : b.offsetWidth),
        yScroll = (window.innerHeight && window.scrollMaxY)
            ? window.innerHeight + window.scrollMaxY :
                (b.scrollHeight > b.offsetHeight ? b.scrollHeight : b.offsetHeight),
        pageWidth = ie || ie6 || ie7 ? iebody.scrollWidth :
            (document.documentElement.clientWidth || self.innerWidth);
          pageHeight = ie || ie6 || ie7 ? iebody.clientHeight :
            (document.documentElement.clientHeight || self.innerHeight);
   
    var width = ie || ie6 || ie7 ? iebody.clientWidth :
            (document.documentElement.clientWidth || self.innerWidth),
        height = ie || ie6 || ie7 ? iebody.clientHeight : self.innerHeight;
   
    return {
        pageWidth: xScroll < pageWidth ? pageWidth : xScroll,
        pageHeight: yScroll < pageHeight ? pageHeight : yScroll,
        width: width,
        height: height,       
        scrollLeft: ie || ie6 || ie7 ? iebody.scrollLeft : pageXOffset,
        scrollTop: ie || ie6 || ie7 ? iebody.scrollTop : pageYOffset
    }
}

/// html for alert
var learnAlertWind = null;
var learnAlertOverlay = null;
var LearnAlertWindow = new LearnAlertWINDOW();

function LearnAlertWINDOW()
{
    this.openLearnAlert = OpenLearnAlertWindow;
    this.closeLearnAlert = CloseLearnAlertWindow; 
}
function OpenLearnAlertWindow(html,title,width,height,buttoncontrol)
{
    try
    {              
        var Pagesize = getPageSize();
        var _learnAlertOver = null;
        var _learnAlertWin = null;
                
        if(learnAlertOverlay == null)
        {
            _learnAlertOver = document.createElement('div');           
            document.body.appendChild(_learnAlertOver);
            _learnAlertWin = document.createElement('div');
            document.body.appendChild(_learnAlertWin);                        
        }
        else
        {            
            _learnAlertOver = document.getElementById('LEARNALERTOVERLAY');
            _learnAlertWin = document.getElementById('LEARNALERTWINDOW');
        }

        $(_learnAlertOver).attr('id','LEARNALERTOVERLAY').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:200});        
        
        $(_learnAlertWin).attr('id','LEARNALERTWINDOW').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({width:width,height:height,border:'1px solid black',zIndex:201});    
        learnAlertWind = 'LEARNALERTWINDOW';
        learnAlertOverlay = 'LEARNALERTOVERLAY';         
        
        var _top = (Pagesize.height - height)/2;
        var _left = (Pagesize.width - width)/2;        
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 25;  
        
        var headClass = '';
        if(parseInt(width) < 410)
            headClass = 'MessageBox_325px';            
        else if(parseInt(width) >= 410 && parseInt(width) < 450)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) >= 450 && parseInt(width) < 500)
            headClass = 'MessageBox_450px'; 
        else if(parseInt(width) >= 500 && parseInt(width) < 788)
            headClass = 'MessageBox_500px';
        else
            headClass = 'MessageBox_788px';
            
        sb.append("<table width='100%' cellSpacing=0 cellPadding=0>");
        sb.append("<tr class="+ headClass +" valign='middle'><td style='cursor:move;width:"+_Wtd1+"px;'><span style='margin-left:5px;' class='fontStylePopup_Header'>" + title +"</span></td>");                
        
        sb.append("<td style='text-align:center; width:20px;'><img id='learnalertclose' src='../images/btn_close_panel.jpg'/></td></tr>");
        var _heightContent = parseInt(height) -  50;
        sb.append("<tr><td width='100%' style='font-size:10.5pt;color:#000000;padding:10px' height='"+_heightContent+"' colspan='2' align='center' valign='middle'>");            
        sb.append(html);
        sb.append("</td></tr>");  
        sb.append("<tr><td style='padding-bottom:15px;' colspan='2' align='center' valign='middle'>"); 
        if(buttoncontrol == '' || buttoncontrol == null)            
            sb.append("<img id='btnOKLearnAlert' src='../images/buttons/OK_Normal.png'/>");     
        else
            sb.append(buttoncontrol)  
                       
        sb.append("</td></tr>");
        sb.append("</table>");    
                
        $(_learnAlertWin).html(sb.toString()).css({top: Pagesize.height/2 - 50 + Pagesize.scrollTop, left: _left}).draggable();
        
        try
        {
            $('#btnOKLearnAlert').click(function () {
                CloseLearnAlertWindow();
            });
            $('#learnalertclose').click(function () {
                CloseLearnAlertWindow();
            })
        }
        catch(e){}
        // show pop up        

        $get('LEARNALERTOVERLAY').style.display = '';
        $get('LEARNALERTWINDOW').style.display = '';
        
        try
        {
            if (document.getElementById('btnOKLearnAlert') != null) {
                $('#btnOKLearnAlert').hover(                
                    function () {                
                        $(this).attr('src','../images/buttons/OK_Hover.png')
                    },
                    function () {
                        $(this).attr('src','../images/buttons/OK_Normal.png')
                    }
                );
            }            
        }catch(e){}
        
        $('#learnalertclose').hover(                
            function () {                
                $(this).attr('src','../images/btn_close_panel.jpg')
            },
            function () {
                $(this).attr('src','../images/btn_close_panel.jpg')
            }
        ).mousedown(function () {
            $(this).attr('src','../images/btn_close_panel.jpg')
        });
            
        // scroll bar                
        $(window).scroll(function () {
            try
            {         
                $(_learnAlertWin).css({top:parseInt(_top) + parseInt(document.documentElement.scrollTop)}); 
                $(_learnAlertOver).css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
            }catch(e){}
        });
        
    }
    catch(e){}
}
function CloseLearnAlertWindow()
{
   try
   {
        if(learnAlertOverlay != null)
        {    
            $('#LEARNALERTOVERLAY').hide();
            $('#LEARNALERTWINDOW').hide();
            //$('#LEARNALERTWINDOW').hide('explode',500);                 
        } 
   }
   catch(e){}
}

function GetFormAddress(address) 
{    
    try
    {
        var array = eval('(' + address + ')');              
    
        var html = "<span style=\"font-weight:bold;\" class=\"fontStylePopup_13\">Address Information</span>";
        html += "<table style=\"margin-top:10px;color:#000000\" class=\"fontStylePopup_10\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
        
        html += "<tr>";
        html += "<td style=\"width:31%; padding-left:10px;text-align:left;\">Nearest Address:</td>";
        html += String.format("<td style=\"width:50%;text-align:left;\">&nbsp;{0}</td>",array.address1);
        html += "</tr>";
        
        html += "<tr>";
        html += "<td></td>";
        html += String.format("<td style=\"text-align:left;\">&nbsp;{0}</td>",array.address2);
        html += "</tr>";
        
        html += "<tr>";
        html += "<td style=\"padding-left:10px;text-align:left; padding-top:10px;\">Nearest Intersection:</td>";
        html += String.format("<td style=\"text-align:left;  padding-top:10px;\">&nbsp;{0}</td>",array.intersection1);
        html += "</tr>";
        
        html += "<tr>";
        html += "<td></td>";
        html += String.format("<td style=\"text-align:left;\">&nbsp;{0}</td>",array.intersection2);
        html += "</tr>";
                
        html += "<tr>";
        html += "<td style=\"padding-left:10px;text-align:left; padding-top:10px;\">Approximate distance</td>";
        html += "<td style=\"padding-top:10px;\"></td>";
        html += "</tr>";
        
        html += "<tr>";
        html += "<td style=\"padding-left:10px;text-align:left;\">from person to address:</td>";
        html += String.format("<td style=\"text-align:left;\">&nbsp;{0}</td>",array.distiance);
        html += "</tr>";
        
        html += "</table>";
        
        html += "<div style=\"width:100%; float:left;padding-left:10px; padding-top:10px;font-weight:bold; text-align:left;\">"
        html += "<p style=\"font-size:10pt\" class=\"fontStylePopup_9\"> Disclaimer: The address listed above is only an estimate.</p></div>";
        
        return html;
    }
    catch(e){}
}

function GetFormGPSCoordinates() 
{    
    try
    {                   
        var html = "<table style=\"margin-top:0px;color:#000000\" class=\"fontStylePopup_10\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
        
        html += "<tr>";
        html += "<td style=\"width:32%;text-align:left;\">Nearest Address:</td>";
        html +="<td style=\"width:50%;text-align:left;font-weight:bold;font-size:17.5pt;line-height:20px;\" class=\"fontStylePopup_13\">&nbsp;GPS Coordinates</td>";
        html += "</tr>";
        
        html += "<tr>";
        html += "<td style=\"text-align:left; padding-top:10px;\">Nearest Intersection:</td>";
        html += "<td style=\"text-align:left;  padding-top:10px;font-weight:bold;font-size:17.5pt;padding-left:20px;padding-bottom:8px;\"  class=\"fontStylePopup_13\">&nbsp;Not Available</td>";
        html += "</tr>";

        html += "</table>";
        
        html += "<div style=\"width:100%; float:left; padding-top:10px;font-weight:bold; text-align:left;\">"
        html += "<p style=\"font-size:10pt\" class=\"fontStylePopup_9\"> Disclaimer: The address listed above is ONLY an estimate.</p></div>";
        
        return html;
    }
    catch(e){}
}

function NoAccessWindow() 
{    
    var mess = new Sys.StringBuilder();
    mess.append("<p><b style='font-size:13.5pt;color:#000000;font-family:arial;'>No Access</b><p>");
    mess.append("<p style='margin-top:10px;'><span style='font-size:10.5pt;color:#000000;font-family:arial;'>This is a restricted feature and is not</span></p>");
    mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000;font-family:arial;'>currently accessible. Please contact your</span></p>");
    mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000;font-family:arial;'>Administrator or Agency Manager.</span></p>");
    GCTWindow.MessageBox(mess.toString(),'FACE SEARCH - Access Restriction',325,190,null);
}

function NoAccessWindow_SharedData(bShared) 
{    
    var mess = new Sys.StringBuilder();
    if (bShared) // thang nay dung cho shared data
    {
        mess.append("<p><b style='font-size:13.5pt;color:#000000'>Warning - Shared Data</b><p>");
        mess.append("<p style='margin-top:10px;'><span style='font-size:10.5pt;color:#000000'>This record does not belong to you</span></p>");
        mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000'>- This record is shared from another Agency -</span></p>");
        mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000'>and therefore you may not Edit or Delete the record.</span></p>");
        
        GCTWindow.MessageBox(mess.toString(),'FACE SEARCH - Shared Data',380,190,null);
    }
    else // thang nay dung cho private data
    {
        mess.append("<p><b style='font-size:13.5pt;color:#000000'>Warning - Private Data</b><p>");
        mess.append("<p style='margin-top:10px;'><span style='font-size:10.5pt;color:#000000'>This record does not belong to you</span></p>");
        mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000'>- Private Data provided by Vigilant Video -</span></p>");
        mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000'>and therefore you may not Edit or Delete the record.</span></p>");
        
        GCTWindow.jWindow(mess.toString(),'FACE SEARCH - Private Data',380,190,null);
    }        
}

function NoAccessWindow_SharedFromLinkServer() 
{
    var mess = new Sys.StringBuilder();
    mess.append("<p><b style='font-size:13.5pt;color:#000000'>Warning - Shared Data</b><p>");
    mess.append("<p style='margin-top:10px;'><span style='font-size:10.5pt;color:#000000'>This record does not belong to you</span></p>");
    mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000'>- This record is shared from Link Server -</span></p>");
    mess.append("<p style='margin-top:5px;'><span style='font-size:10.5pt;color:#000000'>and therefore you may not Edit or Delete the record.</span></p>");
    
    GCTWindow.MessageBox(mess.toString(),'FACE SEARCH - Shared Data',380,190,null);
}

function GotoPage(page)
{ 
    var url = this.location.href;                        
    url = url.substr(0,url.lastIndexOf("/") + 1) + page;
    
    this.location = url;
}
function CustomizeAlertNoRecords(mess,title,width,height,option)
{
    try
    {            
        var Pagesize = getPageSize();                        
        if(cstAlertOver == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }
        
        var _top = (Pagesize.height - height)/2 + Pagesize.scrollTop;
        var _left = (Pagesize.width - width)/2;                                                   
        
        var sb = new Sys.StringBuilder();
        var _Wtd1 = parseInt(width) - 25;  
        
        sb.append("<table cellSpacing=0 cellPadding=0 border=0 style='z-index:10020; width:100%;height:"+height+"px;'>");
        // set background cho header cua windown
        var headClass = 'MessageBox_title';
        /*if(parseInt(width) <= 325)
            headClass = 'MessageBox_325px';            
        else if(parseInt(width) > 325 && parseInt(width) <= 410)
            headClass = 'MessageBox_410px'; 
        else if(parseInt(width) > 410 && parseInt(width) <= 450)
            headClass = 'MessageBox_450px'; 
        else if(parseInt(width) > 450 && parseInt(width) <= 500)
            headClass = 'MessageBox_500px';
        else if(parseInt(width) > 500 && parseInt(width) <= 550)
            headClass = 'MessageBox_550px';
        else
            headClass = 'MessageBox_788px';*/
        
        sb.append("<tr class="+ headClass +" valign='middle' style=\"width:100%; background-color:#7A72AE\"><td style='cursor:move;width:"+_Wtd1+"px;'><span style='margin-left:5px;' class='fontStylePopup_Header'>" + title +"</span></td>");        
        sb.append("<td style='text-align:center;width: 24px;' valign='middle'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></td></tr>");
        sb.append("<tr><td id='bodyContains' width='100%' colspan=2 style='padding-left: 20px;padding-right:20px;padding-top:20px;text-align:center;color:#000000;font-size:10.5pt'>"+mess+"</td></tr>");                            
        sb.append("<tr><td id='tdControlButton' width='100%' colspan=2 style='padding-bottom:20px;padding-top:18px; text-align:center;' vAlign='middle'></td></tr>");  
        sb.append("</table>");                              
                
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass').css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:10009});                       
        $(cstAlertWin).attr('id','pAlertWin').removeClass('gctPopupHeight').addClass('gctPopupHeight').css({minWidth:width,width:'auto !important',width:width,width:width, minHeight:height,height:'auto !important',height:height,top:_top,left:_left,border:'1px solid black',zIndex:10015,backgroundColor:'#D8E1F0'}).html(sb.toString()).draggable();                                  
 		
 		// add buttons        
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }   
        
        $('#btnCloseCustomPanel').click(function(){
            CustomizeAlertClose();
        }); 
        
        // scroll
//         $(window).scroll(function () {
//             try
//             {
//                 $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)}); 
//                 $(cstAlertOver).css({height:Pagesize.pageHeight + parseInt(document.documentElement.scrollTop) +'px'});
//             }catch(e){}
//         });        
        // show window
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}

function AlertNoRecordFoundHot(mess,title,width,height)
{
    //There are no Agency records.
    var alert = String.format("<p style=\"font-size:10.5pt;color:#000000\">{0}</p>",mess);   
    GCTWindow.MessageBoxNoRecord(alert,'FACE SEARCH - ' + title,width,height,null);
}   


// show thong bao khi search k co record
function AlertNoRecordFound(mess,title)
{
    //There are no Agency records.
    var alert = String.format("<p style=\"font-size:10.5pt;color:#000000\">{0}</p>",mess);   
     
    if(mess.length <= 50)
        GCTWindow.MessageBox(alert,'FACE SEARCH - ' + title,325,110,null);
    else    
        GCTWindow.MessageBox(alert,'FACE SEARCH - ' + title,410,110,null);
}   

function JOpenPopup_Wrap(mess,title,option)
{
    try
    {          
       
        var Pagesize = getPageSize();                        
        if(document.getElementById('pAlertWin') == null)
        {
            cstAlertOver = document.createElement('div');           
            document.body.appendChild(cstAlertOver);
            cstAlertWin = document.createElement('div');
            document.body.appendChild(cstAlertWin);                        
        }
        else
        {            
            cstAlertOver = document.getElementById('pAlertOver');
            cstAlertWin = document.getElementById('pAlertWin');
        }                                                                                        
        
        
        
        var sb = new Sys.StringBuilder(); 
        sb.append("<div class='Popup_Wrap'>");
        sb.append("<h3 class='MessageBox_title' onmousedown=\"fDragging('pAlertWin', event, true, '')\"><span class='fontStylePopup_Header'>" + title +"</span></h3>");        
        sb.append("<a class='j_Close_Button'><img id='btnCloseCustomPanel' src='../images/btn_close_panel.jpg' onclick='CustomizeAlertClose(); return false;' /></a>");
        sb.append("<div class='j_Content'>");            
        sb.append(mess);
        sb.append("</div>");
        
        sb.append("<div id='tdControlButton' class='j_Div_Button_Control'></div>");
                   
        sb.append("</div>");    
      
        
        $(cstAlertOver).attr('id','pAlertOver').removeClass('GctOverLayClass').addClass('GctOverLayClass')
        .css({width: Pagesize.pageWidth, height: Pagesize.pageHeight,zIndex:170});   
        
        $(cstAlertWin).attr('id','pAlertWin').html(sb.toString()).removeClass('gctPopupHeight').addClass('gctPopupHeight');                    
                                   
               
        $(window).scroll(function () {
            try
            {
                $(cstAlertWin).css({top:(Pagesize.height - height)/2 + parseInt(document.documentElement.scrollTop)});                 
            }catch(e){}
        });        
 		
        if(option == null)
        {
            try
            {
                var _btnOkCustomizeAlert = document.createElement('IMG');
                $(_btnOkCustomizeAlert).attr({src:'../images/buttons/OK_Normal.png',id:'btnOkCustomizeAlert'}).click(CustomizeAlertClose);                
                $('#tdControlButton').append(_btnOkCustomizeAlert);
                setImageButtonStyle(_btnOkCustomizeAlert.id,"OK_normal.png","OK_hover.png","OK_hover.png");    
            }
            catch(e){}            
        } 
        else if(option != null && option.length > 0)
        {
            try
            {
                var Ctrl = null;
                for(var i=0; i < option.length; i++)
                {
                    Ctrl = document.createElement('IMG');
                    $(Ctrl).attr({src: option[i].url , id:'btnImgControl_'+i}).click(option[i].fClick).css({marginRight:'5px'});
                    $('#tdControlButton').append(Ctrl);
                    setImageButtonStyle(Ctrl.id,option[i].ImgNomal,option[i].ImgHover,option[i].ImgOff);
                }
            }
            catch(e){}
        }  
        
        var pTop = (Pagesize.height - $('#pAlertWin').height())/2 + Pagesize.scrollTop;
        var pLeft = (Pagesize.width - $('#pAlertWin').width())/2; 
        
        $(cstAlertWin).css({top:pTop, left:pLeft})        
        
        $get('pAlertOver').style.display = '';
        $get('pAlertWin').style.display = '';       
    }
    catch(e){}
}