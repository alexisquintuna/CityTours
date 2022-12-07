<template>
  <router-link
    class="big-card"
    v-bind:to="{ name: 'landmark-details', params: { id: landmark.id } }"
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
        <p>{{ landmark.description }}</p>
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
export default {
  name: "landmark-card",
  props: {
    landmark: Object,
  },
};
</script>

<style>
.big-card {
  color: black;
  text-decoration: none;
}

.card {
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
  display: flex;
  flex-direction: column;
}

.details h1{
    color: #022596;
}

.details h1,
.details p {
  display: inline-block;
  margin: 5px 0;
  padding: 0;
  /* how to figure out to hide extra info when being sent */
}

.details p {
  /* background-color: blue; */
  width: 24rem;
  height: 4.5ch;
  overflow: hidden;
  text-overflow: ellipsis;

  /* how to figure out to hide extra info when being sent */
}

.icon {
  position: relative;
  bottom: 45px;
  right: 15px;
  width: 20px;
  height: 20px;
  background-color: rgb(185, 4, 40);
  border-radius: 100px;
}
.img-icon {
  width: 20px;
  height: 20px;
  border-radius: 100px;
}
</style>
