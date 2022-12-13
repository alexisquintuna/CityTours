<template>
  <div class="details-page">
    <div class="details-container">
      <div class="details-main">
        <router-link
          id="back"
          v-bind:to="{
            name: 'home'
          }"
          >BACK</router-link
        >
        <div class="header-section">
          <h1 class="landmark-header">{{ suggestedLandmark.name }}</h1>
          <p class="landmark-subheader">
            In {{ suggestedLandmark.address }}
          </p>
          <div class="addLandmark-container">
            <form class="addToAdv" v-on:submit.prevent="adding">
              <label for="trips">Add To An Adventure:</label>
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
        <section class="info-section">
          <div class="right-side">
            <img
              id="details-img"
              v-bind:src="suggestedLandmark.photo"
              alt="picture of location"
            />
            <p class="details-description">
              {{ suggestedLandmark.description }}
            </p>
          </div>
          <aside>
            <h3>Details</h3>
            <p class="aside-p">
              <span class="aside-span">Address</span>
              {{ suggestedLandmark.address }}
            </p>
            <p class="aside-p">
              <span class="aside-span">Website</span>
              <a
                :href="rawLandmark.link"
                target="_blank"
                class="details-link"
                >{{
                  suggestedLandmark.link ? suggestedLandmark.link : "No Website link found"
                }}</a
              >
            </p>
            <br />
            <hr />
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
      buttonTrigger: false,
      rawLandmark: {},
      image: "",
      suggestedLandmark: {},
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
    togglePopup(){
      this.buttonTrigger = !this.buttonTrigger
    }
  },
  created() {
    landmarkService
      .getLandmarkById(this.id)
      .then((response) => {
        console.log(response.data);
        if (response.status === 200) {
          console.log(response.data);
          this.suggestedLandmark = response.data;

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
  height: 220vh;
}
.details-container {
  margin: 1rem auto;
  padding: 10px;
  height: 100%;
}
.details-main {
  width: 78%;
  margin: 1rem auto;
  height: 90%;
}
.popup-inner-adv > h1{
  text-align: center;
}
#back {
  color: black;
  text-decoration: none;
  font-size: 20px;
  font-weight: bold;
}

.header-section {
  margin: 25px 0;
  display: flex;
  flex-direction: column;
  position: relative;
  width: 100%;
  justify-content: center;
}
.addLandmark-container {
  /* z-index: 99; */
  /* position: fixed;
  top: 0;
  right:0;
  left:0;
  bottom: 0; */
  position: absolute;
  right: 0;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
.addToAdv {
  height: 7rem;
  width: 33rem;
  color: black;
  display: flex;
  justify-content: space-around;
  align-items: center;
}
.addToAdv > label {
  font-size: 1.3rem;
  font-weight: 600;
  display: inline;
}

.addToAdv > input {
  height: 2rem;
  width: 7rem;
  border-radius: 20px;
  background-color: black;
  color: white;
}
.addToAdv > input:hover {
  cursor: pointer;
  background-color: #59e3a8;
  color: black;
  transition: 300ms;
}
.landmark-headerBtn {
  border: 1px solid black;
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
}

.landmark-subheader {
  font-style: italic;
}
.info-section {
  height: auto;
  display: grid;
  grid-template-columns: 3fr 1fr;
  grid-template-areas: "info" "aside";
}

#details-img {
  border-radius: 0px;
  width: 60rem;
  height: 75%;
}
.details-description {
  font-size: 24px;
  width: 75%;
  margin: 50px auto;
  padding-top: 20px;
}
aside {
  grid-area: "aside";
  margin-right: 2rem;
}
aside h3 {
  margin: 1rem 0;
  font-size: 1.8rem;
}
.aside-p {
  margin: 0.5rem 0;
  font-size: 1rem;
  width: 20rem;
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
