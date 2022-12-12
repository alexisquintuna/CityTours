<template>
  <div class="">
    <div class="adventure-list">
      <div class="adv-list-container">
        <adventure-card
          class="adv-card"
          v-for="trip in this.$store.state.trips"
          v-bind:key="trip.id" v-bind:trip="trip"
        />
      </div>
    </div>
  </div>
  <!-- fix icons too -->
</template>

<script>
import AdventureCard from "./AdventureCard.vue";
import TripsService from "../services/TripsService.js";
export default {
  name: "adventure-list",
  components: { AdventureCard },
  methods: {
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
.adventure-list {
  width: 100%;
}

.adv-list-container {
  display: flex;
  justify-content: flex-start;
  width: 25% 25% 25% 25%;
  flex-wrap: wrap;
}
.adv-card {
  margin: 1rem;
}
</style>