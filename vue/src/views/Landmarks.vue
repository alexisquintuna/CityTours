<template>
  <div class="landmark-page">
    <div class="landmark-container">
      <landmark-list></landmark-list>
      <!-- <landmark-map></landmark-map> -->
      <mapbox-map></mapbox-map>
    </div>
  </div>
</template>

<script>
import LandmarkList from "@/components/LandmarkList.vue";
//import LandmarkMap from "@/components/LandmarkMap.vue";
import MapboxMap from "@/components/MapboxMap.vue";

export default {
  name: "landmarks",
  components: { LandmarkList, MapboxMap}, //LandmarkMap
};
</script>

<style>
.landmark-page {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  padding-bottom: 7rem;
}

.landmark-container {
  display: flex;
  justify-content: space-around;
  background-color: #f5f5f5;
  height: 50rem;
  width: 75%;
  margin: 0 auto;
  border-radius: 20px;
}

</style>
