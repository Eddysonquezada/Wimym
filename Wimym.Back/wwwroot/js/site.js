var items;
var j = 0;
var id;
var userName;
var email;
var phoneNumber;
var rol;
var selectRol;

var accessFailedCount;
var concurrencyStamp;
var emailConfirmed;
var lockoutEnabled;
var lockoutEnd;
var normalizedUserName;
var normalizedEmail;
var passwordHash;
var phoneNumberConfirmed;
var securityStamp;
var twoFactorEnabled;

$('#editModal').on('shown.bs.modal', function () {
    $('#myInput').focus()
});

function getUser(id, action) {
    $.ajax({
        type: "POST",
        url: action,
        data: { id },
        success: function (response) {
            showUser(response);
        }
    });
}

function showUser(response) {
    items = response;
    j = 0;
    for (var i = 0; i < 3; i++) {
        var x = document.getElementById('Select');
        x.remove(i);
    }

    $.each(items, function (index, val) {
        $('input[name=Id]').val(val.id);
        $('input[name=UserName]').val(val.userName);
        $('input[name=Email]').val(val.email);
        $('input[name=PhoneNumber]').val(val.phoneNumber);
        document.getElementById('Select').options[0] = newOption(val.rol, val.rolId);
    });

    $("#dEmail").text(val.email);
    $("#dUserName").text(val.userName);
    $("#dPhoneNumber").text(val.phoneNumber);
    $("#dRol").text(val.rol);

    //$('#delUserId').val(val.id);
    $('input[name=delUserId]').val(val.id);
    $('#delUser').val(val.userName);


}

function getRols(action) {
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (j == 0) {
                for (vari = 0; i < response.length; i++) {
                    document.getElementById('Select').options[i] = newOption(response[i].text, response[i].value);
                    document.getElementById('SelectNew').options[i] = newOption(response[i].text, response[i].value);
                }
                j = 1;
            }
        }
    });
}

function editUser(action) {
    id = $('input[name=Id]')[0].value;
    email = $('input[name=Email]')[0].value;
    phoneNumber = $('input[name=PhoneNumber]')[0].value;

    rol = document.getElementById('Select');
    selectRol = role.options[rol.selectedIndex].text;

    $.each(items, function (index, val) {
        accessFailedCount = val.accessFailedCount;
        concurrencyStamp = val.concurrencyStamp;
        emailConfirmed = val.emailConfirmed;
        lockoutEnabled = val.lockoutEnabled;
        lockoutEnd = val.lockoutEnd;
        userName = val.userName;
        normalizedUserName = val.normalizedUserName;
        normalizedEmail = val.normalizedEmail;
        passwordHash = val.passwordHash;
        phoneNumberConfirmed = val.phoneNumberConfirmed;
        securityStamp = val.securityStamp;
        twoFactorEnabled = val.twoFactorEnabled;
    });

    $.ajax({
        type: "POST",
        url: action,
        data: {
            id, userName, email, phoneNumber, accessFailedCount,
            concurrencyStamp,
            emailConfirmed,
            lockoutEnabled,
            lockoutEnd,
            normalizedUserName,
            normalizedEmail,
            passwordHash,
            phoneNumberConfirmed,
            securityStamp,
            twoFactorEnabled, selectRol
        },
        success: function (response) {
            if (response = "Saved") {
                window.location.href = "Users";
            }
            else {
                alert("Something was wrong!!!");
            }
        }
    });
}

function hideUserDetail() {
    $("#detailModal").modal("hide");
}

function DeleteUser(action) {
    var id = $('input[name=delUserId]')[0].value;
    $.ajax(
        {
            type: "POST",
            url: action,
            data: { id },
            success: function (response) {
                if (response === "Delete") {
                    window.location.href = "Users";
                }
                else {
                    alert("User can't be deleted!!!!!");
                }
            }
        });
}

function createUser(action) {

    email = $('input[name=EmailNew]')[0].value;
    phoneNumber = $('input[name=PhoneNumberNew]')[0].value;
    passwordHash = $('input[name=PasswordNew]')[0].value;
    rol = document.getElementById('SelectNew');
    selectRol = rol.options[rol.selectedIndex].text;
    answer = "";

    if (email == "") {
        $('#EmailNew').focus();
        alert("Add an valid Email for this user");
        return;
    }
    //else
    //{

    if (passwordHash == "") {
        $('#PasswordNew').focus();
        alert("Add a Password for this user");
        return;
    }
    //else
    //{ 
    $.ajax({
        type: "POST",
        url: action,
        data: { email, phoneNumber, passwordHash, selectRol },
        success: function (response) {
            if (response == "Save") {
                window.location.href = "Users";
            }
            else {
                $('#NewMessage').html("Can't save the user. <br/>Choose a rol. <br/> Add an Valid Email. <br/> Passwrod must have from 6-20 characters, almost an especial character, one Upper case letter and on number");
            }
        }
    });
    // }
    //}
}


