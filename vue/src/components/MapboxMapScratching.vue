<template>
  <div class="map-container">
      <div id="map">

      </div>
  </div>
</template>

<script>
import mapboxgl from "mapbox-gl";
import turf from "turf";

export default {
    data() {
        return {
            map: null,
            nothing: turf.featureCollection([])
        }
    },
    mounted() {
        console.log(this.$store.state.coordinates)
        mapboxgl.accessToken = 'pk.eyJ1IjoiZHJld3N3ZWV0IiwiYSI6ImNsYmgwM2kzdDBlb2MzcHFtZm8zajg2ZzIifQ.pDG4UufOD--ptSzeCeiPWA';
        this.map = new mapboxgl.Map({
            container: "map",
            style: 'mapbox://styles/mapbox/streets-v11',
            center: [-83, 40], //this.$store.state.coordinates],
            zoom: 12
        })

        // this.map.on('load', () => {

        //     this.map.addSource('route', {
        //         type: 'geojson',
        //         data: this.nothing

        //     })

        //     this.map.addLayer({
        //     id: 'optimized-route',
        //     type: 'line',
        //     source: 'route',
            
        //     })
        //     const routeGeoJSON = turf.featureCollection([
        //         turf.feature(this.$store.state.optimizedRoute.trips[0].geometry)
        //     ]);

        //     this.map.getSource('route').setData(routeGeoJSON);
        // })

        
    }

}
</script>

<style>

</style>