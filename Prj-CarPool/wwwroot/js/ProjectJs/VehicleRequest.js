var imagebase64 = "";

function encodeImageFileAsURL(element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        imagebase64 = reader.result;
    }
    reader.readAsDataURL(file);
}


function LoadTable(newdatas) {
    console.log("NEW DAYA" + JSON.stringify(newdatas));

    var stutbl = '';
    $(".datatables-users-mytable tbody").html('');
    var statusObj = {
        1: { title: 'Pending', class: 'bg-label-warning' },
        2: { title: 'Active', class: 'bg-label-success' },
        3: { title: 'Inactive', class: 'bg-label-secondary' }
    };

    for (var st = 0; st < newdatas.data.length; st++) {




        stutbl += '<tr>';







        stutbl += '<td class="visiblityhidden editRequestID">' + newdatas.data[st].RequestID + '</td>';
        stutbl += '<td id="editEmployeeID">' + newdatas.data[st].EmployeeID + '</td>';
        stutbl += '<td id="editPurpose">' + newdatas.data[st].Purpose + '</td>';
        stutbl += '<td id="editRegionName">' + newdatas.data[st].Region.RegionName + '</td>';
        stutbl += '<td id="editStatus">' + newdatas.data[st].Status + '</td>';
        stutbl += '<td id="editEmployeeContact" >' + newdatas.data[st].EmployeeContact + '</td>';
        stutbl += '<td id="editRequest">' + newdatas.data[st].Request + '</td>';


        //if (newdatas.data[st].IsActive !== true) {
        //    stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        //}
        //else {
        //    stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        //}
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditRequest(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
        stutbl += '<a href="/" class="text-body delete-record"><i class="ti ti-trash ti-sm mx-2"></i></a>';
        stutbl += '<a href="/" class="text-body dropdown-toggle hide-arrow" data-bs-toggle="dropdown"><i class="ti ti-dots-vertical ti-sm mx-1"></i></a>';
        stutbl += '<div class="dropdown-menu dropdown-menu-end m-0">';
        stutbl += '<a href="/" class="dropdown-item">View</a>';
        stutbl += '<a href="javascript:;" class="dropdown-item">Suspend</a>';
        stutbl += '</div>';
        stutbl += '</div></td>';

        stutbl += '</tr>';
    }


    $(".datatables-users-mytable tbody").html(stutbl);


    $(".datatables-users-mytable").DataTable({

        retrieve: true,
        order: [[1, 'desc']],
        dom:
            '<"row me-2"' +
            '<"col-md-2"<"me-3"l>>' +
            '<"col-md-10"<"dt-action-buttons text-xl-end text-lg-start text-md-end text-start d-flex align-items-center justify-content-end flex-md-row flex-column mb-3 mb-md-0"fB>>' +
            '>t' +
            '<"row mx-2"' +
            '<"col-sm-12 col-md-6"i>' +
            '<"col-sm-12 col-md-6"p>' +
            '>',
        language: {
            sLengthMenu: '_MENU_',
            search: '',
            searchPlaceholder: 'Search..'
        },
        // Buttons with Dropdown
        buttons: [
            {
                extend: 'collection',
                className: 'btn btn-label-secondary dropdown-toggle mx-3',
                text: '<i class="ti ti-screen-share me-1 ti-xs"></i>Export',
                buttons: [
                    {
                        extend: 'print',
                        text: '<i class="ti ti-printer me-2" ></i>Print',
                        className: 'dropdown-item',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5],
                            // prevent avatar to be print
                            format: {
                                body: function (inner, coldex, rowdex) {
                                    if (inner.length <= 0) return inner;
                                    var el = $.parseHTML(inner);
                                    var result = '';
                                    $.each(el, function (index, item) {
                                        if (item.classList !== undefined && item.classList.contains('user-name')) {
                                            result = result + item.lastChild.firstChild.textContent;
                                        } else if (item.innerText === undefined) {
                                            result = result + item.textContent;
                                        } else result = result + item.innerText;
                                    });
                                    return result;
                                }
                            }
                        },
                        customize: function (win) {
                            //customize print view for dark
                            $(win.document.body)
                                .css('color', headingColor)
                                .css('border-color', borderColor)
                                .css('background-color', bodyBg);
                            $(win.document.body)
                                .find('table')
                                .addClass('compact')
                                .css('color', 'inherit')
                                .css('border-color', 'inherit')
                                .css('background-color', 'inherit');
                        }
                    },
                    {
                        extend: 'csv',
                        text: '<i class="ti ti-file-text me-2" ></i>Csv',
                        className: 'dropdown-item',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5],
                            // prevent avatar to be display
                            format: {
                                body: function (inner, coldex, rowdex) {
                                    if (inner.length <= 0) return inner;
                                    var el = $.parseHTML(inner);
                                    var result = '';
                                    $.each(el, function (index, item) {
                                        if (item.classList !== undefined && item.classList.contains('user-name')) {
                                            result = result + item.lastChild.firstChild.textContent;
                                        } else if (item.innerText === undefined) {
                                            result = result + item.textContent;
                                        } else result = result + item.innerText;
                                    });
                                    return result;
                                }
                            }
                        }
                    },
                    {
                        extend: 'excel',
                        text: 'Excel',
                        className: 'dropdown-item',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5],
                            // prevent avatar to be display
                            format: {
                                body: function (inner, coldex, rowdex) {
                                    if (inner.length <= 0) return inner;
                                    var el = $.parseHTML(inner);
                                    var result = '';
                                    $.each(el, function (index, item) {
                                        if (item.classList !== undefined && item.classList.contains('user-name')) {
                                            result = result + item.lastChild.firstChild.textContent;
                                        } else if (item.innerText === undefined) {
                                            result = result + item.textContent;
                                        } else result = result + item.innerText;
                                    });
                                    return result;
                                }
                            }
                        }
                    },
                    {
                        extend: 'pdf',
                        text: '<i class="ti ti-file-code-2 me-2"></i>Pdf',
                        className: 'dropdown-item',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5],
                            // prevent avatar to be display
                            format: {
                                body: function (inner, coldex, rowdex) {
                                    if (inner.length <= 0) return inner;
                                    var el = $.parseHTML(inner);
                                    var result = '';
                                    $.each(el, function (index, item) {
                                        if (item.classList !== undefined && item.classList.contains('user-name')) {
                                            result = result + item.lastChild.firstChild.textContent;
                                        } else if (item.innerText === undefined) {
                                            result = result + item.textContent;
                                        } else result = result + item.innerText;
                                    });
                                    return result;
                                }
                            }
                        }
                    },
                    {
                        extend: 'copy',
                        text: '<i class="ti ti-copy me-2" ></i>Copy',
                        className: 'dropdown-item',
                        exportOptions: {
                            columns: [1, 2, 3, 4, 5],
                            // prevent avatar to be display
                            format: {
                                body: function (inner, coldex, rowdex) {
                                    if (inner.length <= 0) return inner;
                                    var el = $.parseHTML(inner);
                                    var result = '';
                                    $.each(el, function (index, item) {
                                        if (item.classList !== undefined && item.classList.contains('user-name')) {
                                            result = result + item.lastChild.firstChild.textContent;
                                        } else if (item.innerText === undefined) {
                                            result = result + item.textContent;
                                        } else result = result + item.innerText;
                                    });
                                    return result;
                                }
                            }
                        }
                    }
                ]
            },
            {
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Details</span>',
                className: 'add-new btn btn-primary',
                attr: {
                    'data-bs-toggle': 'modal',
                    'data-bs-target': '#offcanvasAddUser'
                }
            }
        ]
        // For responsive popup
        //responsive: {
        //    details: {
        //        display: $.fn.dataTable.Responsive.display.modal({
        //            header: function (row) {
        //                var data = row.data();
        //                return 'Details of ' + data['full_name'];
        //            }
        //        }),
        //        type: 'column',
        //        renderer: function (api, rowIdx, columns) {
        //            var data = $.map(columns, function (col, i) {
        //                return col.title !== '' // ? Do not show row in modal popup if title is blank (for check box)
        //                    ? '<tr data-dt-row="' +
        //                    col.rowIndex +
        //                    '" data-dt-column="' +
        //                    col.columnIndex +
        //                    '">' +
        //                    '<td>' +
        //                    col.title +
        //                    ':' +
        //                    '</td> ' +
        //                    '<td>' +
        //                    col.data +
        //                    '</td>' +
        //                    '</tr>'
        //                    : '';
        //            }).join('');

        //            return data ? $('<table class="table"/><tbody />').append(data) : false;
        //        }
        //    }
        //},
        //initComplete: function () {
        //    // Adding role filter once table initialized
        //    this.api()
        //        .columns(2)
        //        .every(function () {
        //            var column = this;
        //            var select = $(
        //                '<select id="UserRole" class="form-select text-capitalize"><option value=""> Select Role </option></select>'
        //            )
        //                .appendTo('.user_role')
        //                .on('change', function () {
        //                    var val = $.fn.dataTable.util.escapeRegex($(this).val());
        //                    column.search(val ? '^' + val + '$' : '', true, false).draw();
        //                });

        //            column
        //                .data()
        //                .unique()
        //                .sort()
        //                .each(function (d, j) {
        //                    select.append('<option value="' + d + '">' + d + '</option>');
        //                });
        //        });
        //    // Adding plan filter once table initialized
        //    this.api()
        //        .columns(3)
        //        .every(function () {
        //            var column = this;
        //            var select = $(
        //                '<select id="UserPlan" class="form-select text-capitalize"><option value=""> Select Plan </option></select>'
        //            )
        //                .appendTo('.user_plan')
        //                .on('change', function () {
        //                    var val = $.fn.dataTable.util.escapeRegex($(this).val());
        //                    column.search(val ? '^' + val + '$' : '', true, false).draw();
        //                });

        //            column
        //                .data()
        //                .unique()
        //                .sort()
        //                .each(function (d, j) {
        //                    select.append('<option value="' + d + '">' + d + '</option>');
        //                });
        //        });
        //    // Adding status filter once table initialized
        //    //this.api()
        //    //    .columns(5)
        //    //    .every(function () {
        //    //        var column = this;
        //    //        var select = $(
        //    //            '<select id="FilterTransaction" class="form-select text-capitalize"><option value=""> Select Status </option></select>'
        //    //        )
        //    //            .appendTo('.user_status')
        //    //            .on('change', function () {
        //    //                var val = $.fn.dataTable.util.escapeRegex($(this).val());
        //    //                column.search(val ? '^' + val + '$' : '', true, false).draw();
        //    //            });

        //    //        column
        //    //            .data()
        //    //            .unique()
        //    //            .sort()
        //    //            .each(function (d, j) {
        //    //                select.append(
        //    //                    '<option value="' +
        //    //                    statusObj[d].title +
        //    //                    '" class="text-capitalize">' +
        //    //                    statusObj[d].title +
        //    //                    '</option>'
        //    //                );
        //    //            });
        //    //    });
        //},


    });


}
$(document).ready(function () {
    var mydata = $('#UserDataJson').val();

    var newdata = JSON.parse(mydata);

    LoadTable(newdata);

    $(".ispicktype").click(function () {
        if ($("#Airportpickup").is(":checked") == true) {
            $(".ispicktypeticket").show("slow");
        }
        else {
            $(".ispicktypeticket").hide("slow");
        }
    });


});
var Comapnydropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/vehiclebrands/all',
    success: function (result) {
        Comapnydropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            Comapnydropdown += '<option value="' + result[i].vehicleBrandId + '">' + result[i].vehicleBrandName + '</option>';
        }
        $(".companylist").html(Comapnydropdown);
        $(".companylistedit").html(Comapnydropdown);

    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});

var Regiondropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/region/all',
    success: function (result) {
        Regiondropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            Regiondropdown += '<option value="' + result[i].regionId + '">' + result[i].regionName + '</option>';
        }
        $(".regionlist").html(Regiondropdown);


    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});

function SaveVC() {
    var vehiclepurposevali = $("#vehiclepurpose").val();
    var VehicleRequestvali = $("#VehicleRequest").val();
    var VehicleTravelfromvali = $("#VehicleTravelfrom").val();
    var VehicleTravelTovali = $("#VehicleTravelTo").val();
    var Employeenovali = $("#Employeeno").val();
    var vehicleRegionvali = $("#vehicleRegion").val();
    var Airportpickupvali = $("#Airportpickup").val();
    var Professionalvisitvali = $("#Professionalvisit").val();
    var Flightnovali = $("#Flightno").val();
    var Ticketnovali = $("#Ticketno").val();
    var ticketpicuploadfilevali = $("#ticketpic-upload-file").val();
    var Pickfromvali = $("#Pickfrom").val();
    var PickTovali = $("#PickTo").val();
    var vehicleremarksvali = $("#vehicleremarks").val();


    $('#vehiclepurpose').on("input", function () {
        $('#vehiclepurpose').next(".error-message").hide();
        $('#vehiclepurpose').css('border', 'none');
        $('#vehiclepurpose').css('background', '#d8f9d8');
    });
    if (vehiclepurposevali == null || vehiclepurposevali == undefined || vehiclepurposevali == "" || vehiclepurposevali == " ") {
        $('#vehiclepurpose').next(".error-message").text("* Purpose Required");
        $('#vehiclepurpose').next(".error-message").show();
        $('#vehiclepurpose').css('border', '1px solid red');
        $('#vehiclepurpose').css('background', '#fff');
        $('#vehiclepurpose').focus();
        return false;
    }

    $('#VehicleRequest').on("input", function () {
        $('#VehicleRequest').next(".error-message").hide();
        $('#VehicleRequest').css('border', 'none');
        $('#VehicleRequest').css('background', '#d8f9d8');
    });
    if (VehicleRequestvali == null || VehicleRequestvali == undefined || VehicleRequestvali == "" || VehicleRequestvali == " ") {
        $('#VehicleRequest').next(".error-message").text("* Request Required");
        $('#VehicleRequest').next(".error-message").show();
        $('#VehicleRequest').css('border', '1px solid red');
        $('#VehicleRequest').css('background', '#fff');
        $('#VehicleRequest').focus();
        return false;
    }
    $('#VehicleTravelfrom').on("input", function () {
        $('#VehicleTravelfrom').next(".error-message").hide();
        $('#VehicleTravelfrom').css('border', 'none');
        $('#VehicleTravelfrom').css('background', '#d8f9d8');
    });
    if (VehicleTravelfromvali == null || VehicleTravelfromvali == undefined || VehicleTravelfromvali == "" || VehicleTravelfromvali == " ") {
        $('#VehicleTravelfrom').next(".error-message").text("* from Required");
        $('#VehicleTravelfrom').next(".error-message").show();
        $('#VehicleTravelfrom').css('border', '1px solid red');
        $('#VehicleTravelfrom').css('background', '#fff');
        $('#VehicleTravelfrom').focus();
        return false;
    }
    $('#VehicleTravelTo').on("input", function () {
        $('#VehicleTravelTo').next(".error-message").hide();
        $('#VehicleTravelTo').css('border', 'none');
        $('#VehicleTravelTo').css('background', '#d8f9d8');
    });
    if (VehicleTravelTovali == null || VehicleTravelTovali == undefined || VehicleTravelTovali == "" || VehicleTravelTovali == " ") {
        $('#VehicleTravelTo').next(".error-message").text("* To Required");
        $('#VehicleTravelTo').next(".error-message").show();
        $('#VehicleTravelTo').css('border', '1px solid red');
        $('#VehicleTravelTo').css('background', '#fff');
        $('#VehicleTravelTo').focus();
        return false;
    }

    $('#Employeeno').on("input", function () {
        $('#Employeeno').next(".error-message").hide();
        $('#Employeeno').css('border', 'none');
        $('#Employeeno').css('background', '#d8f9d8');
    });
    if (Employeenovali == null || Employeenovali == undefined || Employeenovali == "" || Employeenovali == " ") {
        $('#Employeeno').next(".error-message").text("* Employee Number Required");
        $('#Employeeno').next(".error-message").show();
        $('#Employeeno').css('border', '1px solid red');
        $('#Employeeno').css('background', '#fff');
        $('#Employeeno').focus();
        return false;
    }

    $('#vehicleRegion').change("select", function () {
        $('#vehicleRegion').next(".error-message").hide();
        $('#vehicleRegion').css('border', 'none');
        $('#vehicleRegion').css('background', '#d8f9d8');
    });
    if (vehicleRegionvali == null || vehicleRegionvali == undefined || vehicleRegionvali == "" || vehicleRegionvali == " ") {
        $('#vehicleRegion').next(".error-message").text("* Region Required");
        $('#vehicleRegion').next(".error-message").show();
        $('#vehicleRegion').css('border', '1px solid red');
        $('#vehicleRegion').css('background', '#fff');
        $('#vehicleRegion').focus();
        return false;
    }

    $('#Flightno').on("input", function () {
        $('#Flightno').next(".error-message").hide();
        $('#Flightno').css('border', 'none');
        $('#Flightno').css('background', '#d8f9d8');
    });
    if (Flightnovali == null || Flightnovali == undefined || Flightnovali == "" || Flightnovali == " ") {
        $('#Flightno').next(".error-message").text("* Flight Number Required");
        $('#Flightno').next(".error-message").show();
        $('#Flightno').css('border', '1px solid red');
        $('#Flightno').css('background', '#fff');
        $('#Flightno').focus();
        return false;
    }
    $('#Ticketno').on("input", function () {
        $('#Ticketno').next(".error-message").hide();
        $('#Ticketno').css('border', 'none');
        $('#Ticketno').css('background', '#d8f9d8');
    });
    if (Ticketnovali == null || Ticketnovali == undefined || Ticketnovali == "" || Ticketnovali == " ") {
        $('#Ticketno').next(".error-message").text("* Ticket Number Required");
        $('#Ticketno').next(".error-message").show();
        $('#Ticketno').css('border', '1px solid red');
        $('#Ticketno').css('background', '#fff');
        $('#Ticketno').focus();
        return false;
    }

    $('#ticketpic-upload-file').on("input", function () {
        $('#ticketpic-upload-file').next(".error-message").hide();
        $('#ticketpic-upload-file').css('border', 'none');
        $('#ticketpic-upload-file').css('background', '#d8f9d8');
    });
    if (ticketpicuploadfilevali == null || ticketpicuploadfilevali == undefined || ticketpicuploadfilevali == "" || ticketpicuploadfilevali == " ") {
        $('#ticketpic-upload-file').next(".error-message").text("* Ticket Required");
        $('#ticketpic-upload-file').next(".error-message").show();
        $('#ticketpic-upload-file').css('border', '1px solid red');
        $('#ticketpic-upload-file').css('background', '#fff');
        $('#ticketpic-upload-file').focus();
        return false;
    }


    $('#Pickfrom').on("input", function () {
        $('#Pickfrom').next(".error-message").hide();
        $('#Pickfrom').css('border', 'none');
        $('#Pickfrom').css('background', '#d8f9d8');
    });
    if (Pickfromvali == null || Pickfromvali == undefined || Pickfromvali == "" || Pickfromvali == " ") {
        $('#Pickfrom').next(".error-message").text("* Pick From Required");
        $('#Pickfrom').next(".error-message").show();
        $('#Pickfrom').css('border', '1px solid red');
        $('#Pickfrom').css('background', '#fff');
        $('#Pickfrom').focus();
        return false;
    }
    $('#PickTo').on("input", function () {
        $('#PickTo').next(".error-message").hide();
        $('#PickTo').css('border', 'none');
        $('#PickTo').css('background', '#d8f9d8');
    });
    if (PickTovali == null || PickTovali == undefined || PickTovali == "" || PickTovali == " ") {
        $('#PickTo').next(".error-message").text("* Pick To Required");
        $('#PickTo').next(".error-message").show();
        $('#PickTo').css('border', '1px solid red');
        $('#PickTo').css('background', '#fff');
        $('#PickTo').focus();
        return false;
    }

    $('#vehicleremarks').on("input", function () {
        $('#vehicleremarks').next(".error-message").hide();
        $('#vehicleremarks').css('border', 'none');
        $('#vehicleremarks').css('background', '#d8f9d8');
    });
    if (vehicleremarksvali == null || vehicleremarksvali == undefined || vehicleremarksvali == "" || vehicleremarksvali == " ") {
        $('#vehicleremarks').next(".error-message").text("* Remarks Required");
        $('#vehicleremarks').next(".error-message").show();
        $('#vehicleremarks').css('border', '1px solid red');
        $('#vehicleremarks').css('background', '#fff');
        $('#vehicleremarks').focus();
        return false;
    }




















    var pdfpath = ticketpicuploadfilevali;

    var VRequestObj = {
        requestID: 0,
        employeeID: 0,
        status: 0,
        hODApproval: false,
        requestType: "oks",
        dropFrom: "oks",

        dropTo: "oks",


        purpose: vehiclepurposevali,
        request: VehicleRequestvali,
        travelfrom: VehicleTravelfromvali,
        travelTo: VehicleTravelTovali,
        employeeContact: Employeenovali,
        regionID: vehicleRegionvali,
        IsAirport: "isateport",//Airportpickupvali,
        //: Professionalvisitvali,
        flightNo: Flightnovali,
        ticketNo: Ticketnovali,
        ticketPDF: null,
        pickFrom: Pickfromvali,
        pickTo: PickTovali,
        remarks: vehicleremarksvali,






    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VRequestObj, pathfile: pdfpath },
        url: '/VehicleRequest/Upsert',
        success: function (result) {
            if (result.datasuccess == true) {

                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);
                LoadTable(newdata);
                $('#btnEXCancelSave').click();
                Command: toastr["success"]("This Vehicle Details Successfully Saved.");
            }
        },
        complete: function (result) {

        },
        error: function (err) {

            console.log("error" + JSON.stringify(err));
        }
    });
}

