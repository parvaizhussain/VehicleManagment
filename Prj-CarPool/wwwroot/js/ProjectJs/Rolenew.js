function getUserRoleId(roleId) {
    $.ajax({
        type: 'POST',
        async: false,
        url: 'https://localhost:7010/Role/GetRolePermission',
        data: { id: roleId },
        success: function (result) {
            dataMenu = result;
            $(".menulist").html('');
            var list = '';
            for (var i = 0; i < result.length; i++) {
                list += '<li class="list-group-item d-flex align-items-center"><i class="' + result[i].cssClass + ' ti-sm me-2" ></i>' + result[i].name + '</li>';
              //  list += '<li><span style="display:none;">' + result[i].id + '</span>' + result[i].name + '</li>';
            }
            $(".menulist").html(list);
        },
        complete: function (result) {

        },
        error: function (err) { //console.log(JSON.stringify(err)); }
        }
    });
   // $('#permittedMenusModel').modal('show');
}
var input = document.querySelector('input[name=TagifyEditUserList1]');

function getEditMenu(roleId) {
    $.ajax({
        type: 'POST',
        async: false,
        url: 'https://localhost:7010/Role/GetRolePermissionVal',
        data: { id: roleId },
        success: function (result) {
           // dataMenu = result;
            // $('#TagifyEditUserList1').val('');
            $('#RoleNameEdit').val(result.rolesdata.name);
            $('#GroupListEdit').val(result.rolesdata.groupId).trigger('change');
            $('#RoleEditID').val(result.rolesdata.id);


            var tagifyEdit = new Tagify(input);
            var tags = result.datamenu;
            tagifyEdit.removeAllTags();
            tagifyEdit.addTags(tags);
            
           // console.log("data == " + JSON.stringify(result))
        },
        complete: function (result) {

        },
        error: function (err) { //console.log(JSON.stringify(err)); }
        }
    });
    // $('#permittedMenusModel').modal('show');
}

function SaveRole() {
    var roleshortname = $("#RoleName").val().trim().toUpperCase();
    var rolename = $("#RoleName").val();
    var roleId = 0;// $(".roleId").val();
    var groupId = $("#GroupList").val();


    var roleObj = {
        Id: roleId,
        Name: rolename,
        ShortName: roleshortname.toUpperCase(),
        GroupId: parseInt(groupId)
    }

    var rolemenulistvalidationlist = [];
    rolemenulistvalidationlist.length = 0;

    var data = JSON.parse($('#TagifyUserList1').val());
    for (var i = 0; i < data.length; i++) {
        rolemenulistvalidationlist.push(data[i].value);
    }


    $.ajax({
        type: 'POST',
        async: false,
        data: { viewModel: roleObj, permissionIds: rolemenulistvalidationlist },
        url: '/role/CreateRole',
        success: function (result) {
            if (result.created) {
                Command: toastr["success"]("This Role Succefully Saved.");
             
            }
            else {
                Command: toastr["error"]("This Role not Succefully Saved. \n Somthing Went Wrongs.");
            }
            $('#btnCancelSave').click();
            
              
        },
        complete: function (result) {
           

        },
        error: function (err) {
            $(".overlay").hide();
            console.log("error" + JSON.stringify(err));
        }
    });
}
function showdata() {
    var rolemenulistvalidationlist = [];
    rolemenulistvalidationlist.length = 0;
    var data = JSON.parse($('#TagifyUserList1').val());

    for (var i = 0; i < data.length; i++) {
        rolemenulistvalidationlist.push(data[i].value);
    }


    console.log(rolemenulistvalidationlist)


    
}

