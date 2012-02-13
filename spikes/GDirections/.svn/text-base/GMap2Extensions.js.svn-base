
// sets the correct center and zoom for an array of C# points
GMap2.prototype.fitMap = function(serverPoints) {

    var points = serverPoints.collect(function(point) {
        return new GLatLng(point.LatLon.Lat, point.LatLon.Lon);
    });
    var bounds = new GLatLngBounds();
    for (var i = 0; i < points.length; i++) {
        bounds.extend(points[i]);
    }
    this.setZoom(this.getBoundsZoomLevel(bounds));
    this.setCenter(bounds.getCenter());
}

// array of C# points
GMap2.prototype.plotPoints = function(points) {
    var mapObject = this;
    $.each(points, function(i, item) {
        mapObject.addOverlay(new GMarker(new GLatLng(item.LatLon.Lat, item.LatLon.Lon), { title: item.Address }));
    });
}