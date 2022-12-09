<template>
<div class="adding-trip-page">
    <h1>adding new trip form</h1>
    <div class="adding-container">
      <form action="" class="adding-form" submit.prevent="adding">
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
            <p>Enter the a url link to landmark</p>
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
    name: 'adding-new-trip'
}
</script>

<style>
.adding-trip-page{
    background-color: antiquewhite;
    height: 100vh;
}

</style>