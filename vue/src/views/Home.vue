<template>
  <div class="home">
    <div class="home-container">

    <form class="home-form" action="" v-on:submit="saveQuery">
      <input
        class="home-input sub-title-font"
        type="text"
        placeholder="Please enter a location"
        v-model="locationQuery"
      />
        <router-link
          class="submit-btn"
          v-bind:to="{ name: 'landmarks', params: { query: locationQuery } }"
        >
          <input class="enter-zip sub-title-font " type="submit" />
        </router-link>
    </form>

    <div class="landmark-suggestion">
        <h1 class="main-title-font">Hotspots</h1>
      <suggestion-list class="suggestion-container"></suggestion-list>
    </div>

    </div>

  </div>
</template>

<script>
import SuggestionList from "@/components/LandmarkSuggestions.vue"
import TripsService from "../services/TripsService.js"
export default {
  name: "home",
  components: {SuggestionList},
  data() {
    return {
      locationQuery: "",
    };
  },
  methods: {
    saveQuery() {
      this.$store.commit("SET_LOCATION_QUERY", this.locationQuery);
    },
    getTripsByUser() {
      TripsService.getTrips()
        .then((response) => {
          console.log(response.data)
          if (response.status === 200) {
            this.$store.commit("SET_TRIPS", response.data);
          }
        })
        .catch((error) => {
          if (error.response.status == 400) {
            this.$router.push({ name: "NotFound" });
          }
        });
    },
  },
  created() {
    console.log("reaching created");
    this.getTripsByUser();
  },
};
</script>

<style>
.home {
  height: 120vh;
  display: flex;
  flex-direction: column;
}

/* color */
  /* background-color: rgb(165, 62, 62); */

.home-header{
  background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0.938) 35%, rgba(255, 255, 255, 0.733));
  width: 100%;
  height: 100%;
  display: flex;
  align-items: center;
  justify-content: center;
}

.home-header > h1{
  color: white;
  font-size: 4rem;
  font-weight: bold;
}
 
.home-container{
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  height: 100%;
  width: 100%;

}

.home-form {
  width: auto;
  display: flex;
  align-items: center;
  backdrop-filter: blur(1px);
}

.home-input {
  background-color: rgba(255, 255, 255, 0);
  border-bottom: 5px solid white;
  border-radius: 0px;
  font-size: 65px;
  height: 7rem;
  color: white;
  width: 34rem;
  font-size: 3rem;
}


.submit-btn {
  height: 50%;
  width: 8rem;
  border-radius: 20px;
  background-color: #dbdbdb;
  display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: none;
}

.submit-btn:hover {
  cursor: pointer;
  background-color: black;
  color: white;
  transition: 500ms;
  border-radius: 20px;

}
.enter-zip:hover {
  border-radius: 20px;
  cursor: pointer;
  background-color: black;
  color: white;
  transition: 400ms;
}
.enter-zip {
  font-size: 1.4rem;
  height: 100%;
  width: 100%;
  background-color: #fff;
  color:#1A2E34;
  border-radius: 20px;
  margin: 0;
  padding: 0;
}

.home-input::placeholder {
  color: white;
}

.home-input:focus::placeholder {
  color: white;
}

.landmark-suggestion {
  /* position: absolute; */
  /* bottom: 10rem; */
  margin: 5rem auto 0;
  height: 20rem;
  width: 75%;
  background-color:  #7c7c7cd8;
  border-radius: 30px;
}

.landmark-suggestion > h1 {
    font-size: 2.5rem;
    display: inline-block;
    margin: 1rem 1rem 0rem 2.7rem;
    color: rgb(255, 255, 255);
    font-weight: 500;
    padding-left: 2%;
}

.suggestion-container{
  height: 70%;
  /* width: 50%; */
}
</style>
