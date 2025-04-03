const apiKey = "802470abc689eda633fa2f9fc7db896d";
const apiUrl = "https://api.openweathermap.org/data/2.5/weather?&units=metric&q=";

async function checkWhether(city) {
    const response = await fetch(`${apiUrl}${city}&appid=${apiKey}`);



    if (response.status == 404) {
        document.querySelector(".error").style.display = 'block';
        document.querySelector(".whether").style.display = 'none';
    } else {
        var data = await response.json();
        console.log(data);

        document.querySelector(".city").innerHTML = data.name;
        document.querySelector(".temp").innerHTML = data.main.temp;
        document.querySelector(".humidity").innerHTML = data.main.humidity;
        document.querySelector(".wind").innerHTML = data.wind.speed;
        if (data.weather[0].main == 'Clouds') {
            document.querySelector(".whether-icon").src = "images/clouds.png"
        }
        if (data.weather[0].main == 'Clear') {
            document.querySelector(".whether-icon").src = "images/clear.png"
        }
        if (data.weather[0].main == 'Rain') {
            document.querySelector(".whether-icon").src = "images/rain.png"
        }
        if (data.weather[0].main == 'Drizzle') {
            document.querySelector(".whether-icon").src = "images/drizzle.png"
        }
        if (data.weather[0].main == 'Mist') {
            document.querySelector(".whether-icon").src = "images/mist.png"
        }
        document.querySelector(".whether").style.display = "block";
        document.querySelector(".error").style.display = "none";

    }

}
const searchBox = document.querySelector('.search input');
const searchBtn = document.querySelector('.search button');


searchBtn.addEventListener('click', () => {
    checkWhether(searchBox.value);
}
);

document.addEventListener('keydown',(event)=>{
if (event.key ==="Enter"){
    checkWhether(searchBox.value);
}


})