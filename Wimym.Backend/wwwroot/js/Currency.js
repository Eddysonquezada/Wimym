﻿var localStorage = window.localStorage;
class Currency {
    constructor(code, name, state,action)
    {//the properties here are create dinamically just using the this attribute
        this.code = code;
        this.name = name;
        this.state = state;
        this.action = action;
    }

    addCurrency() {
        if (this.code == "") {
            document.getElementById("Code").focus();
            return;
        }
        if (this.name == "") {
            document.getElementById("Name").focus();
            return;
        }
        if (this.state == "0") {
            document.getElementById("messageTag").innerHTML = "Select a Status!!!!!!!";
            return;
        }

         var code = this.code;
        var name = this.name;
        var action = this.action;
        var state = this.state;
        var mesage = "";

        $.ajax({
            type: "POST", url: action,
            data: { code, name,state },
            success: (response) => {//lambda function
                $.each(response, (index, val) =>
                {
                    mesage = val.code.substring(0, 3);
                });
                if (mesage === "200") {
                    this.restore();
                } else {
                    document.getElementById("messageTag").innerHTML = "Currency Can't be saved :'D";
                }
            }
        });
    }

    filterData(pageNum) {
        var filterValue = this.code;
        var action = this.action;
        if (filterValue == "") {
             filterValue = "null";
        }
        $.ajax({
            type: "POST",
            url: action,
            data: { filterValue, pageNum },
            success: (response) => {
                console.log(response);
                $.each(response, (index, val) => {
                    $("#resultSearch").html(val[0]);
                    $("#pagination").html(val[1]);
                });
            }
        });
    }

    getCurrency(id) {
        var action = this.action;
        //remember something, in the data of ajax call, if your paramater name is distinct 
        //from your send it parameter you need to specify the name, 
        //data: { pIdentifier: identifier },
        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) =>
            {
                console.log(response);

                if (response[0].state) {
                    document.getElementById("titleCurrency").innerHTML =
                        "Are you sure you want to deactivate this currency? " + response[0].code;
                } else {
                    document.getElementById("titleCurrency").innerHTML =
                        "Are you sure you want to activate this currency? " + response[0].code;
                }
                //save data in storage by a key identifier, this save just string using html5
                //up to 5 MB
                localStorage.setItem("currency", JSON.stringify(response));
            }
        });
    }

    editCurrency(id, type) {
        var code = null; var name = null; var state = null; var action = null;
        switch (type) {
            case "state":
                var response = JSON.parse(localStorage.getItem("currency"));
                code = response[0].code;
                name = response[0].name;
                state = response[0].state;
                localStorage.removeItem("currency");
                this.edit(id, code, name, state, type);
                break;
            default:
        }
    }

    edit(id, code, name, state, type)
    {
        var action = this.action;
        $.ajax({
            type: "POST",
            url: action,
            data: { id, code, name, state, type },
            success: (response) => {
                console.log(response);
                this.restore();
            }
        });
    }

    restore() {
        document.getElementById("Code").value = "";
        document.getElementById("Name").value = "";
        document.getElementById("messageTag").innerHTML = "";
        document.getElementById("State").selectedIndex = 0;
        $('#modalAdd').modal('hide'); 
        $('#ModalState').modal('hide');
        filterData(1);
    }
}
