function OnAllCheckedChanged(s, e) {
    grid.PerformCallback(s.GetChecked());
}

function OnPageCheckedChanged(s, e) {
    var indexes = grid.cpIndexesUnselected;
    var topVisibleIndex = grid.GetTopVisibleIndex();
    if (s.GetChecked()) {
        //Select All Rows On Page();
        for (var i = topVisibleIndex; i < topVisibleIndex + grid.cpPageSize; i++) {
            if (indexes.indexOf(i) == -1)
                grid.SelectRowOnPage(i, true);
        }
    }
    else
        //Deselect All Rows On Page();
        for (var i = topVisibleIndex; i < topVisibleIndex + grid.cpPageSize; i++) {
            if (indexes.indexOf(i) == -1)
                grid.SelectRowOnPage(i, false);
        }
}

function setGridHeaderCheckboxes(s, e) {
    //cbAll
    var indexes = grid.cpIndexesSelected;
    cbAll.SetChecked(s.GetSelectedRowCount() == Object.size(indexes));

    //cbPage
    var allEnabledRowsOnPageSelected = true;
    var indexes = grid.cpIndexesUnselected;
    var topVisibleIndex = grid.GetTopVisibleIndex();
    for (var i = topVisibleIndex; i < topVisibleIndex + grid.cpPageSize; i++) {
        if (indexes.indexOf(i) == -1)
            if (!grid.IsRowSelectedOnPage(i)) allEnabledRowsOnPageSelected = false;
    }
    cbPage.SetChecked(allEnabledRowsOnPageSelected);
}

function OnGridEndCallback(s, e) {
    setGridHeaderCheckboxes(s, e);
}

function OnGridSelectionChanged(s, e) {
    setGridHeaderCheckboxes(s, e);
}

Object.size = function (obj) {
    var size = 0, key;
    for (key in obj) {
        if (obj.hasOwnProperty(key)) size++;
    }
    return size;
};