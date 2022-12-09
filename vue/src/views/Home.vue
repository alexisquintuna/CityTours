<template>
  <div class="home">
    <form class="home-form" action="" v-on:submit="saveZip">
      <input
        class="home-input"
        type="text"
        placeholder="Please enter a zip code"
        v-model="zipCode"
      />
        <router-link
          class="submit-btn"
          v-bind:to="{ name: 'landmarks', params: { zip: zipCode } }"
        >
          <input class="enter-zip" type="submit" />
        </router-link>
    </form>

    <div class="landmark-suggestion">
        <h1>Hot spots</h1>
      <!-- <suggestion-list></suggestion-list> -->
    </div>

  </div>
</template>

<script>
// import SuggestionList from "@/components/LandmarkSuggestions.vue"
export default {
  name: "home",
  // components: {SuggestionList},
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
  position: relative;
  flex-direction: column;
  margin-bottom: 5rem;
}

.home-form {
  width: auto;
  display: flex;
  align-items: center;
  /* background: chocolate; */
}

.home-input {
  background-color: rgba(255, 255, 255, 0);
  border-bottom: 5px solid white;
  border-radius: 0px;
  font-size: 65px;
  height: 7rem;
  color: white;
  width: 33rem;
  font-size: 3rem;
}


.submit-btn {
  height: 50%;
  width: 8rem;
  border-radius: 20px;
  background-color: #dbdbdb;
  display: flex;
  align-items: center;
  justify-content: center;
  text-decoration: none;
}

.submit-btn:hover {
  cursor: pointer;
  background-color: black;
  color: white;
  transition: 400ms;
}
.enter-zip:hover {
  cursor: pointer;
  background-color: black;
  color: white;
  transition: 400ms;
  font-size: 1.6rem;
}
.enter-zip {
  font-size: 1.4rem;
  height: 100%;
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

.landmark-suggestion {
  position: absolute;
  /* bottom: 2rem; */
  bottom: 0;
  /* border-radius: 20px; */
  margin: 5rem auto 0;
  height: 18rem;
  width: 75%;
  background-color: #f5f5f5;
}

.landmark-suggestion > h1 {
    font-size: 2.5rem;
    display: inline-block;
    margin: 1rem 1rem 0rem 2.7rem;
}

</style>
