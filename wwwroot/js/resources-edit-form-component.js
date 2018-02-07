var ResourcesEditFormComponent = function()
{
    "use strict";
    var FORM_ID = "edit-resources-form";
    var REMOVE_BTN_ID = "edit-resources-remove";
    var POST_SUGGESTION_ENDPOINT = "/api/resources";
    var RECORD_ID = 0;
    var formElement;
    var buttonElement;
    var removeButtonElement;
    var alertRemoveSuccessElement;
    var alertSuccessElement;
    var alertFailElement;

    function init(id) {
        RECORD_ID = id;
        formElement = $("#" + FORM_ID);
        buttonElement = $(formElement).find("button[type=submit]");
        removeButtonElement = $("#" + REMOVE_BTN_ID);
        alertRemoveSuccessElement = $("#remove-resources-success");
        alertSuccessElement = $("#edit-resources-success");
        alertFailElement = $("#edit-resources-fail");
        $(formElement).on("submit", post);
        $(removeButtonElement).on("click", remove);
    }

    function post(event) {
        event.preventDefault();
        $(buttonElement).button("loading");
        var data = $(formElement).serializeFormJSON();
        var url = POST_SUGGESTION_ENDPOINT + "/" + RECORD_ID;
        $.ajax({
            url: url,
            method: "PUT",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json"
        }).done(postSuccess).fail(postFail);
    }

    function postSuccess(response) {
        $(alertFailElement).addClass("hidden");
        $(alertSuccessElement).removeClass("hidden");
        $(buttonElement).button("reset");
    }

    function postFail(response) {
        $(alertSuccessElement).addClass("hidden");
        $(alertFailElement).removeClass("hidden");
        $(buttonElement).button("reset");
        $(removeButtonElement).button("reset");
    }

    function remove(event) {
        event.preventDefault();
        $(removeButtonElement).button("loading");
        if (RECORD_ID==0) return;
        var url = POST_SUGGESTION_ENDPOINT + "/" + RECORD_ID;
        $.ajax({
            url: url,
            method: "DELETE",
            data: "",
            dataType: "json",
            contentType: "application/json"
        }).done(removeSuccess).fail(postFail);
    }

    function removeSuccess(response) {
        $(alertFailElement).addClass("hidden");
        $(alertRemoveSuccessElement).removeClass("hidden");
        $(removeButtonElement).button("reset");
    }

    return {
        init: init
    }
}