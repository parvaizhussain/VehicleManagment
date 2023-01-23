
function edit_user(item) {

    getUserByIdEdit(item);
    /*hiding passwords input*/
    $('.password_wrapper, .confirmpassword_wrapper').hide();
    /*hiding passwords input*/
    $('#userModel .adduserbtn').text("Update");
    $('#userModel .txtchange').text("Edit");
    $('#userModel').modal('show');
                  
}

function role_list() {
    /**TYPE list**/
    var role_list = "";
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44308/Role/GetAll',
        success: function (result) {
            role_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
            for (var i = 0; i < result.length; i++) {          
                    role_list += '<option value="' + result[i].id + '">' + result[i].name + '</option>';                
            }
            $(".role_list").html(role_list);
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }
        
    });
    /**TYPE list**/

}

function region_list(model) {
    if (model.RegionId != null) {
        /**TYPE list**/
        var region_list = '';
        $.ajax({
            type: 'GET',
            async: false,
            url: 'https://localhost:44324/api/region/all',
            success: function (result) {
                //var region_list = '';
                //region_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
                //for (var i = 0; i < result.length; i++) {

                //    if (result[i].regionId == model.RegionId) {
                    
                //        region_list += '<option value="' + result[i].regionId + '" data-cityid="' + result[i].regionId + '">' + result[i].regionName + " - " + result[i].normalizedName + '</option>';

                //    }
                //}

                for (var i = 0; i < result.length; i++) {
                    if (result[i].isDeleted == false) {
                        region_list += '<option value="' + result[i].regionId + '" data-regionid="' + result[i].regionId + '">' + result[i].regionName + " - " + result[i].normalizedName + '</option>';
                    }
                }


                $(".regionlist").html(region_list);

            },
            complete: function (result) {
                $('.regionlist').select2({
                    placeholder: "Select Region"
                });
            },
            error: function (err) { console.log(JSON.stringify(err)); }
        });
    /**TYPE list**/
    } else {
        /**TYPE list**/
        var region_list = '';
        $.ajax({
            type: 'GET',
            async: false,
            url: 'https://localhost:44324/api/region/all',
            success: function (result) {
                //var region_list = '';
                //region_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
                //region_list += '<option  value="0">All</option>';
                //for (var i = 0; i < result.length; i++) {

                //    if (result[i].isDeleted == false) {
                //        region_list += '<option value="' + result[i].regionId + '">' + result[i].regionName + " - " + result[i].normalizedName + '</option>';
                //    }
                //}

                for (var i = 0; i < result.length; i++) {
                    if (result[i].isDeleted == false) {
                        region_list += '<option value="' + result[i].regionId + '" data-regionid="' + result[i].regionId + '">' + result[i].regionName + " - " + result[i].normalizedName + '</option>';
                    }
                }
                $(".regionlist").html(region_list);

            },
            complete: function (result) {
                $('.regionlist').select2({
                    placeholder: "Select Region"
                });
            },
            error: function (err) { console.log(JSON.stringify(err)); }
        });
    /**TYPE list**/
    }
  

}

function accessrights_list() {
    /**TYPE list**/
    var accessrights_list = "";
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44324/api/accessrights/all',
        success: function (result) {
            accessrights_list += '<option selected="true" disabled="disabled" value="">---Select---</option>';
            for (var i = 0; i < result.length; i++) {
                accessrights_list += '<option value="' + result[i].accessId + '">' + result[i].accessName + " - " + result[i].normalizedName + '</option>';
            }
            $(".accessrights_list").html(accessrights_list);
        },
        complete: function (result) {
          
        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });
    /**TYPE list**/

}

