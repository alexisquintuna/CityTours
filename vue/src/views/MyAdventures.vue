<template>
  <div class="adventure-page">
    <div class="adventure-container">
      <div class="newTrip-border-btn">
        <button class="new-trip-btn sub-title-font" v-on:click="TogglePopup()">
          + Add New Trip
        </button>
      </div>
        <adventure-list class="adv-list" :key="this.$store.state.forceRefresh"></adventure-list>
    </div>
    <div class="popup" v-if="buttonTrigger">
      <div class="popup-inner">
        <form
          class="addingTrip-form sub-title-font"
          action=""
          v-on:submit.prevent="addingTrip"
        >
          <h1>Add a new trip to the list!</h1>
          <input
            class="trip-name-input sub-title-font"
            type="text"
            placeholder="Trip Name"
            v-model="trip.name"
          />
          <input
            class="trip-name-input sub-title-font"
            type="text"
            placeholder="Cover Photo URL"
            v-model="trip.pic"
          />
          <div class="buttons-div">
            <button
              class="popup-close close-btn sub-title-font"
              v-on:click.prevent="TogglePopup()"
            >
              Cancel
            </button>
            <button class="popup-close add-btn sub-title-font" type="submit">Add Trip</button>
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
        pic: '',
      },
      hasAdventures: false
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
            this.$store.commit("SET_TRIPS", response.data);
            this.$store.state.forceRefresh++;
            this.trip.name='';
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
  width: 40%;
  height: 70%;
  font-size: 1.3rem;
}
.buttons-div {
  height: 15%;
  width: 78%;
  display: flex;
  align-items: center;
  justify-content: space-around;
}

.close-btn {
  color: black;
  background-color: white;
  border: 1px solid black;
}
.close-btn:hover {
  color: white;
  background-color: black;
}
.add-btn{
  background-color: #59E3A8;
  color: white;
}
.add-btn:hover{
  color: var(--lime-green);
  background-color: white;
  border: 1px solid var(--lime-green);
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
  height: auto;
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
  background-color: black;
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
  background-color: var(--lime-green);
  color: black;
}

.adv-list{
  width: 85%; 
}
</style>
