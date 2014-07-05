function initializeMap(cars) {
    // options of map
    var mapOptions = {
        zoom: 4,
        center: new google.maps.LatLng(0, 0)
    };
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    // iterate on cars
    // retrived as JSON
    for (i = 0; i < cars.length; ++i) {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/api/CarStates/" + cars[i].Id,
            context: cars[i],
            success: function (data) {
                car = $(this)[0];
                // current car's latlong
                var carLatLong = new google.maps.LatLng(data.Latitude, data.Longitude);
                // create marker on map
                // having position carLatLong
                var marker = new google.maps.Marker({
                    position: carLatLong,
                    map: map, // global map
                    title: car.Manufacturer + " " + car.Model
                });

                // fill out simple text to show on tooltip
                var infoContent = "<div width=\"200px\" height=\"200px\">";
                infoContent += "<b>Id</b>: " + car.Id + "</br>";
                infoContent += "<b>Model</b>: " + car.Model + "</br>";
                infoContent += "<b>Manufacturer</b>: " + car.Manufacturer + "</br>";
                infoContent += "<b>Color</b>: " + car.Color + "</br>";
                infoContent += "</div>";

                // create new infobox
                var infoBox = new google.maps.InfoWindow({
                    content: infoContent
                });

                // bind infobox to marker's click
                google.maps.event.addListener(marker, 'click', function () {
                    infoBox.open(map, marker);
                });
            },

            error: function (e) {
                console.log(e.statusText);
            }
        });
    }


}

function initialize() {
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/api/Cars",
        success: function (data) {
            initializeMap(data);
        },
        error: function (e) {
            console.log(e.statusText);
        }
    });
}

google.maps.event.addDomListener(window, 'load', initialize);