import axios from 'axios';

const http = axios.create({
    baseURL: "http://api.positionstack.com/v1"
})

const apiKey = '5c8275113570eb7ad17433f7a8fa380f';

export default {

    getAddressInfo(address) {
        return http.get(`/forward?access_key=${apiKey}&query=${address}, USA&limit=1`);
    }
}