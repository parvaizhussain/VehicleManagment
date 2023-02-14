

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

        stutbl += '<td class="visiblityhidden" hidden></td>';
        stutbl += '<td id="editMHID">' + newdatas.data[st].MaintainaceHistoryId + '</td>';
        stutbl += '<td>' + newdatas.data[st].CarNumber + '</td>';
        stutbl += '<td>' + newdatas.data[st].InvoiceNo + '</td>';
        stutbl += '<td>' + newdatas.data[st].MaintainaceLocation + '</td>';
        stutbl += '<td>' + newdatas.data[st].Amount + '</td>';
       
        if (newdatas.data[st].IsActive === false) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        }
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditBranch(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#modalEditMaintain" ><i class="ti ti-edit ti-sm me-2"></i></a>';
        stutbl += '<a onclick ="Delete(this)" class="text-body delete-record"><i class="ti ti-trash ti-sm mx-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Maintainace History</span>',
                className: 'add-new btn btn-primary',
                attr: {
                    'data-bs-toggle': 'modal',
                    'data-bs-target': '#modalAddMaintain'
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


function SaveVC() {


   // var servicename_validation = $(".AddMaintenanceLocation").val();
   // var servicecontact_validation = $(".Addmaincarno").val();
   ///* var servicecontact_validation = $(".Addmaininvoiceno").val();*/
   // /**Validation**/
   // $('.AddMaintenanceLocation').on("input", function () {
   //     $('.AddMaintenanceLocation').next(".error-message").hide();
   //     $('.AddMaintenanceLocation').css('border', 'none');
   //     $('.AddMaintenanceLocation').css('background', '#d8f9d8');
   // });
   // if (servicename_validation == null || servicename_validation == undefined || servicename_validation == "" || servicename_validation == " ") {
   //     $('.AddMaintenanceLocation').next(".error-message").text("* Service Name Required");
   //     $('.AddMaintenanceLocation').next(".error-message").show();
   //     $('.AddMaintenanceLocation').css('border', '1px solid red');
   //     $('.AddMaintenanceLocation').css('background', '#fff');
   //     $('.AddMaintenanceLocation').focus();
   //     return false;
   // }
   // $('.Addmaincarno').on("input", function () {
   //     $('.Addmaincarno').next(".error-message").hide();
   //     $('.Addmaincarno').css('border', 'none');
   //     $('.Addmaincarno').css('background', '#d8f9d8');
   // });
   // if (servicecontact_validation == null || servicecontact_validation == undefined || servicecontact_validation == "" || servicecontact_validation == " ") {
   //     $('.Addmaincarno').next(".error-message").text("* Contact Number Required");
   //     $('.Addmaincarno').next(".error-message").show();
   //     $('.Addmaincarno').css('border', '1px solid red');
   //     $('.Addmaincarno').css('background', '#fff');
   //     $('.Addmaincarno').focus();
   //     return false;
   // }

   // $('.DealerList').change("select", function () {
   //     $('.DealerList').next(".error-message").hide();
   //     $('.DealerList').css('border', 'none');
   //     $('.DealerList').css('background', '#d8f9d8');
   // });
   // if (Dealerlist_validation == null || Dealerlist_validation == undefined || Dealerlist_validation == "" || Dealerlist_validation == " ") {
   //     $('.DealerList').next(".error-message").text("* Dealer Required");
   //     $('.DealerList').next(".error-message").show();
   //     $('.DealerList').css('border', '1px solid red');
   //     $('.DealerList').css('background', '#fff');
   //     $('.DealerList').focus();
   //     return false;
   // }

    /**Validation**/


    var MHObj = {
        MaintainaceHistoryId: 0,
        MaintainaceLocation: $('.AddMaintenanceLocation').val(),
        MaintainaceDateForm: $('.Addmaindatefrom').val(),
        MaintainaceDateTo: $('.Addmaindateto').val(),
        CarNumber: $('.Addmaincarno').val(),
        Issue: $('.Addmainissue').val(),
        InvoiceNo: $('.Addmaininvoiceno').val(),
        Amount: $('.Addmainamount').val(),
    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: MHObj },
        url: '/MaintenanceHistory/Upsert',
        success: function (result) {
            if (result.datasuccess == true) {
                Command: toastr["success"]("This Maintenance History Succefully Saved.");
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


function ShowEditBranch(item) {

    var MHId = $(item).closest("tr").find('#editMHID').text();
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/MaintainaceHistory/' + MHId,
        success: function (result) {

            $('.EditMaintainHisId').val(MHId);
            $('.EditMaintenanceLocation').val(result.maintainaceLocation);
            dateSetflat(result.maintainaceDateForm, $('.Editmaindatefrom'));
            dateSetflat(result.maintainaceDateTo, $('.Editmaindateto'));
            $('.Editmaincarno').val(result.carNumber);
            $('.Editmainissue').val(result.issue);
            $('.Editmaininvoiceno').val(result.invoiceNo);
            $('.Editmainamount').val(result.amount);
            $('#chkactive').attr("checked", result.isActive);
           
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });

}

function EditMH() {
    let isChecked = $('#chkactive').is(':checked');

    var VCEditObj = {
        MaintainaceHistoryId: $('.EditMaintainHisId').val(),
        MaintainaceLocation: $('.EditMaintenanceLocation').val(),
        MaintainaceDateForm: $('.Editmaindatefrom').val(),
        MaintainaceDateTo: $('.Editmaindateto').val(),
        CarNumber: $('.Editmaincarno').val(),
        Issue: $('.Editmainissue').val(),
        InvoiceNo: $('.Editmaininvoiceno').val(),
        Amount: $('.Editmainamount').val(),
        IsActive: isChecked

    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VCEditObj },
        url: '/MaintenanceHistory/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("maintenance History SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
            else {

                Command: toastr["error"]("This Maintenance History not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
        },
        complete: function (result) {

        },
        error: function (err) {
            Command: toastr["error"]("This maintenance History not Succefully Edit. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });
}



function Delete(item) {
    var maintainaceHistoryId = $(item).closest("tr").find('#editMHID').text();
    var objDelete = {
        MaintainaceHistoryId: maintainaceHistoryId,
    }
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        customClass: {
            confirmButton: 'btn btn-primary me-3',
            cancelButton: 'btn btn-label-secondary'
        },
        buttonsStyling: false
    }).then(function (result) {
        if (result.value) {

            $.ajax({

                type: 'POST',
                async: false,
                data: { Obj: objDelete },
                url: '/MaintenanceHistory/Delete',
                success: function (result) {
                    var mydata = result.json;// $('#UserDataJson').val();
                    var newdata = JSON.parse(mydata);

                    LoadTable(newdata);

                    Swal.fire({
                        icon: 'success',
                        title: 'Deleted!',
                        text: 'Your file has been deleted.',
                        customClass: {
                            confirmButton: 'btn btn-success'
                        }
                    });
                }
            });





        }
    });
}
