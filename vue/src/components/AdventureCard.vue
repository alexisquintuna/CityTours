<template>
  <div class="adventure-card">
    <div class="delete-btn-container">
      <button class="delete-btn" v-on:click.prevent="deleteTrip(trip.id)">
        x
      </button>
    </div>
    <div class="adventure-link-card">
    <img class="adv-card-img" v-bind:src="trip.pic" alt="">
      <router-link
        class="adv-bg"
        v-bind:trip="trip"
        v-bind:to="{ name: 'adventure-details', params: { id: trip.id } }"
      >
        <div class="router-card">
          <h1 class="sub-title-font">{{ trip.name }}</h1>
        </div>
      </router-link>
    </div>
    <div class="popup-adv sub-title-font" v-if="buttonTrigger">
      <div class="popup-inner-adv">
        <h1>Are you sure you want to delete this card?</h1>
        <div class="adv-btn-container">
          <button class="popup-Btn cancel" v-on:click="togglePopup()">Cancel</button>
          <button class="popup-Btn delete add-btn" v-on:click="toggleDelete()">Confirm</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TripsService from "../services/TripsService";
export default {
  data() {
    return {
      buttonTrigger: false,
      confirmDelete: false,
      tripId: 0,
    }; 
  },
  name: "adventure-card",
  props: ["trip"],
  methods: {
    deleteTrip(id) {
      this.buttonTrigger = !this.buttonTrigger;
      this.tripId = id;
    },
    togglePopup() {
      this.buttonTrigger = !this.buttonTrigger;
    },
    toggleDelete() {
      this.confirmDelete = !this.confirmDelete;
      if (this.confirmDelete) {
        TripsService.deleteTrip(this.tripId)
          .then((response) => {
            if (response.status === 200) {
              this.$store.commit("SET_TRIPS", response.data);
              this.$store.state.forceRefresh++;
            }
          })
          .catch((error) => {
            if (error.response.status == 400) {
              this.$router.push({ name: "NotFound" });
            }
          });
      }
    },
  },
};
</script>

<style>
.adventure-card {
  color: white;
  position: relative;
  height: 30rem;
  width: 22%;
  border-radius: 20px;
  overflow: hidden;
}

.adv-card-img{
  display: block;
  position: relative;
  width: 100%;
  height: 29rem;
}

.adventure-link-card {
  height: 100%;
  background-image: linear-gradient(
    to bottom,
    rgba(247, 247, 247, 0) 65%,
    rgb(0, 0, 0)
  );
  border-radius: 20px;
  display: inline-block;
}

/* .adventure-card:hover{
  background-size: 400px;
  transition-duration: 9000ms;
} */
.adventure-link-card:hover,
.adventure-link-card:hover .adv-bg{
 background-image: linear-gradient(
    to bottom,
    rgba(247, 247, 247, 0) 25%,
    rgb(0, 0, 0)
  );
  color: white;
  transition-duration: 400ms;
}

.adv-bg {
  height: 100%;
  width: 100%;
  color: #59e3a8;
  background-color: antiquewhite;
}
.router-card {
  height: 85%;
  width: 100%;
  position: absolute;
  bottom: 0;
  background-image: linear-gradient(
    to bottom,
    rgba(247, 247, 247, 0) 25%,
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

.router-card > h1 {
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
  z-index: 1;
}

.delete-btn {
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.288);
  color: rgb(253, 253, 253);
}
.delete-btn:hover{
  color: white;
  background-color: black;
}

.popup-adv {
  color: black;
  position: fixed;
  left: 0;
  right: 0;
  top: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.2);
  z-index: 99;

  display: flex;
  align-items: center;
  justify-content: center;
}

.popup-inner-adv {
  background: white;
  height: 25%;
  width: 30%;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
}
.popup-inner-adv > h1{
  font-size: 1.5rem;
  font-weight: 600;
}
.popup-Btn{
  width: 10rem;
  height: 3rem;
  font-size: 1.3rem;
}
.adv-btn-container {
  display: flex;
  align-items: center;
  width: 65%;
  height: 25%;
  margin-top: 2rem;
}
.delete{
  background-color: #59E3A8;
  color: white;
}
.delete:hover{
  color: white;
  background-color: black;
  border: 1px solid black;
}
</style>
