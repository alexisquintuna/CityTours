<template>
  <div class="tripCard-details-page">
    <div class="adding-more-landmarks">
    <router-link class="btn-add-more" v-bind:to="{name: 'home'}">Add landmarks</router-link>
    </div>
    <ul class="adventure-list-card-container" v-if="hasLandmarks">
      <li
        class="adventure-card-list"
        v-for="landmark in this.landmarks"
        v-bind:key="landmark.id"
      >
        <adventure-landmark-card
          class="landmark-card"
          v-bind:landmark="landmark"
        ></adventure-landmark-card>
        <div class="adventure-btn-container">
          <button
            class="adventure-btn"
            v-on:click="deleteLandmark(landmark.id)"
          >
            Delete Landmark
          </button>
        </div>
      </li>
    </ul>
    <div class="no-items" v-show="!hasLandmarks">
          <img class="no-items-img" src="https://img.freepik.com/free-vector/rio-de-janeiro-concept-illustration_114360-4589.jpg?w=826&t=st=1670680651~exp=1670681251~hmac=0e14d75f2428b5a1ab39102f1350aaedf924de6f092286ffe6604954abaf376e" alt="">
      <h2>You have no saved landmarks let's change that</h2>
    </div>
  </div>
</template>

<script>
import tripsService from "@/services/TripsService.js";
import AdventureLandmarkCard from "@/components/AdventureLandmarkCard.vue"
import mapboxService from "@/services/MapboxService.js";

export default {
  name: "adventure-card-details",
  components: { AdventureLandmarkCard },
  data() {
    return {
      hasLandmarks: false,
      landmarks: {},
      optimizedRoute: {}
    };
  },
  computed: {
    routeCoordinates() {
      let coordinatesString = `${this.landmarks[0].longitude},${this.landmarks[0].latitude}`;
      console.log(coordinatesString);
      for (let i = 1; i < this.landmarks.length; i++) {
        coordinatesString += `;${this.landmarks[i].longitude},${this.landmarks[i].latitude}`
      }
      return coordinatesString;
    },
    locations() {
      let locationsArray = [];
      for (let i = 0; i < this.landmarks.length; i++) {
        locationsArray.push({
          name: this.landmarks[i].name,
          coordinates: [this.landmarks[i].longitude, this.landmarks[i].latitude]
        })
      }
      return locationsArray;
    },
    services() {
      let servicesArray = [];
      for (let i = 0; i < this.locations.length; i++) {
        servicesArray.push({
          name: `${this.locations[i].name}-service`,
          location: this.locations[i].name
        })
      }
      return servicesArray;
    },
    routeProblem() {
        return {
        version: 1,
        locations: this.locations,
        vehicles: [{
          name: "tourist",
          routing_profile: "mapbox/driving",
        }],
        services: this.services

        }
        
      }
  },
  props: ["id", "trip"],
  methods: {
    deleteLandmark(id) {
      tripsService
        .deleteLandmarkFromTrip(this.$route.params.id, id)
        .then((response) => {
          console.log(response.status);
          if (response.status === 200) {
             this.landmarks = response.data;
          }
        })
        .catch((error) => {
          console.log(error.response.status);
          if (error.response.status == 404) {
            this.$router.push({ name: "NotFound" });
          }
        });
    },
    generateTravelRoute() {
      mapboxService.getOptimizedRoute(this.routeCoordinates)
      .then(response => {
        if(response.status === 200) {
          console.log(response.data);
          this.optimizedRoute = response.data;
          this.$store.commit("SET_OPTIMIZED_ROUTE", this.optimizedRoute);
        }
      })
      .catch((error) => {
          console.log(error.response.status);
          console.log(error.response.data)
          if (error.response.status == 404) {
            this.$router.push({ name: "NotFound" });
          }
      });
      // mapboxService.submitRoutingProblem(this.routeProblem)
      // .then(response => {
      //   if (response.status === 202) {
      //     console.log(response.data);
      //   }
      // })
      // .catch((error) => {
      //     console.log(error.response.status);
      //     if (error.response.status == 404) {
      //       this.$router.push({ name: "NotFound" });
      //     }
      // });
    }
  },
  created() {
    tripsService
      .getTripById(this.id)
      .then((res) => {
        console.log("this is the page");
        console.log(res.data)
        console.log(res.status)
        if (res.status == 200) {
          this.landmarks = res.data;
          console.log(this.landmarks.length);
          console.log(this.landmarks[0].id != "" ? "yes" : "suggested")
          console.log(this.routeCoordinates);
          if(this.landmarks.length != 0){
            this.hasLandmarks = true;
          }
          // console.log(this.locations);
          // console.log(this.services);
          // console.log(this.routeProblem);
          //console.log(this.routeCoordinates);
          this.generateTravelRoute();
        }
      })
      .catch((err) => {
        if (err.response.status == 404) {
          this.$router.push({ name: "NotFound" });
        }
      });
    
  },
};
</script>

<style>
.tripCard-details-page {
  height: 90%;
  width: 50%;
  background-color: rgb(255, 255, 255);
  margin: 30px;
  overflow: auto;
  border-radius: 20px;
  padding: 10px 20px;
  position: relative;
}
.adventure-card-list {
  display: flex;
  align-items: center;
}
.landmark-card {
  width: 95%;
}
.adding-more-landmarks{
  height: 5rem;
  display: flex;
  justify-content: center;
  align-items: center;
}
.btn-add-more{
  border-radius: 20px;
  display: flex;
  background-color: black;
  width: 11rem;
  height: 2.5rem;
  text-align: center;
  justify-content: center;
  align-items: center;
  text-decoration: none;
  color: white;
}
.btn-add-more:hover{
  color: #59E3A8;
  background-color: #1a2e34;
  transition: 400ms;
}

.adventure-btn{
  background-color: black;
  color: white;
}

.adventure-btn:hover{
  background-color: black;
  color: #59E3A8;
}
.no-items{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.no-items-container{
  margin: 0 auto;
}
.no-items-img{
  width: 75%;
  height: 75%;
  margin: 0 auto;
}
</style>
