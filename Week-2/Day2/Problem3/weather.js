// PROMISE VERSION
const fetchWeatherPromise = () => {
    fetch("https://api.open-meteo.com/v1/forecast?latitude=17.48&longitude=78.38&current_weather=true")
        .then(response => response.json())
        .then(data => {
            const temp = data.current_weather.temperature;
            const wind = data.current_weather.windspeed;

            console.log(`(Promise) Temperature: ${temp}°C`);
            console.log(`(Promise) Wind Speed: ${wind} km/h`);
        })
        .catch(error => {
            console.log("Error fetching weather (Promise):", error);
        });
};


// ASYNC/AWAIT VERSION
const fetchWeatherAsync = async () => {
    try {
        const response = await fetch("https://api.open-meteo.com/v1/forecast?latitude=17.48&longitude=78.38&current_weather=true");
        const data = await response.json();

        const temp = data.current_weather.temperature;
        const wind = data.current_weather.windspeed;

        console.log(`(Async) Temperature: ${temp}°C`);
        console.log(`(Async) Wind Speed: ${wind} km/h`);

    } catch (error) {
        console.log("Error fetching weather (Async):", error);
    }
};


// CALL FUNCTIONS
fetchWeatherPromise();
fetchWeatherAsync();