<template>
  <div>
      <h1>{{landmark.name}}</h1>
      <p>{{landmark.description}}</p>
      <p>Location: {{landmark.latitude}}, {{landmark.longitude}}</p>
      <p>{{landmark.address}}</p>
      <p>For more info: {{landmark.link}}</p>
  </div>
</template>

<script>

import landmarkService from '@/services/LandmarkService.js';

export default {
    name: "card-details",
    data() {
      return {
        landmark: {},
      };
    },
    props: ["id"],
    created() {
    landmarkService.getLandmarkById(this.id)
      .then((response) => {
        if (response.status === 200) {
          console.log(response.data);
          this.landmark = response.data;
        }
      })
      .catch((error) => {
        if (error.response.status == 404) {
          this.$router.push({ name: "NotFound" });
        }
      });
      
  },

    
}
</script>

<style>

</style>