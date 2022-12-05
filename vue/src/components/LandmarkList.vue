<template>
  <div class="list">
    <landmark-card class="landmark-card" v-bind:landmark="landmark" v-for="landmark in this.$store.state.landmarks"
          v-bind:key="landmark.id"></landmark-card>
  </div>
</template>

<script>
import LandmarkCard from "@/components/LandmarkCard.vue";
import landmarkService from "../services/LandmarkService.js";

export default {
  name: "landmark-list",
  components: { LandmarkCard },
  methods: {
    getAllLandmarks() {
      landmarkService
        .getLandmarks()
        .then((response) => {
          console.log("reaching");
          if (response.status === 200) {
            this.$store.commit("SET_LANDMARKS", response.data);
            console.log("reaching");
            console.log(response.data);
          }
        })
        .catch((error) => {
          if (error.response.status == 404) {
            this.$router.push({ name: "NotFound" });
          }
        });
    },
  },
  created() {
    console.log("reaching created");
    this.getAllLandmarks();
  },
};
</script>

<style>
.list {
  width: 50%;
  background-color: brown;
  margin: 30px;
  border-radius: 20px;
  overflow: auto;
}

/* width */
::-webkit-scrollbar {
  width: 20px;
}

/* Track */
/* ::-webkit-scrollbar-track {
  box-shadow: inset 0 0 5px rgb(253, 253, 253); 
  border-radius: 10px;
} */

::-webkit-scrollbar-button {
  height: 50px;
  width: 10px;
}
/* Handle */
::-webkit-scrollbar-thumb {
  background: rgba(252, 252, 252, 0.411); 
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #b30000; 
}
</style>
