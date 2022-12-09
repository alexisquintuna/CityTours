<template>
  <div class="addLandmark-page">
    <div class="adding-container">
      <form class="adding-form" v-on:submit.prevent="adding">
        <div class="adding-box-top">
          <div class="adding-header-top">
            <h1>Create a new landmark</h1>
            <p>Please enter the following details</p>
          </div>

          <div class="top-btn">
            <button class="addNew-btn cancel">Cancel</button>
            <button class="addNew-btn adding">Add</button>
          </div>
        </div>

        <div class="alert alert-danger-adding" role="alert" v-if="addingErrors">
          {{ addingErrorsMsg }}
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Name Landmark</h1>
            <p>Insert a name for the new landmark</p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Name"
              v-model="landmark.name"
              required
              class="adding-form-control"
              autofocus
              type="text"
            />
          </div>
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Description</h1>
            <p>Add a description for the new landmark</p>
          </div>

          <div class="adding-input">
            <textarea
              placeholder="Description"
              v-model="landmark.description"
              required
              class="adding-form-control add-text-area"
              type="text"
            />
          </div>
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Category</h1>
            <p>Add the type of category it fits in</p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Category"
              v-model="landmark.category"
              required
              class="adding-form-control"
              type="text-area"
            />
          </div>
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Latitude</h1>
            <p>Enter the latitude for landmark</p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Latitude"
              v-model="landmark.latitude"
              required
              class="adding-form-control"
              type="text"
            />
          </div>
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Longitude</h1>
            <p>Enter the longitude for landmark</p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Longitude"
              v-model="landmark.longitude"
              required
              class="adding-form-control"
              type="text"
            />
          </div>
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Address</h1>
            <p>Enter the address for landmark</p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Address"
              v-model="landmark.address"
              required
              class="adding-form-control"
              type="text"
            />
          </div>
        </div>

        <div class="adding-box">
          <div class="adding-header">
            <h1>Website</h1>
            <p>Enter a url link for landmarks website</p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Website Link"
              v-model="landmark.link"
              required
              class="adding-form-control"
              type="text"
            />
          </div>
        </div>
        
        <div class="adding-box">
          <div class="adding-header">
            <h1>Image Url</h1>
            <p>Enter a image url link </p>
          </div>

          <div class="adding-input">
            <input
              placeholder="Image Url"
              v-model="landmark.link"
              required
              class="adding-form-control"
              type="text"
            />
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import landmarkService from "../services/LandmarkService.js";

export default {
  name: "add-landmarks",
  data() {
    return {
      landmark: {
        name: "",
        description: "",
        category: "",
        latitude: "",
        longitude: "",
        address: "",
        link: "",
        imageUrl: ""
      },
      addingErrors: false,
      addingErrorsMsg: "There were problems adding this landmark",
    };
  },
  methods: {
    adding() {
      //here will add a service to add stuff to the database
      //example
      landmarkService
        .createLandmark(this.landmark)
        .then((res) => {
          if (res.status == 200) {
            this.$router.push({ name: "home" });
          }
        })
        .catch((err) => {
          this.addingErrors = false;
          if (err.response.status == 400) {
            this.addingErrorsMsg = "Bad Request: Validation Errors";
          }
        });
      return this.addingErrors;
    },
  },
};
</script>

<style>
.addLandmark-page {
  width: 100%;
  display: flex;
  align-items: flex-end;
}
.adding-container {
  width: 100%;
  margin: 10rem 0 4rem;
}
.adding-form {
  background-color: #f7f7f7;
  display: flex;
  flex-direction: column;
  width: 50%;
  height: 100%;
  margin: 0 auto;
  border-radius: 20px;
}
.adding-box-top,
.adding-box {
  display: flex;
  align-items: flex-start;
  width: 90%;
  margin: 2rem auto 0;
}

.adding-box-top {
  justify-content: space-between;
}

.adding-header-top > h1 {
  font-size: 1.7rem;
}
.adding-header > h1 {
  font-size: 1rem;
}
.adding-header-top > p,
.adding-header > p {
  font-size: 1rem;
  color: rgb(131, 131, 131);
}

.adding-box {
  height: 7rem;
  margin: 1.5rem auto;
  padding-top: 1rem;
  border-top: 1px solid rgb(179, 179, 179);
}

.adding-header-top,
.adding-header {
  width: 35%;
}

.adding-form-control {
  width: 100%;
  border-radius: 10px;
  margin: 0px auto;
  height: 2rem;
  padding-left: 1rem;
  border: 1px solid rgb(204, 204, 204);
  font-weight: 600;
}

.adding-form-control::placeholder {
  color: rgb(131, 131, 131);
  font-weight: 400;
}

.add-text-area {
  height: 12vh;
  padding: 10px;
  margin: 0;
  resize: none;
}

.add-text-area:focus {
  outline: none;
}

.adding-input {
  margin: 0;
  padding: 0;
  width: 45%;
  overflow: hidden;
  border-radius: 10px;
  box-shadow: 0 -0.5px 1px 0.5px rgba(0, 0, 0, 0.301);
}

.top-btn {
  display: flex;
}
.addNew-btn {
  margin: 5px;
  display: inline-block;
  font-size: 1.2rem;
  height: 2.4rem;
  width: 5rem;
  border-radius: 5px;
}
.cancel {
  background-color: white;
  color: black;
  border: 1px solid;
}
.adding:hover {
  background-color: #6baa75;
  border: none;
  color: white;
}
.cancel:hover {
  color: white;
  background-color: rgb(0, 0, 0);
}
</style>
