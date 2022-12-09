import axios from 'axios';

export default {

    getTrips() {
        return axios.get('/trips');
    },
    getTripById(id) {
        return axios.get(`/trips/${id}`);
    },
    createTrip(trip) {
        return axios.post('/trips', trip);
    },
    addLandmarkToTrip(id, landmark) {
        return axios.post(`/trips/${id}`, landmark);
    },
    deleteTrip(id) {
        return axios.delete(`/trips/${id}`);
    },
    deleteLandmarkFromTrip(id, landmark) {
        return axios.delete(`/trips/${id}/${landmark.id}`);
    }

}