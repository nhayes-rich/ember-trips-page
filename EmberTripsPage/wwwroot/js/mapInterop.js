// wwwroot/js/mapInterop.js

var map;
var markers = [];
var dotNetReference; // To call C# methods from JS

export function initializeMap(mapId, initialLat, initialLng, initialZoom, dotNetHelper) {
    dotNetReference = dotNetHelper; // Store the .NET reference

    map = L.map(mapId).setView([initialLat, initialLng], initialZoom);
    markers = [];

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
}

export function addMarker(lat, lng, popupText, stopClass) {
    var htmlIcon = L.divIcon({
        html: `<div class="map-marker-icon stage-${stopClass}"></div>`,
        className: '',
        iconSize: [10, 10]
    });

    var zOffset = 0;
    if (stopClass !== "intermediate") {
        zOffset = 1000;
    }

    const marker = L.marker([lat, lng], { icon: htmlIcon, zIndexOffset: zOffset }).addTo(map);

    if (popupText) {
        marker.bindPopup(popupText);
    }

    markers.push(marker);
}

export function addRoute() {
    const router = L.Routing.osrmv1();

    var latLngs = markers.map(m => new L.Routing.Waypoint(m.getLatLng()));

    console.log(latLngs);

    router.route(
        latLngs,
        function (err, routes) {
            if (!err && routes.length > 0) {
                const line = L.Routing.line(routes[0], {
                    styles: [{ color: 'darkslategray', weight: 3 }]
                }).addTo(map);
            }
        });
}

export function clearWaypointsAndRoute() {
    markers.forEach(marker => map.removeLayer(marker));
    markers = [];
    if (polyline) {
        map.removeLayer(polyline);
        polyline = null;
    }
}

export function fitBounds(minLat, minLong, maxLat, maxLong) {
    if (map) {
        var bounds = L.latLngBounds(
            new L.LatLng(minLat, minLong),
            new L.LatLng(maxLat, maxLong)
        );

        map.fitBounds(bounds, {
            padding: [20, 20],
            maxZoom: 10,
            animate: true
        });
    }
}