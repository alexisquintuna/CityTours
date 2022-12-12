import axios from 'axios';

const http = axios.create({
    baseURL: "https://api.mapbox.com"
})

const mapboxAccessToken = 'pk.eyJ1IjoiZHJld3N3ZWV0IiwiYSI6ImNsYmgwM2kzdDBlb2MzcHFtZm8zajg2ZzIifQ.pDG4UufOD--ptSzeCeiPWA';

export default {

    getAddressInfo(address) {
        return http.get(`/geocoding/v5/mapbox.places/${address}.json?access_token=${mapboxAccessToken}`);
    },
    submitRoutingProblem(routingProblemDocument) {
        return http.post(`/optimized-trips/v2?access_token=${mapboxAccessToken}`, routingProblemDocument);
    },
    retrieveRoutingSolution(id) {
        return http.get(`/optimized-trips/v2/${id}?access_token=${mapboxAccessToken}`);
    }
}

