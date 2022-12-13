<template>
  <!-- het rid of password thing -->
  <!-- chrome settings and security -->
  <router-link
    class="adventure-landmark-card"
    v-bind:to="{ name: 'suggested-details', params: { id: landmark.id } }"
  >
    <div class="adventure-landmark-bg">
      <div>
        <img
          class="adventure-landmark-img"
          v-bind:src="landmark.photo"
          alt=""
        />
      </div>
      <div class="adventure-landmark-details">
        <h1>{{ landmark.name }}</h1>
      </div>
      <!-- <div class="suggestion-icon">
          <img class="img-icon" v-bind:src="landmark.photo" alt="" />
        </div> -->
    </div>
  </router-link>
</template>

<script>
export default {
  name: "adventure-landmark-card",
  props: {
    landmark: Object,
  },
};
</script>

<style>
.adventure-landmark-card {
  color: black;
  text-decoration: none;
}

.adventure-landmark-bg {
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
.adventure-landmark-img{
  margin: 0;
  padding: 0;
  height: 120px;
  width: 120px;
  background-color: chocolate;
  border-radius: 30px;
  overflow: hidden;
}

.adventure-landmark-details {
  margin: 0 15px;
  width: 75%;
  display: flex;
  flex-direction: column;
}

.adventure-landmark-details h1 {
  color: #1a2e34;
  font-size: 1.8rem;
}

.adventure-landmark-details h1,
.adventure-landmark-details p {
  display: inline-block;
  margin: 5px 0;
  padding: 0;
  /* how to figure out to hide extra info when being sent */
}

.adventure-landmark-details p {
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
