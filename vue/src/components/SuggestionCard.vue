<template>
  <div class="suggestion-card">
    <!-- het rid of password thing -->
    <!-- chrome settings and security -->
    <router-link
      class="suggestion-link"
      v-bind:to="{ name: 'suggested-details', params: { id: landmark.id } }" 
    >
      <div class="suggestion-bg">
        <img class="suggestion-img" v-bind:src="landmark.photo" alt="" />
        <div class="suggestion-details">
          <h1 class="sub-title-font">{{ landmark.name }}</h1>
        </div>
        <!-- <div class="suggestion-icon">
          <img class="img-icon" v-bind:src="landmark.photo" alt="" />
        </div> -->
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
.suggestion-card {
  border-radius: 30px;
  height: 100%;
  width: 5rem;
  overflow: hidden;
  position: relative;
}

.suggestion-bg {
  height: 100%;
  width: 100%;
  border-radius: 20px;
}
.suggestion-link {
  position: relative;
  text-decoration: none;
}
.suggestion-img {
  position: relative;
  width: 100%;
  height: 100%;
}

.suggestion-details {
  background-image: linear-gradient(to bottom, rgba(255, 255, 255, 0.027) 35%,rgb(0, 0, 0));
  width: 100%;
  height: 100%;
  position: absolute;
  bottom: 0;

}

.suggestion-details h1 {
  margin: 15px 10px;
  color: #fff;
  font-size: 1.3rem;
  font-weight: 500;
  position: absolute;
  bottom: 0;
  display: flex;
  flex-wrap:wrap;
  width: 50%;
  height: auto;
}

</style>
