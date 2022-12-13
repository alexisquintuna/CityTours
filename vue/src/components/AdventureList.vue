<template>
  <div class="">
    <div class="adventure-list">
      <div v-if="hasAdventures" class="adv-list-container">
        <adventure-card
          class="adv-card"
          v-for="trip in this.$store.state.trips"
          v-bind:key="trip.id" v-bind:trip="trip"
        />
      </div>
      <div v-show="!hasAdventures" class="no-adventures-container">
          <img class="no-adventures-img" src="https://img.freepik.com/free-vector/journey-concept-illustration_114360-3445.jpg?w=826&t=st=1670683792~exp=1670684392~hmac=6720338be7b3899a378ae2021b7dc6bb73234d9dd9c645b044643eed118f9462" alt="">
          <h2>You have no adventures lets start planning one!</h2>
      </div>
    </div>
  </div>
  <!-- fix icons too -->
</template>

<script>
import AdventureCard from "./AdventureCard.vue";
import TripsService from "../services/TripsService.js";
export default {
  name: "adventure-list",
  components: { AdventureCard },
  data(){
    return{
      hasAdventures: false,
    }
  },
  methods: {
    getTripsByUser() {
      TripsService.getTrips()
        .then((response) => {
          console.log(response.data.length)
          if (response.status === 200) {
            if(response.data.length !=0){
              this.hasAdventures = true;
            }
            this.$store.commit("SET_TRIPS", response.data);
          }
        })
        .catch((error) => {
          if (error.response.status == 400) {
            this.$router.push({ name: "NotFound" });
          }
        });
    },
  },
  created() {
    console.log("reaching created");
    this.getTripsByUser();
  },
};
</script>

<style>
.adventure-list {
  width: 100%;
  animation: 1s ease-out 0s 1 easeIn;

}

.adv-list-container {
  display: flex;
  justify-content: flex-start;
  width: 25% 25% 25% 25%;
  flex-wrap: wrap;
}
.adv-card {
  margin: 1rem;
}
.no-adventures-container{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.no-adventures-img{
  height: 40%;
  width: 40%;
}
.no-adventures-container > h2{
  font-size: 2rem;
}
</style>