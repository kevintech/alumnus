var OportunitiesController = function()
{
    "use strict";
    var FORM_ID = "new-oportunities-form";
    var POST_SUGGESTION_ENDPOINT = "/api/oportunities";
    var formElement;
    var alertSuccessElement;
    var alertFailElement;

    function init() {
        console.log("test")
        formElement = $("#" + FORM_ID);
        alertSuccessElement = $("#new-oportunities-success")
        alertFailElement = $("#new-oportunities-fail")
        $(formElement).on("submit", post);
    }

    function post(event) {
        event.preventDefault();
        var data = $(formElement).serializeArray();
        $.ajax({
            url: POST_SUGGESTION_ENDPOINT,
            method: "POST",
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json"
        }).done(postSuccess).fail(postFail);
    }

    function postSuccess(response) {
        $(alertFailElement).addClass("hidden");
        $(alertSuccessElement).removeClass("hidden");
        $(formElement).trigger("reset");
    }

    function postFail(response) {
        $(alertSuccessElement).addClass("hidden");
        $(alertFailElement).removeClass("hidden");
    }

    return {
        init: init
    }
}