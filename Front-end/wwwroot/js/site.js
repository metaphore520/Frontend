// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var postData = {};
var selectedMaritalStatusArray = new Array();
var selectedMaritalStatus = "";
var selectedCountry = "";
var addressBarId = 2;

var getCustomer = {};
var getAddresses = [];


$(document).ready(function () {

    $(".MaritalStatus").click(function () {
        var n = $(".MaritalStatus:checked").length;
        if (n > 0) {
            $(".MaritalStatus:checked").each(function () {
                selectedMaritalStatusArray.push($(this).val());
            });
        }
        selectedMaritalStatus = selectedMaritalStatusArray[0];
    });
    $("select.country").change(function () {
        selectedCountry = $(this).children("option:selected").val();
    });
    $("#btnAddAddress").click(function () {
        addAddressBar();
    });
});

function getNumberFromId(id) {
    var numberVal = '';
    for (var i = 0; i < id.length; i++) {
        if (id.charCodeAt(i) >= 48 && id.charCodeAt(i) <= 57) {
            numberVal += id[i];
        }
    }
    return numberVal;
}
function Edit() {

////// Addresssss
    var AddressesEdit = [];
    var newObj = { Id: 0, CustomerId: 0 };
    $(".addressBar").each(function () {
        newObj = { Id: 0, CustomerId: 0 };
        var id = $(this).attr('id');
        var idNum = getNumberFromId(id);
        var IdTxt = 'Id' + idNum;
        var customerIdTxt = 'customerId' + idNum;
        var Id = $('#' + IdTxt).val();
        var customerId = $('#' + customerIdTxt).val();

        if ($(this).val().length > 0) {
            newObj.Address = $(this).val();
            newObj.Id = Id;
            newObj.CustomerId = customerId;
            AddressesEdit.push(newObj);
        }
    });
    ////////////////////////////////////////////
    var dataEdit = new FormData();
    var fileEdit = {};
    if ($("#CustomerPhoto").get(0).files.length > 0) {
        fileEdit = $("#CustomerPhoto").get(0).files;
        dataEdit.append("CustomerPhoto", fileEdit[0]);
        dataEdit.append("FileUploaded", true);
    }
    else {
        fileEdit = getCustomer.CustomerPhoto;
        dataEdit.append("CustomerPhotoByte", fileEdit);
        dataEdit.append("FileUploaded",false);
    } 
    dataEdit.append("CustomerName", $('#CustomerName').val());
    dataEdit.append("FatherName", $('#FatherName').val());
    dataEdit.append("MotherName", $('#MotherName').val());
    dataEdit.append("MaritalStatus", selectedMaritalStatus == "" ? getCustomer.MaritalStatus : selectedMaritalStatus);
    dataEdit.append("CountryId", selectedCountry == "" ? getCustomer.CountryId : selectedCountry);
    dataEdit.append("AllAddress", JSON.stringify({ alladdress: AddressesEdit }));
    dataEdit.append("Id",getCustomer.Id)

    var dataBodyJsonEdit = {
        CustomerName: $('#CustomerName').val(),
        FatherName: $('#FatherName').val(),
        MotherName: $('#MotherName').val(),
        MaritalStatus: selectedMaritalStatus == "" ? getCustomer.MaritalStatus : selectedMaritalStatus,
        CountryId: selectedCountry == "" ? getCustomer.CountryId : selectedCountry,
        AllAddress:  AddressesEdit ,
        CustomerPhoto: fileEdit,
        CustomerId: getCustomer.Id
    }
    console.log(dataBodyJsonEdit);

    $.ajax({
        type: 'POST',
        url: '/CustomerPortal/EditCustomer',
        datatype: 'json',
        contentType: false,
        data: dataEdit,
        processData: false,
        success: function (result) {
            alert('Successfully Edited Data ');
            console.log(result);
        },
        error: function (error) {
            alert('Failed to receive the Data');
            console.log(error);
        }
    })


}
function submitForm() {
    var Addresses = [];

    $(".addressBar").each(function () {
        var newObj = { Id: 0, CustomerId: 0 };
        if ($(this).val().length > 0) {
            newObj.Address = $(this).val();
            Addresses.push(newObj);
        }
    });

    ////          USING FORM DATA       
    var file = $("#CustomerPhoto").get(0).files;
    var data = new FormData();
    data.append("CustomerPhoto", file[0]);
    data.append("CustomerName", $('#CustomerName').val());
    data.append("FatherName", $('#FatherName').val());
    data.append("MotherName", $('#MotherName').val());
    data.append("MaritalStatus", selectedMaritalStatus);
    data.append("CountryId", selectedCountry);
    data.append("AllAddress", JSON.stringify({ alladdress: Addresses }));

    $.ajax({
        type: 'POST',
        url: '/CustomerPortal/AddCustomer',
        //url: @Url.Action("AddCustomer", "CustomerPortal"),
        datatype: 'json',
        //contentType: 'application/json; charset=utf-8',
        //data: JSON.stringify(dataBodyJson),
        contentType: false,
        data: data,
        processData: false,
        success: function (result) {
            alert('Successfully received Data ');
            console.log(result);
        },
        error: function (error) {
            alert('Failed to receive the Data');
            console.log(error);
        }
    })
}
function addAddressBar() {
    addressBarId = addressBarId + 1;
    var newId = 'address' + addressBarId;
    var newBtnEditId = 'addressBtnEdit' + addressBarId;
    var newBtnDelId = 'addressBtnDel' + addressBarId;
    var addressTextId = 'addressTxt' + addressBarId;
    var IdTxt = 'Id' + addressBarId;
    var customerIdTxt = 'customerId' + addressBarId;
    var Id = 0; var customerId = 0;
    $("#address_tablebody").append(
        "<tr>" +
        "<td>" +

        "<input type='text' id='" + IdTxt + "' value='" + Id + "' hidden='true'  />" +
        "<input type='text' id='" + customerIdTxt + "' value='" + customerId + "' hidden='true'  />" +

        "<span id='" + addressTextId + "' hidden='true'></span>" +
        "<input id='" + newId + "'" +
        "type='text'  class='addressBar from-control' placeholder='Enter Address...' />" +
        "</td>" +
        "<td>" +
        "<input class='addressBtn' class='btn btn-primary btn-sm'  type='button' id='" + newBtnEditId + "'" + "  value='Edit' />" +
        "<input class='addressBtn'  class='btn btn-primary btn-sm'  type='button' id='" + newBtnDelId + "'" + " onclick='deleteElement(" + addressBarId + ")'  value='Delete' />" +
        "</td>" +
        "</tr>"
    );
}
function addAddressBarWithValue(value, Id, customerId) {
    addressBarId = addressBarId + 1;
    var newId = 'address' + addressBarId;
    var newBtnEditId = 'addressBtnEdit' + addressBarId;
    var newBtnDelId = 'addressBtnDel' + addressBarId;
    var addressTextId = 'addressTxt' + addressBarId;
    var IdTxt = 'Id' + addressBarId;
    var customerIdTxt = 'customerId' + addressBarId;
    $("#address_tablebody").append(
        "<tr>" +
        "<td>" +
        "<input type='text' id='" + IdTxt + "' value='" + Id + "'  hidden='true'  />" +
        "<input type='text' id='" + customerIdTxt + "' value='" + customerId + "' hidden='true'  />" +

        "<span class='addressBtn' id='" + addressTextId + "'>" + value + "</span>" +
        "<input id='" + newId + "'" +
        "type='text' hidden='true' class='addressBar' value='" + value + "'   placeholder='Enter Address...' />" +
        "</td>" +
        "<td>" +
        "<input type='button'  class='addressBtn' id='" + newBtnEditId + "'" + " onclick='editElement(" + addressBarId + ")'  value='Edit'  />" +
        "<input type='button'  class='addressBtn' id='" + newBtnDelId + "'" + " onclick='deleteElement(" + addressBarId + ")'  value='Delete' />" +
        "</td>" +
        "</tr>"
    );
}
function getCustomerById(id) {
    var data = new FormData();
    data.append("id", id);
    var get_url = '/CustomerPortal/GetCustomerById?id=' + id

    $.ajax({
        type: 'GET',
        url: get_url,
        //datatype: 'json',
        //contentType: 'application/json; charset=utf-8',
        //data: JSON.stringify(dataBodyJson),
        contentType: false,
        data: data,
        processData: false,
        success: function (result) {
            console.log(result);
            getCustomer = result.Customer;
            getAddresses = result.Addresses;

            console.log(getCustomer);
            console.log(getAddresses);
            Clear();


            $('#CustomerName').val(result.Customer.CustomerName);
            $('#FatherName').val(result.Customer.FatherName);
            $('#MotherName').val(result.Customer.MotherName);
            $(".MaritalStatus").each(function () {
                if ($(this).val() == 'SINGLE' && result.Customer.MaritalStatus == 1) {
                    getCustomer.MaritalStatus = 'SINGLE';
                    
                    $(this).attr('checked', true);
                }
                else if ($(this).val() == 'MARRIED' && result.Customer.MaritalStatus == 2) {
                    getCustomer.MaritalStatus = 'MARRIED';
                    
                    $(this).attr('checked', true);
                }
                else if ($(this).val() == 'OTHERS' && result.Customer.MaritalStatus == 3) {
                    getCustomer.MaritalStatus = 'OTHERS';
                    
                    $(this).attr('checked', true);
                }
            });
            $("select.country option").each(function () {
                if ($(this).val() == result.Customer.CountryId) {
                    $(this).attr('selected', true);
                }
            });
            for (var i = 0; i < result.Addresses.length; i++) {
                addAddressBarWithValue(result.Addresses[i].Address, result.Addresses[i].Id,
                    result.Addresses[i].CustomerId);

            }
        },
        error: function (error) {
            alert('Failed to receive the Data');
            console.log(error);
        }
    })



}
function deleteElement(addressBarId) {
    var newId = 'address' + addressBarId;
    var addressTextId = 'addressTxt' + addressBarId;
    var newBtnEditId = 'addressBtnEdit' + addressBarId;
    var newBtnDelId = 'addressBtnDel' + addressBarId;
    $('#' + newBtnEditId).remove(); $('#' + newBtnDelId).remove(); $('#' + newId).remove();
    $('#' + addressTextId).remove();
}
function editElement(addressBarId) {
    var newId = 'address' + addressBarId;
    var addressTxt = 'addressTxt' + addressBarId;
    $('#' + newId).removeAttr('hidden'); $('#' + addressTxt).hide();
}
function Clear() {
    $('#CustomerName').val('');
    $('#FatherName').val('');
    $('#MotherName').val('');
    $(".MaritalStatus").each(function () {
        $(this).attr('checked', false);
    });
    $(".addressBar").each(function () {
        $(this).remove();
    });
    $(".addressBtn").each(function () {
        $(this).remove();
    });
    $("#CustomerPhoto").val(null);
}
function deleteCustomerById() {

    var delete_url = '/CustomerPortal/DeleteCustomerById?id=' + getCustomer.Id

    $.ajax({
        type: 'GET',
        url: delete_url,
        contentType: false,
        //data: data,
        processData: false,
        success: function (result) {
            alert('Data Deleted Successfully');
        },
        error: function (error) {
            alert('Failed to receive the Data');
            console.log(error);
        }
    })
}