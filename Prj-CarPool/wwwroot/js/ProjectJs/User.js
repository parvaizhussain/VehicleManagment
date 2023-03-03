function LoadTable(newdatas) {
        console.log(newdatas);
        var stutbl = '';
   var statusObj = {
            1: { title: 'Pending', class: 'bg-label-warning' },
            2: { title: 'Active', class: 'bg-label-success' },
            3: { title: 'Inactive', class: 'bg-label-secondary' }
        };
     
        for (var st = 0; st < newdatas.data.length; st++) {

            var $name = newdatas.data[st].FirstName + " " + newdatas.data[st].LastName;
            $email = newdatas.data[st].Email;
            $image = newdatas.data[st].UserImage;
                            if ($image) {
                                // For Avatar image
                                var $output =
                                    '<img src="data:image/png;base64,' + $image + '" alt="Avatar" class="rounded-circle">';
                            } else {
                                // For Avatar badge
                                var stateNum = Math.floor(Math.random() * 6);
                                var states = ['success', 'danger', 'warning', 'info', 'primary', 'secondary'];
                                var $state = states[stateNum],
                                    $name = newdatas.data[st].FirstName + " " + newdatas.data[st].LastName,
                                    $initials = $name.match(/\b\w/g) || [];
                                $initials = (($initials.shift() || '') + ($initials.pop() || '')).toUpperCase();
                                $output = '<span class="avatar-initial rounded-circle bg-label-' + $state + '">' + $initials + '</span>';
                            }
                            // Creates full output for row
                            

            stutbl += '<tr>';
           
            stutbl += '<td id="UserID" class="visiblityhidden">' + newdatas.data[st].Id +'</td>';
            stutbl+='<td>';
            stutbl+='<div class="d-flex justify-content-start align-items-center user-name">';
            stutbl += '<div class="avatar-wrapper">';
            stutbl+='<div class="avatar avatar-sm me-3">';

            stutbl+=$output;
            stutbl+='</div>';
            stutbl+='</div>';
            stutbl+='<div class="d-flex flex-column">';
            stutbl+='<a href="#" class="text-body text-truncate"><span class="fw-semibold">';
            stutbl+=$name;
            stutbl+='</span></a>';
            stutbl+='<small class="text-muted">';
            stutbl+=$email;
            stutbl+='</small>';
            stutbl+='</div>';
            stutbl+='</div>';
            stutbl += '</td>';
            stutbl += '<td>' + newdatas.data[st].Roles[0].Name + '</td>';
            stutbl += '<td>' + newdatas.data[st].AccessRights.AccessName +'</td>';
            stutbl += '<td>' + newdatas.data[st].Region.RegionName + '</td>';
           
            if (newdatas.data[st].IsActive !== true) {
                stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
            }
            else {
                stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

            }
            stutbl += '<td><div class="d-flex align-items-center">';
            stutbl += '<a  onclick ="ShowEditBranch(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#EditoffcanvasAddUser" ><i class="ti ti-edit ti-sm me-2"></i></a>';
            stutbl += '<a onclick ="Delete(this)" class="text-body delete-record"><i class="ti ti-trash ti-sm mx-2"></i></a>';
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
            {
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New User</span>',
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

    $('#AccessRightsSelect2').on('change', function () {
        // Revalidate the color field when an option is chosen
        fv.revalidateField('AccessRightsSelect2');
    });
    $('#RoleSelect2').on('change', function () {
        // Revalidate the color field when an option is chosen
        fv.revalidateField('RoleSelect2');
    });
    $('#RegionSelect2').on('change', function () {
        // Revalidate the color field when an option is chosen
        fv.revalidateField('RegionSelect2');
    });
    $('#editAccessRightsSelect2').on('change', function () {
        // Revalidate the color field when an option is chosen
        editfv.revalidateField('editAccessRightsSelect2');
    });
    $('#editRoleSelect2').on('change', function () {
        // Revalidate the color field when an option is chosen
        editfv.revalidateField('editRoleSelect2');
    });
    $('#editRegionSelect2').on('change', function () {
        // Revalidate the color field when an option is chosen
        editfv.revalidateField('editRegionSelect2');
    });

});

var accessrightslist = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/AccessRights/all',
    success: function (result) {
        accessrightslist += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            if (result[i].isActive == true && result[i].isDeleted == false) {
                accessrightslist += '<option value="' + result[i].accessId + '">' + result[i].accessName + '</option>';
            }
        }
        $(".accessrights_list").html(accessrightslist);
        //$(".accessrights_list").val('');
        //$(".editaccessrights_list").html(Regiondropdown);
      

    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});
