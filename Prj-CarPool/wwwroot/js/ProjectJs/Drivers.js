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

        
        var $name = newdatas.data[st].DriverName;
        $image = newdatas.data[st].DriverImage;
        if ($image) {
            // For Avatar image
            var $output =
               '<img src="data:image/png;base64,' +  $image + '" alt="Avatar" class="rounded-circle">';
               /* '<i id="editNavIcon" class="' + $image + '" data-icon="' + $image + '" ></i>';*/
        } else {
            // For Avatar badge
            var stateNum = Math.floor(Math.random() * 6);
            var states = ['success', 'danger', 'warning', 'info', 'primary', 'secondary'];
            var $state = states[stateNum],
                $name = newdatas.data[st].DriverName,
                $initials = $name.match(/\b\w/g) || [];
            $initials = (($initials.shift() || '') + ($initials.pop() || '')).toUpperCase();
            $output = '<span class="avatar-initial rounded-circle bg-label-' + $state + '">' + $initials + '</span>';
        }

        stutbl += '<tr>';
       // stutbl += '<td><p id=dataView hidden="hidden">' + JSON.stringify(newdatas.data[st]) + '</p></td>';
        stutbl += '<td class="visiblityhidden"></td>';
        stutbl += '<td id="editVBID">' + newdatas.data[st].DriverID + '</td>';
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


        stutbl += '<td id="editVBCID">' + newdatas.data[st].DriverContact + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].DriverERP + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].DriverLicense + '</td>';
        stutbl += '<td id="editVBCName">' + newdatas.data[st].Region.RegionName + '</td>';
        if (newdatas.data[st].IsActive !== true) {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-danger" text-capitalized>InActive</span></td>';
        }
        else {
            stutbl += '<td id="editVCActive"><span class="badge bg-label-success" text-capitalized>Active</span></td>';

        }

        var objPass = JSON.stringify(newdatas.data[st]);
        stutbl += '<td><div class="d-flex align-items-center">';
        stutbl += '<a  onclick ="ShowEditBranch(this)" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasEditNav" ><i class="ti ti-edit ti-sm me-2"></i></a>';
        stutbl += '<a href="/" class="text-body delete-record"><i class="ti ti-trash ti-sm mx-2"></i></a>';
        stutbl += '<a  onclick="ViewDetails(' + "'" + objPass.replaceAll('"', '...') + "'" + ')" class="text-body" data-bs-toggle="modal" data-bs-target="#offcanvasViewNav" ><i class="ti ti-eye ti-sm me-2"></i></a>';
       /* stutbl += '<a href="/" class="text-body dropdown-toggle hide-arrow" data-bs-toggle="dropdown"><i class="ti ti-dots-vertical ti-sm mx-1"></i></a>';*/
        //stutbl += '<div class="dropdown-menu dropdown-menu-end m-0">';

        //stutbl += '<a onclick="ViewDetails(' + "'" + objPass.replaceAll('"', '...') + "'" + ')" class="dropdown-item" data-bs-toggle="modal" data-bs-target="#offcanvasViewNav"><i class="ti ti-eyes-vertical ti-sm mx-1"></i></a>';

        
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
                text: '<i class="ti ti-plus me-0 me-sm-1 ti-xs"></i><span class="d-none d-sm-inline-block">Add New Driver</span>',
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

var Regiondropdown = "";
$.ajax({
    type: 'GET',
    async: false,
    url: 'https://localhost:7112/api/Region/all',
    success: function (result) {
        Regiondropdown += '<option value="0" style="font-weight: bold;background: #d9d5d5;">No Select</option>';
        for (var i = 0; i < result.length; i++) {
            Regiondropdown += '<option value="' + result[i].regionId + '">' + result[i].regionName + '</option>';
        }
        $(".regionlist").html(Regiondropdown);
        $(".editregionlist").html(Regiondropdown);
       /* $(".companylistedit").html(Comapnydropdown);*/

    },
    complete: function (result) {

    },
    error: function (err) { console.log(JSON.stringify(err)); }

});

