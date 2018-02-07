var OportunitiesEditFormComponent = function()
{
    "use strict";
    var FORM_ID = "edit-oportunities-form";
    var REMOVE_BTN_ID = "edit-oportunities-remove";
    var POST_SUGGESTION_ENDPOINT = "/api/oportunities";
    var RECORD_ID = 0;
    var formElement;
    var removeButtonElement;
    var alertRemoveSuccessElement;
    var alertSuccessElement;
    var alertFailElement;

    function init(id) {
        RECORD_ID = id;
        formElement = $("#" + FORM_ID);
        removeButtonElement = $("#" + REMOVE_BTN_ID);
        alertRemoveSuccessElement = $("#remove-oportunities-success")
        alertSuccessElement = $("#edit-oportunities-success");
        alertFailElement = $("#edit-oportunities-fail");
        $(formElement).on("submit", post);
        $(removeButtonElement).on("click", remove);
    }

    function post(event) {
        event.preventDefault();
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
    }

    function postFail(response) {
        $(alertSuccessElement).addClass("hidden");
        $(alertFailElement).removeClass("hidden");
    }

    function remove(event) {
        event.preventDefault();
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
    }

    return {
        init: init
    }
}