<template>
  <div class="tripCard-details-page">
    <div class="adding-more-landmarks">
    <router-link class="btn-add-more" v-bind:to="{name: 'home'}">Add landmarks</router-link>
    </div>
    <ul class="adventure-list-card-container" v-if="hasLandmarks">
      <li
        class="adventure-card-list"
        v-for="landmark in this.landmarks"
        v-bind:key="landmark.xid"
      >
        <landmark-card
          class="landmark-card"
          v-bind:landmark="landmark"
        ></landmark-card>
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
import LandmarkCard from "@/components/LandmarkCard.vue";

export default {
  name: "adventure-card-details",
  components: { LandmarkCard },
  data() {
    return {
      hasLandmarks: false,
      landmarks: {},
    };
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
  },
  created() {
    tripsService
      .getTripById(this.id)
      .then((res) => {
        console.log("this is the page");
        if (res.status == 200) {
          this.landmarks = res.data;
          console.log(this.trips);
          if(this.trips.length != 0){
            this.hasTrips = true;
          }
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
