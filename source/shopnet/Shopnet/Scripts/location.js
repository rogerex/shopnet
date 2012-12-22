function initializeGoogleMap() {
    latlng = new google.maps.LatLng(-34.397, 150.644);
    myOptions = {
        zoom: 8,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("gmap"), myOptions);

    latitude = document.getElementById("Latitude");
    longitude = document.getElementById("Longitude");

    var first = true;
    if (latitude.value != "" && longitude.value != "") {
        latlng = new google.maps.LatLng(latitude.value, longitude.value);
        marker = new google.maps.Marker({
            position:latlng,
            draggable: true
        });
        google.maps.event.addListener(marker, "dragend", function(event) {
            latitude.value = this.position.lat();
            longitude.value = this.position.lng();
        });
        marker.setMap(map);
        map.setCenter(latlng);
    }else {
        google.maps.event.addListener(map,'click',function(event) {
                if (first) {
                    marker = new google.maps.Marker({
                        position: event.latLng,
                        map: map,
                        draggable:true
                    });
                    latitude.value = event.latLng.lat();
                    longitude.value = event.latLng.lng();
                    google.maps.event.addListener(marker, "dragend", function(event) {
                        latitude.value = this.position.lat();
                        longitude.value = this.position.lng();
                    });
                    marker.setMap(map);
                    first = false;
                }
            }
        );
    }
}

$(function () {
    initializeGoogleMap();
});
    
