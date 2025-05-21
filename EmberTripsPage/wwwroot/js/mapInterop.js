// wwwroot/js/mapInterop.js

var map;
var markers = [];
var polyline;
var dotNetReference; // To call C# methods from JS

export function initializeMap(mapId, initialLat, initialLng, initialZoom, dotNetHelper) {
    dotNetReference = dotNetHelper; // Store the .NET reference

    map = L.map(mapId).setView([initialLat, initialLng], initialZoom);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);
}

export function addMarker(lat, lng, popupText) {
    const marker = L.marker([lat, lng]).addTo(map);
    if (popupText) {
        marker.bindPopup(popupText).openPopup();
    }
    markers.push(marker);
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
            padding: [50, 50],
            maxZoom: 10,
            animate: true
        });
    }
}