function getUserByIdEdit(userId) {
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44308/user/GetUser?id=' + userId,
        data: { id: userId },
        success: function (result) {
            console.log("CULSTER" + JSON.stringify(result));
            $(".userId").val(result.id);
            $(".userfirstnameadd").val(result.firstName);
            $(".userlastnameadd").val(result.lastName);
            //$(".usernameadd").val(result.userName); 
            $(".useremailadd").val(result.email);
            $(".role_list").val(result.roles[0].id);
            $(".accessrights_list").val(result.accessRights.accessId);

            /**Region Edit Populate */
            var editregionlength = result.user_Region.length;
            var editregionselectvalue = "";
            for (var ecr = 0; ecr < editregionlength; ecr++) {
                editregionselectvalue += "<li data-li-remove=" + result.user_Region[ecr].region.regionId + " data-id=" + result.user_Region[ecr].region.regionId + "><button type='button' class='removebox' data-remove-val=" + result.user_Region[ecr].region.regionId + " onclick='removeboxregion(this)'>X</button><span data-select-val=" + result.user_Region[ecr].region.regionId + ">" + result.user_Region[ecr].region.regionName + "</span></li>"

            }
            $(".selectboxes .regionselects").html(editregionselectvalue);
            /**Region Edit Populate */
                //$(".regionlist").val(result.regionId);
                if (result.city_Network_Branch == null) {
                    //$(".networkselectall, .branchselectall").prop('disabled', true);
                    //$(".networkselectall, .branchselectall").prop('checked', false);

                    $(".cityselectall, .networkselectall, .branchselectall").prop('disabled', false);
                    $(".cityselectall, .networkselectall, .branchselectall").prop('checked', false);

                    $(".citylist").prop('disabled', false);
                    $(".networklist").prop('disabled', false);
                    $(".branchlist").prop('disabled', false);

                    $(".cityselects").html('');
                    $(".networkselects").html('');
                    $(".branchselects").html('');

                    /**IS CLUSTER**/
                    if (result.isCluster == false) {
                        $("#flexclusterno").prop("checked", true);
                        $("#flexclusteryes").prop("checked", false);
                    }
                    else {

                        $("#flexclusterno").prop("checked", false);
                        $("#flexclusteryes").prop("checked", true);
                   
                        var editclusterbranchselectvalue = "";
                        var editisculsterlength = result.cluster_Branch.length;
                        for (var ecb = 0; ecb < editisculsterlength; ecb++) {
                            editclusterbranchselectvalue += "<li data-id=" + result.cluster_Branch[ecb].branch.branchId + "><button type='button' class='removebox' onclick='clusterremoveboxbranch(this)'>X</button><span data-select-val=" + result.cluster_Branch[ecb].branch.branchId + ">" + result.cluster_Branch[ecb].branch.branchName + "</span></li>";
                        }
                        $(".clusterbranchselects").html(editclusterbranchselectvalue);
                        $(".clusterbasedhide").hide();
                        $(".cluster_branch_wrapper").show();


                        /***branch dropdown populate***/
                        $('.regionselects li').each(function () {
                            var regionsds = $(this).attr("data-id");//data("id");
                            $.ajax({
                                type: 'GET',
                                async: false,
                                url: 'https://localhost:44324/api/Branch/RegionId?id=' + regionsds,
                                success: function (result) {
                                    console.log("result" + JSON.stringify(result));
                                    var clusterd_branch_list = "";
                                    for (var i = 0; i < result.length; i++) {




                                        /**new**/
                                        var sleect_length = $(".clusterbranchlist").length;
                                        if (sleect_length > 0) {



                                            var selectvlen = $(".clusterbranchlist option").filter('option[value=' + result[i].branchId + ']').length;
                                            if (selectvlen == 0) {
                                                clusterd_branch_list += '<option value="' + result[i].branchId + '" data-culterregion-id="' + regionsds + '">' + result[i].branchName + '</option>';



                                            }
                                        }



                                        /**new**/
                                        else {




                                            clusterd_branch_list += '<option value="' + result[i].branchId + '" data-culterregion-id="' + regionsds + '">' + result[i].branchName + '</option>';
                                        }



                                    }
                                    $(".clusterbranchlist").append(clusterd_branch_list);
                                    $(".clusterbranchlist").prop('disabled', false);
                                },
                                complete: function (result) {
                                    $('.clusterbranchlist').select2({
                                        placeholder: "Select Branch"
                                    });
                                },
                                error: function (err) { console.log(JSON.stringify(err)); }
                            });



                        });

                        /***branch dropdown populate***/
                        

                    }
                    /**IS CULTSER**/


                } else {
                    $(".clusterbasedhide").show();
                    $(".cluster_branch_wrapper").hide();


                    /**IS CLUSTER**/
                    if (result.isCluster == true) {
                        var editclusterbranchselectvalue = "";
                        var editisculsterlength = result.cluster_Branch.length;
                        for (var ecb = 0; ecb < editisculsterlength; ecb++) {
                            editclusterbranchselectvalue += "<li data-id=" + result.cluster_Branch[ecb].branch.branchId + "><button type='button' class='removebox' onclick='clusterremoveboxbranch(this)'>X</button><span data-select-val=" + result.cluster_Branch[ecb].branch.branchId + ">" + result.cluster_Branch[ecb].branch.branchName + "</span></li>";
                        }
                        $(".clusterbranchselects").html(editclusterbranchselectvalue);
                    }
                   
                    /**IS CULTSER**/


                    $(".cityselectall, .networkselectall, .branchselectall").prop('disabled', false);
                    $(".cityselectall, .networkselectall, .branchselectall").prop('checked', false);

                    $(".citylist").prop('disabled', false);
                    $(".networklist").prop('disabled', false);
                    $(".branchlist").prop('disabled', false);

                    var editcityselectvalue = "";
                    var editnetworkselectvalue = "";
                    var editbranchselectvalue = "";
                    var editcnblength = result.city_Network_Branch.length;
                    for (var ecb = 0; ecb < editcnblength; ecb++) {


                        editcityselectvalue += "<li data-li-remove=" + result.city_Network_Branch[ecb].city.region.regionId + " data-id=" + result.city_Network_Branch[ecb].cityId + " ><button type='button' class='removebox' data-remove-val=" + result.city_Network_Branch[ecb].city.region.regionId + " onclick='removeboxcity(this)'>X</button><span data-select-val=" + result.city_Network_Branch[ecb].cityId + ">" + result.city_Network_Branch[ecb].city.cityName + "</span></li>"

                        editnetworkselectvalue+= "<li data-li-remove=" + result.city_Network_Branch[ecb].network.city.cityId + " data-li-removeregion=" + result.city_Network_Branch[ecb].network.city.region.regionId + " data-id=" + result.city_Network_Branch[ecb].network.networkId + " data-cityid=" + result.city_Network_Branch[ecb].network.city.cityId + "><button type='button' class='removebox' data-remove-val=" + result.city_Network_Branch[ecb].network.city.cityId + " onclick='removeboxnetwork(this)'>X</button><span data-select-val=" + result.city_Network_Branch[ecb].network.networkId + ">" + result.city_Network_Branch[ecb].network.networkName + "</span></li>"

                        editbranchselectvalue+= "<li data-li-remove=" + result.city_Network_Branch[ecb].branch.network.networkId + " data-id=" + result.city_Network_Branch[ecb].branch.branchId + " data-city-ids=" + result.city_Network_Branch[ecb].branch.network.city.cityId + " data-region-idsss=" + result.city_Network_Branch[ecb].branch.network.city.region.regionId + "><button type='button' class='removebox' data-remove-val=" + result.city_Network_Branch[ecb].branch.network.networkId + " onclick='removeboxbranch(this)'>X</button><span data-select-val=" + result.city_Network_Branch[ecb].branch.branchId + ">" + result.city_Network_Branch[ecb].branch.branchName + "</span></li>"


                        //editcityselectvalue += "<li data-li-remove=" + result.city_Network_Branch[ecb].cityId + " data-id=" + result.city_Network_Branch[ecb].cityId + "><button type='button' class='removebox' data-remove-val=" + result.city_Network_Branch[ecb].cityId + " onclick='removeboxcity(this)'>X</button><span data-select-val=" + result.city_Network_Branch[ecb].cityId + ">" + result.city_Network_Branch[ecb].city.cityName + "</span></li>"
                        //editnetworkselectvalue += "<li data-li-remove=" + result.city_Network_Branch[ecb].cityId + " data-id=" + result.city_Network_Branch[ecb].networkId + "><button type='button' class='removebox' data-remove-val=" + result.city_Network_Branch[ecb].cityId + " onclick='removeboxnetwork(this)'>X</button><span data-select-val=" + result.city_Network_Branch[ecb].networkId + ">" + result.city_Network_Branch[ecb].network.networkName + "</span></li>"
                        //editbranchselectvalue += "<li data-li-remove=" + result.city_Network_Branch[ecb].networkId + " data-id=" + result.city_Network_Branch[ecb].branchId + " data-city-ids=" + result.city_Network_Branch[ecb].cityId +"><button type='button' class='removebox' data-remove-val=" + result.city_Network_Branch[ecb].networkId + " onclick='removeboxbranch(this)'>X</button><span data-select-val=" + result.city_Network_Branch[ecb].branchId + ">" + result.city_Network_Branch[ecb].branch.branchName + "</span></li>"

                    }
                    $(".cityselects").html(editcityselectvalue);
                    $(".networkselects").html(editnetworkselectvalue);
                    $(".branchselects").html(editbranchselectvalue);



                    /**remove duplication from city**/
                    var cityobj = {};
                    $('.cityselects li').each(function () {
                        var citcheck = $(this).data("id");
                        if (cityobj[citcheck]) {
                            $(this).remove();
                        } else {
                            cityobj[citcheck] = true;
                        }
                    });
                    /**remove duplication from city**/
                    /**remove duplication from network**/
                    var networkobj = {};
                    $('.networkselects li').each(function () {
                        var networkcheck = $(this).data("id");
                        if (networkobj[networkcheck]) {
                            $(this).remove();
                        } else {
                            networkobj[networkcheck] = true;
                        }
                    });
                    /**remove duplication from network**/
                    /**remove duplication from branch**/
                    var branchobj = {};
                    $('.branchselects li').each(function () {
                        var branchcheck = $(this).data("id");
                        if (branchobj[branchcheck]) {
                            $(this).remove();
                        } else {
                            branchobj[branchcheck] = true;
                        }
                    });
                    /**remove duplication from branch**/



                    /**dropdown populate of city**/
                    //if (result.regionId != null) {
                    //    cityByRegion_list(parseInt(result.regionId));//result.regionId
                    //}

                    $('.regionselects li').each(function () {
                        var regiondropid = $(this).data("id");
                        
                        cityByRegion_list(parseInt(regiondropid));
                        //if (cityobj[citcheck]) {
                        //    $(this).remove();
                        //} else {
                        //    cityobj[citcheck] = true;
                        //}
                    });


                    $('.cityselects li').each(function () {
                        var citdropid = $(this).data("id");
                        var regiondropid = $(this).data("li-remove");
                        networkByCity_list(citdropid, regiondropid);
                        //if (cityobj[citcheck]) {
                        //    $(this).remove();
                        //} else {
                        //    cityobj[citcheck] = true;
                        //}
                    });
                    /**dropdown populate of city**/
                   /**dropdown populate of network**/
                  
                    $('.networkselects li').each(function () {
                        var networkdropid = $(this).data("id");
                        var citydropids = $(this).data("cityid");
                        var regiondropids = $(this).data("removeregion");
                        branchkByNetwork_list(networkdropid, citydropids, regiondropids);
                    });
                   /**dropdown populate of network**/
                    /**dropdown populate of branch**/
                    //var branchobj = {};
                    //$('.branchselects li').each(function () {
                    //    var branchcheck = $(this).data("id");
                    //    if (branchobj[citcheck]) {
                    //        $(this).remove();
                    //    } else {
                    //        branchobj[citcheck] = true;
                    //    }
                    //});
                    /**dropdown populate of branch**/

            
                   
                }
            
        },
        complete: function (result) {

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });
}