function ShowEditRequest(item) {
    var VCId = $(item).closest("tr").find('#editRequestID').text();
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/VehicleRequest/' + VCId,
        success: function (result) {

            $('#editvehicleepurpose').val(result.purpose);
            $('#editVehicleRequest').val(result.request);//.trigger('change')
            $('#editVehicleTravelfrom').val(result.vehicleNum);
            $('#editVehicleTravelTo').val(result.vehicleName);
            $('#editEmployeeno').val(result.vehicleColor);
            $('#editvehicleRegion').val(result.purchaseDate);
            $('#editVehicleType').val(result.vehicleType);
            $('#editAirportpickup').val(result.vehicleMilage);
            $('#editProfessionalvisit').val(result.vehicleModel);
            $('#editFlightno').val(result.fuelType);
            $('#editTicketno').val(result.regionID).trigger('change');
            $('#editticketpic-upload-file').val(result.vehicleID);
            $('#editPickfrom').val(result.vehicleID);
            $('#editPickTo').val(result.vehicleID);
            $('#editvehicleremarks').val(result.vehicleID);
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });

}

function EditVC() {

    var VCEditObj = {
        VehicleID: $('#editvehicleID').val(),
        VehicleERP: $('#editVehicleERP').val(),
        VehicleBrandsVehicleBrandId: $('#editvehicleBrands option:selected').val(),
        VehicleBrandID: $('#editvehicleBrands option:selected').val(),
        VehicleNum: $('#editvehicleNO').val(),
        VehicleName: $('#editvehicleName').val(),
        VehicleColor: $('#editvehicleColor').val(),
        PurchaseDate: $('#editPurchaseDate').val(),
        VehicleType: $('#editVehicleType').val(),
        VehicleMilage: $('#editvehicleMilage').val(),
        VehicleModel: $('#editvehicleModel').val(),
        FuelType: $('#editFuelType').val(),
        RegionID: $('#editvehicleRegion option:selected').val(),


    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VCEditObj },
        url: '/VehicleDetails/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Vehicle Brand SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnEditCancelSave').click();
            }
            else {

                Command: toastr["error"]("This Vehicle Brand not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnEditCancelSave').click();
            }
        },
        complete: function (result) {

        },
        error: function (err) {
            Command: toastr["error"]("This Vehicle Company not Succefully Edit. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });
}
