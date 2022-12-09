<template>
  <div class="home">
    <form class="home-form" action="" v-on:submit="saveQuery">
      <input
        class="home-input"
        type="text"
        placeholder="Please enter a location"
        v-model="locationQuery"
      />
      <div class="div-submit">
        <router-link
          class="submit-btn"
          v-bind:to="{ name: 'landmarks', params: { query: locationQuery } }"
        >
          <input class="enter-zip" type="submit" />
        </router-link>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "home",
  data() {
    return {
      locationQuery: "",
    };
  },
  methods: {
    saveQuery() {
      this.$store.commit("SET_LOCATION_QUERY", this.locationQuery);
    },
  },
};
</script>

<style>
.home {
  height: 100vh;
  display: flex;
  align-items: center;
  justify-content: center;
}
.home-form {
  width: 50%;
  display: flex;
  align-items: center;
}
.home-input {
  background-color: rgba(255, 255, 255, 0);
  border-bottom: 5px solid white;
  border-radius: 0px;
  font-size: 65px;
  height: 7rem;
  color: white;
}

.div-submit{
  height: 5rem;
  width: 7rem;
  display: flex;
  align-items: center;
  justify-content: center;
  position: relative;
  right: 7rem;
}
.submit-btn {
  height: 40%;
  width: 45rem;
  border-radius: 20px;
  background-color: #dbdbdb;
  display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: none;
  position: relative;
  left:0.5rem;
}

.enter-zip:hover {
  cursor: pointer;
  background-color: black;
  color: white;
  transition: 400ms;
  z-index: 1;
}
.enter-zip {
  height: 2.4rem;
  width: 100%;
  background-color: #fff;
  color:black;
  border-radius: 20px;
  margin: 0;
  padding: 0;
}

.home-input::placeholder {
  color: white;
}
.home-input:focus::placeholder {
  color: white;
}
</style>