function getUserById(userId) {
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44308/user/GetUser?id=' + userId,
        data: { id: userId },
        success: function (result) {
            console.log("CULSTER View" + JSON.stringify(result));
            $(".Details").html('');
            var list = '', prevRegion = '', prevCity = '', prevNetwork = '', prevBranch = '', cityNames = '', networkNames = '', branchNames = '',regionNames='';
            var clusterbranch = '', clusterregion = '', clustercity = '', clusternetwork = '', prevclusterregion = '', prevclustercity = '', prevclusternetwork = '', prevclusterbranch = '';
            list += '<table id="tblData" class="table tblcount" style="width:100%;margin-bottom:0px;">';
            list += '<thead>';
            list += '<tr>';
            list += '<th>AccessRights</th>';
            list += '<th>Role</th>';
            list += '<th>Group</th>';
            list += '<th>Department</th>';
            list += '<th>Region</th>';
           
                list += '<th class="clusterhideview">City</th>';
                list += '<th class="clusterhideview">Network</th>';
            
            list += '<th>Branch</th>';
            list += '</tr>';
            list += '</thead>';
            list += '<tbody>';


            list += '<tr>';
            list += '<td>' + result.accessRights.accessName + '</td>';
            list += '<td>' + result.roles[0].name + '</td>';
            list += '<td>' + result.roles[0].group.groupName + '</td>';
            list += '<td>' + result.roles[0].group.department.departmentName + '</td>';
            if (result.cluster_Branch != null) {
                for (var ac = 0; ac < result.cluster_Branch.length; ac++) {

                

                    if (prevclusterregion != result.cluster_Branch[ac].branch.network.city.region.regionName) {
                        prevclusterregion = result.cluster_Branch[ac].branch.network.city.region.regionName;
                        clusterregion+= result.cluster_Branch[ac].branch.network.city.region.regionName + ',';
                    }
                    if (prevclustercity != result.cluster_Branch[ac].branch.network.city.cityName) {
                        prevclustercity = result.cluster_Branch[ac].branch.network.city.cityName;
                        clustercity += result.cluster_Branch[ac].branch.network.city.cityName + ',';
                    }
                    if (prevclusternetwork != result.cluster_Branch[ac].branch.network.networkName) {
                        prevclusternetwork = result.cluster_Branch[ac].branch.network.networkName;
                        clusternetwork += result.cluster_Branch[ac].branch.network.networkName + ',';
                    }
                    if (prevclusterbranch != result.cluster_Branch[ac].branch.branchName) {
                        prevclusterbranch = result.cluster_Branch[ac].branch.branchName;
                        clusterbranch += result.cluster_Branch[ac].branch.branchName + ',';
                    }
                    //clusterregion+= result.cluster_Branch[ac].branch.network.city.region.regionName;
                    //clustercity+= result.cluster_Branch[ac].branch.network.city.cityName;
                    //clusternetwork+= result.cluster_Branch[ac].branch.network.networkName;
                    //clusterbranch+= result.cluster_Branch[ac].branch.branchName;
                   
                }
                list += '<td>' + clusterregion.substr(0, clusterregion.length - 1) + '</td>';
               
                list += '<td class="clusterhideview">' + clustercity.substr(0, clustercity.length - 1) + '</td>';
                list += '<td class="clusterhideview">' + clusternetwork.substr(0, clusternetwork.length - 1) + '</td>';
                
                list += '<td>' + clusterbranch.substr(0, clusterbranch.length - 1) + '</td>';
            }
            else
            {

                

                for (var au = 0; au < result.user_Region.length; au++)
                {
                    if (prevRegion != result.user_Region[au].region.regionName) {
                        prevRegion = result.user_Region[au].region.regionName;
                        regionNames += result.user_Region[au].region.regionName + ',';
                    }
                }
                list += '<td>' + regionNames.substr(0, regionNames.length - 1) + '</td>';

            if (result.city_Network_Branch != null && result.city_Network_Branch.length > 0) {
                for (var a = 0; a < result.city_Network_Branch.length; a++) {
                    if (prevCity != result.city_Network_Branch[a].city.cityName) {
                        prevCity = result.city_Network_Branch[a].city.cityName;
                        cityNames = cityNames + result.city_Network_Branch[a].city.cityName + ',';
                    }
                    if (prevNetwork != result.city_Network_Branch[a].network.networkName) {
                        prevNetwork = result.city_Network_Branch[a].network.networkName;
                        networkNames = networkNames + result.city_Network_Branch[a].network.networkName + ',';
                    }
                    if (prevBranch != result.city_Network_Branch[a].branch.branchName) {
                        prevBranch = result.city_Network_Branch[a].branch.branchName;
                        branchNames = branchNames + result.city_Network_Branch[a].branch.branchName + ',';
                    }
                }
                list += '<td class="clusterhideview">' + cityNames.substr(0, cityNames.length - 1) + '</td>';
                list += '<td class="clusterhideview">' + networkNames.substr(0, networkNames.length - 1) + '</td>';
                list += '<td>' + branchNames.substr(0, branchNames.length - 1) + '</td>';
            } else {
                list += '<td class="clusterhideview">All</td>';
                list += '<td class="clusterhideview">All</td>';
                list += '<td>All</td>';
            }
        }
            list += '</tr>';
            list += '</tbody>';

            $(".Details").html(list);
        },
        complete: function (result) {
          
            if (result.responseJSON.cluster_Branch == null) {
                $(".clusterhideview").show();
            }
            else {
                $(".clusterhideview").hide();
            }

        },
        error: function (err) { console.log(JSON.stringify(err)); }

    });


    $('#DetailModel').modal('show');
}

function cityByRegion_list(regionId) {

    var city_list = "";
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44324/api/city/RegionId?id='+regionId,
        success: function (result) {
   
            //for (var i = 0; i < result.length; i++) {
            //    if (result[i].isDeleted == false) {
            //        city_list += '<option value="' + result[i].cityId + '" data-cityid="' + result[i].cityId +'">' + result[i].cityName +  '</option>';
            //    }
            //}
            for (var i = 0; i < result.length; i++) {
                if (result[i].isDeleted == false) {

                    /**new**/
                    var sleect_length = $(".citylist").length;
                    if (sleect_length > 0) {
                        var selectvlen = $(".citylist option").filter('option[value=' + result[i].cityId + ']').length;
                        if (selectvlen == 0) {
                            city_list += '<option value="' + result[i].cityId + '" data-cityid="' + result[i].cityId +'" data-regionid="' + regionId + '">' + result[i].cityName + '</option>';

                        }
                    }
                    /**new**/
                    else {
                        city_list += '<option value="' + result[i].cityId + '" data-cityid="' + result[i].cityId +'" data-regionid="' + regionId + '">' + result[i].cityName + '</option>';
                    }
                }
            }
            $(".citylist").append(city_list);
            $(".citylist").prop('disabled', false);
        },
        complete: function (result) {
            $('.citylist').select2({
                placeholder: "Select City"
            }
            );
        },
        error: function (err) { console.log(JSON.stringify(err)); }
        
    });


}

function networkByCity_list(cityId,regionId) {
   var network_list="";
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44324/api/network/cityId?id=' + cityId,
        success: function (result) {
            for (var i = 0; i < result.length; i++) {
                if (result[i].isDeleted == false) {

                    /**new**/
                    var sleect_length = $(".networklist").length;
                    if (sleect_length > 0) {
                        var selectvlen =$(".networklist option").filter('option[value=' + result[i].networkId + ']').length;
                        if (selectvlen==0) {
                            network_list += '<option value="' + result[i].networkId + '" data-cityid="' + cityId + '" data-region-idss="' + regionId + '">' + result[i].networkName + '</option>';

                        }
                    }
                    /**new**/
                    else {
                        network_list += '<option value="' + result[i].networkId + '" data-cityid="' + cityId + '" data-region-idss="' + regionId + '">' + result[i].networkName + '</option>';
                    }
                }
            }
            $(".networklist").append(network_list);
            $(".networklist").prop('disabled',false);
        },
        complete: function (result) {
            $('.networklist').select2({
                placeholder: "Select Network"
            });
            
            
        },
        error: function (err) { console.log(JSON.stringify(err)); }
    });

}

function branchkByNetwork_list(networkId,cityId,regionId) {
    var branch_list = "";
    $.ajax({
        type: 'GET',
        async: false,
        url: 'https://localhost:44324/api/branch/networkId?id='+networkId,
        success: function (result) {
            
            for (var i = 0; i < result.length; i++) {
                if (result[i].isDeleted == false) {

                    /**new**/
                    var sleect_length = $(".branchlist").length;
                    if (sleect_length > 0) {
                     
                        var selectvlen = $(".branchlist option").filter('option[value=' + result[i].branchId + ']').length;
                        if (selectvlen == 0) {
                            branch_list += '<option value="' + result[i].branchId + '" data-networkid="' + networkId + '" data-city-ids="' + cityId + '" data-region-idsss="' + regionId +'">' + result[i].branchName + '</option>';

                        }
                    }

                    /**new**/
                    else {


                        branch_list += '<option value="' + result[i].branchId + '" data-networkid="' + networkId + '" data-city-ids="' + cityId + '" data-region-idsss="' + regionId +'">' + result[i].branchName + '</option>';
                    }
                }
            }
            $(".branchlist").append(branch_list);
            $(".branchlist").prop('disabled', false);
        },
        complete: function (result) {
            $('.branchlist').select2({
                placeholder: "Select Branch"
            });
        },
        error: function (err) { console.log(JSON.stringify(err)); }
    });

}


function removeboxregion(item) {

    var itemrow = $(item).parents('li').find("span").attr("data-select-val");

    //$(".selectboxes ul li").filter("[data-li-remove=" + itemrow + "]").remove();
    $(".regionselects li").filter("[data-li-remove=" + itemrow + "]").remove();
    $(".cityselects li").filter("[data-li-remove=" + itemrow + "]").remove();
    $(".networkselects li").filter("[data-li-removeregion= " + itemrow + "]").remove();
    $(".branchselects li").filter("[data-region-idsss= " + itemrow + "]").remove();

    var isClusterchecked = $(".iscluster").val();
    if (isClusterchecked == "Cluster") {
        $(".clusterbranchselects li").filter("[data-clusterregion= " + itemrow + "]").remove();
    }
    $(".citylist option:selected").prop("selected", false);
    $(".networklist option:selected").prop("selected", false);
    $(".branchlist option:selected").prop("selected", false);

    /**remove from dropdown */
    $(".citylist option[data-regionid=" + itemrow + "]").remove();

    $(".networklist option[data-region-idss=" + itemrow + "]").remove();
    $(".branchlist option[data-region-idsss=" + itemrow + "]").remove();
    /**remove from dropdown */

    var ctlen = $(".cityselects li").length;
    if (ctlen == 0) {
        $(".branchselectall").prop("disabled", true);
        $(".branchselectall").prop("checked", false);
        $(".networkselectall").prop("disabled", true);
        $(".networkselectall").prop("checked", false);
    }
}


function removeboxcity(item) {
  
    var itemrow = $(item).parents('li').find("span").attr("data-select-val");

    //$(".selectboxes ul li").filter("[data-li-remove=" + itemrow + "]").remove();

    $(".cityselects li").filter("[data-id=" + itemrow + "]").remove();
    $(".networkselects li").filter("[data-cityid= " + itemrow + "]").remove();
    $(".branchselects li").filter("[data-city-ids= " + itemrow + "]").remove();

    $(".citylist option:selected").prop("selected", false);
    $(".networklist option:selected").prop("selected", false);
    $(".branchlist option:selected").prop("selected", false);

    /**remove from dropdown */
  
    
    $(".networklist option[data-cityid=" + itemrow + "]").remove();
    $(".branchlist option[data-city-ids=" + itemrow + "]").remove();
    /**remove from dropdown */

    var ctlen = $(".cityselects li").length;
    if (ctlen == 0) {
        $(".branchselectall").prop("disabled", true);
        $(".branchselectall").prop("checked", false);
        $(".networkselectall").prop("disabled", true);
        $(".networkselectall").prop("checked", false);
    }
}

