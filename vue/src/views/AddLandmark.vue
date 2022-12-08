<template>
  <div class="addLandmark-page">
    <!-- <h1>Adding Landmarks</h1> -->
    <div class="adding-container">
      <form action="" class="adding-form" submit.prevent="adding">
        <div class="adding-box-top">
          <div class="adding-header-top">
            <h1>Create a new landmark</h1>
            <p>Please enter your details</p>
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
            <input
              placeholder="Description"
              v-model="landmark.description"
              required
              class="adding-form-control"
              type="text"
            />
          </div>
        </div>
        
        <div class="adding-box">
          <div class="adding-header">
            <h1>Something</h1>
            <p>Description for something</p>
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
            <h1>Something</h1>
            <p>Description for something</p>
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
            <h1>Something</h1>
            <p>Description for something</p>
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
            <h1>Something</h1>
            <p>Description for something</p>
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
            <h1>Something</h1>
            <p>Description for something</p>
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
      
      </form>
    </div>
  </div>
</template>

<script>
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
      },
      addingErrors: false,
      addingErrorsMsg: "There were problems adding this landmark",
    };
  },
  methods: {
    adding() {
      if (this.landmark) {
        this.addingErrors = true;
        this.addingErrorsMsg = "Something bam bam";
      } else {
        //here will add a service to add stuff to the database
        //example landmarkService.add(this.landmark).then((res) => {if(res.status=201) {this.$router.push({name:"landmarks"})}}).catch((err) => {this.addingErrors = false if(err.response.status == 400){this.addingErrorsMsg = "Bad Request: Validation Errors"}})
        return this.addingErrors;
      }
    },
  },
};
</script>

<style>
.addLandmark-page {
  background-color: rgb(0, 0, 185);
  height: 100vh;
  width: 100%;
  display: flex;
  align-items: flex-end;
}
.adding-container {
  background-color: aquamarine;
  width: 100%;
  height: 100%;
  position: relative;
  top: 8rem;
}
.adding-form {
  background-color: rgb(14, 99, 70);
  display: flex;
  flex-direction: column;
  width: 50%;
  height: 100%;
  margin: 0 auto;
}
.adding-box-top,
.adding-box{
  display: flex;
  align-items:flex-start;
  width: 90%;
  margin: 2rem auto 0;
  /* background-color: rgb(38, 136, 136); */
}

.adding-box-top{
  justify-content: space-between;
}

.adding-header-top > h1{
  font-size: 1.7rem;
}

.adding-box{
  /* border-top: 2px solid rgb(129, 129, 129); */
  height: 7rem;
  padding-top: 1rem;
}

.adding-header-top,
.adding-header{
  /* background-color: beige; */
  width: 35%;
}

.adding-form-control {
  width: 100%;
  border-radius: 5px;
  margin: 0px auto;
  height: 3rem;
}

.adding-input{
  margin: 0;
  padding:0;
  background-color: blue;
  display: flex;
  width: 45%;
  overflow: hidden;
}

.top-btn{
  display: flex;}
.addNew-btn {
  margin: 5px;
  display: inline-block;
  font-size: 1.2rem;
  height: 2.4rem;
  width: 5rem;
  border-radius: 5px;
}

</style>
