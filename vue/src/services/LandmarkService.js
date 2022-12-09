import axios from "axios";

export default {
    getLandmarks() {
        return axios.get("/landmark");
    },
    getLandmarkById(id) {
        return axios.get(`/landmark/${id}`);
    },
    createLandmark(landmark) {
        return axios.post("/landmark", landmark);
    },
    getHotspots() {
        return axios.get("/hotspots");
    },
};