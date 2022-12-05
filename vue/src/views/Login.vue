<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 id="title" class="h3 mb-3 font-weight-normal">Welcome Back!</h1>
      <p id="sub-title">Please enter your details</p>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <!-- <label for="username" class="sr-only">Username</label> -->
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="username"
        v-model="user.username"
        required
        autofocus
      />
      <!-- <label for="password" class="sr-only">Password</label> -->
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="password"
        v-model="user.password"
        required
      />
      <button type="submit">LOGIN</button>
      <p class="register-p">Don't have an account?<router-link :to="{ name: 'register' }" class="register"> click here</router-link></p>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style >

#login{
  width: 100%;
  position: relative;
  display: flex;
  justify-content: center;
  align-content: center;
}
.form-signin{
  width: 450px;
  height: 450px;
  position: absolute;
  top: 50%;
  transform: translate(0, 50%);
  display: flex;
  flex-direction: column;
  text-align: center;
  background-color:rgb(255, 255, 255);
  border-radius: 50px;
}
#title{
  position: relative;
  top: 10px;
  font-size: 40px;
}
#sub-title{
  position: relative;
  bottom: 24px;
  font-size: 20px;
}
input{
  height: 47px;
  width: 300px;
  border-radius: 10px;
  border:none;
  background-color:#d9d9d9;
  margin: 5px auto 10px;
  padding-left: 10px;
  font-size: 18px;
}
input::placeholder{
  color: black;
}
input:focus{
  outline: none;
}

input:focus::placeholder{
  color:transparent;
}
button:hover{
  color:black;
  background-color:white;
  border: 1px solid black;
  transition: 300ms;
  cursor: pointer;
}
button{
  width: 65%;
  margin: auto;
  height: 60px;
  border:none;
  border-radius: 50px;
  background-color: black;
  color: white;
  font-size: 28px;
}
.register-p{
  position: relative;
  bottom: 20px;
}

.register{
  font-weight: 900;
  font-style: italic;
}

</style>
