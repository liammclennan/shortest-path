
// sets the correct center and zoom for an array of MAP.orderedPoint
GMap2.prototype.fitMap = function(orderedPoints) {

    var points = orderedPoints.collect(function(point) {
        return new GLatLng(point.lat, point.lon);
    });
    var bounds = new GLatLngBounds();
    for (var i = 0; i < points.length; i++) {
        bounds.extend(points[i]);
    }
    this.setZoom(this.getBoundsZoomLevel(bounds));
    this.setCenter(bounds.getCenter());
};

// array of MAP.orderedPoint
GMap2.prototype.plotPoints = function(orderedPoints) {
    var mapObject = this;
    
    for (i = 0; i < orderedPoints.length; i += 1) {
        mapObject.addOverlay(new GMarker(new GLatLng(orderedPoints[i].lat, orderedPoints[i].lon), { title: orderedPoints[i].address, icon: MAP.makeIcon() }));
    }
};

GMap2.prototype.addMarkerForPoint = function(point, pointCounter) {
    var image = new GIcon(MAP.makeIcon());
    image.image = MAP.imagePrefix + "pin" + pointCounter.toString() + ".png";
    this.addOverlay(new GMarker(new GLatLng(point.lat, point.lon), { title: point.address, icon: image }));
};

GMap2.prototype.plotRoutes = function(directions) {
    MAP.mostRecentDirections = directions;
    var mapObject = this;
    var collection = [];
    var isLoop = function() {
        if (directions.Routes.length === 0) return false;
        var firstPoint = directions.Routes[0].From;
        var lastPoint = directions.Routes[directions.Routes.length - 1].To;
        return firstPoint.lat === lastPoint.lat && firstPoint.lon === lastPoint.lon;
    };

    for (i = 0; i < directions.Routes.length; i += 1) {
        var route = directions.Routes[i];
        if (i === 0) {
            collection.push(route.From);
        }
        collection.push(route.To);
    }

    var path = new GDirections(this, $('#result')[0]);
    GEvent.addListener(path, "load", function() {
        $('.result_subheading').html('about ' + path.getDuration().html);
        if (isLoop()) {
            var sf = path.getMarker(path.getNumGeocodes() - 1);
            var icon = sf.getIcon();
            icon.image = MAP.imagePrefix + "sf.png";
        }
    });
    path.loadFromWaypoints(collection.collect(function(point) {
        return point.address;
    }));
    $('.tabs').tabs('enable', 1);
    $('.tabs').tabs('select', 1);
};