<template>
  <div id="login" class="text-center">
    <div class="login-container">
      <div class="left-side-login">
        <p class="left-side-p">
          Explore with <br />
          OPN CITY
        </p>
      </div>
      <form class="form-login" @submit.prevent="login">
        <h1 id="title" class="h3 mb-3 font-weight-normal">Login</h1>
        <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
          Invalid username and password!
        </div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >
          Thank you for registering, please sign in.
        </div>
        <div class="input-container">
        <input
          type="text"
          id="username"
          class="form-control"
          v-model="user.username"
          required
          
          autocomplete="off"
        />
        <label class="label">username</label>
        </div>
        <div class="input-container">
        <input
          type="password"
          id="password"
          class="form-control"
          v-model="user.password"
          required
        />
        <label class="label">password</label>
        </div>
        
        <button class="login-btn" type="submit">LOGIN</button>
        <p class="register-p">
          Don't have an account?<router-link
            :to="{ name: 'register' }"
            class="click-here"
          >
            click here</router-link
          >
        </p>
      </form>
    </div>
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
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style>
#login {
  display: flex;
  justify-content: center;
  align-items: center;
  backdrop-filter: blur(5px);
  height: 100vh;
}
.login-container {
  display: flex;
  width: 50rem;
  height: 30rem;
  background-color: rgb(255, 255, 255);
  padding: 2rem;
}
.left-side-login {
  height: 100%;
  width: 50%;
  background-image: url("https://img.freepik.com/free-vector/traveling-concept-illustration_114360-3328.jpg?w=900&t=st=1670680647~exp=1670681247~hmac=cc87d67be2e1de4fb82b61c0e236ce6cdc894326973a15b79e684d332d4d3696");
  background-size: contain;
  background-repeat: no-repeat;
  background-position: bottom;
}
.left-side-p {
  font-size: 2rem;
  text-align: center;
  display: block;
  margin-top: 0.1rem;
  font-weight: bolder;
}
.form-login {
  padding: 10px;
  align-items: center;
  justify-content: center;
  width: 50%;
  display: flex;
  flex-direction: column;
  gap: 3%;
  text-align: center;
  background-color: rgb(255, 255, 255);
}
#title {
  display: inline-block;
  font-size: 2.7rem;
  margin: 1rem;
}

.input-container{
  position: relative;
}
.form-control {
  height: 47px;
  width: 300px;
  background-color: #ffffff;
  margin: 5px auto 10px;
  padding-left: 10px;
  font-size: 18px;
  border-bottom: 3px solid black;
  display: inline-block;
  color: #444;
  border-top-left-radius: 10px;
  border-top-right-radius: 10px;
  position: relative;
}

.form-control:focus {
  border: thin solid #000000;
  border-bottom: solid medium #000000;
  background-color: #fff;
}

.label {
  color: rgb(107, 107, 107);
  position: absolute;
  pointer-events: none;
  left: 10px;
  top: 23px;
  transition: 0.2s;
}
.form-control:focus ~ label,
.form-control:valid ~ label {
  top: -2px;
  left: 15px;
  font-size: small;
  color: #3D9F76;
  background-color: #fff;
  padding: 0 5px 0 5px;
}
.login-btn{
  background-color: black;
  color:white;
  width: 80%;
  height: 10%;
  font-size: 1rem;
}


/* Alert Section */

.alert-danger {
  color: red;
  position: relative;
  bottom: 10px;
}

.alert-success {
  color: rgb(0, 129, 0);
  position: relative;
  bottom: 10px;
}
</style>
