import axios from 'axios';

const http = axios.create({
    baseURL: "http://api.geonames.org/postalCodeSearchJSON"
})

const apiUsername = 'drewsweet';

export default {

    getZipCodeInfo(code) {
        return http.get(`?postalCode=${code}&country=US&username=${apiUsername}`);
    }
}