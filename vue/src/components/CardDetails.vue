<template>
  <div class="details-page">
    <div class="details-container">
      <div class="details-main">
        <router-link
          id="back"
          class="sub-title-font"
          v-bind:to="{
            name: 'landmarks',
            params: { query: this.$store.state.locationQuery },
          }"
          >BACK</router-link
        >
        <div class="header-section">
          <div class="main-header-section">
            <h1 class="landmark-header main-title-font">
              {{ rawLandmark.name }}
            </h1>
            <div class="addLandmark-container">
              <form
                class="addToAdv sub-title-font"
                v-on:submit.prevent="adding"
              >
                <select name="trips" class="select-adv" v-model="trip">
                  <option>Select Adventure</option>
                  <option
                    v-for="trip in this.$store.state.trips"
                    v-bind:key="trip.id"
                    v-bind:value="trip"
                  >
                    {{ trip.name }}
                  </option>
                </select>
                <input type="submit" v-on:click="togglePopup()" />
              </form>
            </div>
          </div>
          <div class="submain-header-section">
            <p class="landmark-subheader sub-title-font">
              In {{ rawLandmark.address.city }},
              {{ rawLandmark.address.country }}
            </p>
            <div class="count sub-title-font">
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
              v-bind:src="image"
              alt="picture of location"
            />
          </div>
          <aside>
            <h3 class="main-title-font">Details</h3>
            <p class="aside-p sub-title-font">
              <span class="aside-span">Address</span>
              {{ rawLandmark.address.house_number }}
              {{ rawLandmark.address.road }} {{ rawLandmark.address.city }}
              {{ rawLandmark.address.postcode }}
            </p>
            <p class="aside-p sub-title-font">
              <span class="aside-span">Website</span>
              <a
                :href="rawLandmark.link"
                target="_blank"
                class="details-link"
                >{{
                  rawLandmark.url ? rawLandmark.url : "No Website link found"
                }}</a
              >
            </p>
            <br />
            <hr />
            <p class="details-description sub-title-font">
              {{ rawLandmark.wikipedia_extracts.text }}
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
import openMapTripService from "../services/OpenMapTripService.js";
import TripsService from "../services/TripsService.js";

export default {
  name: "card-details",
  data() {
    return {
      count: Math.floor(Math.random() * 100),
      buttonTrigger: false,
      rawLandmark: {},
      image: "",
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
    openMapTripService
      .getPlaceDetails(this.id)
      .then((response) => {
        console.log(response.data);
        if (response.status === 200) {
          console.log(response.data);
          this.rawLandmark = response.data;

          this.image = this.rawLandmark.preview.source;
          this.landmark.name = `${this.rawLandmark.name}`;
          this.landmark.description = `${this.rawLandmark.wikipedia_extracts.text}`;
          this.landmark.category = `${this.rawLandmark.kinds}`;
          this.landmark.latitude = `${this.rawLandmark.point.lat}`;
          this.landmark.longitude = `${this.rawLandmark.point.lon}`;
          this.landmark.address = `${this.rawLandmark.address.house_number} ${this.rawLandmark.address.road}, ${this.rawLandmark.address.city}, ${this.rawLandmark.address.postcode}`;
          this.landmark.link = `${this.rawLandmark.link}`;
          this.landmark.photo = `${this.image}`;
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

<style>
.details-page {
  background-color: rgb(255, 255, 255);
  color: black;
  padding: 0;
  height: 160vh;
}
.details-container {
  margin: 1rem auto;
  padding: 10px;
}
.details-main {
  width: 78%;
  margin: 1rem auto;
  height: 90%;
}

#back {
  color: black;
  text-decoration: none;
  font-size: 22px;
  font-weight: bold;
}

.header-section {
  margin: 25px 0;
  display: flex;
  flex-direction: column;
  position: relative;
  width: 100%;
  height: 6.5rem;
  justify-content: center;
}

/*          HEADER SECTION          */

/*      main header section */

.main-header-section{
  position: absolute;
  height: 100%;
  width: 100%;
  display: flex;
  justify-content: space-between;
}

/* add to adventure */

.addLandmark-container {
  position:absolute;
  bottom:0;
  right: 0;
}

.addToAdv {
  width: 25rem;
  height: 2.4rem;
  color: black;
  display: flex;
  justify-content: space-between;
  align-items: center;
}
.select-adv{
  width: 14rem;
}
.addToAdv > input {
  height: 2rem;
  width: 7rem;
  border-radius: 20px;
  background-color: black;
  color: white;
  border:none;
}
.addToAdv > input:hover {
  cursor: pointer;
  background-color: #59e3a8;
  color: black;
  transition: 300ms;
}

/*        SUBMAIN SECTION */
.submain-header-section{
  position: absolute;
  bottom: 0;
  background-color: white;
  width: 63%;
  display: flex;
  justify-content: space-between;
}

/* BUTTON UP AND DOWN */


.count {
  display: flex;
  user-select: none;
  align-items: center;
}
.count p,
.material-symbols-outlined {
  font-size: 1.3rem;
}
.thumbs_up {
  margin-left: 0.5rem;
  margin-right: 0.3rem;
}
.thumbs_up:hover {
  color: green;
  cursor: pointer;
}
.thumbs_down:hover {
  color: red;
  cursor: pointer;
}

.header-section h1,
.header-section p {
  margin: 5px 0;
  padding: 0;
}
.right-side {
  padding-right: 2rem;
  grid-area: "info";
}
.landmark-header {
  font-size: 48px;
  font-weight: 500;
}

.landmark-subheader {
  font-style: italic;
}
.info-section {
  height: auto;
  display: grid;
  grid-template-columns: 2fr 1fr;
  grid-template-areas: "info" "aside";
}
#details-img {
  border-radius: 0px;
  width: 100%;
}

.details-description {
  font-size: 20px;
  margin: 50px auto;
  padding-top: 20px;
}

aside {
  grid-area: "aside";
  margin-right: 2rem;
  width: 30rem;
}
aside h3 {
  margin: 1rem 0;
  font-size: 1.8rem;
  font-weight: 400;
}
.aside-p {
  margin: 0.5rem 0;
  font-size: 1rem;
  width: 24rem;
  overflow: hidden;
  display: flex;
}
.aside-span {
  color: rgb(80, 80, 80);
  margin-right: 1rem;
}

.details-link {
  color: blue;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 20rem;
}
</style>
