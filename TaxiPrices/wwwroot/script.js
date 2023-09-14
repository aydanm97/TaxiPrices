//Create a directions service and renderer
var directionsService = new google.maps.DirectionsService();
var directionsDisplay = new google.maps.DirectionsRenderer();
//defining options for autocomplete
const options = {
    fields: ["formatted_address", "geometry", "name"],
    strictBounds: false,
};


//function to initialize the map
function initialize() {
    //Define the initial center for the map
    let myLatLng = {
        lat: 55.676098,
        lng: 12.568337
    };
    //setting map options
    let mapOptions = {
        center: myLatLng,
        zoom: 7,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    //creating a new map and set the direction render
    map = new google.maps.Map(document.getElementById('map'), mapOptions);
    directionsDisplay = new google.maps.DirectionsRenderer();
    directionsDisplay.setMap(map);
    //setup the directions service
    directionsService = new google.maps.DirectionsService();
    //inputs  for autocomplete
    let input1 = document.getElementById('from');
    let input2 = document.getElementById('to');

    const options = {
        fields: ["formatted_address", "geometry", "name"],
        strictBounds: false,
    };
    //creating autocomplete objects
    let autocomplete1 = new google.maps.places.Autocomplete(input1, options);
    let autocomplete2 = new google.maps.places.Autocomplete(input2, options);
}//function to calculate and display the route 
function calcRoute() {
    //defining requests for directions
    let request = {
        origin: document.getElementById('from').value,
        destination: document.getElementById('to').value,
        travelMode: google.maps.TravelMode.DRIVING,
        unitSystem: google.maps.UnitSystem.METRIC
    };
    //request directions from direction service
    directionsService.route(request, function (result, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            const output = document.querySelector("#output");
            output.innerHTML =
                "<div class='alert-info'>Fra: " +
                document.getElementById("from").value +
                ".<br/> To: " +
                document.getElementById("to").value +
                ".<br/> Distance <i class='fas fa-foad'></i> : " +
                result.routes[0].legs[0].distance.text +
                ". <br /> Duration <i class='fas fa-hourglass-start'></i> : " +
                result.routes[0].legs[0].duration.text +
                ".</div>"
            //Rendering the directions on the map
            directionsDisplay.setDirections(result);
        }
    });
}
