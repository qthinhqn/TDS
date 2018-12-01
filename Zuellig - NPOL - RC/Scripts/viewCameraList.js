function Ajax_GetList() {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:18968/test/getCameraList.aspx',
        dataType: 'html',
         success: function(data) {
         ParseCameraList(data);
        },
        error: function(jqXHR, status) {
        alert("Failed to load list" + status + jqXHR);
        }
    });
}
function ParseCameraList(xml) {
    xmlDoc = $.parseXML(xml);
    $xml = $(xmlDoc);

    $CameraName = $xml.find("Camera > Name");

    var camlist = '';
    for (var i = 0; i < $CameraName.length; i++) {

        $Name = $CameraName[i];
        if ($Name.tagName == 'Name') {


            camlist += $Name.textContent + '</br>';
        }
    }


    $('#div_cameralist').html(camlist);

}