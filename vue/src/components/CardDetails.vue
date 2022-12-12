<template>
  <div class="details-page">
    <div class="details-container">
      <div class="details-main">
    <router-link id="back" v-bind:to="{ name: 'landmarks', params: {query: this.$store.state.locationQuery} }">BACK</router-link>
        <div class="header-section">
          <h1 class="landmark-header">{{ landmark.name }}</h1>
          <p class="landmark-subheader">In {{ landmark.address.city }}, {{landmark.address.country}} </p>
          <button class="landmark-headerBtn">Save adventure</button>
        </div>
        <section class="info-section">
          <div class="right-side">
            <img
              id="details-img"
              v-bind:src='image'
              alt="picture of location"
            />
            <p class="details-description">{{ landmark.wikipedia_extracts.text }}</p>
          </div>
          <aside>
            <h3>Details</h3>
            <p class="aside-p">
              <span class="aside-span">Address</span> {{ landmark.address.house_number }} {{ landmark.address.road }} {{ landmark.address.city }} {{ landmark.address.postcode }}
            </p>
            <p class="aside-p">
              <span class="aside-span">Website</span>
              <a :href="landmark.link" target="_blank" class="details-link">{{
                landmark.url ? landmark.url : "No Website link found"
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

export default {
  name: "card-details",
  data() {
    return {
      landmark: {},
      image: ""
    };
  },
  props: ["id"],
  created() {
    openMapTripService.getPlaceDetails(this.id)
    .then((response) => {
      console.log(response.data)
      if (response.status === 200) {
        this.landmark = response.data;
        this.image = this.landmark.preview.source;
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
