var OportunitiesTableComponent = function()
{
    "use strict";
    var TABLE_ID = "oportunities-table";
    var INPUT_SEARCH_ID = "input-search";
    var ENDPOINT = "/api/oportunities";
    var tableElement;
    var tableBodyElement;
    var inputSearchElement;
    var typeSearchElement;

    function init() {
        tableElement = $("#" + TABLE_ID);
        tableBodyElement = $(tableElement).find("tbody");
        inputSearchElement = $("#" + INPUT_SEARCH_ID);
        typeSearchElement = $("#type-search");
        $(inputSearchElement).on("keyup", filter);
        $(typeSearchElement).change(filterType);
    }

    function getTypeFiltered() {
        return $(typeSearchElement).val().toString();
    }

    function filterType(event) {
        if (getTypeFiltered()==="") {
            resetSearch();
            return;
        }

        applySearch("");
    }

    function filter(event) {
        var query = $(this).val();
        if (query.length===0 && getTypeFiltered()==="") {
            resetSearch();
            return;
        }

        applySearch(query);
    }

    function applySearch(query) {
        $(tableBodyElement).find("tr").hide();
        $(tableBodyElement).find("tr")
            .map(function() {
                var data = $(this).data();
                if (getTypeFiltered()!=="" && data.type.toString()!==getTypeFiltered())
                {
                    return;
                }
                if (data.title.toString().toLowerCase().indexOf(query)>-1)
                {
                    return this;
                }
            })
            .show();
    }

    function resetSearch() {
        $(tableBodyElement).find("tr").show();
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
        init: init
    }
}