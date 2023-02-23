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

        var $name = newdatas.data[st].ServiceCenterName;

        var dealerName = newdatas.data[st].VehicleCompany ? newdatas.data[st].VehicleCompany.VehicleCompanyName : "Null";

        stutbl += '<tr>';

        stutbl += '<td class="visiblityhidden" hidden></td>';
        stutbl += '<td id="editSCID">' + newdatas.data[st].ServiceCenterId + '</td>';
        stutbl += '<td id="editSCName">' + newdatas.data[st].ServiceCenterName + '</td>';
        //stutbl += '<td id="editSCDealer">' + newdatas.data[st].VehicleCompany.VehicleCompanyName + '</td>';
        stutbl += '<td id="editSCDealer">' + dealerName  + '</td>';
      

        if (newdatas.data[st].DealerType === true) {
            stutbl += '<td id="editVCdealer"><span class="badge bg-label-warning" text-capitalized>Authorized Dealer</span></td>';
        }
        else {
            stutbl += '<td id="editVCdealer"><span class="badge bg-label-secondary" text-capitalized>UnAuthorized Dealer</span></td>';

        }

        if (newdatas.data[st].IsActive === true) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';

        }
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditBranch(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditCenter" ><i class="ti ti-edit ti-sm me-2"></i></a>';
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Service Center</span>',
                className: 'add-new btn btn-primary',
                attr: {
                    'data-bs-toggle': 'modal',
                    'data-bs-target': '#offcanvasCenter'
                }
            }
        ]
        


    });


}
$(document).ready(function () {
    var mydata = $('#UserDataJson').val();

    var newdata = JSON.parse(mydata);

    LoadTable(newdata);
    $(".isdealer").click(function () {
        if ($("#authorizeddealer").is(":checked") == true) {
            $(".isdealerauth").show("slow");
        }
        else {
            $(".isdealerauth").hide("slow");
        }
    });
});

var DealerLists = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/VehicleCompany/all',
    success: function (result) {
        DealerLists += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            if (result[i].isActive == true && result[i].isDeleted == false) {
                DealerLists += '<option value="' + result[i].vehicleCompanyId + '">' + result[i].vehicleCompanyName + '</option>';
            }
        }
        $("#DealerList").html(DealerLists);
        $("#EditDealerList").html(DealerLists);

    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});


