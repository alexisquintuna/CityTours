<template>
  <div id="app">
    <nav id="nav" ref="nav" class="inactive">
      <div>
        <router-link id="logo-text" v-bind:to="{ name: 'home' }">
          <img class="logo" src="@/images/LOGOCITY.png" alt="" />
        </router-link>
      </div>
      <div id="nav-right">
        <router-link
          class="nav-subtext nav-text sub-title-font"
          v-bind:to="{ name: 'home' }"
          v-if="$store.state.token != ''"
          >Home</router-link
        >
        <router-link
          class="nav-subtext nav-text sub-title-font"
          v-bind:to="{ name: 'adventures' }"
          v-if="$store.state.token != ''"
          >My Adventures</router-link
        >
        <router-link
          class="nav-subtext nav-text sub-title-font"
          v-bind:to="{ name: '' }"
          v-if="$store.state.user.role == 'user'"
          >My Profile</router-link
        >
        <router-link
          class="nav-subtext nav-text sub-title-font"
          v-bind:to="{ name: 'add-landmarks' }"
          v-if="$store.state.user.role == 'admin'"
          >Add Landmarks</router-link
        >
        <router-link
          class="nav-subtext nav-text sub-title-font"
          v-bind:to="{ name: '' }"
          v-if="$store.state.user.role == 'admin'"
          >Admin Profile</router-link
        >
        <router-link
          class="nav-login-btn sub-title-font"
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token != ''"
          >Logout</router-link
        >
        <router-link
          class="nav-login-btn sub-title-font"
          v-bind:to="{ name: 'login' }"
          v-if="$store.state.token == ''"
          >Log In</router-link
        >
      </div>
    </nav>
    <router-view class="router-view" />
    <footer>
      <div class="footer-container">
        <div class="logo-side">
          <img class="footer-logo" src="@/images/LOGOCITY.png" alt="" />
          <div class="footer-words">
            <p>share your memories with us on social media</p>
            <div>
              <i class="social-icons fa fa-instagram"></i>
              <i class="social-icons fa fa-facebook-square"></i>
              <i class="social-icons fa fa-twitter-square"></i>
            </div>
          </div>
        </div>
        <div class="navFooter">
          <router-link class="navFooter-text" v-bind:to="{ name: 'home' }"
            >Home</router-link
          >
          <router-link class="navFooter-text" v-bind:to="{ name: 'home' }"
            >About Us</router-link
          >
          <router-link class="navFooter-text" v-bind:to="{ name: 'home' }"
            >Contact Us</router-link
          >
        </div>
        <div class="copyright">
          <p>Copyright <i class="fa fa-copyright"></i> 2022 OPEN CITY</p>
        </div>
      </div>
    </footer>
  </div>
</template>
<script>
export default {
  data() {
    return {
      user: {
        role: this.$store.state.user,
      },
    };
  },
  methods: {
    addingClass() {
      console.log("reaching adding");
      let navBar = document.getElementById("nav");
      console.log(navBar);
      navBar.classList.remove(".inactive");
      navBar.classList.add(".active");
    },
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Cinzel:wght@600&display=swap");
@import url("https://fonts.googleapis.com/css2?family=DM+Sans:ital@0;1&family=DM+Serif+Display&display=swap");

:root {
  --logo: green;
  --title: black;
  --subtitle: white;

  --lime-green: #59e3a8;
}
/* 

font-family: 'DM Sans', sans-serif;
font-family: 'DM Serif Display', serif;

*/
.main-title-font {
  font-family: "DM Serif Display", serif;
}

.sub-title-font {
  font-family: "DM Sans", sans-serif;
}

.router-view {
  position: relative;
  width: 100%;
  margin: 7.5rem 0;
}
#app {
  height: auto;
  position: absolute;
  top: 0;
  width: 100%;
}
.background-img {
  animation-name: zoomOut;
  animation-duration: 2.5s;
  animation-timing-function: ease-in;
  animation-delay: 0s;

  width: 100%;
  position: absolute;
  top: 7rem;
  display: flex;
  justify-content: center;
}
.background-img > img {
  width: 65%;
}
.inactive {
  display: none;
}
.active {
  animation: 1s ease-out 0s 1 slideInDown;
}
#nav {
  backdrop-filter: blur(5px);
  background-color: #1a2e34c9;
  position: absolute;
  top: 0;
  display: flex;
  justify-content: space-between;
  height: 120px;
  width: 100%;
  align-items: center;
  z-index: 99;
}

#nav > div {
  margin: 0 70px;
}

.logo {
  width: 10%;
  margin-top: 0.5rem;
}
.nav-text {
  text-decoration: none;
  color: rgb(255, 255, 255);
  display: inline-block;
  font-size: 1.2rem;
}

#logo-text {
  font-size: 36px;
  color: #59e3a8;
  font-family: "Cinzel", serif;
}

#nav-right {
  /* background-color: tomato; */
  display: flex;
  align-items: center;
  justify-content: flex-end;
  width: auto;
}
.nav-subtext {
  margin: 0 1rem;
}
.nav-subtext:hover {
  color: #59e3a8;
  text-decoration: underline;
  transition: 400ms;
}

.nav-login-btn {
  background-color: rgba(255, 255, 255, 0.288);
  color: white;
  border-radius: 20px;
  height: 2.8rem;
  width: 7rem;
  display: flex;
  margin: 0 10px;
  justify-content: center;
  align-items: center;
  text-decoration: none;
  font-size: 1.2rem;
}

.nav-login-btn:hover {
  color: #1a2e34;
  background-color: #59e3a8;
  transition: 300ms;
}

.login-btn:hover {
  transition: 300ms;
  color: #1a2e34;
  background-color: #59e3a8;
}
footer {
  position: absolute;
  bottom: 0;
  height: 10rem;
  width: 100%;
  background: #1a2e34;
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
}

footer > div {
  display: flex;
  justify-content: space-between;
}

footer > div > div {
  width: 28%;
  height: 90%;
  display: flex;
  align-items: center;
  justify-content: center;
}
.footer-container {
  height: 100%;
  width: 90%;
  display: flex;
  align-items: center;
}
.footer-logo {
  width: 25%;
}
.logo-side {
  display: flex;
  align-items: center;
  justify-content: space-evenly;
}
.footer-words {
  width: 50%;
}
.footer-words p,
.footer-words div {
  margin: 1rem 0;
}
.footer-words p {
  font-size: 1.5rem;
}
.footer-words div {
  width: 93%;
  font-size: 1.7rem;
  display: flex;
  justify-content: space-between;
}

.social-icons:hover{
  transition: 400ms;
  transform: translateY(5px);
  cursor: pointer;
  color: var(--lime-green)
}

.navFooter {
  justify-content: space-evenly;
}

.navFooter-text {
  font-size: 1.3rem;
  text-decoration: none;
  color: white;
}
.navFooter-text:hover{
  transition: 400ms;
  color: var(--lime-green);
  text-decoration: underline;
  transform: translateY(5px);
}
input {
  border: none;
}
input:focus {
  outline: none;
}

button {
  margin: 0 auto;
  height: 60px;
  border: none;
  border-radius: 50px;
}

button:hover {
  color: black;
  background-color: white;
  transition: 300ms;
  cursor: pointer;
}
</style>