function removeboxnetwork(item) {
  
    var itemrow = $(item).parents('li').find("span").attr("data-select-val");
    $(".networkselects li").filter("[data-id=" + itemrow + "]").remove();
    $(".branchselects li").filter("[data-li-remove=" + itemrow + "]").remove();

    $(".citylist option:selected").prop("selected", false);
    $(".networklist option:selected").prop("selected", false);
    $(".branchlist option:selected").prop("selected", false);

    /**remove from dropdown */
    
    $(".branchlist option[data-networkid=" + itemrow + "]").remove();

    /**remove from dropdown */
    var ntlen = $(".networkselects li").length;
    if (ntlen == 0) {
        $(".branchselectall").prop("disabled", true);
        $(".branchselectall").prop("checked", false);
    }
}

function removeboxbranch(item) {
    var itemrow = $(item).parents('li').find("span").attr("data-select-val");
    $(".branchselects li").filter("[data-id=" + itemrow + "]").remove();

    $(".citylist option:selected").prop("selected", false);
    $(".networklist option:selected").prop("selected", false);
    $(".branchlist option:selected").prop("selected", false);
}

function clusterremoveboxbranch(item) {
    var itemrow = $(item).parents('li').find("span").attr("data-select-val");
    $(".clusterbranchselects li").filter("[data-id=" + itemrow + "]").remove();


    $(".clusterbranchlist option:selected").prop("selected", false);
}

function selectallcity(item) {
    if ($(item).is(':checked') == true) {
        $(".citylist, .networklist, .branchlist").prop("disabled", true);
        $(".networkselectall, .branchselectall").prop("disabled", true);
        $(".networkselectall, .branchselectall").prop('checked', false);
        $(".cityselects li, .networkselects li, .branchselects li").remove();
    }
    else {
        $(".citylist, .networklist, .branchlist").prop("disabled", false);
        $(".networkselectall, .branchselectall").prop("disabled", false);
    }
}

function selectallnetwork(item) {
    if ($(item).is(':checked') == true) {
        $(".networklist, .branchlist").prop("disabled", true);
        $(".branchselectall").prop("disabled", true);
        $(" .branchselectall").prop('checked', false);

        $(".networkselects li, .branchselects li").remove();
    }
    else {
        $(".networklist, .branchlist").prop("disabled", false);
        $(".branchselectall").prop("disabled", false);
    }
}


function selectallbranch(item) {
    if ($(item).is(':checked') == true) {
        $(".branchlist").prop("disabled", true);

        $(".branchselects li").remove();
       
    }
    else {
        $(".branchlist").prop("disabled", false);
       
    }
}

