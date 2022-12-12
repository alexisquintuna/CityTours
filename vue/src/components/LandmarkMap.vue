<template>
  <div class="map">
    <mapbox-map />
  </div>
</template>

<script>

import MapboxMap from '@/components/MapboxMap.vue';

export default {
    name: 'landmark-map',
    components: {
      MapboxMap
    }

}
</script>

<style>
.map{
  background-color:rgb(37, 37, 37);
  width: 50%;
  margin: 30px;
  border-radius: 20px;
  text-align: center;
}

</style>