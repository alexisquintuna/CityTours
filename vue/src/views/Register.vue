<template>
  <div id="register" class="text-center">
    <div class="register-container">
      <div class="left-side-register">
        <p class="left-side-p">Register and explore <br />OPN CITY</p>
      </div>
      <form class="form-register" @submit.prevent="register">
        <h1 id="title" class="h3 mb-3 font-weight-normal">Create Account</h1>
        <div class="alert alert-danger" role="alert" v-if="registrationErrors">
          {{ registrationErrorMsg }}
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
          <label class="label">enter password</label>
        </div>
        <div class="input-container">
          <input
            type="password"
            id="confirmPassword"
            class="form-control"
            v-model="user.confirmPassword"
            required
          />
          <label class="label">re-enter password</label>
        </div>
        <button
          class="login-btn"
          type="submit"
        >
          CREATE ACCOUNT
        </button>
        <p class="register-p">
          Already have an account?
          <router-link :to="{ name: 'login' }" class="click-here"
            >click here</router-link
          >
        </p>
      </form>
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style>
#register {
  display: flex;
  justify-content: center;
  align-items: center;
  backdrop-filter: blur(5px);
  height: 100vh;
}
.register-container {
  display: flex;
  width: 50rem;
  height: 30rem;
  background-color: rgb(255, 255, 255);
  padding: 2rem;
}
.left-side-register {
  background-image: url("https://img.freepik.com/free-vector/hiking-concept-illustration_114360-3374.jpg?w=826&t=st=1670680650~exp=1670681250~hmac=6df100b82e610c17b20f366d25fd61fdce1add6956d56a198bac2a41414815fd");
  background-size: contain;
  background-size: contain;
  background-repeat: no-repeat;
  background-position: bottom;
  height: 100%;
  width: 50%;
}
.form-register {
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
.register-p{
  margin-top: 1rem;
}
.click-here { 
  font-weight: 900;
  font-style: italic;
}
</style>
