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

        var $name = newdatas.data[st].BranchName;
        $email = "";
        $image = newdatas.data[st].CssClass;
        if ($image) {
            // For Avatar image
            var $output =
                // '<img src="' + assetsPath + 'img/avatars/' + $image + '" alt="Avatar" class="rounded-circle">';
                '<i id="editNavIcon" class="' + $image + '" data-icon="' + $image + '" ></i>';
        } else {
            // For Avatar badge
            //var stateNum = Math.floor(Math.random() * 6);
            //var states = ['success', 'danger', 'warning', 'info', 'primary', 'secondary'];
            //var $state = states[stateNum],
            //    $name = newdatas.data[st].Name,
            //    $initials = $name.match(/\b\w/g) || [];
            //$initials = (($initials.shift() || '') + ($initials.pop() || '')).toUpperCase();
            $output = '<i class="ti ti-menu-2" data-icon="ti ti-menu-2"></i>';// '<span class="avatar-initial rounded-circle bg-label-' + $state + '">' + $initials + '</span>';
        }
        // Creates full output for row


        stutbl += '<tr>';

        stutbl += '<td class="visiblityhidden"></td>';
        stutbl += '<td id="editbranchID">' + newdatas.data[st].BranchId + '</td>';
        stutbl += '<td>';
        stutbl += '<div id="editbranchName" class="d-flex justify-content-start align-items-center user-name">';
        stutbl += '<div class="avatar-wrapper">';
        stutbl += '<div class="avatar avatar-sm me-3">';

        stutbl += $output;
        stutbl += '</div>';
        stutbl += '</div>';
        stutbl += '<div class="d-flex flex-column">';
        stutbl += '<a href="#" class="text-body text-truncate"><span class="fw-semibold">';
        stutbl += $name;
        stutbl += '</span></a>';
        stutbl += '<small class="text-muted">';
        stutbl += $email;
        stutbl += '</small>';
        stutbl += '</div>';
        stutbl += '</div>';
        stutbl += '</td>';
        stutbl += '<td id="editBranchCode"> <span class="fw-semibold">' + newdatas.data[st].BranchCode + '</span></td>';
        stutbl += '<td id="editBranchNorm">' + newdatas.data[st].NormalizedName + '</td>';
        stutbl += '<td id="editBranchNetworkID">' + newdatas.data[st].Network.NetworkId + '</td>';
        stutbl += '<td id="editBranchNetworkName">' + newdatas.data[st].Network.NetworkName + '</td>';
        stutbl += '<td id="chkActiveEdit" hidden="hidden">' + newdatas.data[st].IsActive + '</td>';
        if (newdatas.data[st].IsActive == false) {
            stutbl += '<td id="editBranchVisible"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        }
        else {
            stutbl += '<td id="editBranchVisible"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        }
      

        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditBranch(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Branch</span>',
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


var Networkdropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/network/all',
    success: function (result) {
        Networkdropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            Networkdropdown += '<option value="' + result[i].networkId + '">' + result[i].networkName + '</option>';
        }
        $(".networklist").html(Networkdropdown);
        $(".Editnetworklist").html(Networkdropdown);
    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});





function ShowEditBranch(item) {

    var branchId = $(item).closest("tr").find('#editbranchID').text();
    // var navigationshortnameedit = $(item).closest("tr").find('.navigationshortnameedit').text();
    var branchName = $(item).closest("tr").find('#editbranchName').text();
    var BranchCOde = $(item).closest("tr").find('#editBranchCode').text();
    var branchnorm = $(item).closest("tr").find('#editBranchNorm').text();
    var networkID = $(item).closest("tr").find('#editBranchNetworkID').text();
    //var navigationvisibleedit = true;//$(item).closest("tr").find('.editBranchVisible input').prop('checked') == true ? "checked" : "";
    var IsVisibleChkedit = JSON.parse($(item).closest("tr").find('#chkActiveEdit').text());
    


    $('.EditbranchId').val(branchId.trim());
    $('.Editbranchnameadd').val(branchName.trim());
    $('.Editbranchcodeadd').val(BranchCOde.trim());
    $('.Editbranchshortnameadd').val(branchnorm.trim());
    $('.Editnetworklist').val(networkID).trigger('change');
    // $('.editmenuName').val(navigationvisibleedit);
    $('#chkactive').attr("checked", IsVisibleChkedit);
}
function EditBranch() {
    let isChecked = $('#chkactive').is(':checked');

    var EditbranchObj = {
        branchId: $('.EditbranchId').val(), 
        branchName: $('.Editbranchnameadd').val(),
        NormalizedName: $('.Editbranchshortnameadd').val().toUpperCase(),
        branchCode: $('.Editbranchcodeadd').val(),
        networkId: $('.Editnetworklist option:selected').val(),
        IsActive: isChecked
    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: EditbranchObj },
        url: '/Branch/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Branch SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
            }
            else {

                Command: toastr["error"]("This Branch not Succefully Edit. \n Somthing Went Wrongs.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
            }
        },
        complete: function (result) {

            var parnetmenudropdown = "";
            $.ajax({
                type: 'POST',
                async: false,
                url: 'https://localhost:7010/Navigation/MenuList',
                success: function (result) {
                    parnetmenudropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Parent</option>';
                    for (var i = 0; i < result.length; i++) {
                        parnetmenudropdown += '<option value="' + result[i].id + '">' + result[i].name + '</option>';
                    }
                    $(".navigationparentmenu").html(parnetmenudropdown);
                },
                complete: function (result) {

                },
                error: function (err) { console.log(JSON.stringify(err)); }

            });

            $('#btnCancelEdit').click();


        },
        error: function (err) {
            Command: toastr["error"]("This Navigation not Succefully Edit. \n Somthing Went Wrongs.");
            // console.log("Error" + err);
        }
    });
}

function SaveBranch() {
  

    var branchObj = {
        branchId: 0,
        branchName: $('.branchnameadd').val(),
        NormalizedName: $('.branchshortnameadd').val().toUpperCase(),
        branchCode: $('.branchcodeadd').val(),
        networkId: $('.networklist option:selected').val()
    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: branchObj },
        url: '/Branch/Upsert',
        success: function (result) {
            if (result.datasuccess == true) {
                Command: toastr["success"]("This Branch Succefully Saved.");
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
