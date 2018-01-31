var OportunitiesTableComponent = function()
{
    "use strict";
    var TABLE_ID = "oportunities-table";
    var ENDPOINT = "/api/oportunities";
    var tableElement;
    var tableBodyElement;

    function init() {
        tableElement = $("#" + TABLE_ID);
        tableBodyElement = $(tableElement).find("tbody");
        getAll();
    }

    function getAll() {
        $.ajax({
            url: ENDPOINT,
            method: "GET",
            dataType: "json",
            contentType: "application/json"
        }).done(getSuccess).fail(getFail);
    }

    function getSuccess(response) {
        console.log(response);
        for(var i=0; i<response.length; i++)
        {
            var item = getOportunityItem(i, response[i]);
            $(tableBodyElement).append(item);
        }
    }

    function getFail(error) {
        
    }

    function getOportunityItem(i, oportunity) {
        return "<tr>"
            +"<td>" + (++i) + "</td>"
            +"<td>" + oportunity.title + "</td>"
            +"<td>" + oportunity.description + "</td>"
            +"<td>" + oportunity.endDate + "</td>"
        +"</tr>";
    }

    return {
        init: init,
        getAll: getAll
    }
}