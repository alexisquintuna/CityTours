<template>
  <div id="app">
    <div id="nav">
      <div>
        <router-link id="logo-text" class="nav-text" v-bind:to="{ name: 'home' }">Opn <br>City</router-link>
      </div>
      <div id="nav-left">
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: 'landmarks' }" v-if="$store.state.token != ''">Landmark List</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: 'adventures' }" v-if="$store.state.user.role == 'user'">My Adventures</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: '' }" v-if="$store.state.user.role == 'user'">My Profile</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: 'add-landmarks' }" v-if="$store.state.user.role == 'admin'">Add Landmarks</router-link>
        <router-link class="nav-subtext nav-text" v-bind:to="{ name: '' }" v-if="$store.state.user.role == 'admin'">Admin Profile</router-link>
        <router-link class="nav-subtext nav-text login-btn" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
        <router-link class="nav-subtext nav-text login-btn" v-bind:to="{ name: 'login' }" v-if="$store.state.token == ''" >Log In</router-link>
      </div>
    </div>
    <router-view class="router-view" />
      <!-- <p v-if="$store.state.user.username"> User is {{$store.state.user.username}}</p> -->
  </div>
</template>
<script>
export default{
  data(){
    return{
      user:{
        role: this.$store.state.user
      }
    }
  }
}
</script>

<style>
.router-view{
  bottom: 0;
  height: auto;
  width: 100%;
}
#app{
  height: auto;
}
#nav{
  position: absolute;
  top: 0;
  display: flex;
  justify-content: space-between;
  height: 120px;
  width: 100%;
  align-items: center;
}

#nav > div{
  margin: 0 70px;
}

.nav-text {
  text-decoration: none;
  color: rgb(255, 255, 255);;
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
  color:#6BAA75;
  text-decoration: underline;
  transition: 400ms;
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
  background-color: #6BAA75;
}

</style>