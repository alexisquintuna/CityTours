<template>
  <div class="tripCard-details-page">
    <h1>This is the trip card details</h1>
    <h1>somethign</h1>
    <ul>
      <li class="adventure-card-list" v-for="landmark in this.trips" v-bind:key="landmark.xid">
        <landmark-card
          class="landmark-card"
          v-bind:landmark="landmark"
        ></landmark-card>
        <div class="adventure-btn-container">
          <button class="adventure-btn">Delete Landmark</button>
        </div>
      </li>
    </ul>
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
      trips: {},
    };
  },
  props: ["id"],
  created() {
    tripsService
.getTripById(this.id)
      .then((res) => {
        console.log("this is the page");
        if (res.status == 200) {
          this.trips = res.data;
          console.log(this.trips);
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
.adventure-card-list{
  display: flex;
}
.landmark-card{
  background-color: cadetblue;
  width: 95%;
}
</style>
