  
  function Ajax_GetProbeList() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:18968/test/getProbeList.aspx',
        dataType: 'html',
         success: function(data) {
 ParseProbeList(data)          
        },
        error: function(jqXHR, status) {
            //alert("Failed to load list" + status + jqXHR);
        }
    });
}

   /*$.ajax({
        type: 'GET',
        url: 'http://localhost:3372/FSWservice/API/getProbeList.aspx',
        data: '',
        dataType: 'xml',
        beforeSend: function () {

        },
        success: function (data) {
            //var value;
            //    value=res;
            ParseProbeList(data);
            //   alert(res);


        },
        error: function () {

        }
    });
}*/
/*String.prototype.format = function (args) {
			var str = this;
			return str.replace(String.prototype.format.regex, function(item) {
				var intVal = parseInt(item.substring(1, item.length - 1));
				var replace;
				if (intVal >= 0) {
					replace = args[intVal];
				} else if (intVal === -1) {
					replace = "{";
				} else if (intVal === -2) {
					replace = "}";
				} else {
					replace = "";
				}
				return replace;
			});
		};
        */




function ParseProbeList(xml) {

    //String.prototype.format.regex = new RegExp("{-?[0-9]+}", "g");
    var tas_td =
        '<tr align="center" style="font-weight: normal; font-style: normal; text-decoration: none;">'

            + '<td style="background-color:white;">{0}</td>' // 
            + '<td style="background-color:white;">{1}</td>' //   
            + '<td style="background-color:white;">{2}</td>' // 
            + '<td style="background-color:white;">{3}</td>' //  
            + '<td style="background-color:white;">{4}</td>' //  
            + '<td style="background-color:white;">{5}</td>' //  


        + '</tr>'

 
    xmlDoc = $.parseXML(xml);
    $xml = $(xmlDoc);
    $ProbeInfo = $xml.find("Probe");
   
 

    var problist = '<table style="background-color:#CC9966"><td style="background-color:white;"><div style="width:100%; background-color:#003399;font-size:large" align="center" ><font  style="color:#CCCCFF;"><center><b>probe</b></center></font></div></td><td style="background-color:white;"><div style="width:100%; background-color:#003399;font-size:large" align="center" ><font  style="color:#CCCCFF;"><center><b>Result</b></center></font></div></td><td style="background-color:white;"><div style="width:100%; background-color:#003399;font-size:large" align="center" ><font  style="color:#CCCCFF;"><center><b>Score</b></center></font></div></td><td style="background-color:white;"><div style="width:100%; background-color:#003399;font-size:large" align="center" ><font  style="color:#CCCCFF;"><center><b>FullName</b></center></font></div></td><td style="background-color:white;"><div style="width:100%; background-color:#003399;font-size:large" align="center" ><font  style="color:#CCCCFF;"><center><b>Verify</b></center></font></div></td><td style="background-color:white;"><div style="width:100%; background-color:#003399;font-size:large" align="center" ><font  style="color:#CCCCFF;"><center><b>Quanlity</b></center></font></div></td></tr>';
    var $number = 0;
    var check = 'myCheck';
    for (var i = 0; i < $ProbeInfo.length; i++) {
        $resultChild = $ProbeInfo[i].childNodes;
        for (var j = 0; j < $resultChild.length; j++) {
            switch ($resultChild[j].tagName) {
                case "ProbeDetails": $probeDetails = $resultChild[j]

                    {
                        check = 'myCheck';
                        $number = $number + 1;
                        check += $number;
                        //problist += '<tr>';
                        //problist += '<td style="background-color:white;" align="center"><input type="checkbox" id="' + check + '" onClick="check()"/></td>'
                        if ($probeDetails.childNodes[0].tagName = "probe") {

                            $probe = $probeDetails.childNodes[0];
                           // problist += '<td style="background-color:white;">' + $probe.textContent + '</td>';
                        }
                        if ($probeDetails.childNodes[1].tagName = "Result") {
                            $Result = $probeDetails.childNodes[1];
                            //problist += '<td style="background-color:white;">' + $Result.textContent + '</td>';


                        }
                        if ($probeDetails.childNodes[2].tagName = "Score") {
                            $Score = $probeDetails.childNodes[2];
                            //problist += '<td style="background-color:white;">' + $Score.textContent + '</td>';

                        }
                        if ($probeDetails.childNodes[3].tagName = "FullName") {
                            $FullName = $probeDetails.childNodes[3];
                            //problist += '<td style="background-color:white;">' + $FullName.textContent + '</td>';

                        }
                        if ($probeDetails.childNodes[4].tagName = "Verify") {
                            $Verify = $probeDetails.childNodes[4];
                            //problist += '<td style="background-color:white;">' + $Verify.textContent + '</td>';

                        }
                        if ($probeDetails.childNodes[5].tagName = "Quanlity") {
                            $Quanlity = $probeDetails.childNodes[5];
                            //problist += '<td style="background-color:white;">' + $Quanlity.textContent + '</td>';

                        }
                        //    problist += '</tr>';

                        
                        var str = String.format(tas_td.toString(),
                                 $probe.textContent, // probe
                                 $Result.textContent,   // result
                                 $Score.textContent, // Score
                                 $FullName.textContent, // Full Name  
                                 $Verify.textContent, // Verify 
                                 $Quanlity.textContent  // Quality
                            
                             );
                        problist += str;
                    }
            
            
            }


        }

  }
  problist += '</table>';
 
    $('#div_problist').html(problist);
    
}