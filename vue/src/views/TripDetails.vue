<template>
  <div>
      <trip-card-details v-bind:id="tripId" />
  </div>
</template>

<script>
import TripCardDetails from "@/components/TripCardDetails"
export default {
components:TripCardDetails,
data(){
    return{
        tripId:0
    }
},
created(){
    this.tripId = this.$route.params.id
}
        }
</script>

<style>

</style>