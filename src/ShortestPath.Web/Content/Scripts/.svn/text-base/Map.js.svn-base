
var MAP = {};

MAP.imagePrefix = "./Content/Images/";
MAP.mostRecentDirections = {};

MAP.makeIcon = function() {
    var baseIcon = new GIcon();
    baseIcon.image = MAP.imagePrefix + "pin.png";
    baseIcon.iconSize = new GSize(46, 34);
    baseIcon.iconAnchor = new GPoint(23, 36);
    baseIcon.infoWindowAnchor = new GPoint(9, 30);
    baseIcon.transparent = MAP.imagePrefix +  "pin_trans.png";
    return baseIcon;
};

MAP.init = function(divId, pinUrl) {
    if (GBrowserIsCompatible()) {
        var map = new GMap2(document.getElementById(divId));
        map.setCenter(new GLatLng(0, 0), 1);
        map.setUIToDefault();
        MAP.PinUrl = pinUrl;
        return map;
    }
};

MAP.geocode = function(elementSelector /* css selector for the elements that hold the addresses to geocode */, callback) {
    var isNotEmpty = function(domElement) {
        return $(domElement).val() !== "";
    };

    var resetTextboxes = function() {
        $(elementSelector).removeClass("input-validation-error");
        Help.clearIcons();
    };

    var handleGeocodeResult = function() {
        var results = [];
        for (i = 0; i < MAP.directions.getNumGeocodes(); i += 1) {
            results.push(MAP.orderedPointConstructor(i, MAP.directions.getGeocode(i).address, MAP.directions.getGeocode(i).Point.coordinates[1], MAP.directions.getGeocode(i).Point.coordinates[0]));
        }
        callback(results);
    };

    var handleGeocodeError = function() {
        var addressFound = function(result) {
            return result.Status.code === 200 && result.Placemark && result.Placemark.length > 0 && result.Placemark[0].AddressDetails.Accuracy > 7;
        };

        Help.flashError('Oh no! We can not find a path between the addresses you entered. Try specifying the full address, such as: 5 Queen St, Fitzroy North VIC 3068, Australia');

        var geocode = new GClientGeocoder();

        $(elementSelector).each(function() {
            var textbox = $(this);
            if (textbox.val() !== "") {
                geocode.getLocations(textbox.val(), function(result) {
                    if (!addressFound(result)) {
                        Debug.Log('Status: ' + result.Status.code);
                        if (result.Placemark && result.Placemark.length > 0) {
                            Debug.Log('Accuracy: ' + result.Placemark[0].AddressDetails.Accuracy);
                        } else {
                            Debug.Log('Accuracy: cant be determined');
                        }
                        textbox.addClass("input-validation-error");
                        textbox.after(Help.getHelpIcon('Sorry! We could not find this address. Suggestions: <ul><li>include a city and a state</li><li>include a zip or postal code</li><li>make sure that everything is spelled correctly</li></ul>'));
                    }
                });
            }
        });
    };

    var getAddresses = function() {
        return $(elementSelector).get()
            .where(isNotEmpty)
            .collect(function(domElement) { return $(domElement).val(); });
    }

    resetTextboxes();
    var addresses = getAddresses();
    if (addresses.length < 2) {
        alert("Please specify at least two addresses.");
        return;
    };

    MAP.directions = new GDirections();
    GEvent.addListener(MAP.directions, "load", handleGeocodeResult);
    GEvent.addListener(MAP.directions, "error", handleGeocodeError);
    MAP.directions.loadFromWaypoints(addresses);
};

MAP.orderedPointConstructor = function(index, address, lat, lon) {
    var orderedPoint = {};
    orderedPoint.index = index;
    orderedPoint.address = address;
    orderedPoint.lat = lat;
    orderedPoint.lon = lon;
    return orderedPoint;
};

MAP.reset = function() {
    MAP.map.clearOverlays();
    Help.hideFlash();
    Help.clearIcons();
    $('#result').html('');
    $('.tabs').tabs('disable', 1);
    $('.tabs').tabs('select', 0);
};
