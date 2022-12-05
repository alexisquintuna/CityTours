<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1  id="title" class="h3 mb-3 font-weight-normal">Create Account</h1>
      <p id="sub-title" >Please enter your details</p>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="username"
        v-model="user.username"
        required
        autofocus
      />
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="confirm password"
        v-model="user.confirmPassword"
        required
      />
      <button class="btn btn-lg btn-primary btn-block register-btn" type="submit">
        Create Account
      </button>
      <p class="login-p">Already have an account? <router-link :to="{ name: 'login' }" class="login">click here</router-link></p>
    </form>
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

<style >
#register {
  width: 100%;
  position: relative;
  display: flex;
  justify-content: center;
  align-content: center;
}

.form-register {
  width: 450px;
  height: 525px;
  position: absolute;
  top: 50%;
  transform: translate(0, 50%);
  display: flex;
  flex-direction: column;
  text-align: center;
  background-color: rgb(255, 255, 255);
  border-radius: 50px;
}

.login-p {
  position: relative;
  bottom: 20px;
}

.login {
  font-weight: 900;
  font-style: italic;
} 

</style>
