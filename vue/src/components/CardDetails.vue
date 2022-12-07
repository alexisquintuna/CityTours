<template>
  <div class="details-page">
    <router-link id="back" v-bind:to="{ name: 'landmarks' }">BACK</router-link>
    <div class="details-container">
      <div class="details-main">
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
            <p class="aside-p">
              <span class="aside-span">Address</span> {{ landmark.address }}
            </p>
            <p class="aside-p">
              <span class="aside-span">Website</span>
              <a :href="landmark.link" target="_blank" class="details-link">{{
                landmark.link
              }}</a>
            </p>
            <br />
            <hr />
          </aside>
        </section>
      </div>
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
#back {
  position: relative;
  bottom: -9.2rem;
  left: 13rem;
  text-decoration: none;
  font-size: 20px;
  font-weight: bold;
  z-index: 1;
}

.details-page {
  color: black;
  background-color: rgb(0, 0, 185);
  height: 120%;
}
.details-container {
  background-color: rgb(255, 255, 255);
  position: relative;
  top: 4.5rem;
  height: 100%;

}
.details-main {
  margin: 0 auto;
  width: 78%;
  height: auto;
}
.header-section {
  margin: 35px 0;
}

.header-section,
.info-section {
  position: relative;
  top: 3.5rem;
}

.header-section h1,
.header-section p {
  margin: 15px 0;
  padding: 0;
}
.right-side {
  padding-right: 2rem;
  grid-area: "info";
}
.landmark-header {
  font-size: 48px;
}
.info-section {
  display: grid;
  grid-template-columns: 3fr 1fr;
  grid-template-areas: "info" "aside";
}

.details-img {
  width: 100%;
  height: 75%;
  border-radius: 20px;
}
.details-description {
  font-size: 24px;
  width: 75%;
  margin: 50px auto;
  padding-top: 20px;
}
aside {
  grid-area: "aside";
  margin-right: 2rem;
}
aside h3 {
  margin: 1rem 0;
  font-size: 1.8rem;
}
.aside-p {
  margin: 0.5rem 0;
  font-size: 1rem;
  width: 20rem;
  overflow: hidden;
  display: flex;
}
.aside-span {
  color: rgb(80, 80, 80);
  margin-right: 1rem;
}

.details-link {
  color: blue;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  width: 20rem;
}
</style>
