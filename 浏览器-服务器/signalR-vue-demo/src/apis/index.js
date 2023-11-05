import axios from "axios";

axios.defaults.baseURL = "/api";

axios.interceptors.response.use(function(resp) {
    if (resp.status === 200) {
        return resp.data;
    }
    return Promise.reject(resp);
});

export function AddWeatherForecast() {
    return axios.request({
        url: '/WeatherForecast',
        method: 'put'
    });
}

export function DeleteWeatherForecast() {
    return axios.request({
        url: '/WeatherForecast',
        method: 'delete'
    });
}

export function EditWeatherForecast() {
    return axios.request({
        url: '/WeatherForecast',
        method: 'post'
    });
}

export function GetWeatherForecast() {
    return axios.request({
        url: '/WeatherForecast',
        method: 'get'
    });
}