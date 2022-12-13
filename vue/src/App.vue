<template>
  <div id="app">
    <div id="nav">
      <div>
        <router-link
          id="logo-text"
          class="nav-text"
          v-bind:to="{ name: 'home' }"
          >Opn <br />City</router-link
        >
      </div>
      <div id="nav-right">
        <router-link
          class="nav-subtext nav-text"
          v-bind:to="{ name: 'home' }"
          v-if="$store.state.token != ''"
          >Home</router-link
        >
        <router-link
          class="nav-subtext nav-text"
          v-bind:to="{ name: 'adventures' }"
          v-if="$store.state.token != ''"
          >My Adventures</router-link
        >
        <router-link
          class="nav-subtext nav-text"
          v-bind:to="{ name: '' }"
          v-if="$store.state.user.role == 'user'"
          >My Profile</router-link
        >
        <router-link
          class="nav-subtext nav-text"
          v-bind:to="{ name: 'add-landmarks' }"
          v-if="$store.state.user.role == 'admin'"
          >Add Landmarks</router-link
        >
        <router-link
          class="nav-subtext nav-text"
          v-bind:to="{ name: '' }"
          v-if="$store.state.user.role == 'admin'"
          >Admin Profile</router-link
        >
        <router-link
          class="nav-login-btn"
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token != ''"
          >Logout</router-link
        >
        <router-link
          class="nav-login-btn"
          v-bind:to="{ name: 'login' }"
          v-if="$store.state.token == ''"
          >Log In</router-link
        >
      </div>
    </div>
    <router-view class="router-view" />
    <footer>
      <h1>this is the footer</h1>
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
};
</script>

<style>
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
#nav {
  animation: 1s ease-out 0s 1 slideInDown;
  background-color: #1a2e34;
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
@keyframes slideInDown {
        0% {
          transform: translatey(-100%);
        }
        100% {
          transform: translatey(0);
        }
      }

@keyframes easeIn {
  0%{
    opacity: 0%;
  }
  100%{
    opacity: 100%;
  }
}
.nav-text {
  text-decoration: none;
  color: rgb(255, 255, 255);
  display: inline-block;
  font-size: 1.2rem;
}

#logo-text {
  font-size: 36px;
  color:#59E3A8;
}

#nav-right {
  /* background-color: tomato; */
  display: flex;
  align-items: center;
  justify-content: flex-end;
  width: auto;
}
.nav-subtext{
  margin: 0 1rem;
}
.nav-subtext:hover {
  color: #59E3A8;
  text-decoration: underline;
  transition: 400ms;
}

.nav-login-btn {
  background-color: rgba(255, 255, 255, 0.288);
  color:white;
  border-radius: 20px;
  height: 2.5rem;
  width: 6rem;
  display:flex;
  margin: 0 10px;
  justify-content: center;
  align-items: center;
  text-decoration: none;
  font-size: 1.2rem;

}

.nav-login-btn:hover{
  color:#1A2E34;
  background-color: #59E3A8 ;
  transition: 300ms;
}

.login-btn:hover {
  transition: 300ms;
  color: #1A2E34;
  background-color: #59E3A8;
}
footer {
  position: absolute;
  bottom: 0;
  height: 10rem;
  width: 100%;
  background: #1A2E34;
  color: white;
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
