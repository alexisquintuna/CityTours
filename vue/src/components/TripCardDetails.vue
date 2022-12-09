<template>
  <div>
      <h1>This is the trip card details</h1>
  </div>
</template>

<script>
import TripsService from "@/services/TripsService.js"
export default {
    name:"trip-details",
    data(){
        return{
            trip: {}
        }
    },
    props: ["id"],
    created(){
        TripsService
        .getTripById(this.id)
        .then((res) => {
            if(res.status == 200){
                console.log(res.data);
                this.trip = res.data
            }
        })
        .catch((err) => {
            if(err.response.status == 404){
                this.$router.push({name: "NotFound"})
            }
        })
    }
}
</script>

<style>

</style>