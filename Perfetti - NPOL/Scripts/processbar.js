
function OpenProcessing(func) {
    var options = {
        bgColor: '#fff',
        duration: 0,
        opacity: 0.1,
        cancelfunc: func
    }
    loader01 = new InitProcessing(jQuery("#showprocessing"), options);

    return loader01;
}

function CloseProcessing() {    
    if (loader01)
        loader01.remove();
}


function InitProcessing(el, options) {
    
    // Becomes this.options
    var defaults = {
        bgColor: '#fff',
        duration: 800,
        opacity: 0.7,
        classOveride: false,
        cancelfunc: 'CloseProcessing'
    }
    
    this.options = jQuery.extend(defaults, options);
    
    this.container = $(el);

    this.init = function() {

        var container = this.container;

        // Delete any other loaders
        this.remove();
        // Create the overlay

        var page = getPageSize();
        var overlay = $('<div></div>').css({
            'background-color': this.options.bgColor,
            'opacity': this.options.opacity,
            'width': page.pageWidth - 0 + "px",
            'height': page.pageHeight - 0 + "px",
            'position': 'absolute',
            'top': '0px',
            'left': '0px',
            'z-index': 8888
        }).addClass('ajax_overlay');

        // insert overlay and loader into DOM

        var top = page.height / 2 - 50 + page.scrollTop;
        var left = parseInt(page.pageWidth) / 2 - 175 + "px";

        var html = '<div class="modalPopup" style="width: 350px; padding: 10px; position: absolute; z-index: 9999">' +
            '<div style="position: relative; top: 0%; text-align: center; border: solid 1px black; background-color: White; padding-left: 30px; padding-right: 30px; padding-top: 5px; padding-bottom: 5px;">' +
            '<p> <span>Processing...</span></p>' +
            '<br />' +
            '<p><img src="../Images/loading2.gif" align="middle" style="height:20px;width:20px;border-width:0px;" /></p>' +
            '<br />' +
            '<p><input type="submit" value="Cancel" onclick="' + this.options.cancelfunc + ';return false;" id="btnAbort" class="button100" /></p>' +
            '</div>';

        var processform = $(html);
        processform.css({ top: top, left: left });
        processform.addClass('ajax_overlay');

        // scroll
        window.onscroll = function() {
            processform.css({ top: page.height / 2 - 50 + parseInt(document.documentElement.scrollTop) });
        }

        container.append(overlay);

        // on/off effect
        if (this.options.duration > 0) {
            container.append(
				processform
			).fadeIn(this.options.duration);
        }
        else {
            container.append(
				processform
			);
        }
    };

    this.remove = function() {
        var overlay = this.container.children(".ajax_overlay");
        if (overlay.length) {

            // on/off effect
            if (this.options.duration > 0) {
                overlay.fadeOut(this.options.classOveride, function() {
                    overlay.remove();
                });
            }
            else {
                overlay.remove();
            }
            
        }
    }

    this.init();
}	

