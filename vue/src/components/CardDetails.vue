<template>
  <div class="details-page">
    <div class="details-main">
      <router-link class="back" v-bind:to="{ name: 'landmarks' }"
        >BACK</router-link
      >
      <div class="header-section">
        <h1 class="landmark-header">{{ landmark.name }}</h1>
        <p>In {{ landmark.address }}</p>
      </div>
      <section class="info-section">
        <div class="right-side">
          <img
            class="details-img"
            src="https://www.ncaa.com/_flysystem/public-s3/styles/large_16x9/public-s3/images/2022-10/ohiostadium.jpg?h=06ac0d8c&itok=WYyRIchp"
            alt=""
          />
          <p class="details-description">{{ landmark.description }}</p>
        </div>
        <aside>
          <h3>Details</h3>
          <p class="aside-p"><span class="aside-span" >Address</span> {{ landmark.address }}</p>
          <p class="aside-p"><span class="aside-span" >Website</span> <a :href="landmark.link" target="_blank" class="details-link">{{ landmark.link }}</a></p>
          <br>
          <hr>
        </aside>
      </section>
    </div>
  </div>
</template>

<script>
import landmarkService from "@/services/LandmarkService.js";

export default {
  name: "card-details",
  data() {
    return {
      landmark: {},
    };
  },
  props: ["id"],
  created() {
    landmarkService
      .getLandmarkById(this.id)
      .then((response) => {
        if (response.status === 200) {
          console.log(response.data);
          this.landmark = response.data;
        }
      })
      .catch((error) => {
        if (error.response.status == 404) {
          this.$router.push({ name: "NotFound" });
        }
      });
  },
};
</script>

<style>
.back {
  position: relative;
  top: 20px;
  text-decoration: none;
  font-size: 20px;
  font-weight: bold;
  color: black;
}

.details-page {
  background-color: #fff;
  color: black;
}

.details-main {
  margin: auto;
  width: 78%;
  height: auto;
}

.header-section{
  margin: 35px 0;
}

.header-section h1,
.header-section p{
  margin:15px 0;
  padding: 0;
}
.right-side{
  padding-right: 2rem;
}
.landmark-header {
  font-size: 48px;
}
.info-section {
  display: flex;
}

.details-img {
  width: 100%;
  height: 75%;
  border-radius: 20px;
}
.details-description{
  font-size: 24px;
  width: 75%;
  margin: 50px auto;
  padding-top: 20px;
}
aside h3 {
  font-size: 24px;
}
.aside-p{
  font-size: 14px;
}
.aside-span{
  color: rgb(80, 80, 80);
  margin-right: 25px;
}
.details-link{
  color: blue;
}
</style>
