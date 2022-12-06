<template>
<div>
  <landmark-card v-bind:landmark="landmark" />
</div>
</template>

<script>
import LandmarkCard from "@/components/LandmarkCard.vue";
// import landmarkService from "../services/LandmarkService.js";

export default {
    name: "landmark-details",
  components: { LandmarkCard },
  methods: {
    // getAllLandmarks() {
    //   landmarkService
    //     .getLandmarkById(this.landmark.id)
    //     .then((response) => {
    //       console.log("reaching");
    //       if (response.status === 200) {
    //         this.$store.commit("SET_LANDMARKS", response.data);
    //         console.log("reaching");
    //         console.log(response.data);
    //       }
    //     })
    //     .catch((error) => {
    //       if (error.response.status == 404) {
    //         this.$router.push({ name: "NotFound" });
    //       }
    //     });
    // },
  },
  computed: {
      landmark(){
          const foundLandmark = this.$store.state.landmarks.find((lm) => lm.id === this.$route.params.id)
          return foundLandmark
      }
  }
};
</script>
<style></style>
