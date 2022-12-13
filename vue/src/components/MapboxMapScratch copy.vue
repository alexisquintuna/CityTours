<template>
  <div class="map-container">
      <div id="map"></div>
  </div>
</template>

<script>
import mapboxgl from "mapbox-gl";

export default {
    created() {
        const map = new mapboxgl.Map({
            container: "map",
            style: 'mapbox://styles/mapbox/streets-v11',
            center: this.$store.state.coordinates,
            zoom: 12
        })

        map.on('load', () => {
            map.addSource('optimized-route', {
                type: 'geojson',
                data: this.$store.state.trips[0].geometry,
                
            })
        })
    }

}
</script>

<style>

</style>