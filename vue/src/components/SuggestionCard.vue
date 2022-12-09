<template>
    <div class="suggestion-card">

  <router-link
    class="suggestion-link"
    v-bind:to="{ name: 'landmark-details', params: { id: landmark.id } }"
  >
      <div class="suggestion-bg">
        <img class="suggestion-img" v-bind:src="landmark.photo" alt="">
        <div class="suggestion-details">
          <h1>{{ landmark.name }}</h1>
        </div>
        <div class="suggestion-icon">
          <img
            class="img-icon"
            v-bind:src="landmark.photo"
            alt=""
          />
        </div>
      </div>
  </router-link>
    </div>
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
  height: 100%;
  width: 100%;
  border-radius: 20px;
  background-image: linear-gradient(
    to bottom,
    rgba(247, 247, 247, 0),
    rgb(0, 0, 0)
  );
  overflow: hidden;
}
.suggestion-link {
  text-decoration: none;
}
.suggestion-img{
  height: 100%;
}
.suggestion-card {
  background-repeat: no-repeat;
  background-size: cover;
  border-radius: 30px;
  height: 100%;
  width: 18rem;
}

.suggestion-details {
  margin-right: 1rem;
  margin-bottom: 2rem;
  overflow: hidden;
  width: 100%;
  height: 100%;
}

.suggestion-details h1 {
  position: absolute;
  bottom: 1rem;
  color: #fff;
  font-size: 1.8rem;
  display: inline-block;
  margin: 5px 0;
  padding: 0;
  flex-wrap: wrap;
  width: 10%;
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
