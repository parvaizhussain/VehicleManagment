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

        var $name = newdatas.data[st].VehicleERP;
        var $output = '<i class="ti ti-car" data-icon="ti ti-car"></i>';

        stutbl += '<tr>';

        stutbl += '<td class="visiblityhidden"></td>';
        stutbl += '<td id="editVehicleDetailID">' + newdatas.data[st].VehicleID + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].VehicleName + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].VehicleNum + '</td>';
        stutbl += '<td id="editVBName">' + $name + '</td>';
        stutbl += '<td id="editVBCID" hidden="hidden">' + newdatas.data[st].VehicleBrandID + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].VehicleBrands.VehicleBrandName + '</td>';
       
       
        if (newdatas.data[st].IsActive !== true) {
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

    $('#vehicleRegion').on('change', function () {
            // Revalidate the color field when an option is chosen
        fv.revalidateField('vehicleRegion');
        });

    $('#vehicleBrands').on('change', function () {
        // Revalidate the color field when an option is chosen
        fv.revalidateField('vehicleBrands');
    });
    $('#editvehicleRegion').on('change', function () {
        // Revalidate the color field when an option is chosen
        editfv.revalidateField('editvehicleRegion');
    });

    $('#editvehicleBrands').on('change', function () {
        // Revalidate the color field when an option is chosen
        editfv.revalidateField('editvehicleBrands');
    });


});


var Comapnydropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/vehiclebrands/all',
    success: function (result) {
        Comapnydropdown += '<option value="" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            if (result[i].isActive == true && result[i].isDeleted == false) {
                Comapnydropdown += '<option value="' + result[i].vehicleBrandId + '">' + result[i].vehicleBrandName + '</option>';
            }
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

            if (result[i].isActive == true && result[i].isDeleted == false) {
                Regiondropdown += '<option value="' + result[i].regionId + '">' + result[i].regionName + '</option>';
            }
        }
        $(".regionlist").html(Regiondropdown);


    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});







function SaveVC() {


    var VDetailsObj = {
        vehicleID: 0,

        VehicleERP: $('#VehicleERP').val(),
        VehicleBrandsVehicleBrandId: $('#vehicleBrands option:selected').val(),
        VehicleBrandID: $('#vehicleBrands option:selected').val(),
        VehicleNum: $('#vehicleNO').val(),
        VehicleName: $('#vehicleName').val(),
        VehicleColor: $('#vehicleColor').val(),
        PurchaseDate: $('#PurchaseDate').val(),
        VehicleType: $('#VehicleType').val(),
        VehicleMilage: $('#vehicleMilage').val(),
        VehicleModel: $('#vehicleModel').val(),
        FuelType: $('#FuelType').val(),
        RegionID: $('#vehicleRegion option:selected').val(),

    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VDetailsObj },
        url: '/VehicleDetails/Upsert',
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
function ShowEditBranch(item) {
 var VCId = $(item).closest("tr").find('#editVehicleDetailID').text();
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/vehicledetails/' + VCId,
        success: function (result) {
            
            $('#editVehicleERP').val(result.vehicleERP);
            $('#editvehicleBrands').val(result.vehicleBrandID).trigger('change');
            $('#editvehicleNO').val(result.vehicleNum);
            $('#editvehicleName').val(result.vehicleName);
            $('#editvehicleColor').val(result.vehicleColor);
            dateSetflat(result.purchaseDate, $('#editPurchaseDate'));
           // $('#editPurchaseDate').val(result.purchaseDate);
            $('#editVehicleType').val(result.vehicleType);
            $('#editvehicleMilage').val(result.vehicleMilage);
            $('#editvehicleModel').val(result.vehicleModel);
            $('#editFuelType').val(result.fuelType);
            $('#editvehicleRegion').val(result.regionID).trigger('change');
            $('#editvehicleID').val(result.vehicleID);
            $('#chkactive').attr("checked", result.isActive);

        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });

}
function EditVC() {
    let isChecked = $('#chkactive').is(':checked');

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
        IsActive: isChecked


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
function Delete(item) {
    var vehicleID = $(item).closest("tr").find('#editVehicleDetailID').text();
    var objDelete = {
        VehicleID: vehicleID,
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
                url: '/VehicleDetails/Delete',
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


//------------- Add validations-----------------------------
const formValidationExamples = document.getElementById('AddUserForm');
const fv = FormValidation.formValidation(formValidationExamples, {
    fields: {
        vehicleName: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle name'
                },
                //stringLength: {
                //    min: 6,
                //    max: 30,
                //    message: 'The name must be more than 6 and less than 30 characters long'
                //},
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        VehicleERP: {
            validators: {
                notEmpty: {
                    message: 'Please enter Vehicle ERP'
                },
                stringLength: {
                    min: 1,
                    max: 6,
                    message: 'The Vehicle ERP must be more than 1 and less than 6 characters long'
                },
                regexp: {
                    regexp: /^[0-9 ]+$/,
                    message: 'The Vehicle ERP can only consist of numbers'
                }
            }
        },
        vehicleBrands: {
            validators: {
                //notEmpty: {
                //    message: 'Please select vehicle Brands Name',
                //},
                callback: {
                    message: 'Please select vehicle Brands Name',
                    callback: function (input)
                    {
                        return input.value > 0;                        
                    }
                    
                }
            }
        },
        vehicleNO: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle NO'
                },
               
            }
        },
        vehicleColor: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle Color'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
                
            }
        },
        PurchaseDate: {
            validators: {
                notEmpty: {
                    message: 'Please enter Purchase Date'
                }
            }
        },
        VehicleType: {
            validators: {
                notEmpty: {
                    message: 'Please enter Vehicle Type'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        vehicleModel: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle Model'
                }
            },
            regexp: {
                regexp: /^[0-9 ]+$/,
                message: 'The name can only consist of alphabeticals and space'
            }
        },
        FuelType: {
            validators: {
                notEmpty: {
                    message: 'Please enter Fuel Type'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        vehicleRegion: {
            validators: {
                callback: {
                    message: 'Please select vehicle Region Name',
                    callback: function (input) {
                        return input.value > 0;
                    }

                }
            }
        },
        vehicleMilage: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle Milage'
                },
                regexp: {
                    regexp: /^[0-9 ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
    
        
        
      
    },
    plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
            // Use this for enabling/changing valid/invalid class
            // eleInvalidClass: '',
            eleValidClass: '',
            rowSelector: function (field, ele) {
                // field is the field name & ele is the field element
                switch (field) {
                    //case 'formValidationName':
                    case 'vehicleName':
                    case 'VehicleERP':
                    case 'vehicleBrands':
                    case 'vehicleNO':
                    case 'vehicleColor':
                    case 'PurchaseDate':
                    case 'VehicleType':
                    case 'vehicleModel':
                    case 'FuelType':
                    case 'vehicleRegion':
                    case 'vehicleMilage':
                   
                 
                    default:
                        return '.row';
                }
            }
        }),
        submitButton: new FormValidation.plugins.SubmitButton(),
       
        // Submit the form when all fields are valid
        // defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
        autoFocus: new FormValidation.plugins.AutoFocus()
    },
    init: instance => {
        instance.on('plugins.message.placed', function (e) {
            //* Move the error message out of the `input-group` element
            if (e.element.parentElement.classList.contains('input-group')) {
                // `e.field`: The field name
                // `e.messageElement`: The message element
                // `e.element`: The field element
                e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
            //* Move the error message out of the `row` element for custom-options
            if (e.element.parentElement.parentElement.classList.contains('custom-option')) {
                e.element.closest('.row').insertAdjacentElement('afterend', e.messageElement);
            }
        });
    }
}).on('core.form.valid', function (event) {
    SaveVC();

});

