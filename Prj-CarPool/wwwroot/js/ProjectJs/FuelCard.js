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
        stutbl += '<td id="editCID">' + newdatas.data[st].CardID + '</td>';
        stutbl += '<td  id="editCName">' + newdatas.data[st].CardName + '</td>';



        stutbl += '<td>' + newdatas.data[st].CardNum + '</td>';
        stutbl += '<td>' + newdatas.data[st].CardLimit + '</td>';
        if (newdatas.data[st].IsActive === true) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';

        }
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="Edit(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
        stutbl += '<a onclick ="Delete(this)"  class="text-body delete-record" data-bs-toggle="modal" data-bs-target="#offcanvasDeleteNav"  ><i class="ti ti-trash ti-sm mx-2"></i></a>';
      /*  stutbl += '<a href="/" class="text-body dropdown-toggle hide-arrow" data-bs-toggle="dropdown"><i class="ti ti-dots-vertical ti-sm mx-1"></i></a>';*/
        //stutbl += '<div class="dropdown-menu dropdown-menu-end m-0">';
        //stutbl += '<a href="/" class="dropdown-item">View</a>';
        //stutbl += '<a href="javascript:;" class="dropdown-item">Suspend</a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Fuel Card</span>',
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
    debugger
    var mydata = $('#UserDataJson').val();

    var newdata = JSON.parse(mydata);

    LoadTable(newdata);
    debugger
    $(".flatpickr-datetime1").flatpickr({

        plugins: [
            new monthSelectPlugin({
                shorthand: true, //defaults to false
                dateFormat: "m/y", //defaults to "F Y"
                altFormat: "F Y", //defaults to "F Y"
            })
        ]
    });
    $(".flatpickr-datetime2").flatpickr({
        plugins: [
            new monthSelectPlugin({
                shorthand: true, //defaults to false
                dateFormat: "m/y", //defaults to "F Y"
                altFormat: "F Y", //defaults to "F Y"
            })
        ]
    });
    $(".Cardissuanceedit").flatpickr({
        plugins: [
            new monthSelectPlugin({
                shorthand: true, //defaults to false
                dateFormat: "m/y", //defaults to "F Y"
                altFormat: "F Y", //defaults to "F Y"
            })
        ]
    });
    $(".Cardexpiryedit").flatpickr({
        plugins: [
            new monthSelectPlugin({
                shorthand: true, //defaults to false
                dateFormat: "m/y", //defaults to "F Y"
                altFormat: "F Y", //defaults to "F Y"
            })
        ]
    });

});


function Save_Card() {


    var AddObj = {
        CardID: 0,
        CardName: $('.Cardnameadd').val(),
        CardNum: $('.Cardnumadd').val(),
        CardLimit: $('.Cardlimitadd').val(),
        IssueDate: $('.Cardissuanceadd').val(),
        ExipryDate: $('.Cardexpiryadd').val(),

    }
    debugger
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: AddObj },
        url: '/FuelCard/Upsert',

        success: function (result) {
            if (result.datasuccess == true) {
                const Enddate = new Date();
                console.log("Endtime : " + Enddate.getMilliseconds());

                Command: toastr["success"]("This Fuel Card Succefully Saved.");
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
    var CardID = $(item).closest("tr").find('#editCID').text();
    $.ajax({

        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/FuelCard/' + CardID,
        success: function (result) {
            $('.Cardidedit').val(result.cardID);
            $('.Cardnameedit').val(result.cardName);
            $('.Cardnumedit').val(result.cardNum);
            $('.Cardlimitedit').val(result.cardLimit);
            $('#chkactive').attr("checked", result.isActive);

            dateSetflatMonth(result.issueDate, $('.Cardissuanceedit'));
            dateSetflatMonth(result.exipryDate, $('.Cardexpiryedit'));
          // $('.Cardissuanceedit').val(result.issueDate);
        //  $('.Cardexpiryedit').val(result.exipryDate);
        }

    });
}


function Edit_Card() {

    let isChecked = $('#chkactive').is(':checked');
    var eidtobj = {
        CardID: $('.Cardidedit').val(),
        CardName: $('.Cardnameedit').val(),
        CardNum: $('.Cardnumedit').val(),
        CardLimit: $('.Cardlimitedit').val(),
        IssueDate: $('.Cardissuanceedit').val(),
        ExipryDate: $('.Cardexpiryedit').val(),
        IsActive: isChecked
    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: eidtobj },
        url: '/FuelCard/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Fuel Card SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
            else {

                Command: toastr["error"]("This Fuel Card not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
        },
        complete: function (result) {

        },
        error: function (err) {
            Command: toastr["error"]("This Fuel Card not Succefully Edit. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });
}
function Delete(item) {
    var CardID = $(item).closest("tr").find('#editCID').text();
    var objDelete = {
        CardID: CardID,
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
                url: '/FuelCard/Delete',
                success: function (result) {
                    var mydata = result.json;// $('#UserDataJson').val();
                    var newdata = JSON.parse(mydata);

                    LoadTable(newdata);

                    Swal.fire({
                        icon: 'success',
                        title: 'Deleted!',
                        text: 'Your record has been deleted.',
                        customClass: {
                            confirmButton: 'btn btn-success'
                        }
                    });
                }
            });





        }
    });
}