function encodeImageFileAsURL(element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        imagebase64 = reader.result;

    }
    reader.readAsDataURL(file);
}
async function SaveVC() {

    const fileInput = document.querySelector('.account-file-input');
    if (fileInput.files.length !== 0) {

        let byteArray = await fileToByteArray(fileInput.files[0]);
        var base64Data = btoa(String.fromCharCode.apply(null, byteArray));
    }
    else {
        var base64Data = null;
    }
    console.log(base64Data);

    var VCObj = {
        DriverID: 0,
        DriverERP: $('.addDriverERP').val(),
        DriverName: $('.addDriverName').val(),
        DriverContact: $('.addDriverContact').val(),
        DriverCNIC: $('.addDriverCNIC').val(),
        DriverLicense: $('.addDriverLicence').val(),
        DriverImage: base64Data,
        RegionID: $('.regionlist option:selected').val(),
        CityID: 1// $('.companylist option:selected').val(),
       
        }
        //convertUrlToBase64(accountUserImage.src),//fileReader.onload = processFile(fileInput.files[0]),

    $.ajax({

        type: 'POST',
        async: false,
        //contentType: false,
      //  processData: false,
        data: { Obj: VCObj },//formData,
      
        url: '/Drivers/Upsert',

        success: function (result) {
            if (result.datasuccess == true) {
                Command: toastr["success"]("This Driver Succefully Saved.");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);

                $('#btnCancelSave').click();
            }
            else {
                if (result.jsonerror) {
                    Command: toastr["error"](result.jsonerror);
                }
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
    $('.editDriverId').val(VCId.trim());
    let seditaccountUserImage = document.getElementById('edituploadedAvatar');
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/driver/' + VCId,
        success: function (result) {
            $('.editDriverId').val(VCId.trim());
            $('.editDriverERP').val(result.driverERP);
            $('.editDriverName').val(result.driverName);
            $('.editDriverContact').val(result.driverContact);
            $('.editDriverCNIC').val(result.driverCNIC);
            $('.editDriverLicence').val(result.driverLicense);
            $('#chkactive').attr("checked",result.isActive);
            if (result.driverImage !== "") {
                seditaccountUserImage.src = "data:image/png;base64," + result.driverImage;
            }
            
            $('.editregionlist').val(result.regionID).trigger('change');
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });

}

async function EditVC() {
    let isChecked = $('#chkactive').is(':checked');

    const editfileInput = document.querySelector('.edit-account-file-input');
    if (editfileInput.files.length !== 0) {

        let editbyteArray = await fileToByteArray(editfileInput.files[0]);
        var editbase64Data = btoa(String.fromCharCode.apply(null, editbyteArray));
    }
    else {
        let editaccountUserImage = document.getElementById('edituploadedAvatar');
        if (editaccountUserImage.src.includes("/CityLogo/defaultAvatar.jpg")) {
            var editbase64Data = null;
            console.log(editbase64Data);
        }
        else {
           var editbase64Data = editaccountUserImage.src.split(",")[1];
            console.log(editbase64Data);
        }
    }
   // console.log(base64Data);
    var VCEditObj = {
        DriverID: $('.editDriverId').val(),
        DriverERP: $('.editDriverERP').val(),
        DriverName: $('.editDriverName').val(),
        DriverContact: $('.editDriverContact').val(),
        DriverCNIC: $('.editDriverCNIC').val(),
        DriverLicense: $('.editDriverLicence').val(),
        DriverImage: editbase64Data,
        RegionID: $('.editregionlist option:selected').val(),
        CityID: 1,// $('.companylist option:selected').val(),
        IsActive: isChecked

    }
    $.ajax({

        type: 'POST',
        async: false,
        data: { Obj: VCEditObj },
        url: '/Drivers/Upsert',
        success: function (result) {

            if (result.datasuccess == true) {

                Command: toastr["success"]("Driver SuccessFully Edited !");
                var mydata = result.json;// $('#UserDataJson').val();
                var newdata = JSON.parse(mydata);

                LoadTable(newdata);
                $('#btnCancelEdit').click();
            }
            else {

                Command: toastr["error"]("This Driver not Successfully Edit. \n Somthing Went Wrongs.");
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


function fileToByteArray(file) {
    return new Promise((resolve, reject) => {
        try {
            let reader = new FileReader();
            let fileByteArray = [];
            reader.readAsArrayBuffer(file);
            reader.onloadend = (evt) => {
                if (evt.target.readyState == FileReader.DONE) {
                    let arrayBuffer = evt.target.result,
                        array = new Uint8Array(arrayBuffer);
                    for (byte of array) {
                        fileByteArray.push(byte);
                    }
                }
                resolve(fileByteArray);
            }
        }
        catch (e) {
            reject(e);
        }
    })
}

function ViewDetails(data) {
   
    console.log('test')
    var viewdata = JSON.parse(data.replaceAll('...', '"'));
    var details = '';

    $image = viewdata.DriverImage;
    if ($image) {
        // For Avatar image
        details += '<div class="user-avatar-section">';
        details += '<div class="d-flex align-items-center flex-column border-bottom">';
        details += '<img class="img-fluid rounded mb-3  w-px-100 h-px-100 pt-1 mt-4" src="data:image/png;base64,' + viewdata.DriverImage + '" />';
        details += '<div class="user-info text-center">';
        details += '<h4 class="mb-2">' + viewdata.DriverName + '</h4>';
        /* details += '<span class="badge bg-label-secondary mt-1">Author</span>';*/
        details += '</div>';
        details += '</div>';
        details += '</div>';
    } else {
       
        details += '<div class="user-avatar-sections">';
        details += '<div class="d-flex align-items-center flex-column border-bottom">';
        details += '<img class="img-fluid rounded mb-3  w-px-100 h-px-100 pt-1 mt-4" src="../img/CityLogo/defaultAvatar.jpg" />';
        details += '<div class="user-info text-center">';
        details += '<h4 class="mb-2">' + viewdata.DriverName + '</h4>';
        /* details += '<span class="badge bg-label-secondary mt-1">Author</span>';*/
        details += '</div>';
        details += '</div>';
        details += '</div>';
     
    }

    

    details += '<table class=" mt-3 pt-3 pb-4" style="width:100% ">';
    //details += '<tr class="row">';
    //details += '<td class="col-3 fw-bold">Driver Name</td>';
    //details += '<td class="col-6">' + viewdata.DriverName +'</td>';
    //details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Driver NIC</td>';
    details += '<td class="col-3">' + viewdata.DriverCNIC + '</td>';

    details += '<td class="col-3 fw-bold">Status</td>';
    if (viewdata.IsActive) {
        details += '<td class="col-3"><span class="badge bg-label-success">Active</span></td>';
    }
    else {
        details += '<td class="col-3"><span class="badge bg-label-danger">InActive</span></td>';
    }
    details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Driver Contact</td>';
    details += '<td class="col-6">' + viewdata.DriverContact + '</td>';
    details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Driver ERP #</td>';
    details += '<td class="col-6">' + viewdata.DriverERP + '</td>';
    details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Driver Licenece No</td>';
    details += '<td class="col-6">' + viewdata.DriverLicense + '</td>';
    details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Region</td>';
    details += '<td class="col-6">' + viewdata.Region.RegionName + '</td>';
    details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Created By</td>';
    details += '<td class="col-3">' + viewdata.CreatedBy + '</td>';
  
    details += '<td class="col-3 fw-bold">Created Date</td>';
    details += '<td class="col-3">' + formatdatewithMonth(viewdata.CreatedDate) + '</td>';
    details += '</tr>';

    details += '<tr class="row">';
    details += '<td class="col-3 fw-bold">Last Edited By</td>';
    details += '<td class="col-3">' + viewdata.LastModifiedBy + '</td>';

    details += '<td class="col-3 fw-bold">Last Edited Date</td>';
    details += '<td class="col-3 ">' + formatdatewithMonth(viewdata.LastModifiedDate) + '</td>';
    details += '</tr>';


    details += '</table>';
  


    //details += '<div class="d-flex justify-content-around flex-wrap mt-3 pt-3 pb-4 border-bottom">';
    //details += '<div class="d-flex align-items-start me-4 mt-3 gap-2">';
    //details += '<span class="badge bg-label-primary p-2 rounded"><i class="ti ti-checkbox ti-sm"></i></span>';
    //details += '<div>';
    //details += '<p class="mb-0 fw-semibold">1.23k</p>';
    //details += '<small>Tasks Done</small>';
    //details += '</div>';
    //details += '</div>';
    //details += '<div class="d-flex align-items-start mt-3 gap-2">';
    //details += '<span class="badge bg-label-primary p-2 rounded"><i class="ti ti-briefcase ti-sm"></i></span>';
    //details += '<div>';
    //details += '<p class="mb-0 fw-semibold">568</p>';
    //details += '<small>Projects Done</small>';
    //details += '</div>';
    //details += '</div>';
    //details += '</div>';
    //details += '<p class="mt-4 small text-uppercase text-muted">Details</p>';
    //details += '<div class="info-container">';
    //details += '<ul class="list-unstyled">';
    //details += '<li class="mb-2">';
    //details += '<span class="fw-semibold me-1">Driver Name:</span>';
    //details += '<span>' + viewdata.DriverName + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Driver NIC:</span>';
    //details += '<span>' + viewdata.DriverCNIC + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Driver Contact:</span>';
    //details += '<span>' + viewdata.DriverContact + '</span>'; 
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Driver ERP No:</span>';
    //details += '<span>' + viewdata.DriverERP + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Region:</span>';
    //details += '<span>' + viewdata.RegionID + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Status:</span>';
    //details += '<span class="badge bg-label-success">' + viewdata.IsActive + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Created By:</span>';
    //details += '<span>' + viewdata.CreatedBy + '</span>';
    //details += '</li>';
    //details += '<li class="pt-1">';
    //details += '<span class="fw-semibold me-1">Created Date:</span>';
    //details += '<span>' + viewdata.CreatedDate + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Edited By:</span>';
    //details += '<span>' + viewdata.LastModifiedBy + '</span>';
    //details += '</li>';
    //details += '<li class="mb-2 pt-1">';
    //details += '<span class="fw-semibold me-1">Edited Date:</span>';
    //details += '<span>' + viewdata.LastModifiedDate + '</span>';
    //details += '</li>';
    //details += '</ul>';
    //details += '<div class="d-flex justify-content-center">';
    //details += '<a href="javascript:;"';
    //details += 'class="btn btn-primary me-3"';
    //details += 'data-bs-target="#editUser"';
    //details += 'data-bs-toggle="modal">Edit</a>';
    //details += '<a href="javascript:;" class="btn btn-label-danger suspend-user">Suspended</a>';
    //details += '</div>';
    details += '</div>';

    $('.DetailViewHtml').html(details);
}