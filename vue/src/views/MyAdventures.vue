<template>
  <div class="adventure-page">
    <div class="adventure-container">
      <div class="newTrip-border-btn">
        <router-link class="new-trip-btn" v-bind:to="{ name: '' }">
          + Add New Trip</router-link
        >
      </div>
      <adventure-list class="adv-list"></adventure-list>
    </div>
  </div>
</template>

<script>
import AdventureList from "@/components/AdventureList.vue";
export default {
  name: "my-adventures",
  components: { AdventureList },
};
</script>

<style>
.adventure-page {
  display: flex;
  justify-content: center;
  height: auto;
}
.adv-list {
  position: relative;
  height: 100%;
  margin-top: 1rem;
}
.adventure-container {
  background-color: rgb(255, 255, 255);
  border-radius: 20px;
  position: relative;
  height: 100%;
  margin-top: 7rem;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.newTrip-border-btn {
  height: 3rem;
  width: 10rem;
  background-color: #6baa75;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 20px;
  margin: 2rem 0;
}
.new-trip-btn {
  color: white;
  text-decoration: none;
}
</style>
