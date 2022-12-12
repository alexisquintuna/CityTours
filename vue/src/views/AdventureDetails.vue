<template>
  <div class="adventure-details-page">
    <div class="adventure-details-container">
      <adventure-card-details v-bind:id="tripId" />
      <landmark-map />
    </div>
  </div>
</template>

<script>
import AdventureCardDetails from "@/components/AdventureCardDetails.vue";
import LandmarkMap from "@/components/LandmarkMap.vue";
export default {
  name: "adventure-details",
  components: { AdventureCardDetails, LandmarkMap },
  data() {
    return {
      tripId: 0,
    };
  },
  created() {
    this.tripId = this.$route.params.id;
  },
};
</script>

<style>
.adventure-details-page{
    height: 100vh;
    display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  background-color: black;
  margin-top: 7rem;
}
.adventure-details-container{
    display: flex;
  justify-content: space-around;
  background-color: #f5f5f5;
  height: 50rem;
  width: 75%;
  margin: 0 auto;
  border-radius: 20px;
}
</style>