//-------------Add validations End-----------------------------


//------------- Edit validations-----------------------------
const editformValidationExamples = document.getElementById('editUserForm');
const editfv = FormValidation.formValidation(editformValidationExamples, {
    fields: {
        editvehicleName: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle name'
                },
                //stringLength: {
                //    min: 6,
                //    max: 30,
                //    message: 'The name must be more than 6 and less than 30 characters long'
                //},
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        editVehicleERP: {
            validators: {
                notEmpty: {
                    message: 'Please enter Vehicle ERP'
                },
                stringLength: {
                    min: 1,
                    max: 6,
                    message: 'The Vehicle ERP must be more than 1 and less than 6 characters long'
                },
                regexp: {
                    regexp: /^[0-9 ]+$/,
                    message: 'The Vehicle ERP can only consist of numbers'
                }
            }
        },
        editvehicleBrands: {
            validators: {
                //notEmpty: {
                //    message: 'Please select vehicle Brands Name',
                //},
                callback: {
                    message: 'Please select vehicle Brands Name',
                    callback: function (input) {
                        return input.value > 0;
                    }

                }
            }
        },
        editvehicleNO: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle NO'
                },

            }
        },
        editvehicleColor: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle Color'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }

            }
        },
        editPurchaseDate: {
            validators: {
                notEmpty: {
                    message: 'Please enter Purchase Date'
                }
            }
        },
        editVehicleType: {
            validators: {
                notEmpty: {
                    message: 'Please enter Vehicle Type'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        editvehicleModel: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle Model'
                }
            },
            regexp: {
                regexp: /^[0-9 ]+$/,
                message: 'The name can only consist of alphabeticals and space'
            }
        },
        editFuelType: {
            validators: {
                notEmpty: {
                    message: 'Please enter Fuel Type'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        editvehicleRegion: {
            validators: {
                callback: {
                    message: 'Please select vehicle Region Name',
                    callback: function (input) {
                        return input.value > 0;
                    }

                }
            }
        },
        editvehicleMilage: {
            validators: {
                notEmpty: {
                    message: 'Please enter vehicle Milage'
                },
                regexp: {
                    regexp: /^[0-9 ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },

    },
    plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
            // Use this for enabling/changing valid/invalid class
            // eleInvalidClass: '',
            eleValidClass: '',
            rowSelector: function (field, ele) {
                // field is the field name & ele is the field element
                switch (field) {
                    //case 'formValidationName':
                    case 'editvehicleName':
                    case 'editVehicleERP':
                    case 'editvehicleBrands':
                    case 'editvehicleNO':
                    case 'editvehicleColor':
                    case 'editPurchaseDate':
                    case 'editVehicleType':
                    case 'editvehicleModel':
                    case 'editFuelType':
                    case 'editvehicleRegion':
                    case 'editvehicleMilage':


                    default:
                        return '.row';
                }
            }
        }),
        submitButton: new FormValidation.plugins.SubmitButton(),

        // Submit the form when all fields are valid
        // defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
        autoFocus: new FormValidation.plugins.AutoFocus()
    },
    init: instance => {
        instance.on('plugins.message.placed', function (e) {
            //* Move the error message out of the `input-group` element
            if (e.element.parentElement.classList.contains('input-group')) {
                // `e.field`: The field name
                // `e.messageElement`: The message element
                // `e.element`: The field element
                e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
            }
            //* Move the error message out of the `row` element for custom-options
            if (e.element.parentElement.parentElement.classList.contains('custom-option')) {
                e.element.closest('.row').insertAdjacentElement('afterend', e.messageElement);
            }
        });
    }
}).on('core.form.valid', function (event) {
    EditVC();

});

//-------------Add validations End-----------------------------
