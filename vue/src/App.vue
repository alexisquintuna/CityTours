<template>
  <div id="app">
    <div id="nav">
      <div>
        <router-link id="logo-text" class="nav-text" v-bind:to="{ name: 'home' }">City Tours</router-link>
      </div>
      <div id="nav0left">
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: '' }" v-if="$store.state.token != ''"> My Adventures</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: '' }" v-if="$store.state.token != ''">My Profile</router-link>
        <router-link class="nav-subtext nav-text login-btn" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
        <router-link class="nav-subtext nav-text login-btn" v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''" >Log In</router-link>
      </div>
    </div>
      <p v-if="$store.state.user.username"> User is {{$store.state.user.username}}</p>
    <router-view />
  </div>
</template>

<style>
#app{
  width: 100%;
  height: 100%;
}
#nav{
  background-color: seagreen;
  display: flex;
  justify-content: space-between;
  height: 70px;
  align-items: center;
}

#nav > div{
  margin: 0 10px;
}

.nav-text {
  text-decoration: none;
  color: white;;
}
 
#logo-text{
  font-size: 36px;
}

.nav-subtext{
  font-size: 24px;
  margin: 0 15px;
}

.login-btn{
  background-color: rgb(117, 81, 55);
  border-radius: 100px;
  display: block;
  height: 40px;
  width: 100px;

}

</style>