function EditRole() {
    var roleshortname = $("#RoleNameEdit").val().trim().toUpperCase();
    var rolename = $("#RoleNameEdit").val();
    var roleId = $("#RoleEditID").val();
    var groupId = $("#GroupListEdit").val();
   // var menus = TagifyEditUserList1.val();


    var roleObj = {
        Id: roleId,
        Name: rolename,
        ShortName: roleshortname.toUpperCase(),
        GroupId: parseInt(groupId)
    }

    var rolemenulistvalidationlist = [];
    rolemenulistvalidationlist.length = 0;
    if ($('#TagifyEditUserList1').val() != '') {
        var data = JSON.parse($('#TagifyEditUserList1').val());
        for (var i = 0; i < data.length; i++) {
            rolemenulistvalidationlist.push(data[i].value);
        }
    }
    $.ajax({
        type: 'POST',
        async: false,
        data: { viewModel: roleObj, permissionIds: rolemenulistvalidationlist },
        url: '/role/EditRolePermission',
        success: function (result) {
            if (result.edited) {
                Command: toastr["success"]("This Role Succefully Saved Changes.");
                window.globalModel = result.dataRefresh;
            }
            else {
                Command: toastr["error"]("This Role Not Succefully Saved Changes. \n Somthing Went Wrongs.");
            }
            $('#btnCancelEdit').click();
            


        },
        complete: function (result) {


        },
        error: function (err) {
            $(".overlay").hide();
            console.log("error" + JSON.stringify(err));
        }
    });
}


$(document).ready(function () {
    var group_list = "";
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:7112/api/group/allGroups',
        success: function (result) {
            group_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
            for (var i = 0; i < result.length; i++) {
                if (result[i].isDeleted == false) {
                    group_list += '<option value="' + result[i].groupId + '">' + result[i].groupName + " - " + result[i].normalizedName + '</option>';
                }
            }
            $("#GroupList").html(group_list);
            $("#GroupListEdit").html(group_list);
            
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }
    });
//$.ajax({
//        type: 'POST',
//        async: false,
//        url: 'https://localhost:7010/Role/GetRolePermissionVal',
//        data: { id: "1A789D96-392D-421C-8379-2CE3AD20DCFA" },
//        success: function (result) {
//            dataMenu = result.datamenu;
//        },
//        complete: function (result) {

