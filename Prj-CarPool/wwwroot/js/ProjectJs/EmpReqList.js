function LoadTable(newdatas) {
    /* console.log("NEW DAYA" + JSON.stringify(newdatas));*/

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
        stutbl += '<td id="editEmployeeContact" >' + newdatas.data[st].EmployeeContact + '</td>';
        stutbl += '<td id="editRequest">' + flatpickr.formatDate(new Date(newdatas.data[st].RequestDate), "d-M-Y"); + '</td>';
        stutbl += '<td id="editRequest">' + newdatas.data[st].RequestTime + '</td>';
        // stutbl += '<td id="editStatus">' + newdatas.data[st].Status + '</td>';


        if (newdatas.data[st].Status == 0) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-warning" text-capitalized>Pending</span></td>';
        }
        else if (newdatas.data[st].Status == 1) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Approved</span></td>';
            
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>Rejected</span></td>';

        }
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a href ="javascript:0;" onclick="showdataid(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#onboardHorizontalImageModal" ><i class="ti ti-circle-check ti-sm me-2 approve"></i></a>';
        stutbl += '<a href ="javascript:0;" onclick="showdataReject(this)" class="text-body delete-record" data-bs-toggle="modal" data-bs-target="#onboardHorizontalImageModalReject"><i class="ti ti-circle-x ti-sm mx-2 reject"></i></a>';
        //stutbl += '<a href="/" class="text-body dropdown-toggle hide-arrow" data-bs-toggle="dropdown"><i class="ti ti-dots-vertical ti-sm mx-1"></i></a>';
        //stutbl += '<div class="dropdown-menu dropdown-menu-end m-0">';
        //stutbl += '<a href="/" class="dropdown-item">View</a>';
        //stutbl += '<a href="javascript:;" class="dropdown-item">Suspend</a>';
        //stutbl += '</div>';
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
            //{
            //    text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Request</span>',
            //    className: 'add-new btn btn-primary',
            //    attr: {
            //        'data-bs-toggle': 'modal',
            //        'data-bs-target': '#createApp'
            //    }
            //}
        ]
      

    });


}
$(document).ready(function () {
    var mydata = $('#UserDataJson').val();
    var newdata = JSON.parse(mydata);
    LoadTable(newdata);

});


function showdataid(item) {
    var VCId = $(item).closest("tr").find('.editRequestID').text();
    $('#ReqID').val(VCId);
}

function showdataReject(item) {
    var VCIds = $(item).closest("tr").find('.editRequestID').text();
    $('#ReqIDReject').val(VCIds);
}


function Approved() {
    $('#btnCancelapp').click();
    var objdata = {
        RequestID: $('#ReqID').val(),
        Status: 1,
        Remarks: $('#nameEx7').val(),
        HodApproval : true
    }

    $.ajax({
        type: 'POST',
        async: false,
        data: {obj: objdata},
        url: '/VehicleUserRequest/Upsert',
        success: function (result) {
            var mydata = result.json;// $('#UserDataJson').val();
            var newdata = JSON.parse(mydata);
            LoadTable(newdata);
            Swal.fire({
                icon: 'success',
                title: 'Approved!',
                text: 'Request Approved.',
                customClass: {
                    confirmButton: 'btn btn-success'
                }
            });

        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });

    
}


function Reject() {
    $('#btnCancelrej').click();
    $('#btnCancelapp').click();
    var objdata = {
        RequestID: $('#ReqIDReject').val(),
        Status: 2,
        Remarks: $('#txtReasonReject').val(),
        HodApproval: false
    }

    $.ajax({
        type: 'POST',
        async: false,
        data: { obj: objdata },
        url: '/VehicleUserRequest/Upsert',
        success: function (result) {
            var mydata = result.json;// $('#UserDataJson').val();
            var newdata = JSON.parse(mydata);
            LoadTable(newdata);
            Swal.fire({
                icon: 'success',
                title: 'Rejected!',
                text: 'Request Rejected SuccessFully.',
                customClass: {
                    confirmButton: 'btn btn-success'
                }
            });

        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });





   
}