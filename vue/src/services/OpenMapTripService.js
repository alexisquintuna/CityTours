import axios from 'axios';

const http = axios.create({
    baseURL: "https://api.opentripmap.com/0.1/en/places"
})

const apiKey = '5ae2e3f221c38a28845f05b63990604f55d5cb94615f18773a16bd6c';

export default {

    getNearbyPlaces() {
        return http.get(`/radius?radius=10000&lon=-73.9632&lat=40.7794&rate=3h&format=json&limit=30&apikey=${apiKey}`);
    },

    getPlaceDetails(xid) {
        return http.get(`/xid/${xid}?apikey=${apiKey}`);
    }
}