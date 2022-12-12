<template>
  <div class="adventure-card">
<router-link class="adventure-link-card" v-bind:to="{name: 'adventure-details', params: {id: trip.id}}">
    <div class="adv-bg">
      <div class="delete-btn-container">
        <button class="delete-btn" v-on:click="deleteTrip(trip.id)">x</button>
      </div>
      <h1>{{ trip.name }}</h1>
    </div>
    <div class="popup-adv" v-if="buttonTrigger">
      <div class="popup-inner-adv" >
        <h1>Are you sure you want to delete this card?</h1>
        <div class="adv-btn-container">
          <button v-on:click="togglePopup()" >Cancel</button>
          <button v-on:click="toggleDelete()" >Confirm</button>
        </div>
      </div>
    </div>
  </router-link>
  </div>
</template>

<script>
import TripsService from "../services/TripsService";
export default {
  data(){
    return{
      buttonTrigger: false,
      confirmDelete: false,
      tripId: 0,
    }
  },
  name: "adventure-card",
  props: ["trip"],
  methods: {
    deleteTrip(id) {
      this.buttonTrigger = !this.buttonTrigger
      this.tripId = id
    },
    togglePopup(){
      this.buttonTrigger = !this.buttonTrigger
    },
    toggleDelete(){
      this.confirmDelete = !this.confirmDelete
      if(this.confirmDelete){
              TripsService.deleteTrip(this.tripId)
        .then(
           location.reload()
        )
        .catch((error) => {
          if (error.response.status == 400) {
            this.$router.push({ name: "NotFound" });
          }
        });
      }
    }
  },
};
</script>

<style>
.adventure-card {
  color: white;
  position: relative;
  height: 30rem;
  width: 22%;
  background-image: url("https://globalgrasshopper.com/wp-content/uploads/2020/09/The-best-places-to-vist-in-Ecuador.jpg");
}
.adventure-link-card{
  color: #59E3A8;
}
.adv-bg {
  height: 100%;
  width: 100%;
  background-image: linear-gradient(
    to bottom,
    rgba(247, 247, 247, 0),
    rgb(0, 0, 0)
  );
}

.adv-bg:hover {
  background-image: linear-gradient(
    to bottom,
    rgba(0, 0, 0, 0),
    rgba(0, 0, 0, 0)
  );
  transition: 300ms;
  cursor: pointer;
}

.adv-card-img {
  height: 100%;
  width: 100%;
  background-size: cover;
  background-position: 50% 10%;
}

.adv-bg > h1 {
  font-size: 38px;
  position: absolute;
  bottom: 2rem;
  left: 1rem;
}

.delete-btn-container {
  position: absolute;
  right: 1rem;
  top: 1rem;
  width: 2rem;
  height: 2rem;
}

.delete-btn {
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.288);
  color: rgb(253, 253, 253);
}

.popup-adv{
  color: black;
  position: fixed;
  left:0;
  right: 0;
  top:0;
  bottom:0;
  background: rgba(0,0,0,0.2);
  z-index: 99;

  display: flex;
  align-items: center;
  justify-content: center;
}

.popup-inner-adv{
  background: white;
  height: 25%;
  width: 30%;
  display: flex;
  align-items: center;
  justify-content: center;
flex-direction: column;
}

.adv-btn-container{
  display: flex;
}
</style>
