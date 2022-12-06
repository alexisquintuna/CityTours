import axios from 'axios';

export default {

    getLandmarks() {
        return axios.get('/landmark');
    },
    getLandmarkById(id) {
        return axios.get(`/landmark/${id}`)
    }
}