function SaveVC() {


    var servicename_validation = $(".Addservicenameadd").val();
    var servicecontact_validation = $(".Addservicecontactadd").val();
    var servicecontact_validation = $(".Addservicepersonadd").val();
    var Dealerlist_validation = $("#DealerList").val();
    /**Validation**/
    $('.Addservicenameadd').on("input", function () {
        $('.Addservicenameadd').next(".error-message").hide();
        $('.Addservicenameadd').css('border', 'none');
        $('.Addservicenameadd').css('background', '#d8f9d8');
    });
    if (servicename_validation == null || servicename_validation == undefined || servicename_validation == "" || servicename_validation == " ") {
        $('.Addservicenameadd').next(".error-message").text("* Service Name Required");
        $('.Addservicenameadd').next(".error-message").show();
        $('.Addservicenameadd').css('border', '1px solid red');
        $('.Addservicenameadd').css('background', '#fff');
        $('.Addservicenameadd').focus();
        return false;
    }
    $('.Addservicecontactadd').on("input", function () {
        $('.Addservicecontactadd').next(".error-message").hide();
        $('.Addservicecontactadd').css('border', 'none');
        $('.Addservicecontactadd').css('background', '#d8f9d8');
    });
    if (servicecontact_validation == null || servicecontact_validation == undefined || servicecontact_validation == "" || servicecontact_validation == " ") {
        $('.Addservicecontactadd').next(".error-message").text("* Contact Number Required");
        $('.Addservicecontactadd').next(".error-message").show();
        $('.Addservicecontactadd').css('border', '1px solid red');
        $('.Addservicecontactadd').css('background', '#fff');
        $('.Addservicecontactadd').focus();
        return false;
    }

    $('.DealerList').change("select", function () {
        $('.DealerList').next(".error-message").hide();
        $('.DealerList').css('border', 'none');
        $('.DealerList').css('background', '#d8f9d8');
    });
    if (Dealerlist_validation == null || Dealerlist_validation == undefined || Dealerlist_validation == "" || Dealerlist_validation == " ") {
        $('.DealerList').next(".error-message").text("* Dealer Required");
        $('.DealerList').next(".error-message").show();
        $('.DealerList').css('border', '1px solid red');
        $('.DealerList').css('background', '#fff');
        $('.DealerList').focus();
        return false;
    }

    /**Validation**/

    
    let isChecked = $('#authorizeddealer').is(':checked');

    var SCObj = {
        ServiceCenterId: 0,
        ServiceCenterName: $('.Addservicenameadd').val(),
        ContactNo: $('.Addservicecontactadd').val(),
        ContactPersonName: $('.Addservicepersonadd').val(),
        DealerType: isChecked,//$('.VCnameadd').val(),
        DealerID: $('#DealerList option:selected').val()
       }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: SCObj },
        url: '/ServiceCenter/Upsert',
        success: function (result) {
            if (result.datasuccess == true) {
                Command: toastr["success"]("This Service Center Succefully Saved.");
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

    var SCId = $(item).closest("tr").find('#editSCID').text();
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/ServiceCenter/' + SCId,
        success: function (result) {

            $('.EditserviceId').val(SCId);
            $('.Editservicenameadd').val(result.serviceCenterName);
            $('.Editservicecontactadd').val(result.contactNo);
            $('.Editservicepersonadd').val(result.contactPersonName);
            //$('#editvehicleColor').val(result.dealerType);
            $('#EditDealerList').val(result.dealerID).trigger('change');
            $('#chkactive').attr("checked", result.isActive);
          //  Editserviceaddressadd

        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });


}
function Editservice() {
    let isChecked = $('#chkactive').is(':checked');

    var SCEditObj = {
        ServiceCenterId: $('.EditserviceId').val(),
        ServiceCenterName: $('.Editservicenameadd').val(),
        ContactNo: $('.Editservicecontactadd').val(),
        ContactPersonName: $('.Editservicepersonadd').val(),
        DealerType: true,//$('.VCnameadd').val(),
        DealerID: $('#EditDealerList option:selected').val(),
        IsActive: isChecked


    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: SCEditObj },
        url: '/ServiceCenter/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Service Center SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
            else {

                Command: toastr["error"]("This Service Center not Succefully Edit. \n Somthing Went Wrongs.");
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
    var serviceCenterId = $(item).closest("tr").find('#editSCID').text();
    var objDelete = {
        ServiceCenterId: serviceCenterId,
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
                url: '/ServiceCenter/Delete',
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
const formValidationExamples = document.getElementById('addNewUserForm1');
const fv = FormValidation.formValidation(formValidationExamples, {
    fields: {
        ServiceCenter: {
            validators: {
                notEmpty: {
                    message: 'Please enter Service Center'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        ContantNumber: {
            validators: {
                notEmpty: {
                    message: 'Please enter Contant Number'
                },
                regexp: {
                    regexp: /^[0-9]+$/,
                    message: 'The Contant Number can only consist of number'
                }
            }
        },
        ContantPersonName: {
            validators: {
                notEmpty: {
                    message: 'Please enter Contant Person Name'
                },
               
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        ServiceCenterAddress: {
            validators: {
                notEmpty: {
                    message: 'Please enter Service Center Address'
                },
            }
        },
        Dealer: {
            validators: {
                notEmpty: {
                    message: 'Please confirm password'
                },
            }
        },
       
    },
    plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
            // Use this for enabling/changing valid/invalid class
            // eleInvalidClass: '',
        
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




//------------- edit validations-----------------------------
const editformValidationExamples = document.getElementById('EditNewUserForm');
const editfv = FormValidation.formValidation(editformValidationExamples, {
    fields: {
        editServiceCenter: {
            validators: {
                notEmpty: {
                    message: 'Please enter Service Center'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        editContantNumber: {
            validators: {
                notEmpty: {
                    message: 'Please enter Contant Number'
                },
                regexp: {
                    regexp: /^[0-9]+$/,
                    message: 'The Contant Number can only consist of number'
                }
            }
        },
        editContantPersonName: {
            validators: {
                notEmpty: {
                    message: 'Please enter Contant Person Name'
                },

                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        editServiceCenterAddress: {
            validators: {
                notEmpty: {
                    message: 'Please enter Service Center Address'
                },
            }
        },
        editDealer: {
            validators: {
                notEmpty: {
                    message: 'Please confirm password'
                },
            }
        },

    },
    plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({

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
    Editservice();
});
//-------------Add validations End-----------------------------