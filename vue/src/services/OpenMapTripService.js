import axios from 'axios';

const http = axios.create({
    baseURL: "https://api.opentripmap.com/0.1/en/places/radius"
})

const apiKey = '5ae2e3f221c38a28845f05b63990604f55d5cb94615f18773a16bd6c';

export default {

    getNearbyPlaces(lat, long) {
        return http.get(`?radius=10000&lon=${long}&lat=${lat}&apikey=${apiKey}`);
    }
}