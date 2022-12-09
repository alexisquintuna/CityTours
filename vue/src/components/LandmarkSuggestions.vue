<template>
  <div class="suggestion-list">
      <ul>
      <li
      class="suggestion-li"
        v-for="landmark in this.$store.state.landmarks"
        v-bind:key="landmark.id"
      >
        <suggestion-card
          class="landmark-card"
          v-bind:landmark="landmark"
        ></suggestion-card>
      </li>
    </ul>
  </div>
</template>

<script>
import SuggestionCard from "@/components/SuggestionCard.vue"
import landmarkService from "../services/LandmarkService.js";

export default {
  name: "suggestion-list",
  components: { SuggestionCard },
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
.suggestion-list {
  width: 95%;
  height: 77%;
  background-color: rgb(255, 255, 255);
  margin: 1rem auto 0;
  overflow: auto;
  border-radius: 20px;
  padding: 10px 20px;
  position: relative;
}
.suggestion-list  > ul {
    display: flex;
    height: 100%;
    width: auto;
    display: flex;
    align-items: center;
}
.suggestion-list  > ul > li {
    width: 22%;
    height: 100%;
    margin-right: 2rem;
}
</style>