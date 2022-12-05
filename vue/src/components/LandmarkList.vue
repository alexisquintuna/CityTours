<template>
<div>
    <landmark-card></landmark-card>
</div>

</template>

<script>
import LandmarkCard from "@/components/LandmarkCard.vue";
import landmarkService from "../services/LandmarkService.js";

export default {
  name: "landmark-list",
  components: {LandmarkCard},
  methods: {
    getAllLandmarks() {
      landmarkService.getLandmarks()
        .then((response) => {
            console.log("reaching")
          if (response.status === 200) {
            this.$store.commit("SET_LANDMARKS", response.data);
            console.log("reaching")
            console.log(response.data);
          }
        })
        .catch((error) => {
          if (error.response.status == 404) {
            this.$router.push({ name: "NotFound" });
          }
        });
    }
  },
  created() {
      console.log("reaching created");
    this.getAllLandmarks();
  }
};
</script>

<style>

</style>