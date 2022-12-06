<template>
  <div>
    <card-details v-bind:id="landmarkId" />
  </div>
</template>

<script>
import CardDetails from "@/components/CardDetails.vue";
//import landmarkService from "../services/LandmarkService.js";

export default {
  name: "landmark-details",
  components: { CardDetails },
  //props: ['id'],
  data() {
    return { landmarkId: 0 }
  },
  // methods: {
  //   // getAllLandmarks() {
  //   //   landmarkService
  //   //     .getLandmarkById(this.landmark.id)
  //   //     .then((response) => {
  //   //       console.log("reaching");
  //   //       if (response.status === 200) {
  //   //         this.$store.commit("SET_LANDMARKS", response.data);
  //   //         console.log("reaching");
  //   //         console.log(response.data);
  //   //       }
  //   //     })
  //   //     .catch((error) => {
  //   //       if (error.response.status == 404) {
  //   //         this.$router.push({ name: "NotFound" });
  //   //       }
  //   //     });
  //   // },
  // },
  created() {
    this.landmarkId = this.$route.params.id;
  //   this.landmark = landmarkService.getLandmarkById(this.landmark.id)
  //     .then((response) => {
  //       console.log("reaching");
  //       if (response.status === 200) {
  //         //this.$store.commit("SET_LANDMARKS", response.data);
  //         console.log("reaching");
  //         console.log(response.data);
  //       }
  //     })
  //     .catch((error) => {
  //       if (error.response.status == 404) {
  //         this.$router.push({ name: "NotFound" });
  //       }
  //     });
  },
};
</script>
<style></style>
