<template>
<div class="">

  <div class="adventure-list">
      <div class="adv-list-container">
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>
      <adventure-card class="adv-card" ></adventure-card>

      </div>
  </div>
</div>
</template>

<script>
import AdventureCard from './AdventureCard.vue'
export default {
    name:"adventure-list",
  components: { AdventureCard },

}
</script>

<style>
.adventure-list{
    background-color: aqua;
    width: 100rem;
}

.adv-list-container{
    display: flex;
    justify-content: flex-start;
    width: 25% 25% 25% 25%;
    flex-wrap: wrap;
}
.adv-card{
    margin: 1rem;
}

</style>