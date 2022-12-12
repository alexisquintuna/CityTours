<template>
  <MglMap :accessToken="accessToken" :mapStyle="mapStyle" :center="center" />

</template>

<script>
import Mapbox from "mapbox-gl";
import {MglMap} from "vue-mapbox";

export default {
    name: "mapbox-map",
    components: {
        MglMap
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
            center: this.$store.state.coordinates
        };
    },
    created() {
        this.mapbox = Mapbox;
        //this.options.center=this.$store.state.coordinates
        
    }

};
</script>

<style>

</style>