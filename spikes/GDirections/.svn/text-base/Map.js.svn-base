
var MAP = {};

MAP.pollAttempts = 0;

MAP.init = function(divId) {
    if (GBrowserIsCompatible()) {
        var map = new GMap2(document.getElementById(divId));
        map.setCenter(new GLatLng(0, 0), 1);
        map.setUIToDefault();
        return map;
    }
};


MAP.geocode = function(elementSelector /* css selector for the elements that hold the addresses to geocode */, callback) {
    var isNotEmpty = function(domElement) {
        return $(domElement).val() !== "";
    };
    
    var checkForGeocodedResults = function() {
        Debug.Log("attempting to read geocodes");
        MAP.pollAttempts += 1;
        if (MAP.pollAttempts > 50) {
            return;
        }

        if (!MAP.directions || MAP.directions.getNumGeocodes() == 0) {
            setTimeout(checkForGeocodedResults, 1000);
            return;
        }
        var results = [];
        for (i = 0; i < MAP.directions.getNumGeocodes(); i += 1) {
            results.push(MAP.orderedPointConstructor(i, MAP.directions.getGeocode(i).address, MAP.directions.getGeocode(i).Point.coordinates[0], MAP.directions.getGeocode(i).Point.coordinates[1]));
        }
        alert(results[0].address);
        callback(results);
    };
    
    var addresses = $(elementSelector).get()
        .where(isNotEmpty)
        .collect(function(domElement) { return $(domElement).val(); });

    MAP.directions = new GDirections(MAP.map, null);
    MAP.directions.loadFromWaypoints(addresses);
    MAP.pollAttempts = 0;
    setTimeout(checkForGeocodedResults, 1000);    
};

MAP.orderedPointConstructor = function(index, address, lat, lon) {
    var orderedPoint = {};
    orderedPoint.index = index;
    orderedPoint.address = address;
    orderedPoint.lat = lat;
    orderedPoint.lon = lon;
    return orderedPoint;
};
