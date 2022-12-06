<template>
  <div id="app">
    <div id="nav">
      <div>
        <router-link id="logo-text" class="nav-text" v-bind:to="{ name: 'home' }">City Tours</router-link>
      </div>
      <div id="nav-left">
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: 'landmarks' }" v-if="$store.state.token != ''">Landmark List</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: '' }" v-if="$store.state.token != ''">My Adventures</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: '' }" v-if="$store.state.token != ''">My Profile</router-link>
        <router-link class="nav-subtext nav-text login-btn" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
        <router-link class="nav-subtext nav-text login-btn" v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''" >Log In</router-link>
      </div>
    </div>
    <router-view class="router-view" />
      <!-- <p v-if="$store.state.user.username"> User is {{$store.state.user.username}}</p> -->
  </div>
</template>

<style>
.router-view{
  height: 100%;
}
#app{
  position: relative;
  width: 100%;
  height: 100%;
}
#nav{
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

#nav-left{
  display: flex;
  align-items: center;
}

.nav-subtext{
  font-size: 24px;
  margin: 0 15px;
}

.nav-subtext:hover{
  color:rgb(189, 55, 166);
  text-decoration: underline;
  transition: 200ms;
}

.login-btn{
  background-color: rgba(255, 255, 255, 0.288);
  border-radius: 100px;
  display: block;
  height: 40px;
  width: 120px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.login-btn:hover{
  transition: 700ms;
  color: white;
  background-color: rgb(189, 55, 166);
}

</style>