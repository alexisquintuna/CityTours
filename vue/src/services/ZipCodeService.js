import axios from 'axios';

const http = axios.create({
    baseURL: "http://api.geonames.org/",
    withCredentials: false
})

const apiUsername = 'drewsweet';

export default {

    getZipCodeInfo(code) {
        return http.get(`postalCodeLookupJSON?postalcode=${code}&country=US&username=${apiUsername}`);
    }
}