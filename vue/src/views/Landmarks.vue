<template>
  <div class="landmark-page">
    <div class="landmark-container">
      <landmark-list></landmark-list>
      <landmark-map></landmark-map>
    </div>
    <div class="landmark-suggestion">
        <h1>Admins Suggestions</h1>
      <suggestion-list></suggestion-list>
    </div>
  </div>
</template>

<script>
import LandmarkList from "@/components/LandmarkList.vue";
import LandmarkMap from "@/components/LandmarkMap.vue";
import SuggestionList from "@/components/LandmarkSuggestions.vue";

export default {
  name: "landmarks",
  components: { LandmarkList, LandmarkMap, SuggestionList },
};
</script>

<style>
.landmark-page {
  display: flex;
  justify-content: center;
  flex-direction: column;
  height: 100rem;
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

.landmark-suggestion {
  position: relative;
  top: 3rem;
  border-radius: 20px;
  margin: 0px auto;
  height: 24rem;
  width: 75%;
  background-color: #f5f5f5;
}

.landmark-suggestion > h1 {
    font-size: 2.5rem;
    display: inline-block;
    margin: 1rem 1rem 0rem 2.7rem;
}
</style>
