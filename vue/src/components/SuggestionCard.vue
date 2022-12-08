<template>
  <router-link
    class="suggestion-link"
    v-bind:to="{ name: 'landmark-details', params: { id: landmark.id } }"
  >
    <div class="suggestion-card">
      <div class="suggestion-bg">
        <div class="suggestion-details">
          <h1>{{ landmark.name }}</h1>
        </div>
        <div class="suggestion-icon">
          <img
            class="img-icon"
            src="https://w7.pngwing.com/pngs/244/287/png-transparent-google-map-maker-pin-computer-icons-google-maps-map-icon-angle-black-map.png"
            alt=""
          />
        </div>
      </div>
    </div>
  </router-link>
</template>

<script>
export default {
  name: "suggestion-card",
  props: {
    landmark: Object,
  },
};
</script>

<style>
.suggestion-bg {
  padding: 5px 10px;
  margin: 0;
  height: 100%;
  width: 100%;
  border-radius: 20px;
  background-image: linear-gradient(
    to bottom,
    rgba(247, 247, 247, 0),
    rgb(0, 0, 0)
  );
}
.suggestion-link {
  text-decoration: none;
}

.suggestion-card {
  background-image: url("https://upload.wikimedia.org/wikipedia/commons/thumb/8/89/LeVeque_Tower%2C_Columbus%2C_OH%2C_US_crop.jpg/170px-LeVeque_Tower%2C_Columbus%2C_OH%2C_US_crop.jpg");
  background-repeat: no-repeat;
  background-size: cover;
  margin: 1rem auto;
  border-radius: 30px;
  height: 90%;
  width: 18rem;
  position: absolute;
}
.suggestion-details {
  margin: 0 15px;
}

.suggestion-details h1 {
  position: absolute;
  bottom: 1rem;
  color: #fff;
  font-size: 1.8rem;
  display: inline-block;
  margin: 5px 0;
  padding: 0;
}

.suggestion-icon {
  position: absolute;
  top: 1.2rem;
  right: 1.5rem;
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
