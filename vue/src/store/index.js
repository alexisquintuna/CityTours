import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
    axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
    state: {
        token: currentToken || '',
        user: currentUser || {},
        landmarks: [],
        trips: [],
        locationQuery: "",
        hotspots: [],
        zipCode: "",
        coordinates: [],
        forceRefresh: 0,
        optimizedRoute: {}
    },
    mutations: {
        SET_AUTH_TOKEN(state, token) {
            state.token = token;
            localStorage.setItem('token', token);
            axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
        },
        SET_USER(state, user) {
            state.user = user;
            console.log(state.user)
            localStorage.setItem('user', JSON.stringify(user));
        },
        LOGOUT(state) {
            localStorage.removeItem('token');
            localStorage.removeItem('user');
            state.token = '';
            state.user = {};
            axios.defaults.headers.common = {};
        },
        SET_LANDMARKS(state, payload) {
            state.landmarks = payload;
        },
        SET_LOCATION_QUERY(state, payload) {
            state.locationQuery = payload;
        },
        SET_TRIPS(state, payload) {
            state.trips = payload;
        },
        SET_HOTSPOTS(state, payload) {
            state.hotspots = payload;
        },
        SET_COORDINATES(state, payload) {
            state.coordinates = payload;
        },
        SET_OPTIMIZED_ROUTE(state, payload) {
            state.optimizedRoute = payload;
        }


    }
})