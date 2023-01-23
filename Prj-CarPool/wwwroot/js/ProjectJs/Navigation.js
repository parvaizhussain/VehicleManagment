/***parent menu**/
function LoadTable(newdatas) {
  
    var stutbl = '';
    $(".datatables-users-mytable tbody").html('');
    var statusObj = {
        1: { title: 'Pending', class: 'bg-label-warning' },
        2: { title: 'Active', class: 'bg-label-success' },
        3: { title: 'Inactive', class: 'bg-label-secondary' }
    };

    for (var st = 0; st < newdatas.data.length; st++) {

        var $name = newdatas.data[st].Name;
        $email = "";
        $image = newdatas.data[st].CssClass;
        if ($image) {
            // For Avatar image
            var $output =
                // '<img src="' + assetsPath + 'img/avatars/' + $image + '" alt="Avatar" class="rounded-circle">';
                '<i id="editNavIcon" class="' + $image +'" data-icon="'+$image+'" ></i>';
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
        stutbl += '<td id="editNavID">' + newdatas.data[st].Id + '</td>';
        stutbl += '<td>';
        stutbl += '<div id="editNavName" class="d-flex justify-content-start align-items-center user-name">';
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
        stutbl += '<td id="editNavControllerName"> <span class="fw-semibold">' + newdatas.data[st].ControllerName + '</span></td>';
        stutbl += '<td id="editNavParentMenuName">' + newdatas.data[st].ParentMenuName + '</td>';
        stutbl += '<td id="editNavParentMenuID" class="visiblityhidden">' + newdatas.data[st].ParentMenuId + '</td>';
        if (newdatas.data[st].Visible == true) {
            stutbl += '<td id="editNavVisible"><span class="badge bg-label-secondary" text-capitalized>Active</span></td>';
        }
        else {
            stutbl += '<td id="editNavVisible"><span class="badge bg-label-success" text-capitalized>Inactive</span></td>';

        }
        stutbl += '<td id="editNavDisplayOrder">' + newdatas.data[st].DisplayOrder + '</td>';

        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditNavigations(this)" class="text-body" data-bs-toggle="offcanvas" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Navigation</span>',
                className: 'add-new btn btn-primary',
                attr: {
                    'data-bs-toggle': 'offcanvas',
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
        $(".editSnavigationparentmenu").html(parnetmenudropdown);
    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});

var iconmenudropdown = "";
$.ajax({
    type: 'POST',
    async: false,
    url: 'https://localhost:7010/Navigation/IconList',
    success: function (result) {
        iconmenudropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">Select</option>';
        for (var i = 0; i < result.length; i++) {
           
                iconmenudropdown += '<option value="' + result[i].className + '" data-icon="' + result[i].className + '">' + result[i].iconName + '</option>';
        }
        $(".myselectpickerIcons").html(iconmenudropdown);
        $(".editmyselectpickerIcons").html(iconmenudropdown);
    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});



function ShowEditNavigations(item) {

    var navigationidedit = $(item).closest("tr").find('#editNavID').text();
    // var navigationshortnameedit = $(item).closest("tr").find('.navigationshortnameedit').text();
    var navigationnameedit = $(item).closest("tr").find('#editNavName').text();
    var navigationcontrolleredit = $(item).closest("tr").find('#editNavControllerName').text();
    var navigationparentmenuidedit = $(item).closest("tr").find('#editNavParentMenuID').text();
    var navigationvisibleedit = true;//$(item).closest("tr").find('.navigationvisibleedit input').prop('checked') == true ? "checked" : "";
    var navigationdisplayorderedit = $(item).closest("tr").find('#editNavDisplayOrder').text();
    var navigationdIconedit = $(item).closest("tr").find('#editNavIcon').data('icon');
    

    

    $('.editmenuID').val(navigationidedit.trim());
    $('.editmenuName').val(navigationnameedit.trim());
    $('.editmenuController').val(navigationcontrolleredit.trim());
    $('.editSnavigationparentmenu').val(navigationparentmenuidedit).trigger('change');
   // $('.editmenuName').val(navigationvisibleedit);
    $('.editmenuDisplayorder').val(navigationdisplayorderedit.trim());
    $('.selectpicker').selectpicker('val', navigationdIconedit);

}
function EditNav() {

    var navid = $('.editmenuID').val();
    navid = parseInt(navid);
    var val = $('.editmyselectpickerIcons option:selected').data('icon');
    var navigationparentmenuvalidation = $(".editSnavigationparentmenu option:Selected").val();


    var navigationObj = {
        Id: parseInt(navid),
        Name: $(".editmenuName").val(),
        ControllerName: $(".editmenuController").val(),
        ParentMenuId: navigationparentmenuvalidation,
        DisplayOrder: parseInt($(".editmenuDisplayorder").val()),
        Visible: true,//$('#visiblecheckbox').is(':checked'),
        CssClass: val

    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { viewModel: navigationObj },
        url: '/navigation/EditNavigation',
        success: function (result) {
            
            if (result.datasuccess == true) {

                Command: toastr["success"]("Navigation SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
            }
            else {

                Command: toastr["error"]("This Navigation not Succefully Edit. \n Somthing Went Wrongs.");
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

function SaveNavigation() {
    var navid = $('.navigationparentmenu option:last-child').val();
    navid = parseInt(navid) + 1;
    var val = $('.myselectpickerIcons option:selected').data('icon');
    var navigationparentmenuvalidation = $(".navigationparentmenu option:Selected").val();

    navigationparentmenuvalidation = navigationparentmenuvalidation == "0" ? null : parseInt(navigationparentmenuvalidation);

    var navigationObj = {
        Id: parseInt(navid),
        Name: $(".menuName").val(),
        ControllerName: $(".menuController").val(),
        ParentMenuId: navigationparentmenuvalidation, 
        DisplayOrder: parseInt($(".menuDisplayorder").val()),
        Visible: true,//$('#visiblecheckbox').is(':checked'),
        CssClass: val

    }
    $.ajax({
       
        type: 'POST',
        async: false,
        data: { viewModel: navigationObj },
        url: '/navigation/CreateNavigation',
        success: function (result) {
          
            if (result.datasuccess == true) {
                
                Command: toastr["success"]("Navigation SuccessFully Added !");
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

            $('#btnCancel').click();


        },
        error: function (err) {
            Command: toastr["error"](err);
           // console.log("Error" + err);
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
