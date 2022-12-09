<template>
  <div class="home">
    <form class="home-form" action="" v-on:submit="saveZip">
      <input
        class="home-input"
        type="text"
        placeholder="Please enter a zip code"
        v-model="zipCode"
      />
      <div class="div-submit">
        <router-link
          class="submit-btn"
          v-bind:to="{ name: 'landmarks', params: { zip: zipCode } }"
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
      zipCode: "",
    };
  },
  methods: {
    saveZip() {
      this.$store.commit("SET_ZIPCODE", this.zipCode);
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
  /* right: 7.5rem; */
}

.enter-zip:hover {
  cursor: pointer;
  background-color: white;
  color: black;
  transition: 400ms;
  z-index: 1;
}
.enter-zip {
  height: 2.4rem;
  width: 100%;
  background-color: #000;
  color:white;
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
