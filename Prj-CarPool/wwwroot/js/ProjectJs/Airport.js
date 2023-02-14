﻿function LoadTable(newdatas) {
    console.log(newdatas);
    var stutbl = '';
    $(".datatables-users-mytable tbody").html('');
    var statusObj = {
        1: { title: 'Pending', class: 'bg-label-warning' },
        2: { title: 'Active', class: 'bg-label-success' },
        3: { title: 'Inactive', class: 'bg-label-secondary' }
    };

    for (var st = 0; st < newdatas.data.length; st++) {

        var $name = newdatas.data[st].AirportName;
        // var $output = '<i class="ti ti-car" data-icon="ti ti-car"></i>';

        stutbl += '<tr>';

        stutbl += '<td class="visiblityhidden"></td>';
        stutbl += '<td id="editAID">' + newdatas.data[st].AirportID + '</td>';
        stutbl += '<td  id="editAName">' + newdatas.data[st].AirportName + '</td>';
      

        stutbl += '<td id="editACity" hidden="hidden">' + newdatas.data[st].City.CityId + '</td>';
        stutbl += '<td>' + newdatas.data[st].City.CityName + '</td>';
        stutbl += '<td id="editARegion" hidden="hidden">' + newdatas.data[st].Region.RegionId + '</td>';
        stutbl += '<td>' + newdatas.data[st].Region.RegionName + '</td>';
        stutbl += '<td id="IsVisibleChk" hidden="hidden">' + newdatas.data[st].IsActive + '</td>';

        if (newdatas.data[st].IsActive !== true) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        }
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="Edit(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
        stutbl += '<a onclick ="Delete(this)"  class="text-body delete-record" data-bs-toggle="modal" data-bs-target="#offcanvasDeleteNav"  ><i class="ti ti-trash ti-sm mx-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Airport</span>',
                className: 'add-new btn btn-primary',
                attr: {
                    'data-bs-toggle': 'modal',
                    'data-bs-target': '#offcanvasAddUser'
                }
            }
        ]
       

    });


}

$(document).ready(function () {
    var mydata = $('#UserDataJson').val();

    var newdata = JSON.parse(mydata);

    LoadTable(newdata);

});

var Citydropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/City/all',
    success: function (result) {
        Citydropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            Citydropdown += '<option value="' + result[i].cityId + '">' + result[i].cityName + '</option>';
        }
        $(".Citylist").html(Citydropdown);
        $(".EditCitylist").html(Citydropdown);

    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});

var Regiondropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/Region/all',
    success: function (result) {
        Regiondropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            Regiondropdown += '<option value="' + result[i].regionId + '">' + result[i].regionName + '</option>';
        }
        $(".Regionlist").html(Regiondropdown);
        $(".EditRegionlist").html(Regiondropdown);

    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});



function Save_Airport() {


    var AddObj = {
        AirportID: 0,
        AirportName: $('.Aiportnameadd').val(),
        CityID: $('.Citylist option:selected').val(),
        RegionID: $('.Regionlist option:selected').val(),

    }

    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: AddObj },
        url: '/Airport/Upsert',

        success: function (result) {
            if (result.datasuccess == true) {
                const Enddate = new Date();
                console.log("Endtime : " + Enddate.getMilliseconds());

                Command: toastr["success"]("This Airport Succefully Saved.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);

                $('#btnCancelSave').click();
            }
        },
        complete: function (result) {

        },
        error: function (err) {

            console.log("error" + JSON.stringify(err));
        }
    });
}
function Edit(item) {
    debugger
    var AirportId = $(item).closest("tr").find('#editAID').text();
    var AirportName = $(item).closest("tr").find('#editAName').text();
    var CityName = $(item).closest("tr").find('#editACity').text();
    var RegionName = $(item).closest("tr").find('#editARegion').text();
    var IsVisibleChkedit = JSON.parse($(item).closest("tr").find('#IsVisibleChk').text());


    $('.EditAirportID').val(AirportId.trim());
    $('.EditAirportName').val(AirportName.trim());
    $('.EditCitylist').val(CityName).trigger('change');
    $('.EditRegionlist').val(RegionName).trigger('change');
    $('#chkactive').attr("checked", IsVisibleChkedit);


}


function Edit_Airport() {
    let isChecked = $('#chkactive').is(':checked');

    var objupdate = {
        AirportId: parseInt($('.EditAirportID').val()),
        AirportName: $(".EditAirportName").val(),
        CityID: $(".EditCitylist").val(),
        RegionID: $(".EditRegionlist").val(),
        IsActive: isChecked,


    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: objupdate },
        url: '/Airport/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Airport SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
            else {

                Command: toastr["error"]("This Airport not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
        },
        complete: function (result) {

        },
        error: function (err) {
            Command: toastr["error"]("This Airport not Succefully Edit. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });
}

function Delete(item) {
    debugger

    var AirportId = $(item).closest("tr").find('#editAID').text();
   
    $('.EditAirportID').val(AirportId.trim());

}


function Delete_Airport() {

    var objDelete = {
        AirportID: parseInt($('.EditAirportID').val()),
    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: objDelete },
        url: '/Airport/Delete',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Airport SuccessFully Deleted !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnDelete').click();
            }
            else {

                Command: toastr["error"]("This Airport not Succefully Deleted. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnDelete').click();
            }
        },
        complete: function (result) {

        },
        error: function (err) {
            Command: toastr["error"]("This City not Succefully Deleted. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });


}