//        },
//        error: function (err) { //console.log(JSON.stringify(err)); }
//        }
//    });

    $.ajax({
        type: 'POST',
        async: false,
        url: 'https://localhost:7010/Navigation/MenuValList',
        //data: { id: "1A789D96-392D-421C-8379-2CE3AD20DCFA" },
        success: function (result) {
            dataMenu = result;
        },
        complete: function (result) {

        },
        error: function (err) { //console.log(JSON.stringify(err)); }
        }
    });


    
    const TagifyUserListEl = document.querySelector('#TagifyUserList1');
    const TagifyUserEditListEl = document.querySelector('#TagifyEditUserList1');
    const usersList = dataMenu;
    function tagTemplate(tagData) {
      
        return `
    <tag title="${tagData.title || tagData.controllerName}"
      contenteditable='false'
      spellcheck='false'
      tabIndex="-1"
      class="${this.settings.classNames.tag} ${tagData.class ? tagData.class : ''}"
      ${this.getAttributes(tagData)}
    >
      <x title='' class='tagify__tag__removeBtn' role='button' aria-label='remove tag'></x>
      <div>
        <div class='tagify__tag__avatar-wrap'>

            <i class="${tagData.cssClass} ti-sm me-2" ></i>

           
        </div>
        <span class='tagify__tag-text'>${tagData.name}</span>
      </div>
    </tag>
  `;
    }
    // <img onerror="this.style.visibility='hidden'" src="${tagData.buttonClass}">
    function suggestionItemTemplate(tagData) {
        return `
    <div ${this.getAttributes(tagData)}
      class='tagify__dropdown__item align-items-center ${tagData.class ? tagData.class : ''}'
      tabindex="0"
      role="option"
    >
      ${tagData.cssClass
            ? `<div class='list-group-item d-flex align-items-center'>
  <i class="${tagData.cssClass} ti-sm me-2" ></i>
         
        </div>`
                : ''
            }
      <strong>${tagData.name}</strong>
      <span>${tagData.controllerName}</span>
    </div>
  `;
    }
    // <img onerror="this.style.visibility='hidden'" src="${tagData.cssClass}">
    let TagifyMenuList = new Tagify(TagifyUserListEl, {
        tagTextProp: 'name', // very important since a custom template is used with this property as text. allows typing a "value" or a "name" to match input with whitelist
        enforceWhitelist: true,
        skipInvalid: true, // do not remporarily add invalid tags
        dropdown: {
            closeOnSelect: false,
            enabled: 0,
            classname: 'users-list',
            searchKeys: ['name', 'controllerName'] // very important to set by which keys to search for suggesttions when typing
        },
        templates: {
            tag: tagTemplate,
            dropdownItem: suggestionItemTemplate
        },
        whitelist: usersList
    });

    let TagifyEditMenuList = new Tagify(TagifyUserEditListEl, {
        tagTextProp: 'name', // very important since a custom template is used with this property as text. allows typing a "value" or a "name" to match input with whitelist
        enforceWhitelist: true,
        skipInvalid: true, // do not remporarily add invalid tags
        dropdown: {
            closeOnSelect: false,
            enabled: 0,
            classname: 'users-list',
            searchKeys: ['name', 'controllerName'] // very important to set by which keys to search for suggesttions when typing
        },
        templates: {
            tag: tagTemplate,
            dropdownItem: suggestionItemTemplate
        },
        whitelist: usersList
    });

    TagifyMenuList.on('dropdown:show dropdown:updated', onDropdownShow);
    TagifyMenuList.on('dropdown:select', onSelectSuggestion);

    TagifyEditMenuList.on('dropdown:show dropdown:updated', onDropdownEditShow);
    TagifyEditMenuList.on('dropdown:select', onSelectEditSuggestion);

    let addAllSuggestionsEl;

    function onDropdownShow(e) {
        let dropdownContentEl = e.detail.tagify.DOM.dropdown.content;

        if (TagifyMenuList.suggestedListItems.length > 1) {
            addAllSuggestionsEl = getAddAllSuggestionsEl();

            // insert "addAllSuggestionsEl" as the first element in the suggestions list
            dropdownContentEl.insertBefore(addAllSuggestionsEl, dropdownContentEl.firstChild);
        }
    }
    function onDropdownEditShow(e) {
        let dropdownContentEl = e.detail.tagify.DOM.dropdown.content;

        if (TagifyEditMenuList.suggestedListItems.length > 1) {
            addAllSuggestionsEl = getAddAllSuggestionsEl();

            // insert "addAllSuggestionsEl" as the first element in the suggestions list
            dropdownContentEl.insertBefore(addAllSuggestionsEl, dropdownContentEl.firstChild);
        }
    }

    function onSelectSuggestion(e) {
        if (e.detail.elm == addAllSuggestionsEl) TagifyEditMenuList.dropdown.selectAll.call(TagifyEditMenuList);
    }
    function onSelectEditSuggestion(e) {
        if (e.detail.elm == addAllSuggestionsEl) TagifyEditMenuList.dropdown.selectAll.call(TagifyEditMenuList);
    }

    // create an "add all" custom suggestion element every time the dropdown changes
    function getAddAllSuggestionsEl() {
        // suggestions items should be based on "dropdownItem" template
        return TagifyMenuList.parseTemplate('dropdownItem', [
            {
                class: 'addAll',
                name: 'Add all',
                controllerName:
                    TagifyMenuList.settings.whitelist.reduce(function (remainingSuggestions, item) {
                        return TagifyMenuList.isTagDuplicate(item.value) ? remainingSuggestions : remainingSuggestions + 1;
                        
                    }, 0) + ' Menus'
            }
        ]);
    }

    function getAddAllSuggestionsEl() {
        // suggestions items should be based on "dropdownItem" template
        return TagifyEditMenuList.parseTemplate('dropdownItem', [
            {
                class: 'addAll',
                name: 'Add all',
                controllerName:
                    TagifyEditMenuList.settings.whitelist.reduce(function (remainingSuggestions, item) {
                        return TagifyEditMenuList.isTagDuplicate(item.value) ? remainingSuggestions : remainingSuggestions + 1;

                    }, 0) + ' Menus'
            }
        ]);
    }

   
    });

