<template>
  <div class="adventure-page">
    <div class="adventure-container">
      <div class="newTrip-border-btn">
        <button class="new-trip-btn" v-on:click="TogglePopup()">
          + Add New Trip
        </button>
      </div>
        <adventure-list class="adv-list"></adventure-list>
    </div>
    <div class="popup" v-if="buttonTrigger">
      <div class="popup-inner">
        <form
          class="addingTrip-form"
          action=""
          v-on:submit.prevent="addingTrip"
        >
          <h1>Add a new trip to the list!</h1>
          <input
            class="trip-name-input"
            type="text"
            placeholder="Name of trip"
            v-model="trip.name"
          />
          <div class="buttons-div">
            <button
              class="popup-close close-btn"
              v-on:click.prevent="TogglePopup()"
            >
              Cancel
            </button>
            <button class="popup-close add-btn" type="submit">Add Trip</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import AdventureList from "@/components/AdventureList.vue";
import TripsService from "../services/TripsService";
export default {
  data() {
    return {
      buttonTrigger: false,
      trip: {
        name: "",
      },
    };
  },
  name: "my-adventures",
  components: { AdventureList },
  methods: {
    TogglePopup() {
      console.log("getting clicked");
      console.log(this.buttonTrigger);
      this.buttonTrigger = !this.buttonTrigger;
    },
    addingTrip() {
      TripsService.createTrip(this.trip)
        .then((response) => {
          if (response.status === 200) {
            this.TogglePopup();
            location.reload();
          }
        })
        .catch((error) => {
          if (error.response.status == 400) {
            this.$router.push({ name: "NotFound" });
          }
        });
    },
  },
};
</script>

<style>
.popup {
  position: fixed;
  right: 0;
  left: 0;
  top: 0;
  bottom: 0;
  z-index: 99;
  background-color: rgba(0, 0, 0, 0.2);

  display: flex;
  align-items: center;
  justify-content: center;
}

.popup-inner {
  background: #fff;
  padding: 2rem;
  height: 50%;
  width: 25%;
  border-radius: 20px;
}

.addingTrip-form {
  position: relative;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  justify-content: center;
}

.addingTrip-form > h1,
.addingTrip-form > input,
.addingTrip-form > .buttons-div {
  margin: 1.8rem;
}
.addingTrip-form > h1 {
  font-size: 2rem;
}
.trip-name-input {
  height: 2rem;
  border-bottom: 3px solid black;
  width: 75%;
}
.popup-close {
  width: 35%;
  height: 55%;
  font-size: 1.3rem;
}
.buttons-div {
  height: 15%;
  display: flex;
  align-items: center;
  justify-content: space-around;
  width: 100%;
}

.close-btn {
  color: black;
  background-color: white;
}
.close-btn:hover {
  color: white;
  background-color: black;
}

.addingTrip-form {
  height: 100%;
  width: 100%;
  border-radius: 20px;
}

.adventure-page {
  display: flex;
  flex-direction: column;
  justify-content: center;
  height: auto;
}

.adventure-container {
  background-color: rgb(255, 255, 255);
  position: relative;
  height: 100%;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 3rem 0 10rem;
}
.newTrip-border-btn {
  height: 3rem;
  width: 90rem;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 20px;
  margin: 1rem;
}
.new-trip-btn {
  background-color: #6baa75;
  color: white;
  text-decoration: none;
  height: 3rem;
  width: 15rem;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 1.5rem;
  border-radius: 20px;
}

.new-trip-btn:hover {
  background-color: black;
  color: white;
}

.adv-list{
  width: 85%; 
}
</style>
