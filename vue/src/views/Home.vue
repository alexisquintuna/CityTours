<template>
  <div class="home">
    <form class="home-form" action="">
      <input class="home-input" type="text" placeholder="CITY">
      <!-- <router-link>SEND</router-link> -->
    </form>
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>

<style>
.home{
  display: flex;
  align-items: center;
  justify-content: center;
}
.home-form{
  height: 13%;
  width: 22.1%;
  display: inline-block;
}
.home-input{
  background-color:rgba(240, 248, 255, 0);
  border-bottom: 5px solid white;
  border-radius: 0px;
  margin: 0;
  font-size: 65px;
  height: 7rem;
  width: 25rem;
  color: white;
}

.home-input::placeholder{
  color: white;
}
.home-input:focus::placeholder{
  color:white;
}
</style>