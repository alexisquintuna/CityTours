import axios from 'axios';

const http = axios.create({
    baseURL: "https://api.mapbox.com/geocoding/v5"
})

const apiKey = 'pk.eyJ1IjoiZHJld3N3ZWV0IiwiYSI6ImNsYmgwM2kzdDBlb2MzcHFtZm8zajg2ZzIifQ.pDG4UufOD--ptSzeCeiPWA';

export default {

    getAddressInfo(address) {
        return http.get(`/mapbox.places/${address}.json?access_token=${apiKey}`);
    }
}

