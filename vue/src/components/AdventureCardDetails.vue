<template>
  <div class="tripCard-details-page">
      <h1>This is the trip card details</h1>
      <h1>somethign</h1>
      <ul>
      <li
        v-for="landmark in this.trips"
        v-bind:key="landmark.xid"
      >
        <landmark-card
          class="landmark-card"
          v-bind:landmark="landmark"
        ></landmark-card>
      </li>
    </ul>
  </div>
</template>

<script>
import tripsService from "@/services/TripsService.js"
import LandmarkCard from "@/components/LandmarkCard.vue";

export default {
    name:"adventure-card-details",
  components: { LandmarkCard },
    data(){
        return{
            trips: {}
        }
    },
    props: ["id"],
    created(){
        tripsService.getTripById(this.id).then((res) => {
            console.log("this is the page")
            if(res.status == 200){
                this.trips = res.data
                console.log(this.trips);
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
.tripCard-details-page{
    height: 100%;
    width: 50%;
    background-color: blue;
}

</style>