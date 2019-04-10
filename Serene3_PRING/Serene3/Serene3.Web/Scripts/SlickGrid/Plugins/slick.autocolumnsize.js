(function ($) {

    $.extend(true, window, {
        "Slick": {
            "AutoColumnSize": AutoColumnSize
        }
    });

    function AutoColumnSize(initialAutosize) {

        var grid, $container, context,
            keyCodes = {
                'A': 65
            };

        function init(_grid) {
            grid = _grid;
            //maxWidth = maxWidth || 200;
            maxwidth = 200;

            $container = $(grid.getContainerNode());
            $container.on("dblclick.autosize", ".slick-resizable-handle", reSizeColumn);
            $container.keydown(handleControlKeys);

            context = document.createElement("canvas").getContext("2d");

            if (initialAutosize) {
                $container.ready(resizeAllColumns());
            }
        }

        function destroy() {
            $container.off();
        }

        function handleControlKeys(event) {
            if (event.ctrlKey && event.shiftKey && event.keyCode === keyCodes.A) {
                resizeAllColumns();
            }
        }

        function resizeAllColumns() {

            // *** John Ranger 2017-02-12 added in order to make this plugin work with current serenity version (2.9.4). Somehow it takes some time until all data is loaded in the grid - so we have to make sure that the data is there before we try to find out the max width of each column ***
            var data = grid.getData();
            data = data.getItems();
            if (data.length > 0) {
                var elHeaders = $container.find(".slick-header-column");
                var allColumns = grid.getColumns();
                elHeaders.each(function (index, el) {
                    var columnDef = $(el).data('column');
                    var headerWidth = getElementWidth(el);
                    var colIndex = grid.getColumnIndex(columnDef.id);
                    var column = allColumns[colIndex];
                    var autoSizeWidth = Math.max(headerWidth, getMaxColumnTextWidth(columnDef, colIndex)) + 1;

                    // *** John Ranger 2016-03-23: Remarked as this causes some problems with some columns ***
                    //autoSizeWidth = Math.min(maxWidth, autoSizeWidth);

                    column.width = autoSizeWidth;
                });
                grid.setColumns(allColumns);
                grid.onColumnsResized.notify();
            }   // *** John Ranger 2017-02-12 added in order to make this plugin work with current serenity version (2.9.4). Somehow it takes some time until all data is loaded in the grid - so we have to make sure that the data is there before we try to find out the max width of each column ***
            else {
                setTimeout(resizeAllColumns, 50);
            }
        }



        function reSizeColumn(e) {
            var headerEl = $(e.currentTarget).closest('.slick-header-column');
            var columnDef = headerEl.data('column');

            if (!columnDef || !columnDef.resizable) {
                return;
            }

            e.preventDefault();
            e.stopPropagation();

            var headerWidth = getElementWidth(headerEl[0]);
            var colIndex = grid.getColumnIndex(columnDef.id);
            var allColumns = grid.getColumns();

            var column = allColumns[colIndex];

            var autoSizeWidth = Math.max(headerWidth, getMaxColumnTextWidth(columnDef, colIndex)) + 1;

            if (autoSizeWidth !== column.width) {
                column.width = autoSizeWidth;
                grid.setColumns(allColumns);
                grid.onColumnsResized.notify();
            }
        }

        function getMaxColumnTextWidth(columnDef, colIndex) {

            var texts = [];
            var rowEl = createRow(columnDef);

            var data = grid.getData();

            // *** John Ranger 2016-03-23: Block remarked as this causes the plugin not to work within serenity framework ***
            //if (Slick.Data && data instanceof Slick.Data.DataView) {
            //    alert('jojo in 2.5');
            //    data = data.getItems();
            //}

            data = data.getItems(); // *** John Ranger 2017-02-09 added in order to make this plugin work with current serenity version (2.9.4) ***

            //alert(data.length);
            for (var i = 0; i < data.length; i++) {
                texts.push(data[i][columnDef.field]);
            }
            var maxWidth = getMaxWidth(texts, columnDef, colIndex, data, rowEl);    // *** Using new function to directly get max width without running over template mechanism (which does not work anymore) ***
            deleteRow(rowEl);

            maxWidth = maxWidth + 15;   // *** Additional space for better reading and to accomodate additional little space used by diverse invisible objects - adjust if needed ***
            return maxWidth;
        }


        function getMaxWidth(texts, columnDef, colIndex, data, rowEl) {
            var max = 0;
            var formatFun = columnDef.formatter;
            $(texts).each(function (index, text) {
                var template;
                if (formatFun) {
                    template = $("<span>" + formatFun(index, colIndex, text, columnDef, data) + "</span>");
                    text = template.text() || text;
                }
                var length = text ? getElementWidthUsingCanvas(rowEl, text) : 0;

                if (length > max) {
                    max = length;
                }
            });

            return max;
        }

        function createRow(columnDef) {
            var rowEl = $('<div class="slick-row"><div class="slick-cell"></div></div>');
            rowEl.find(".slick-cell").css({
                "visibility": "hidden",
                "text-overflow": "initial",
                "white-space": "nowrap"
            });
            var gridCanvas = $container.find(".grid-canvas");
            $(gridCanvas).append(rowEl);
            return rowEl;
        }

        function deleteRow(rowEl) {
            $(rowEl).remove();
        }

        function getElementWidth(element) {
            var width, clone = element.cloneNode(true);
            clone.style.cssText = 'position: absolute; visibility: hidden;right: auto;text-overflow: initial;white-space: nowrap;';
            element.parentNode.insertBefore(clone, element);
            width = clone.offsetWidth;
            clone.parentNode.removeChild(clone);
            return width;
        }

        function getElementWidthUsingCanvas(element, text) {
            context.font = element.css("font-size") + " " + element.css("font-family");
            var metrics = context.measureText(text);
            return metrics.width;
        }

        return {
            init: init,
            resizeAllColumns: resizeAllColumns,
            destroy: destroy
        };
    }
}(jQuery));