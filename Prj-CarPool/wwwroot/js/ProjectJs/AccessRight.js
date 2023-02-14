/***parent menu**/
function LoadTable(newdatas) {
    console.log(newdatas);
    var stutbl = '';
    $(".datatables-users-mytable tbody").html('');
    var statusObj = {
        1: { title: 'Pending', class: 'bg-label-warning' },
        2: { title: 'Active', class: 'bg-label-success' },
        3: { title: 'Inactive', class: 'bg-label-secondary' }
    };

    for (var st = 0; st < newdatas.data.length; st++) {

        stutbl += '<tr>';

        stutbl += '<td class="visiblityhidden"></td>';
        stutbl += '<td id="editAccessRightID">' + newdatas.data[st].AccessId  + '</td>';
        stutbl += '<td id="editregionname"> <span class="fw-semibold">' + newdatas.data[st].AccessName + '</span></td>';

        stutbl += newdatas.data[st].View ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Create ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Edit ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Email ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Download ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Approve ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Print ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
        stutbl += newdatas.data[st].Scan ? '<td class="text-center"><i class="ti ti-circle-check" style="color:green"></></td>' : '<td  class="text-center"><i class="ti ti-circle-x" style="color:red"></i></td>';
       

        if (newdatas.data[st].IsActive == false) {
            stutbl += '<td id="editBranchVisible"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        }
        else {
            stutbl += '<td id="editBranchVisible"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        }


        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditAccessRight(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Access Rights</span>',
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








function ShowEditAccessRight(item) {
    
    var AccessId = $(item).closest("tr").find('#editAccessRightID').text();
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/AccessRights/' + AccessId,
        success: function (result) {
            console.log(result)
            $('#editID').val(AccessId);
            $('#editAccessName').val(result.accessName);
            $('#editShortName').val(result.normalizedName);

            $("#chkViewEdit").prop("checked", result.view).trigger('change');
            $("#chkCreateEdit").prop("checked", result.create).trigger('change');
            $("#chkEditEdit").prop("checked", result.edit).trigger('change');
            $("#chkEmailEdit").prop("checked", result.email).trigger('change');
            $("#chkDownloadEdit").prop("checked", result.download).trigger('change');
            $("#chkApproveEdit").prop("checked", result.approve).trigger('change');
            $("#chkPrintEdit").prop("checked", result.print).trigger('change');
            $("#chkScanEdit").prop("checked", result.scan).trigger('change');
            $("#chkactive").prop("checked", result.isActive).trigger('change');
          },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });


    


}
function EditRights() {
    
    var AccessRightObj = {
        AccessId: $('#editID').val(),
        AccessName: $('#editAccessName').val(),
        NormalizedName: $('#editShortName').val().toUpperCase(),
        View: $('#chkViewEdit').is(':checked') ? true : false,
        Create: $('#chkCreateEdit').is(':checked') ? true : false,
        Edit: $('#chkEditEdit').is(':checked') ? true : false,
        Email: $('#chkEmailEdit').is(':checked') ? true : false,
        Download: $('#chkDownloadEdit').is(':checked') ? true : false,
        Approve: $('#chkApproveEdit').is(':checked') ? true : false,
        Print: $('#chkPrintEdit').is(':checked') ? true : false,
        Scan: $('#chkScanEdit').is(':checked') ? true : false,
        IsActive: $('#chkactive').is(':checked') ? true : false,
    }

    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: AccessRightObj },
        url: '/AccessRights/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Access Rights SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
            }
            else {

                Command: toastr["error"]("This Access Rights not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
            }

            $('#btnCancelEdit').click();
        },
        complete: function (result) {




        },
        error: function (err) {
            Command: toastr["error"]("This Navigation not Succefully Edit. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });
}

function SaveRights() {


    

  var AccessRightObj = {
      AccessId: 0,
      AccessName: $('#addAccessName').val(),
      NormalizedName: $('#addShortName').val().toUpperCase(),
      View: $('#chkView').is(':checked') ? true : false,
      Create: $('#chkCreate').is(':checked') ? true : false,
      Edit: $('#chkEdit').is(':checked') ? true : false,
      Email: $('#chkEmail').is(':checked') ? true : false,
      Download: $('#chkDownload').is(':checked') ? true : false,
      Approve: $('#chkApprove').is(':checked') ? true : false,
      Print: $('#chkPrint').is(':checked') ? true : false,
      Scan: $('#chkScan').is(':checked') ? true : false,
    }
    console.log(AccessRightObj);
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: AccessRightObj },
        url: '/AccessRights/Upsert',
        success: function (result) {
            if (result.datasuccess == true) {
                Command: toastr["success"]("This Access Rights Successfully Saved.");
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


function btnShow() {

    Command: toastr["success"]("Navigation SuccessFully Added !")

    //toastr.options = {
    //    "closeButton": false,
    //    "debug": false,
    //    "newestOnTop": false,
    //    "progressBar": false,
    //    "positionClass": "toast-top-right",
    //    "preventDuplicates": false,
    //    "onclick": null,
    //    "showDuration": "300",
    //    "hideDuration": "1000",
    //    "timeOut": "5000",
    //    "extendedTimeOut": "1000",
    //    "showEasing": "swing",
    //    "hideEasing": "linear",
    //    "showMethod": "fadeIn",
    //    "hideMethod": "fadeOut"
    //}


}
