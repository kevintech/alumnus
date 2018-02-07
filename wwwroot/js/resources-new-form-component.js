var ResourcesNewFormComponent = function()
{
    "use strict";
    var FORM_ID = "new-resources-form";
    var POST_SUGGESTION_ENDPOINT = "/api/resources";
    var formElement;
    var alertSuccessElement;
    var alertFailElement;

    function init() {
        formElement = $("#" + FORM_ID);
        alertSuccessElement = $("#new-resources-success")
        alertFailElement = $("#new-resources-fail")
        $(formElement).on("submit", post);
    }

    function post(event) {
        event.preventDefault();
        var data = $(formElement).serializeFormJSON();
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