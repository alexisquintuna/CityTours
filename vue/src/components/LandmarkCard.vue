<template>
  <router-link
    class="big-card"
    v-bind:to="{ name: 'landmark-details', params: { id: landmark.xid } }"
  > 
    <div class="card">
      <div>
        <img
          class="img-location"
          src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR7oV4dvRTPvtGv56ZPQN0P1iXRpBHoWM3i_g&usqp=CAU"
          alt=""
        />
      </div>
      <div class="details">
        <h1>{{ landmark.name }}</h1>
        <p>{{ this.kinds }}</p>
      </div>
      <div class="icon">
        <img
          class="img-icon"
          src="https://w7.pngwing.com/pngs/244/287/png-transparent-google-map-maker-pin-computer-icons-google-maps-map-icon-angle-black-map.png"
          alt=""
        />
      </div>
    </div>
  </router-link>
</template>

<script>
// import openMapTripService from "@/services/OpenMapServices.js"
export default {
  data(){
    return{
      kinds: ''
    }
  },
  name: "landmark-card",
  props: {
    landmark: Object,
  },
  created(){
    this.kinds = this.landmark.kinds.split('_')[0].split(',')[0]
    // openMapTripService.getPlaceDetails(this.id)
    // .then((response) => {
    //   console.log(response.data)
    //   if (response.status === 200) {
    //     this.image = this.landmark.preview.source;
    //   }
    // })
    // .catch((error) => {
    //   if (error.response.status == 404) {
    //     this.$router.push({name: "NotFound"});
    //   }
    // })
  }
};
</script>

<style>
.big-card {
  color: black;
  text-decoration: none;
}

.card {
  overflow: hidden;
  padding: 5px 10px;
  display: flex;
  align-items: center;
  margin: 35px auto;
  border-radius: 30px;
  height: 150px;
  width: 90%;
  background-color: #fff;
}
.img-location {
  margin: 0;
  padding: 0;
  height: 120px;
  width: 120px;
  background-color: chocolate;
  border-radius: 30px;
  overflow: hidden;
}

.details {
  margin: 0 15px;
  width: 75%;
  display: flex;
  flex-direction: column;
}

.details h1{
    color: #1a2e34;
    font-size: 1.8rem;
}

.details h1,
.details p {
  display: inline-block;
  margin: 5px 0;
  padding: 0;
  /* how to figure out to hide extra info when being sent */
}

.details p {
  width: 100%;
  height: 4.5ch;
  overflow: hidden;
  text-overflow: ellipsis;

  /* how to figure out to hide extra info when being sent */
}

.icon {
  position: relative;
  bottom: 2.8rem;
  width: 1.3rem;
  height: 1.3rem;
  border-radius: 100px;
}
.img-icon {
  width: 1.3rem;
  height: 1rem;
  border-radius: 100px;
}
</style>
