<template>
  <div class="details-page">
    <div class="details-container">
      <div class="details-main">
        <router-link
          id="back"
          v-bind:to="{
            name: 'home',
          }"
          >BACK</router-link
        >
        <div class="header-section">
          <div class="main-header-section">
            <h1 class="landmark-header main-title-font">{{ landmark.name }}</h1>
            <div class="addLandmark-container">
              <form class="addToAdv" v-on:submit.prevent="adding">
                <label for="trips">Choose Adventure:</label>
                <select name="trips" class="select-adv" v-model="trip">
                  <option
                    v-for="trip in this.$store.state.trips"
                    v-bind:key="trip.id"
                    v-bind:value="trip"
                  >
                    {{ trip.name }}
                  </option>
                </select>
                <input type="submit" value="Add" v-on:click="togglePopup()" />
              </form>
            </div>
          </div>
          <div class="submain-header-section">
            <p class="landmark-subheader sub-title-font">
              In {{ landmark.address }}
            </p>
            <div class="count">
              <p>{{ this.count }}</p>
              <span
                class="material-symbols-outlined thumbs_up"
                v-on:click="countUp()"
                >thumb_up</span
              >
              <span
                class="material-symbols-outlined thumbs_down"
                v-on:click="countDown()"
                >thumb_down</span
              >
            </div>
          </div>
        </div>
        <section class="info-section">
          <div class="right-side">
            <img
              id="details-img"
              v-bind:src="landmark.photo"
              alt="picture of location"
            />
          </div>
          <aside>
            <h3 class="main-title-font">Details</h3>
            <p class="aside-p sub-title-font">
              <span class="aside-span">Address</span>
              {{ landmark.address }}
            </p>
            <p class="aside-p sub-title-font">
              <span class="aside-span">Website</span>
              <a :href="landmark.link" target="_blank" class="details-link">{{
                landmark.link ? landmark.link : "No Website link found"
              }}</a>
            </p>
            <br />
            <hr />
            <p class="details-description sub-title-font">
              {{ landmark.description }}
            </p>
          </aside>
        </section>
      </div>
    </div>
    <div class="popup-adv" v-show="buttonTrigger">
      <div class="popup-inner-adv">
        <h1>Adventure added to {{ trip.name }}</h1>
        <div class="adv-btn-container">
          <button class="popup-Btn delete" v-on:click="togglePopup()">
            Okay
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import landmarkService from "../services/LandmarkService.js";
import TripsService from "../services/TripsService.js";

export default {
  name: "suggested-card-details",
  data() {
    return {
      count: Math.floor(Math.random() * 100),
      buttonTrigger: false,
      image: "",
      /* suggestedLandmark: {}, */
      landmark: {
        name: "",
        description: "",
        category: "",
        latitude: "",
        longitude: "",
        address: "",
        link: "",
        photo: "",
      },
      trip: {
        id: "",
        name: "",
      },
    };
  },
  props: ["id"],
  methods: {
    countUp() {
      this.count++;
    },
    countDown() {
      this.count--;
    },
    adding() {
      TripsService.addLandmarkToTrip(this.trip.id, this.landmark)
        .then((res) => {
          if (res.status == 200) {
            console.log(res.status);
          }
        })
        .catch((err) => {
          if (err.response.status == 400) {
            console.log(err.response.status);
          }
        });
    },
    togglePopup() {
      this.buttonTrigger = !this.buttonTrigger;
    },
  },
  created() {
    landmarkService
      .getLandmarkById(this.id)
      .then((response) => {
        console.log(response.data);
        if (response.status === 200) {
          console.log(response.data);
          this.landmark = response.data;

          /* this.image = this.rawLandmark.preview.source;
          this.landmark.name = `${this.rawLandmark.name}`;
          this.landmark.description = `${this.rawLandmark.wikipedia_extracts.text}`;
          this.landmark.category = `${this.rawLandmark.kinds}`;
          this.landmark.latitude = `${this.rawLandmark.point.lat}`;
          this.landmark.longitude = `${this.rawLandmark.point.lon}`;
          this.landmark.address = `${this.rawLandmark.address.house_number} ${this.rawLandmark.address.road}, ${this.rawLandmark.address.city}, ${this.rawLandmark.address.postcode}`;
          this.landmark.link = `${this.rawLandmark.link}`;
          this.landmark.photo = `${this.image}`; */
        }
      })
      .catch((error) => {
        if (error.response.status == 404) {
          this.$router.push({ name: "NotFound" });
        }
      });
  },
};
</script>

<style></style>
