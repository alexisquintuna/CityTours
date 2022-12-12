<template>
  <div>
    <card-details v-bind:id="landmarkId" />
  </div>
</template>

<script>
import CardDetails from "@/components/CardDetails.vue";
export default {
  name: "landmark-details",
  components: { CardDetails },
  data() {
    return { landmarkId: 0 };
  },
  created() {
    this.landmarkId = this.$route.params.id;
  },
};
</script>
<style></style>
