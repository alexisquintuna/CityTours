<template>
  <div class="adventure-page">
    <div class="adventure-container">
      <h1>Need to add list</h1>
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
  height: 220vh;
  background-color: rgba(250, 235, 215, 0.993);
  display: flex;
  justify-content: center;
  align-items: center;
}
.adv-list {
  position: relative;
}
.adventure-container {
    background-color: forestgreen;
    height: 100%;
    position: relative;
    top: 10rem;
}
.adventure-container > h1 {
  color: white;
  font-size: 98px;
}
</style>
