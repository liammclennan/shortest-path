<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	TheFastWay.net Route Planner
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="flash" style="clear: both;"></div>

<div class="tabs">
    <ul>    
        <li><a href="#inputs"><span>Addresses</span></a></li>    
        <li><a href="#driving_directions"><span>Directions</span></a></li>    
    </ul>

    <div id="inputs">
<form id="addressForm">
        <table id="input">
            <tr class="button_row"><td></td><td>
                <%= Html.SubmitButton("Show", "Show on Map", new { onclick="showOnMapClick();" }) %> <%= Html.SubmitButton("Path","Find Shortest Path", new { onclick="findShortestPathClick();" }) %>
            </td></tr>
            <tr><td>Start:</td><td><%= Html.TextBox("Address1", "", new { @class="addressInput" }) %></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address2", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address3", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address4", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address5", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address6", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address7", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address8", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address9", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address10", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address11", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address12", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address13", "", new { @class = "addressInput" })%></td></tr>
            <tr><td></td><td><%= Html.TextBox("Address14", "", new { @class = "addressInput" })%></td></tr>
            <tr><td>End:</td><td><%= Html.TextBox("Address15", "", new { @class = "addressInput" })%></td></tr>
            <tr class="button_row"><td></td><td>
                <%= Html.SubmitButton("Show", "Show on Map", new { onclick="showOnMapClick();" }) %> <%= Html.SubmitButton("Path","Find Shortest Path", new { onclick="findShortestPathClick();" }) %>
            </td></tr>
        </table>
        
</form>
    <div class="loading"><img src="<%= Url.Content("~/Content/Images/loading.gif") %>" alt="loading" /></div>
    </div>
    
    <div id="driving_directions">
        <h3>Driving Directions</h3>
        <span class="gpx_export">
            <% Html.BeginForm("Download", "GPX", FormMethod.Get, new { id="downloadGPX" }); %>
                <%= Html.Button("Download", "Download GPX File", HtmlButtonType.Submit) %>
                <%= Html.Hidden("toDownload") %>
            <% Html.EndForm(); %>
        </span>
        <p class="result_subheading"></p>
        <div id="result"></div>   
    </div> 
    
</div>

    <div id="map_canvas"></div>

<script type="text/javascript">

    $(document).ready(function() {
        $('.tabs').tabs({ disabled: [1] });
        MAP.map = MAP.init("map_canvas", '<%= Url.Content("~/Content/Images/pin.png") %>');
        GPX.init('<%= Url.Action("Download", "GPX") %>');
        $('#addressForm').submit(addressForm_submit);
        setAjaxFormBehaviour();
    });

    // stop the synchronous form submission
    function addressForm_submit() {
        return false;
    }

    function showOnMapClick() {
        MAP.reset();
        MAP.geocode('.addressInput', function(results) {
            MAP.map.plotPoints(results);
            MAP.map.fitMap(results);
        });
    }

    function findShortestPathClick() {
        MAP.reset();    
        MAP.geocode('.addressInput', function(geocodedPoints) {
            submitFindShortestPath(geocodedPoints);
        });
    }

    // ajax form submission to the server to find the shortest path
    function submitFindShortestPath(geocodedPoints) {
        var url = '<%= Url.Action("FindShortestPath", "Home") %>';
        $.getJSON(url, { pointsJSON: JSON.stringify(geocodedPoints) }, function(result) {
            MAP.map.plotRoutes(result.directions);
            GPX.data = result.gpx;
            $('[name=toDownload]').val(result.gpx);
        });
    }

    function setAjaxFormBehaviour() {
        jQuery().ajaxStart(function() {
            $('.loading').show();
            $('#addressForm').hide();
        });
        jQuery().ajaxStop(function() {
            $('.loading').hide();
            $('#addressForm').show();
        });
    }
</script>

</asp:Content>
