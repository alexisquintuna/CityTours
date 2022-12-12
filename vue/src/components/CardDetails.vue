<template>
  <div class="details-page">
    <div class="details-container">
      <div class="details-main">
    <router-link id="back" v-bind:to="{ name: 'landmarks', params: {query: this.$store.state.locationQuery} }">BACK</router-link>
        <div class="header-section">
          <h1 class="landmark-header">{{ rawLandmark.name }}</h1>
          <p class="landmark-subheader">In {{ rawLandmark.address.city }}, {{rawLandmark.address.country}} </p>
          <form class="addLandmarkBtn" v-on:submit.prevent="adding">
            <label for="trips">Add To An Adventure:</label>
            <select name="trips" class="form-control" v-model="trip">
              <option>Select Adventure</option>
              <option v-for="trip in this.$store.state.trips"
              v-bind:key="trip.id" v-bind:value="trip">{{trip.name}}</option>
            </select>
            <input type="submit">
          </form>
        </div>
        <section class="info-section">
          <div class="right-side">
            <img
              id="details-img"
              v-bind:src='image'
              alt="picture of location"
            />
            <p class="details-description">{{ rawLandmark.wikipedia_extracts.text }}</p>
          </div>
          <aside>
            <h3>Details</h3>
            <p class="aside-p">
              <span class="aside-span">Address</span> {{ rawLandmark.address.house_number }} {{ rawLandmark.address.road }} {{ rawLandmark.address.city }} {{ rawLandmark.address.postcode }}
            </p>
            <p class="aside-p">
              <span class="aside-span">Website</span>
              <a :href="rawLandmark.link" target="_blank" class="details-link">{{
                rawLandmark.url ? rawLandmark.url : "No Website link found"
              }}</a>
            </p>
            <br />
            <hr />
          </aside>
        </section>
      </div>
    </div>
  </div>
</template>
 
<script>
import openMapTripService from "../services/OpenMapTripService.js";
import TripsService from '../services/TripsService.js';

export default {
  name: "card-details",
  data() {
    return {
      rawLandmark: {},
      image: "",
      landmark:{
        name: '',
        description: '',
        category: '',
        latitude: '',
        longitude: '',
        address: '',
        link: '',
        photo: '',
      },
      trip: {
        id: '',
        name: '',
      }
    };
  },
  props: ["id"],
  methods: {
    adding() {
      TripsService
      .addLandmarkToTrip(this.trip.id, this.landmark)
      .then((res) => {
        if (res.status == 200) {
          console.log(res.status)
        }
      })
      .catch ((err) => {
        if(err.response.status==400) {
          console.log(err.response.status)
        }
      });
    }
  },
  created() {
    openMapTripService.getPlaceDetails(this.id)
    .then((response) => {
      console.log(response.data)
      if (response.status === 200) {
        console.log(response.data);
        this.rawLandmark = response.data;
        
        this.image = this.rawLandmark.preview.source;
        this.landmark.name= `${this.rawLandmark.name}`;
        this.landmark.description= `${this.rawLandmark.wikipedia_extracts.text}`;
        this.landmark.category= `${this.rawLandmark.kinds}`;
        this.landmark.latitude= `${this.rawLandmark.point.lat}`;
        this.landmark.longitude= `${this.rawLandmark.point.lon}`;
        this.landmark.address= `${this.rawLandmark.address.house_number} ${this.rawLandmark.address.road}, ${this.rawLandmark.address.city}, ${this.rawLandmark.address.postcode}`;
        this.landmark.link= `${this.rawLandmark.link}`;
        this.landmark.photo= `${this.image}`;
      }
    })
    .catch((error) => {
      if (error.response.status == 404) {
        this.$router.push({name: "NotFound"});
      }
    })
  },
};
</script>

<style>

.details-page {
  background-color: rgb(255, 255, 255);
  color: black;
  padding: 0;
  height: 160vh;
}
.details-container {
  margin: 1rem auto;
  padding: 10px;
  height: 100%;

}
.details-main {
  width: 78%;
  margin: 1rem auto;
  height: 90%;
}

#back {
  color: black;
  text-decoration: none;
  font-size: 20px;
  font-weight: bold;
}

.header-section {
  margin: 25px 0;
  display: flex;
  flex-direction: column;
  position: relative;
  width: 100%;
  justify-content: center;
}
.landmark-headerBtn{
  height: 3rem;
  width: 10rem;
  background-color: black;
  color: white;
  position: absolute;
  right: 0rem;
}
.landmark-headerBtn{
  border: 1px solid black;
}

.header-section h1,
.header-section p {
  margin: 5px 0;
  padding: 0;
}
.right-side {
  padding-right: 2rem;
  grid-area: "info";
}
.landmark-header {
  font-size: 48px;
}

.landmark-subheader{
  font-style: italic;
}
.info-section {
  height: auto;
  display: grid;
  grid-template-columns: 3fr 1fr;
  grid-template-areas: "info" "aside";
}

#details-img {
  border-radius: 0px;
  width: 60rem;
  height: 75%;
}
.details-description {
  font-size: 24px;
  width: 75%;
  margin: 50px auto;
  padding-top: 20px;
}
aside {
  grid-area: "aside";
  margin-right: 2rem;
}
aside h3 {
  margin: 1rem 0;
  font-size: 1.8rem;
}
.aside-p {
  margin: 0.5rem 0;
  font-size: 1rem;
  width: 20rem;
  overflow: hidden;
  display: flex;
}
.aside-span {
  color: rgb(80, 80, 80);
  margin-right: 1rem;
}

.details-link {
  color: blue;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 20rem;
}
</style>
