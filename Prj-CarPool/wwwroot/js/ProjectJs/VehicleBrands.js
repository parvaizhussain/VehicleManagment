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

        var $name = newdatas.data[st].VehicleBrandName;
        var $output = '<i class="ti ti-car" data-icon="ti ti-car"></i>';

        stutbl += '<tr>';

        stutbl += '<td class="visiblityhidden"></td>';
        stutbl += '<td id="editVBID">' + newdatas.data[st].VehicleBrandId + '</td>';
        stutbl += '<td>';
        stutbl += '<div id="editVBName" class="d-flex justify-content-start align-items-center user-name">';
        stutbl += '<div class="avatar-wrapper">';
        stutbl += '<div class="avatar avatar-sm me-3">';

        stutbl += $output;
        stutbl += '</div>';
        stutbl += '</div>';
        stutbl += '<div class="d-flex flex-column">';
        stutbl += '<a href="#" class="text-body text-truncate"><span class="fw-semibold">';
        stutbl += $name;
        stutbl += '</span></a>';
        stutbl += '</div>';
        stutbl += '</div>';
        stutbl += '</td>';

        stutbl += '<td id="editVBCID" hidden="hidden">' + newdatas.data[st].VehicleCompanyId + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].VehicleCompany.VehicleCompanyName + '</td>';
        stutbl += '<td id="IsVisibleChk" class="visiblityhidden">' + newdatas.data[st].IsActive + '</td>';

        if (newdatas.data[st].IsActive == false) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        }
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditBranch(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Brands</span>',
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

});
var Comapnydropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/VehicleCompany/all',
    success: function (result) {
        Comapnydropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {

            if (result[i].isActive == true && result[i].isDeleted == false) {
                Comapnydropdown += '<option value="' + result[i].vehicleCompanyId + '">' + result[i].vehicleCompanyName + '</option>';
            }
        }
        $(".companylist").html(Comapnydropdown);
        $(".companylistedit").html(Comapnydropdown);
      
    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});



function SaveVC() {


    var VCObj = {
        VehicleBrandId: 0,
        VehicleBrandName: $('.VCnameadd').val(),
        VehicleCompanyId: $('.companylist option:selected').val(),

    }

  
    const date = new Date();
    
    console.log("Starttime : " + date.getMilliseconds())





    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VCObj},
        url: '/VehicleBrands/Upsert',

        success: function (result) {
            if (result.datasuccess == true) {
                const Enddate = new Date();
                console.log("Endtime : " + Enddate.getMilliseconds());

                Command: toastr["success"]("Vehicle Brand Successfully Saved.");
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

    var VCId = $(item).closest("tr").find('#editVBID').text();
    var VCName = $(item).closest("tr").find('#editVBName').text();
    var CompanyName = $(item).closest("tr").find('#editVBCID').text();
    var IsVisibleChkedit = JSON.parse($(item).closest("tr").find('#IsVisibleChk').text());

    $('.EditVCId').val(VCId.trim());
    $('.EditVCnameadd').val(VCName.trim());
    $('.companylistedit').val(CompanyName).trigger('change');
    $('#chkactive').attr("checked", IsVisibleChkedit);

}

function EditVC() {
    let isChecked = $('#chkactive').is(':checked');

    var VCEditObj = {
        VehicleBrandId: parseInt($('.EditVCId').val()),
        VehicleBrandName: $(".EditVCnameadd").val(),
        VehicleCompanyId: $(".companylistedit option:selected").val(),
        IsActive: isChecked

    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VCEditObj },
        url: '/VehicleBrands/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Vehicle Brand Successfully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
            else {

                Command: toastr["error"]("This Vehicle Brand not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
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

function Delete(item) {
    var vehicleBrandId = $(item).closest("tr").find('#editVBID').text();
    var objDelete = {
        VehicleBrandId: vehicleBrandId,
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
                url: '/VehicleBrands/Delete',
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