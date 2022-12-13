<template>
  <div>
    <suggested-card-details v-bind:id="landmarkId" />
  </div>
</template>
 
<script>
import SuggestedCardDetails from "@/components/SuggestedCardDetails.vue";
export default {
  name: "landmark-details",
  components: { SuggestedCardDetails },
  data() {
    return { landmarkId: 0 };
  },
  created() {
    this.landmarkId = this.$route.params.id;
    console.log("reaching card-details from home page")
    console.log(this.landmarkId)
  },
};
</script>
<style></style>
