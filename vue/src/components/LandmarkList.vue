<template>
  <div class="list">
    <ul>
      <li
        v-for="landmark in this.$store.state.landmarks"
        v-bind:key="landmark.xid"
      >
        <landmark-card
          class="landmark-card"
          v-bind:landmark="landmark"
        ></landmark-card>
      </li>
    </ul>
    <div class="overlay-list"></div>
  </div>
</template>

<script>
import LandmarkCard from "@/components/LandmarkCard.vue";
//import landmarkService from "../services/LandmarkService.js";
import mapboxService from "../services/MapboxService.js";
import openMapTripService from "../services/OpenMapTripService.js"

export default {
  name: "landmark-list",
  components: { LandmarkCard },
  data() {
      return {
          location: {
            features: [
          ]
          },
          coordinates: []
      }
  },
  //props: ['zipCode'],
  methods: {
      getLandmarksByAddress() {
          const address = this.$route.params.query;
          mapboxService.getAddressInfo(address)
          .then((response) => {
              //response.header("Access-Control-Allow-Origin", "*");
              console.log("Getting Zip Codes");
              if (response.status === 200) {
                  this.location = response.data;
                  console.log(response.data);
                  this.coordinates = (this.location.features[0].geometry.coordinates);
                  console.log(this.coordinates);
                  this.$store.commit("SET_COORDINATES", this.coordinates);

                            openMapTripService.getNearbyPlaces(this.coordinates[0], this.coordinates[1])
                  .then((response) => {
                      if (response.status === 200) {
                          this.$store.commit("SET_LANDMARKS", response.data);
                          console.log(response.data);
                      }
                  })
                  .catch((error) => {
                      if (error.response.status == 404) {
                          this.$router.push({ name: "NotFound"});
                      }
                  });
                  
              }
          })
          .catch((error) => {
              console.log("reached catch in landmarklist.vue");
              console.log(error);
              if (error.response.status == 404) {
                  this.$router.push({ name: "NotFound"});
              }
          })



      }
    // getAllLandmarks() {
    //   landmarkService
    //     .getLandmarks()
    //     .then((response) => {
    //       console.log("reaching");
    //       if (response.status === 200) {
    //         this.$store.commit("SET_LANDMARKS", response.data);
    //         console.log("reaching");
    //         console.log(response.data);
    //       }
    //     })
    //     .catch((error) => {
    //       if (error.response.status == 404) {
    //         this.$router.push({ name: "NotFound" });
    //       }
    //     });
    //}
  },
  created() {
    console.log("reaching created");
    //this.getAllLandmarks();
    this.getLandmarksByAddress();
  },
};
</script>

<style>
.list {
  width: 50%;
  background-color: rgb(255, 255, 255);
  margin: 30px;
  overflow: auto;
  border-radius: 20px;
  padding: 10px 20px;
  position: relative;
}

li {
  width: 95%;
  margin: auto;
  border-radius: 30px;
}

.list> ul > li:nth-child(1) {
  box-shadow: 0px 2px 5px 3px rgba(168, 167, 167, 0.281);
}

.list> ul > li:hover {
  box-shadow: 0px 2px 5px 3px rgba(168, 167, 167, 0.281);
}

ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
}

/* .overlay-list {
  content: "";
  background-image: linear-gradient(to bottom, var(--tw-gradient-stops));
  --tw-gradient-from: transparent;
  --tw-gradient-to: transparent;
  --tw-gradient-stops: var(--tw-gradient-from), var(--tw-gradient-to);
  --tw-gradient-to: #fff;
  position: absolute;
  bottom: 500px;
  display: block;
  height: 8rem;
  width: 95%;
} */

/* width */
::-webkit-scrollbar {
  background: rgba(252, 252, 252, 0.411);
  width: 20px;
}
::-webkit-scrollbar-button {
  height: 50px;
  width: 10px;
}
/* Handle */
::-webkit-scrollbar-thumb {
  background: #7c7c7cb7;
  border-radius: 10px;
}
/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #0717aa;
  transition: 400ms;
}
</style>