var roleList = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'Role/GetAll',
    success: function (result) {
        roleList += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            
                roleList += '<option value="' + result[i].id + '">' + result[i].name + '</option>';
           
        }
        $(".role_list").html(roleList);
       // $(".role_list").val('');
        $(".editrole_list").html(roleList);
      //  $(".editrole_list").val('');
        //$(".editaccessrights_list").html(Regiondropdown);


    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});
var regionList = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/Region/all',
    success: function (result) {
        regionList += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            if (result[i].isActive == true && result[i].isDeleted == false) {
                regionList += '<option value="' + result[i].regionId + '">' + result[i].regionName + '</option>';
            }
        }
        $(".regionlist").html(regionList);
       // $(".regionlist").val('');
        //$(".editaccessrights_list").html(Regiondropdown);


    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});




//--===========================Pass====================================
const strongPassword = function () {
    return {
        validate: function (input) {
            const value = input.value;
            if (value === '') {
                return {
                    valid: true,
                };
            }

            // Check the password strength
            if (value.length < 8) {
                return {
                    valid: false,
                };
            }

            // The password does not contain any uppercase character
            if (value === value.toLowerCase()) {
                return {
                    valid: false,
                };
            }

            // The password does not contain any uppercase character
            if (value === value.toUpperCase()) {
                return {
                    valid: false,
                };
            }

            // The password does not contain any digit
            if (value.search(/[0-9]/) < 0) {
                return {
                    valid: false,
                };
            }

            return {
                valid: true,
            };
        },
    };
};
//--===========================Pass====================================
FormValidation.validators.checkPassword = strongPassword;
/*FormValidation.validators.checkEmail = emailcsnValidate;*/
//------------- Add validations-----------------------------
const formValidationExamples = document.getElementById('formValidationExamples');
const fv = FormValidation.formValidation(formValidationExamples, {
    fields: {
        FirstName: {
            validators: {
                notEmpty: {
                    message: 'Please enter First name'
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
        LastName: {
            validators: {
                notEmpty: {
                    message: 'Please enter Last name'
                },
                //stringLength: {
                //    min: 6,
                //    max: 30,
                //    message: 'The name must be more than 6 and less than 30 characters long'
                //},
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabetical and space'
                }
            }
        },
        UserName: {
            validators: {
                notEmpty: {
                    message: 'Please enter your email'
                },
                emailAddress: {
                    message: 'The value is not a valid email address'
                },
                regexp: {
                    regexp: /^[a-zA-Z0-9._%+-]+@csn.edu.pk$/,
                    message: 'No email apart from csn.edu.pk is allowed. The email must end with "@csn.edu.pk'
                }
            }
        },
        Password: {
            validators: {
                notEmpty: {
                    message: 'Please enter your password'
                },
                checkPassword: {
                    message: 'The password is too weak'
                },
            }
        },
        formValidationConfirmPass: {
            validators: {
                notEmpty: {
                    message: 'Please confirm password'
                },
                identical: {
                    compare: function () {
                        return formValidationExamples.querySelector('[name="Password"]').value;
                    },
                    message: 'The password and its confirm are not the same'
                }
            }
        },

        //formValidationFile: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select the file'
        //        }
        //    }
        //},
        //formValidationDob: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select your DOB'
        //        },
        //        date: {
        //            format: 'YYYY/MM/DD',
        //            message: 'The value is not a valid date'
        //        }
        //    }
        //},
        AccessRightsSelect2: {
            validators: {
                callback: {
                    message: 'Please Select Access Rights',
                    callback: function (value, validator, $field) {

                        return value.value > 0;
                    }
                }
            }
        },
        RoleSelect2: {
            validators: {
                callback: {
                    message: 'Please Select Role',
                    callback: function (value, validator, $field) {

                        return value.value !== "0";
                    }
                }
            }
        },
        RegionSelect2: {
            validators: {
                callback: {
                    message: 'Please Select Region',
                    callback: function (value, validator, $field) {

                        return value.value > 0;
                    }
                }
            }
        },

        //formValidationLang: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please add your language'
        //        }
        //    }
        //},
        //formValidationTech: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select technology'
        //        }
        //    }
        //},
        //formValidationHobbies: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select your hobbies'
        //        }
        //    }
        //},
        //formValidationBio: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please enter your bio'
        //        },
        //        stringLength: {
        //            min: 100,
        //            max: 500,
        //            message: 'The bio must be more than 100 and less than 500 characters long'
        //        }
        //    }
        //},
        //formValidationGender: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select your gender'
        //        }
        //    }
        //},
        //formValidationPlan: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select your preferred plan'
        //        }
        //    }
        //},
        //formValidationSwitch: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please select your preference'
        //        }
        //    }
        //},
        //formValidationCheckbox: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please confirm our T&C'
        //        }
        //    }
        //}
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
                    case 'formValidationEmail':
                    case 'Password':
                    case 'formValidationConfirmPass':
                    case 'AccessRightsSelect2':
                    case 'RoleSelect2':
                    case 'RegionSelect2':
                    //case 'formValidationFile':
                    //case 'formValidationDob':
                    //case 'formValidationSelect2':
                    //case 'formValidationLang':
                    //case 'formValidationTech':
                    //case 'formValidationHobbies':
                    //case 'formValidationBio':
                    //case 'formValidationGender':
                    //    return '.col-md-6';
                    //case 'formValidationPlan':
                    //    return '.col-xl-3';
                    //case 'formValidationSwitch':
                    //case 'formValidationCheckbox':
                    //   return '.col-12';
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
   
    var rolearr = [];
    rolearr.push({
        Name: $(".role_list option:selected").text()
    })
    //const $form = $(demoForm);
    var objdata = {
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        UserName: $('#UserName').val(),
        Email: $('#UserName').val(),
        AccessRightsId: $('#AccessRightsSelect2 option:selected').val(),
        RegionId: $('#RegionSelect2 option:selected').val(),
        UserImage: null,
        Roles: rolearr,
        Password: $("#Password").val()

    };

    $.ajax({
        type: 'POST',
        async: false,
        url: 'User/CreateUser',
        data: { userViewModel: objdata },
        success: function (result) {
            if (result.created) {
                Command: toastr["success"](result.messeage);
                var mydata = result.dataresult;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);
                LoadTable(newdata);
                $('#btnCancelSave').click();
            }
            else {
                Command: toastr["error"](result.messeage);

            }

        },
        complete: function (result) {
          
        },
        error: function (err) { console.log(JSON.stringify(err)); }
        
    });

    
});
//-------------Add validations End-----------------------------


//------------- Edit validations-----------------------------
const editformValidationExamples = document.getElementById('editformValidationExamples');
const editfv = FormValidation.formValidation(editformValidationExamples, {
    fields: {
        editFirstName: {
            validators: {
                notEmpty: {
                    message: 'Please enter First name'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabeticals and space'
                }
            }
        },
        editLastName: {
            validators: {
                notEmpty: {
                    message: 'Please enter Last name'
                },
                regexp: {
                    regexp: /^[a-zA-Z ]+$/,
                    message: 'The name can only consist of alphabetical and space'
                }
            }
        },
        editUserName: {
            validators: {
                notEmpty: {
                    message: 'Please enter your email'
                },
                emailAddress: {
                    message: 'The value is not a valid email address'
                },
                regexp: {
                    regexp: /^[a-zA-Z0-9._%+-]+@csn.edu.pk$/,
                    message: 'No email apart from csn.edu.pk is allowed. The email must end with "@csn.edu.pk'
                }
            }
        },
        //editPassword: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please enter your password'
        //        },
        //        checkPassword: {
        //            message: 'The password is too weak'
        //        },
        //    }
        //},
        //editformValidationConfirmPass: {
        //    validators: {
        //        notEmpty: {
        //            message: 'Please confirm password'
        //        },
        //        identical: {
        //            compare: function () {
        //                return editformValidationExamples.querySelector('[name="editPassword"]').value;
        //            },
        //            message: 'The password and its confirm are not the same'
        //        }
        //    }
        //},
        editAccessRightsSelect2: {
            validators: {
                callback: {
                    message: 'Please Select Access Rights',
                    callback: function (value, validator, $field) {

                        return value.value > 0;
                    }
                }
            }
        },
        editRoleSelect2: {
            validators: {
                callback: {
                    message: 'Please Select Role',
                    callback: function (value, validator, $field) {

                        return value.value !== "0";
                    }
                }
            }
        },
        editRegionSelect2: {
            validators: {
                callback: {
                    message: 'Please Select Region',
                    callback: function (value, validator, $field) {

                        return value.value > 0;
                    }
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
                    case 'editformValidationEmail':
                   // case 'editPassword':
                  //  case 'editformValidationConfirmPass':
                    case 'editAccessRightsSelect2':
                    case 'editRoleSelect2':
                    case 'editRegionSelect2':
                    //case 'formValidationFile':
                    //case 'formValidationDob':
                    //case 'formValidationSelect2':
                    //case 'formValidationLang':
                    //case 'formValidationTech':
                    //case 'formValidationHobbies':
                    //case 'formValidationBio':
                    //case 'formValidationGender':
                    //    return '.col-md-6';
                    //case 'formValidationPlan':
                    //    return '.col-xl-3';
                    //case 'formValidationSwitch':
                    //case 'formValidationCheckbox':
                    //   return '.col-12';
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
    var rolearr = [];
    rolearr.push({
        Name: $(".editrole_list option:selected").text()
    })
   let isChecked = $('#chkactive').is(':checked');
   
    //const $form = $(demoForm);
    var objdata = {
        Id: $('#edituserid').val(),
        FirstName: $('#editFirstName').val(),
        LastName: $('#editLastName').val(),
        UserName: $('#editUserName').val(),
        Email: $('#editUserName').val(),
        AccessRightsId: $('#editAccessRightsSelect2 option:selected').val(),
        RegionId: $('#editRegionSelect2 option:selected').val(),
        UserImage: null,
        Roles: rolearr,
        Password: $("#editPassword").val(),
        Pwd: $("#editPassword").val(),
        IsActive: isChecked

    };
    $.ajax({
        type: 'POST',
        async: false,
        url: 'User/EditUser',
        data: { viewModel: objdata },
        success: function (result) {
            if (result.edited) {
                Command: toastr["success"](result.messeage);
                var mydata = result.dataresult;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);
                LoadTable(newdata);
                $('#btnCanceledit').click();
            }
            else {
                Command: toastr["error"](result.messeage);

            }

        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });


});
//-------------Edit validations End-----------------------------


function ShowEditBranch(item) {

    var userid = $(item).closest("tr").find('#UserID').text();
    $('#edituserid').val(userid);
    //let seditaccountUserImage = document.getElementById('edituploadedAvatar');
    $.ajax({
        type: 'POST',
        async: false,
        data: { id: userid },
        url: 'User/UserFind',
        success: function (result) {
            console.log(result);
           
            $('#editFirstName').val(result.data.firstName);
            $('#editLastName').val(result.data.lastName);
            $('#editUserName').val(result.data.userName);
            $('#editAccessRightsSelect2').val(result.data.accessRightsId).trigger('change');
            $('#editRegionSelect2').val(result.data.regionId).trigger('change');
            $('.editrole_list').val(result.data.roles[0].id).trigger('change');
            $('#chkactive').attr("checked", result.data.isActive);

              // $("#editPassword").val()

            //$('.editDriverId').val(VCId.trim());
            //$('.editDriverERP').val(result.driverERP);
            //$('.editDriverName').val(result.driverName);
            //$('.editDriverContact').val(result.driverContact);
            //$('.editDriverCNIC').val(result.driverCNIC);
            //$('.editDriverLicence').val(result.driverLicense);
            //if (result.driverImage !== "") {
            //    seditaccountUserImage.src = "data:image/png;base64," + result.driverImage;
            //}

            //$('.editregionlist').val(result.regionID).trigger('change');
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });

}

function Delete(item) {
    var UserID = $(item).closest("tr").find('#UserID').text();
    
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
                data: { Uid: UserID },
                url: '/User/DeleteUser',
                success: function (result) {
                    if (result.deleted) {
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
                }
            });





        }
    });
}

