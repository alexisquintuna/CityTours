<template>
  <div class="suggestion-list">
      <ul>
      <li
      class="suggestion-li"
        v-for="landmark in this.$store.state.hotspots"
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
    getAllHotspots() {
      landmarkService
        .getHotspots()
        .then((response) => {
          console.log(response.data)
          if (response.status === 200) {
            this.$store.commit("SET_HOTSPOTS", response.data);
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
    this.getAllHotspots();
  },
};
</script>

<style>
.suggestion-list {
  width: 95%;
  background-color: rgb(255, 255, 255);
  margin: 1rem auto 0;
  border-radius: 10px;
  padding: 10px 20px;
}
.suggestion-list  > ul {
    display: flex;
    /*grid-column: ;flex-wrap: nowrap;
    overflow-x: scroll;
    overflow-y: hidden;
    white-space: nowrap;
    background-color: aquamarine; */
    width: 100%;
    height: 100%;
    margin: 4px, 4px;
        padding: 4px;
        /* background-color: #08c708; */
        overflow-x: auto;
        overflow-y: hidden;
        white-space: nowrap;
}
.suggestion-li{
    height: 90%;
    width: 25%;
}
</style>