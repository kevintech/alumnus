var ContactFormController = function()
{
    "use strict";
    var FORM_ID = "email-suggestion-form";
    var POST_SUGGESTION_ENDPOINT = "/api/emails";
    var formElement;
    var alertSuccessElement;
    var alertFailElement;

    function init() {
        formElement = $("#" + FORM_ID);
        alertSuccessElement = $("#email-suggestion-success")
        alertFailElement = $("#email-suggestion-fail")
        $(formElement).on("submit", postSuggestion);
    }

    function postSuggestion(event) {
        event.preventDefault();
        var data = $(formElement).serialize();
        $.post(POST_SUGGESTION_ENDPOINT, data).done(postSuccess).fail(postFail);
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