$(document).ready(function () {
    setTimeout(function () {
        $(".overlay").hide();
    }, 500);

    $(".count_tr span").text($(".table tbody tr").length);

    $(".data_table").DataTable();


    /***Card Pagination */
    function getPageList(totalPages, page, maxLength) {
        function range(start, end) {
            return Array.from(Array(end - start + 1), (_, i) => i + start);
        }

        var sideWidth = maxLength < 9 ? 1 : 2;
        var leftWidth = (maxLength - sideWidth * 2 - 3) >> 1;
        var rightWidth = (maxLength - sideWidth * 2 - 3) >> 1;

        if (totalPages <= maxLength) {
            return range(1, totalPages);
        }

        if (page <= maxLength - sideWidth - 1 - rightWidth) {
            return range(1, maxLength - sideWidth - 1).concat(0, range(totalPages - sideWidth + 1, totalPages));
        }

        if (page >= totalPages - sideWidth - 1 - rightWidth) {
            return range(1, sideWidth).concat(0, range(totalPages - sideWidth - 1 - rightWidth - leftWidth, totalPages));
        }

        return range(1, sideWidth).concat(0, range(page - leftWidth, page + rightWidth), 0, range(totalPages - sideWidth + 1, totalPages));
    }

    $(function () {
        var numberOfItems = $(".card-content .card").length;
        var limitPerPage = 8; //How many card items visible per a page
        var totalPages = Math.ceil(numberOfItems / limitPerPage);
        var paginationSize = 11; //How many page elements visible in the pagination
        var currentPage;

        function showPage(whichPage) {
            if (whichPage < 1 || whichPage > totalPages) return false;

            currentPage = whichPage;

            $(".card-content .card").hide().slice((currentPage - 1) * limitPerPage, currentPage * limitPerPage).show();

            $(".pagination li").slice(1, -1).remove();

            getPageList(totalPages, currentPage, paginationSize).forEach(item => {
                $("<li>").addClass("page-item").addClass(item ? "current-page" : "dots")
                    .toggleClass("active", item === currentPage).append($("<a>").addClass("page-link")
                        .attr({ href: "javascript:void(0)" }).text(item || "...")).insertBefore(".next-page");
            });

            $(".previous-page").toggleClass("disable", currentPage === 1);
            $(".next-page").toggleClass("disable", currentPage === totalPages);
            return true;
        }

        $(".pagination").append(
            $("<li>").addClass("page-item").addClass("previous-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("Prev")),
            $("<li>").addClass("page-item").addClass("next-page").append($("<a>").addClass("page-link").attr({ href: "javascript:void(0)" }).text("Next"))
        );

        $(".card-content").show();
        showPage(1);

        $(document).on("click", ".pagination li.current-page:not(.active)", function () {
            return showPage(+$(this).text());
        });

        $(".next-page").on("click", function () {
            return showPage(currentPage + 1);
        });

        $(".previous-page").on("click", function () {
            return showPage(currentPage - 1);
        });
    });
    /***Card Pagination */


    var model = JSON.parse($("#UserData").val());

    /**Unclustered branch***/
    $(".iscluster").change(function () {
        var isCluster = $(".iscluster:checked").val();
        if (isCluster == "Cluster") {
            $(".cluster_branch_wrapper").show();
            $(".clusterbasedhide").hide();
            var userId=$(".userId").val();
            //if (userId== "0") {
            //    $("#userModel .cityselects li, #userModel .networkselects li, #userModel .branchselects li").remove();
            //    $("#userModel .cityselectall, #userModel .networkselectall, #userModel .branchselectall").prop("disabled", true);
            //    $("#userModel .cityselectall, #userModel .networkselectall, #userModel .branchselectall").prop("checked", false);
            //    $("#userModel .citylist, #userModel .networklist, #userModel .branchlist").html('');


            //    $("#userModel .citylist, #userModel .networklist, #userModel .branchlist").prop("disabled", true);

            //    if ($('#userModel .citylist, #userModel .networklist, #userModel .branchlist').hasClass('select2-hidden-accessible')) {
            //        $("#userModel .citylist, #userModel .networklist, #userModel .branchlist").select2('destroy');
            //    }

            //}


            //var regionsds = $(".regionlist").val();
            
                var clusterd_branch_list = "";
            if ($('.regionselects li').length > 0) {
                $('.regionselects li').each(function () {
                    var regionsds = $(this).attr("data-id");//data("id");
                    $.ajax({
                        type: 'GET',
                        async: false,
                        url: 'https://localhost:44324/api/Branch/RegionId?id=' + regionsds,
                        success: function (result) {
                            console.log("result" + JSON.stringify(result));
                            for (var i = 0; i < result.length; i++) {




                                /**new**/
                                var sleect_length = $(".clusterbranchlist").length;
                                if (sleect_length > 0) {



                                    var selectvlen = $(".clusterbranchlist option").filter('option[value=' + result[i].branchId + ']').length;
                                    if (selectvlen == 0) {
                                        clusterd_branch_list += '<option value="' + result[i].branchId + '" data-culterregion-id="' + regionsds + '">' + result[i].branchName + '</option>';



                                    }
                                }



                                /**new**/
                                else {




                                    clusterd_branch_list += '<option value="' + result[i].branchId + '" data-culterregion-id="' + regionsds + '">' + result[i].branchName + '</option>';
                                }



                            }
                            $(".clusterbranchlist").append(clusterd_branch_list);
                            $(".clusterbranchlist").prop('disabled', false);
                        },
                        complete: function (result) {
                            $('.clusterbranchlist').select2({
                                placeholder: "Select Branch"
                            });
                        },
                        error: function (err) { console.log(JSON.stringify(err)); }
                    });



                });
            }
            if ($('.regionselects li').length == 0) {
                var regionsds = $(".regionlist").val();
                $.ajax({
                    type: 'GET',
                    async: false,
                    url: 'https://localhost:44324/api/Branch/RegionId?id=' + regionsds,
                    success: function (result) {
                        console.log("result" + JSON.stringify(result));
                        for (var i = 0; i < result.length; i++) {




                            /**new**/
                            var sleect_length = $(".clusterbranchlist").length;
                            if (sleect_length > 0) {



                                var selectvlen = $(".clusterbranchlist option").filter('option[value=' + result[i].branchId + ']').length;
                                if (selectvlen == 0) {
                                    clusterd_branch_list += '<option value="' + result[i].branchId + '" data-culterregion-id="' + regionsds + '">' + result[i].branchName + '</option>';



                                }
                            }



                            /**new**/
                            else {




                                clusterd_branch_list += '<option value="' + result[i].branchId + '" data-culterregion-id="' + regionsds + '">' + result[i].branchName + '</option>';
                            }



                        }
                        $(".clusterbranchlist").append(clusterd_branch_list);
                        $(".clusterbranchlist").prop('disabled', false);
                    },
                    complete: function (result) {
                        $('.clusterbranchlist').select2({
                            placeholder: "Select Branch"
                        });
                    },
                    error: function (err) { console.log(JSON.stringify(err)); }
                });
            }
            /**for edit */
            if (userId != "0")
            {
                $.ajax({
                    type: 'POST',
                    async: false,
                    data: { UserId: userId, Type: isCluster},
                    url: '/User/GetUserTypeAssociation',
                    success: function (result) {
                        var editclusterbranchselectvalue = "";
                        if (result.clusterBased.length > 0) {
                            var editisculsterlength = result.clusterBased.length;
                            for (var ecb = 0; ecb < editisculsterlength; ecb++) {
                                editclusterbranchselectvalue += "<li data-id=" + result.cluster_Branch[ecb].branch.branchId + "><button type='button' class='removebox' onclick='clusterremoveboxbranch(this)'>X</button><span data-select-val=" + result.cluster_Branch[ecb].branch.branchId + ">" + result.cluster_Branch[ecb].branch.branchName + "</span></li>";
                            }
                            $(".clusterbranchselects").html(editclusterbranchselectvalue);
                        }
                    }
                });


     
            }
             /**edit**/
        
        }
        else
        {
            $(".cluster_branch_wrapper").hide();
            $(".clusterbasedhide").show();
            if (userId == "0") {
                $("#userModel .clusterbranchselects li").remove();
            }
        }
    });

    $(".clusterbranchlist").change(function () {

        var clusterbranchval = $(this).val();
        var clusterbranchtxt = $(this).find("option:selected").text();
        var clusterlastbranch = clusterbranchval[clusterbranchval.length - 1];


        var clusterli_length = $(".clusterselectboxes .clusterbranchselects li").length;

        if (clusterli_length > 0) {

            var clustersslen = $(".clusterselectboxes .clusterbranchselects li").filter("[data-id=" + clusterlastbranch + "]").length;

            if (clustersslen == 0 && typeof (clusterlastbranch) !== "undefined") {
                var clustertxts = $(".clusterbranchlist option:selected").filter("[value=" + clusterlastbranch + "]").text();

                var clusterbranchssbyregionattr = $(".clusterbranchlist option[value=" + clusterlastbranch + "]").data("culterregion-id");
                var clusterbranchselectvalue = "";

                clusterbranchselectvalue += "<li  data-id=" + clusterlastbranch + " data-clusterregion=" + clusterbranchssbyregionattr+"><button type='button' class='removebox'  onclick='clusterremoveboxbranch(this)'>X</button><span data-select-val=" + clusterlastbranch + ">" + clustertxts + "</span></li>"


                $(".clusterselectboxes .clusterbranchselects").append(clusterbranchselectvalue);
                clusterbranchval = "";
                clusterbranchtxt = "";
                clusterbranchselectvalue = "";
            }

        }
        else {



            var clusterbranchssbyregionattr = $(".clusterbranchlist option[value=" + clusterlastbranch + "]").data("culterregion-id");

            var clusterbranchselectvalue = "";

            clusterbranchselectvalue += "<li data-id=" + clusterlastbranch + " data-clusterregion=" + clusterbranchssbyregionattr +"><button type='button' class='removebox'  onclick='clusterremoveboxbranch(this)'>X</button><span data-select-val=" + clusterlastbranch + ">" + clusterbranchtxt + "</span></li>"


            $(".clusterselectboxes .clusterbranchselects").append(clusterbranchselectvalue);
            clusterbranchval = "";
            clusterbranchtxt = "";
            clusterbranchselectvalue = "";
        }
        $(".clusterbranchlist option:selected").prop("selected", false);
    });

/**Unclustered branch***/




    //$(".regionlist").change(function () {
    //    var regionval = $(this).val();
    //    if ($("#SelectedRegion").val() != "") {
    //        /***IS CLUSTER***/
    //        $(".iscluster").change();
    //        /***IS CLUSTER***/
    //        $("#SelectedRegion").val(regionval);
    //        if (regionval == 0) {
    //            $(".citylist, .networklist, .branchlist").prop('disabled', true)
    //            $(".cityselectall, .networkselectall, .branchselectall").prop('disabled', true);
    //            $(".selectboxes ul li").remove();
    //        }
    //        else {
    //            $(".citylist, .networklist, .branchlist").prop('disabled', false)
    //            $(".cityselectall, .networkselectall, .branchselectall").prop('disabled', false);
    //            cityByRegion_list(parseInt(regionval))
    //        }

        
    //    } else {
    //        if (regionval == 0) {
    //            $(".citylist, .networklist, .branchlist").prop('disabled', true)       
    //            $(".cityselectall, .networkselectall, .branchselectall").prop('disabled', true);
    //            $(".selectboxes ul li").remove();
    //        }
    //        else {
    //            if (regionval != $("#SelectedRegion").val()) {
    //                $(".cityselectall").prop('checked', false);
    //                $(".citylist").prop('disabled', false)
    //                $(".cityselectall").prop('disabled', false);
    //                $(".selectboxes ul li").remove();
    //                cityByRegion_list(parseInt(regionval))
    //                $("#userModel .networklist, #userModel .branchlist").html('');
    //                $(".networklist, .branchlist").prop('disabled', true)
    //            } 
    //        }
    //    }

    //});

    /***REGION CHANGE**/
    $(".regionlist").change(function () {
        $(".cityselectall").prop('disabled', false);
        /***IS CLUSTER***/
 $(".iscluster").change();
    //        /***IS CLUSTER***/
        var regionval = $(this).val();
        var regiontxt = $(this).find("option:selected").text();
        var lastregion = regionval[regionval.length - 1];
        if (regionval.length > 0) {
        
            cityByRegion_list(parseInt(lastregion));
        }

        var li_length = $(".selectboxes .regionselects li").length;

        if (li_length > 0) {

            var sslen = $(".selectboxes .regionselects li").filter("[data-li-remove=" + lastregion + "]").length;

            if (sslen == 0 && typeof (lastregion) !== "undefined") {
                var txts = $(".regionlist option:selected").filter("[data-regionid=" + lastregion + "]").text();
                var regionselectvalue = "";

                regionselectvalue += "<li data-li-remove=" + lastregion + " data-id=" + lastregion + "><button type='button' class='removebox' data-remove-val=" + lastregion + " onclick='removeboxregion(this)'>X</button><span data-select-val=" + lastregion + ">" + txts + "</span></li>"


                $(".selectboxes .regionselects").append(regionselectvalue);
                regionval = "";
                regiontxt = "";
                regionselectvalue = "";
            }
        }
        else {
            if (typeof (lastregion) !== "undefined") {
                var regionselectvalue = "";


                regionselectvalue += "<li data-li-remove=" + lastregion + " data-id=" + lastregion + "><button type='button' class='removebox' data-remove-val=" + lastregion + " onclick='removeboxregion(this)'>X</button><span data-select-val=" + lastregion + ">" + regiontxt + "</span></li>"


                $(".selectboxes .regionselects").append(regionselectvalue);
                regionval = "";
                regiontxt = "";
                regionselectvalue = "";
            }
        }


        $(".regionlist option:selected").prop("selected", false);
    });
    /***REGION CHANGE**/

    /**CITY CHANGE**/
    

    $(".citylist").change(function () {
        $(".networkselectall").prop('disabled', false);
        var cityval = $(this).val();

        var citytxt = $(this).find("option:selected").text();
        var lastcity = cityval[cityval.length - 1];

        var regionidatt = $(".citylist option[value=" + lastcity + "]").data("regionid");

        if (cityval.length > 0) {
            //branchkByNetwork_list(parseInt(lastnetwork), cityidatt);
            networkByCity_list(parseInt(lastcity),regionidatt);
        }

        var li_length = $(".selectboxes .cityselects li").length;

        if (li_length > 0) {

            var sslen = $(".selectboxes .cityselects li").filter("[data-id=" + lastcity + "]").length;

            if (sslen == 0 && typeof (lastcity) !== "undefined") {
                var txts = $(".citylist option:selected").filter("[value=" + lastcity + "]").text();


                var cityssbydataattr = $(".citylist option[value=" + lastcity + "]").data("regionid");
                var cityselectvalue = "";

                cityselectvalue += "<li data-li-remove=" + cityssbydataattr + " data-id=" + lastcity + " ><button type='button' class='removebox' data-remove-val=" + cityssbydataattr + " onclick='removeboxcity(this)'>X</button><span data-select-val=" + lastcity + ">" + txts + "</span></li>"


                $(".selectboxes .cityselects").append(cityselectvalue);
                cityval = "";
                citytxt = "";
                cityselectvalue = "";
            }

        }
        else {

            var cityssbydataattr = $(".citylist option[value=" + lastcity + "]").data("regionid");
            var cityselectvalue = "";

            cityselectvalue += "<li data-li-remove=" + cityssbydataattr + " data-id=" + lastcity + "><button type='button' class='removebox' data-remove-val=" + cityssbydataattr + " onclick='removeboxcity(this)'>X</button><span data-select-val=" + lastcity + ">" + citytxt + "</span></li>"


            $(".selectboxes .cityselects").append(cityselectvalue);
            cityval = "";
            citytxt = "";
           cityselectvalue = "";
        }
        $(".citylist option:selected").prop("selected", false);
        
       
    });


    /**CITY CHANGE**/


    /**Network CHANGE**/


    $(".networklist").change(function () {
        $(".branchselectall").prop('disabled', false);
        var networkval = $(this).val();
        
        var networktxt = $(this).find("option:selected").text();
        var lastnetwork = networkval[networkval.length - 1];

        var cityidatt = $(".networklist option[value=" + lastnetwork + "]").data("cityid");
        var regionidatt = $(".networklist option[value=" + lastnetwork + "]").data("region-idss");
        if (networkval.length > 0) {
            branchkByNetwork_list(parseInt(lastnetwork), cityidatt, regionidatt);
        }

        var li_length = $(".selectboxes .networkselects li").length;

        if (li_length > 0) {

            var sslen = $(".selectboxes .networkselects li").filter("[data-id=" + lastnetwork + "]").length;

            if (sslen == 0 && typeof (lastnetwork) !== "undefined") {
                var txts = $(".networklist option:selected").filter("[value=" + lastnetwork + "]").text();

              
                var newtorkssbydataattr = $(".networklist option[value=" + lastnetwork + "]").data("cityid");
                //var newtorkssregionbydataattr = $(".newtorklist option[value=" + lastnetwork + "]").data("region-idss");
             
                var networkselectvalue = "";

                networkselectvalue += "<li data-li-remove=" + newtorkssbydataattr + " data-li-removeregion=" + regionidatt + " data-id=" + lastnetwork + " data-cityid="+newtorkssbydataattr+"><button type='button' class='removebox' data-remove-val=" + newtorkssbydataattr + " onclick='removeboxnetwork(this)'>X</button><span data-select-val=" + lastnetwork + ">" + txts + "</span></li>"


                $(".selectboxes .networkselects").append(networkselectvalue);
                networkval = "";
                networktxt = "";
                networkselectvalue = "";
            }

        }
        else {
            
            var newtorkssbydataattr = $(".networklist option[value=" + lastnetwork + "]").data("cityid");
            //var newtorkssregionbydataattr = $(".newtorklist option[value=" + lastnetwork + "]").data("region-idss");
           
            var networkselectvalue = "";

            networkselectvalue += "<li data-li-remove=" + newtorkssbydataattr + " data-li-removeregion=" + regionidatt + " data-id=" + lastnetwork + " data-cityid=" + newtorkssbydataattr +"><button type='button' class='removebox' data-remove-val=" + newtorkssbydataattr + " onclick='removeboxnetwork(this)'>X</button><span data-select-val=" + lastnetwork + ">" + networktxt + "</span></li>"


            $(".selectboxes .networkselects").append(networkselectvalue);
            networkval = "";
            networktxt = "";
            networkselectvalue = "";
        }
        $(".networklist option:selected").prop("selected", false);
      
    });

    /**Branch CHANGE**/


    $(".branchlist").change(function () {

        var branchval = $(this).val();
        var branchtxt = $(this).find("option:selected").text();
        var lastbranch = branchval[branchval.length - 1];
        

        var li_length = $(".selectboxes .branchselects li").length;

        if (li_length > 0)
        {

            var sslen = $(".selectboxes .branchselects li").filter("[data-id=" + lastbranch + "]").length;

            if (sslen == 0 && typeof (lastbranch) !== "undefined") {
                var txts = $(".branchlist option:selected").filter("[value=" + lastbranch + "]").text();


                var branchssbydataattr = $(".branchlist option[value=" + lastbranch + "]").data("networkid");
                var branchssbycityattr = $(".branchlist option[value=" + lastbranch + "]").data("city-ids");
                var branchssbyregionattr = $(".branchlist option[value=" + lastbranch + "]").data("region-idsss");
                var branchselectvalue = "";

                branchselectvalue += "<li data-li-remove=" + branchssbydataattr + " data-id=" + lastbranch + " data-city-ids=" + branchssbycityattr + " data-region-idsss=" + branchssbyregionattr +"><button type='button' class='removebox' data-remove-val=" + branchssbydataattr + " onclick='removeboxbranch(this)'>X</button><span data-select-val=" + lastbranch + ">" + txts + "</span></li>"


                $(".selectboxes .branchselects").append(branchselectvalue);
                branchval = "";
                branchtxt = "";
                branchselectvalue = "";
            }

        }
        else {



            var branchssbydataattr = $(".branchlist option[value=" + lastbranch + "]").data("networkid");
            var branchssbycityattr = $(".branchlist option[value=" + lastbranch + "]").data("city-ids");
            var branchssbyregionattr = $(".branchlist option[value=" + lastbranch + "]").data("region-idsss");

            var branchselectvalue = "";

            branchselectvalue += "<li data-li-remove=" + branchssbydataattr + " data-id=" + lastbranch + " data-city-ids=" + branchssbycityattr + " data-region-idsss=" + branchssbyregionattr +"><button type='button' class='removebox' data-remove-val=" + branchssbydataattr + " onclick='removeboxbranch(this)'>X</button><span data-select-val=" + lastbranch + ">" + branchtxt + "</span></li>"


            $(".selectboxes .branchselects").append(branchselectvalue);
            branchval = "";
            branchtxt = "";
            branchselectvalue = "";
        }
        $(".branchlist option:selected").prop("selected", false);
    });

    /**Branch CHANGE**/


    /**REMOVE on basis of parent***/
    $("ul#select2-cityOpt-container .select2-selection__choice__remove").click(function () {
        alert("remove");

    });
    /**REMOVE on basis of parent***/

    role_list();
    accessrights_list();
    region_list(model);
  

    /***SEARCH***/
    $("#cardSearch").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $(".user_cardprofile .custom-card").filter(function () {
            $(this).parent().toggle($(this).find(".profile-details h5").text().toLowerCase().indexOf(value) > -1)
        });
    });
    /***SEARCH***/


    $(".add_user").click(function () {
        $(".password_wrapper, .confirmpassword_wrapper").show();
        $("#userModel .userId").val("0");
        $('#userModel .userfirstnameadd').val("");
        $('#userModel .userlastnameadd').val("");
        $('#userModel .userpassword1add').val("");
        $('#userModel .userpassword2add').val("");
        //$('#userModel .usernameadd').val("");
        $('#userModel .useremailadd').val("");
        $('#userModel .role_list').val("");
        $('#userModel .accessrights_list').val("");
        $('#userModel .regionlist').val("");
        $("#userModel .regionselects li, #userModel .cityselects li, #userModel .networkselects li, #userModel .branchselects li").remove();
        $("#userModel .cityselectall, #userModel .networkselectall, #userModel .branchselectall").prop("disabled", true);
        $("#userModel .cityselectall, #userModel .networkselectall, #userModel .branchselectall").prop("checked",false);
        $("#userModel .citylist, #userModel .networklist, #userModel .branchlist").html('');


        $("#userModel .citylist, #userModel .networklist, #userModel .branchlist").prop("disabled", true);

        if ($('#userModel .citylist, #userModel .networklist, #userModel .branchlist').hasClass('select2-hidden-accessible')) {
            $("#userModel .citylist, #userModel .networklist, #userModel .branchlist").select2('destroy');
        }

        /**IS CLUSTER**/
        $("#flexclusterno").prop("checked", true);
        $("#flexclusteryes").prop("checked", false);
        $(".cluster_branch_wrapper").hide();
        $(".clusterbasedhide").show();
        /**IS CLUSTER**/

        $('#userModel .adduserbtn').text("Save");
        $('#userModel .txtchange').text("Add");
        $('#userModel').modal('show');
    });

    //$(".regionlist").change(function () {
    //    if ($(this).val() != '0' && $(this).val() != '') {
    //        $(".citylist").prop('disabled', false)
    //        $(".networklist").prop('disabled', false)
    //        $(".branchlist").prop('disabled', false)
    //    } else {
    //        $(".citylist").prop('disabled', true);
    //        $(".networklist").prop('disabled', true);
    //        $(".branchlist").prop('disabled', true)
    //    }

    //}) due to duplicate body


    /**ADD user **/
    $(".adduserbtn").click(function () {


        /***VALIDATION ***/

        var userId = $(".userId").val();
        var useremail = $(".useremailadd").val();
        var userfirstname = $(".userfirstnameadd").val();
        var userlastname = $(".userlastnameadd").val();
        var userpassword1 = $(".userpassword1add").val();
        var userpassword2 = $(".userpassword2add").val();
       
        //var username = $(".usernameadd").val();

        var role_listvalidation = $(".role_list").val();
        var accessrights_listvalidation = $(".accessrights_list").val();
        var regionlistvalidation = $(".regionlist").val();
        ///**Validation**/

        $('.userfirstnameadd').on("input", function () {
            $('.userfirstnameadd').next(".error-message").hide();
            $('.userfirstnameadd').css('border', 'none');
            $('.userfirstnameadd').css('background', '#d8f9d8');
        });
        if (userfirstname == null || userfirstname == undefined || userfirstname == "" || userfirstname == " ") {
            $('.userfirstnameadd').next(".error-message").text("* First Name Required");
            $('.userfirstnameadd').next(".error-message").show();
            $('.userfirstnameadd').css('border', '1px solid red');
            $('.userfirstnameadd').css('background', '#fff');
            $('.userfirstname').focus();
            return false;
        }


        $('.userlastnameadd').on("input", function () {
            $('.userlastnameadd').next(".error-message").hide();
            $('.userlastnameadd').css('border', 'none');
            $('.userlastnameadd').css('background', '#d8f9d8');
        });
        if (userlastname == null || userlastname == undefined || userlastname == "" || userlastname == " ") {
            $('.userlastnameadd').next(".error-message").text("* Last Name Required");
            $('.userlastnameadd').next(".error-message").show();
            $('.userlastnameadd').css('border', '1px solid red');
            $('.userlastnameadd').css('background', '#fff');
            $('.userlastnameadd').focus();
            return false;
        }

        if (userfirstname == userlastname)
        {
            Swal.fire(
                'Warning',
                "First & Last Name should not be same"
                ,
                'warning'
            )
            return false;
        }


        //$('.usernameadd').on("input", function () {
        //    $('.usernameadd').next(".error-message").hide();
        //    $('.usernameadd').css('border', 'none');
        //    $('.usernameadd').css('background', '#d8f9d8');
        //});
        //if (username == null || username == undefined || username == "" || username == " ") {
        //    $('.usernameadd').next(".error-message").text("* User Name Required");
        //    $('.usernameadd').next(".error-message").show();
        //    $('.usernameadd').css('border', '1px solid red');
        //    $('.usernameadd').css('background', '#fff');
        //    $('.usernameadd').focus();
        //    return false;
        //}


        $('.useremailadd').on("input", function () {
            $('.useremailadd').next(".error-message").hide();
            $('.useremailadd').css('border', 'none');
            $('.useremailadd').css('background', '#d8f9d8');
        });
        if (useremail == null || useremail == undefined || useremail == "" || useremail == " ") {
            $('.useremailadd').next(".error-message").text("* Email Required");
            $('.useremailadd').next(".error-message").show();
            $('.useremailadd').css('border', '1px solid red');
            $('.useremailadd').css('background', '#fff');
            $('.useremailadd').focus();
            return false;
        }



        $('.role_list').change("select", function () {
            $('.role_list').next(".error-message").hide();
            $('.role_list').css('border', 'none');
            $('.role_list').css('background', '#d8f9d8');
        });
        if (role_listvalidation == null || role_listvalidation == undefined || role_listvalidation == "" || role_listvalidation == " ") {
            $('.role_list').next(".error-message").text("* Role Required");
            $('.role_list').next(".error-message").show();
            $('.role_list').css('border', '1px solid red');
            $('.role_list').css('background', '#fff');
            $('.role_list').focus();
            return false;
        }

        $('.accessrights_list').change("select", function () {
            $('.accessrights_list').next(".error-message").hide();
            $('.accessrights_list').css('border', 'none');
            $('.accessrights_list').css('background', '#d8f9d8');
        });
        if (accessrights_listvalidation == null || accessrights_listvalidation == undefined || accessrights_listvalidation == "" || accessrights_listvalidation == " ") {
            $('.accessrights_list').next(".error-message").text("* AccessRights Required");
            $('.accessrights_list').next(".error-message").show();
            $('.accessrights_list').css('border', '1px solid red');
            $('.accessrights_list').css('background', '#fff');
            $('.accessrights_list').focus();
            return false;
        }
        //$('.regionlist').change("select", function () {
        //    $('.regionlist').next(".error-message").hide();
        //    $('.regionlist').css('border', 'none');
        //    $('.regionlist').css('background', '#d8f9d8');
        //});
        //if (regionlistvalidation == null || regionlistvalidation == undefined || regionlistvalidation == "" || regionlistvalidation == " ") {
        //    $('.regionlist').next(".error-message").text("* Region Required");
        //    $('.regionlist').next(".error-message").show();
        //    $('.regionlist').css('border', '1px solid red');
        //    $('.regionlist').css('background', '#fff');
        //    $('.regionlist').focus();
        //    return false;
        //}
        if (userId == "0") {
          
            $('.userpassword1add').on("input", function () {
                $('.userpassword1add').next(".error-message").hide();
                $('.userpassword1add').css('border', 'none');
                $('.userpassword1add').css('background', '#d8f9d8');
            });
            if (userpassword1 == null || userpassword1 == undefined || userpassword1 == "" || userpassword1 == " ") {
                $('.userpassword1add').next(".error-message").text("* Password Required");
                $('.userpassword1add').next(".error-message").show();
                $('.userpassword1add').css('border', '1px solid red');
                $('.userpassword1add').css('background', '#fff');
                $('.userpassword1add').focus();
                return false;
            }

            $('.userpassword2add').on("input", function () {
                $('.userpassword2add').next(".error-message").hide();
                $('.userpassword2add').css('border', 'none');
                $('.userpassword2add').css('background', '#d8f9d8');
            });
            if (userpassword2 == null || userpassword2 == undefined || userpassword2 == "" || userpassword2 == " ") {
                $('.userpassword2add').next(".error-message").text("* Confirm Password Required");
                $('.userpassword2add').next(".error-message").show();
                $('.userpassword2add').css('border', '1px solid red');
                $('.userpassword2add').css('background', '#fff');
                $('.userpassword2add').focus();
                return false;
            }

            const pass1 = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
            const pass2 = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
            var testpass1 = pass1.test(userpassword1);
            var testpass2 = pass2.test(userpassword2);
            if (testpass1) {

            }
            else {
                Swal.fire({
                    title: 'Warning',
                    html: '<ul style="list-style: none;padding-left: 0px;"><li><h5>New Password</h5></li><li>at least 8 characters</li><li>1 number</li><li>1 upper and 1 lowercase</li></ul>',
                    icon: 'warning'
                })
                return false;
            }

            if (testpass2) {
            }
            else {
                Swal.fire({
                    title: 'Warning',
                    html: '<ul style="list-style: none;padding-left: 0px;"><li><h5>Confirm Password</h5></li><li >at least 8 characters</li><li>1 number</li><li>1 upper and 1 lowercase</li></ul>',
                    icon: 'warning'
                })
                return false;
            }

            if (userpassword1 != userpassword2) {
                Swal.fire(
                    'Warning',
                    "Password & Confirm Password should be same",
                    'warning'
                )
                return false;
            }
        } 



        /**Validation**/

        var cnb = [];
        var cb = [];
       
        var isCluster =$('.iscluster:checked').val();
        var rolearr = [];
        var regionarr = [];
        /***region array***/
        var cregionlength = $(".regionselects li").length;

        if (cregionlength==0) {
            Swal.fire(
                'Warning',
                "Atleast 1 Region Must be selected",
                'warning'
            )
            return false;
        }


        for (var ucr = 1; ucr <= cregionlength; ucr++) {
            var cregiondataid = $(".regionselects li:nth-child(" + ucr + ")").data("id");
            regionarr.push({
                UserId : userId,
                RegionId: cregiondataid
            });
        }
        /***region array***/

        rolearr.push({
            Name: $(".role_list option:selected").text()
        })
        if (isCluster=="Cluster") {
            var cbranchlength = $(".clusterbranchselects li").length;

            if (cbranchlength < 2) {
                Swal.fire(
                    'Warning',
                    "Atleast 2 Clutser Branch Must be selected",
                    'warning'
                )
                return false;
            }


            for (var ucb = 1; ucb <= cbranchlength; ucb++) {
                var cbrndataid = $(".clusterbranchselects li:nth-child(" + ucb + ")").data("id");
                cb.push({
                    UserId: userId,
                    BranchId: cbrndataid
                });
            }

        } else {
            var regioncond = $(".regionlist").val();
            var cityallselected = $(".cityselectall").prop('checked');
            if (regioncond != "0") {

     


                if (cityallselected == false) {

                    /***REGION ASSOCIATION WITH CITY***/

                    var regionerror = false;
                    var regionlength = $(".regionselects li").length;
                    var citylength = $(".cityselects li").length;

                    if (regionlength == 0) {
                        Swal.fire(
                            'Warning',
                            "Region Must be selected",
                            'warning'
                        )
                        return false;
                    }

                    if (citylength == 0) {
                        Swal.fire(
                            'Warning',
                            "No City Is Associated",
                            'warning'
                        )
                        return false;
                    }
                    else {
                        for (var rt = 1; rt <= regionlength; rt++) {
                            var rtdata = $(".regionselects li:nth-child(" + rt + ")").data("id");
                            for (var nt = 1; nt <= citylength; nt++) {
                                var ctwdata = $(".cityselects li:nth-child(" + nt + ")").data("li-remove");
                                if (rtdata == ctwdata) {
                                    regionerror = false;
                                    break;
                                }
                                else {
                                    regionerror = true;
                                }
                            }
                        }

                        if (regionerror) {
                            Swal.fire(
                                'Warning',
                                "Region's City Not Associated" + $(".regionselects li:nth-child(" + rt + ") span").text(),
                                'warning'
                            )
                            return false;
                        }

                    }
                    /***REGION ASSOCIATION WITH CITY***/

                    var networkallselected = $(".networkselectall").prop('checked');

                    

                    if (networkallselected == false)
                    { 
                        /***CITY ASSOCIATION WITH NETWORK */


                        var cityerror = false;
                    var citylength = $(".cityselects li").length;
                    var nwtroklength = $(".networkselects li").length;

                    if (citylength == 0) {
                        Swal.fire(
                            'Warning',
                            "City Must be selected",
                            'warning'
                        )
                        return false;
                    }

                    if (nwtroklength == 0) {
                        Swal.fire(
                            'Warning',
                            "No Network Is Associated",
                            'warning'
                        )
                        return false;
                    }
                    else {
                        for (var ct = 1; ct <= citylength; ct++) {
                            var ctdata = $(".cityselects li:nth-child(" + ct + ")").data("id");
                            for (var nr = 1; nr <= nwtroklength; nr++) {
                                var ntwdata = $(".networkselects li:nth-child(" + nr + ")").data("li-remove");
                                if (ctdata == ntwdata) {
                                    cityerror = false;
                                    break;
                                }
                                else {
                                    cityerror = true;
                                }
                            }
                        }

                        if (cityerror) {
                            Swal.fire(
                                'Warning',
                                "City's Network Not Associated" + $(".cityselects li:nth-child(" + ct + ") span").text(),
                                'warning'
                            )
                            return false;
                        }

                    }

                    /***CITY ASSOCIATION WITH NETWORK */


                        /***NETWORK ASSOCIATION WITH Branch */
                        var branchallselected = $(".branchselectall").prop('checked');
                        if (branchallselected == false) {
                            var networkerror = false;
                            var nwtroklength = $(".networkselects li").length;
                            var brnchlength = $(".branchselects li").length;
                            if (brnchlength == 0) {
                                Swal.fire(
                                    'Warning',
                                    "No Branch Is Associated",
                                    'warning'
                                )
                                return false;
                            }
                            else {
                                for (var nt = 1; nt <= nwtroklength; nt++) {
                                    var nwtdata = $(".networkselects li:nth-child(" + nt + ")").data("id");/*rajachnage li-remove*/
                                    for (var br = 1; br <= brnchlength; br++) {
                                        var brndata = $(".branchselects li:nth-child(" + br + ")").data("li-remove");
                                        if (nwtdata == brndata) {
                                            networkerror = false;
                                            break;
                                        }
                                        else {
                                            networkerror = true;
                                        }
                                    }
                                }

                                if (networkerror) {
                                    Swal.fire(
                                        'Warning',
                                        "Network's Branch Not Associated" + $(".networkselects li:nth-child(" + nt + ") span").text(),
                                        'warning'
                                    )
                                    return false;
                                }

                            }
                        }
                    /***NETWORK ASSOCIATION WITH Branch */
                }
                    /**REPOSNSE MAKING */


                    var nwtroklength = $(".networkselects li").length;
                    var brnchlength = $(".branchselects li").length;
                    var citylength = $(".cityselects li").length;
                    var networkallselected = $(".networkselectall").prop('checked');
                    var branchallselected = $(".branchselectall").prop('checked');
                    /***network length**/
                    if (networkallselected == true)
                    {
                        for (var ct = 1; ct <= citylength; ct++) {
                            var ctdataid = $(".cityselects li:nth-child(" + ct + ")").data("id");//City Value

                            cnb.push({
                                CityId: ctdataid,
                                NetworkId: 0,
                                BranchId: 0
                            });
                        }
                    }
                    if (branchallselected == true)
                    {
                        for (var ct = 1; ct <= citylength; ct++) {
                            var ctdataid = $(".cityselects li:nth-child(" + ct + ")").data("id");//City Value
                            for (var nt = 1; nt <= nwtroklength; nt++) {
                                var nwtdata = $(".networkselects li:nth-child(" + nt + ")").data("li-remove");
                                cnb.push({
                                    CityId: ctdataid,
                                    NetworkId: nwtdata,
                                    BranchId: 0
                                });
                            }
                        }
                    }
                    /***network length**/


                    for (var ct = 1; ct <= citylength; ct++) {
                        var ctdataid = $(".cityselects li:nth-child(" + ct + ")").data("id");//City Value
                        for (var nt = 1; nt <= nwtroklength; nt++) {
                            var nwtdata = $(".networkselects li:nth-child(" + nt + ")").data("li-remove");

                            if (ctdataid == nwtdata) {
                                var nwtdataid = $(".networkselects li:nth-child(" + nt + ")").data("id");


                            }
                            else {
                                if (ct + 1 <= citylength) {
                                    var ct = ct + 1;
                                    ctdataid = $(".cityselects li:nth-child(" + ct + ")").data("id");//City Value

                                    if (ctdataid == nwtdata) {
                                        nwtdataid = $(".networkselects li:nth-child(" + nt + ")").data("id");

                                    }

                                }
                            }

                            for (var brn = 1; brn <= brnchlength; brn++) {
                                var brndata = $(".branchselects li:nth-child(" + brn + ")").data("li-remove");

                                if (nwtdataid == brndata) {
                                    var brndataid = $(".branchselects li:nth-child(" + brn + ")").data("id");
                                    cnb.push({
                                        CityId: ctdataid,
                                        NetworkId: nwtdataid,
                                        BranchId: brndataid
                                    });
                                }

                            }

                        }
                    }

                }
            }
    
        }
       
        var isculterbool = (isCluster == "Cluster") ? true : false;
        var userObj = {
            Id:userId,
            FirstName: $(".userfirstnameadd").val(),
            LastName: $(".userlastnameadd").val(),
            UserName: $(".useremailadd").val(),
            Email: $(".useremailadd").val(),
            Password: $(".userpassword1add").val(),
            User_Region: regionarr,//parseInt($(".regionlist").val()),
            AccessRightsId: parseInt($(".accessrights_list").val()),
            Roles: rolearr,
            City_Network_Branch: cnb, 
            IsCluster: isculterbool,
            Cluster_Branch: cb
        }

        if (userId != "0") {

            $.when(updateOrder(userObj)).then(function (response) {
            }).fail(function (err) {
                alert("ERORRRR" + err);
            });
        } else {
            $.when(saveOrder(userObj)).then(function (response) {
            }).fail(function (err) {
                alert("ERORRRR" + JSON.stringify(err));
            });
        }

        function updateOrder(userObj) {

            $(".overlay").show();
            return $.ajax({
                type: 'POST',
                async: false,
                data: { viewModel: userObj, AllCity: $(".cityselectall").prop("checked"), AllNetwork: $(".networkselectall").prop("checked"), AllBranch: $(".branchselectall").prop("checked")},
                url: '/User/EditUser',
                success: function (result) {
                    if (!result) {
                        alert("Something Went Wrong!")
                    } else {
                        if (result.edited) {
                            Swal.fire(
                                'Success',
                                result.Message,
                                'success'
                            ).then(function () {
                                location.reload(true);
                            });
                        } else if (!result.edited) {
                            Swal.fire(
                                'Warning',
                                result.Message,
                                'warning'
                            )
                        }
                    }
                },
                complete: function (result) {
                    $(".overlay").hide();
                    $('#userModel').modal('hide');
                    $("#userModel .userId").val("0");
                    $('#userModel .userfirstnameadd').val("");
                    $('#userModel .userlastnameadd').val("");
                    $('#userModel .usernameadd').val("");
                    $('#userModel .useremailadd').val("");
                    $('#userModel .role_list').val("");
                    $('#userModel .accessrights_list').val("");

                },
                error: function (err) {
                    $(".overlay").hide();
                    console.log("error" + JSON.stringify(err));
                }
            });
        }

        function saveOrder(userObj) {
            console.log("userObj" + JSON.stringify(userObj));
            $(".overlay").show();
            return $.ajax({
                type: 'POST',
                async: false,
                data: { userViewModel: userObj, AllCity: $(".cityselectall").prop("checked"), AllNetwork: $(".networkselectall").prop("checked"), AllBranch: $(".branchselectall").prop("checked")},
                url: '/User/CreateUser',
                success: function (result) {
                    if (!result) {
                        alert("Something Went Wrong!")
                    } else {
                        if (result.created) {
                            Swal.fire(
                                'Success',
                                result.Message,
                                'success'
                            ).then(function () {
                                location.reload(true);
                            });


                        } else if (!result.created) {
                            Swal.fire(
                                'Warning',
                                result.Message,
                                'warning'
                            )
                        }
                    }
                        
                },
                complete: function (result) {
                    $(".overlay").hide();
                    $('#userModel').modal('hide');
                    $("#userModel .userId").val("0");
                    $('#userModel .userfirstnameadd').val("");
                    $('#userModel .userlastnameadd').val("");
                    $('#userModel .usernameadd').val("");
                    $('#userModel .useremailadd').val("");
                    $('#userModel .role_list').val("");
                    $('#userModel .accessrights_list').val("");

                },
                error: function (err) {
                    $(".overlay").hide();
                    console.log("error" + JSON.stringify(err));
                }
            });
        }
        /**ADD user**/
    });
});
