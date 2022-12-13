<template>
  <MglMap :accessToken="accessToken" :mapStyle="mapStyle" :center="this.$store.state.coordinates" :zoom=12 :key="this.$store.state.coordinates">

      <!-- <MglGeojsonLayer :source="geoJsonSource" layerId="myLayer" :layer="geoJsonlayer" /> -->
  </MglMap>

</template>

<script>
import Mapbox from "mapbox-gl";
import {MglMap} from "vue-mapbox";

export default {
    name: "mapbox-map",
    components: {
        MglMap,
    },

    // methods: {
    //     async onMapLoad(event) {
    //         const asyncActions = event.component.asyncActions
            
    //         const newParams = await asyncActions.flyTo({
    //             center: this.$store.state.coordinates,
    //             zoom: 9,
    //             speed: 1
    //         })
    //         console.log(newParams)
    //     }
    // },
    data() {
        return {
            accessToken: 'pk.eyJ1IjoiZHJld3N3ZWV0IiwiYSI6ImNsYmgwM2kzdDBlb2MzcHFtZm8zajg2ZzIifQ.pDG4UufOD--ptSzeCeiPWA',
            mapStyle: "mapbox://styles/mapbox/streets-v11",
            // geoJsonSource: {
            //     //...some GeoJSON object
            // },
            // geoJsonLayer: {
            //     id: 'optimized-route',
            //     type: 'line',
            //     source: 'geoJsonSource',
            //     layout: {

            //     }
            // }
        };
    },
    updated() {
        this.mapbox = Mapbox;
        console.log(this.$store.state.coordinates)

        
        
    },


};
</script>

<style>

</style>