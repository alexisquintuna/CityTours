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
        <form class="addingTrip-form" action="">
          <h1>Add a new trip to the list!</h1>
          <input class="trip-name-input" type="text" placeholder="Name of trip" />
          <div class="buttons-div">
            <button class="popup-close close-btn" v-on:click.prevent="TogglePopup()">
              Cancel
            </button>
            <button class="popup-close add-btn" v-on:click.prevent="TogglePopup()">
              Add Trip
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import AdventureList from "@/components/AdventureList.vue";
export default {
  data() {
    return {
      buttonTrigger: false,
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

.addingTrip-form{
  position: relative;
  display: flex;
  flex-direction: column;
  align-items: center;
  text-align: center;
  justify-content: center;
}

.addingTrip-form> h1,
.addingTrip-form> input,
.addingTrip-form> .buttons-div{
  margin: 1.8rem;
}
.addingTrip-form> h1{
  font-size: 2rem;
}
.trip-name-input{
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
  /* position: absolute;
  bottom: 1rem; */
  align-items: center;
  justify-content: space-around;
  width: 100%;
}

.close-btn{
  color:black;
  background-color: white;
}
.close-btn:hover{
  color: white;
  background-color: black;
}

.addingTrip-form {
  height: 100%;
  width: 100%;
  border-radius: 20px;;
}
.adding-new-trip {
  background-color: aquamarine;
  height: 100vh;
  width: 100%;
  display: hidden;
}
.adventure-page {
  display: flex;
  flex-direction: column;
  justify-content: center;
  height: auto;
}
.adv-list {
  position: relative;
  height: 100%;
  margin-top: 1rem;
}
.adventure-container {
  background-color: rgb(255, 255, 255);
  border-radius: 20px;
  position: relative;
  height: 100%;
  margin-top: 7rem;
  display: flex;
  flex-direction: column;
  align-items: center;
}
.newTrip-border-btn {
  height: 3rem;
  width: 90rem;
  display: flex;
  align-items: center;
  justify-content: center;
  border-radius: 20px;
  margin: 2rem 0;
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
</style>
