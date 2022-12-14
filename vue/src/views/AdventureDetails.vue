<template>
  <div class="adventure-details-page">
    <div class="adventure-details-container">
      <adventure-card-details v-bind:id="tripId" />
      <mapbox-map-adventure />
    </div>
  </div>
</template>

<script>
import AdventureCardDetails from "@/components/AdventureCardDetails.vue";
import MapboxMapAdventure from "@/components/MapboxMapAdventure.vue";
export default {
  name: "adventure-details",
  components: { AdventureCardDetails, MapboxMapAdventure },
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
.adventure-details-page {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  margin-top: 7rem;
  padding-bottom: 7rem;
}
.adventure-details-container {
  display: flex;
  justify-content: space-around;
  background-color: #f5f5f5;
  width: 75%;
  height: 85%;
  margin: 0 auto;
  border-radius: 20px;
}
</style>
