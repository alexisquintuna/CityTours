<template>
  <div>
      <h1>{{landmark.name}}</h1>
      <p>{{landmark.description}}</p>
  </div>
</template>

<script>
export default {
    name: "card-details",
    props: ["landmark"]
}
</script>

<style>

</style>