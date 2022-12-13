<template>
  <MglMap :accessToken="accessToken" :mapStyle="mapStyle" :center="this.$store.state.coordinates" :zoom=12 >

      <MglGeojsonLayer :sourceId="geoJsonSource.id" :source="geoJsonSource" layerId="optimized-route" :layer="geoJsonLayer" />
  </MglMap>

</template>

<script>
import Mapbox from "mapbox-gl";
import {MglMap, MglGeojsonLayer} from "vue-mapbox"; //MglGeojsonLayer

export default {
    name: "mapbox-map",
    components: {
        MglMap,
        MglGeojsonLayer,
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
            geoJsonSource: {
                id: 'geojson-source',
                type: 'geojson',
                data: {
                    type: "FeatureCollection",
                    features: [{
                        type: "Feature",
                        properties: {},
                        geometry: {
                            type: "LineString",
                            coordinates: [
                                -76.53063297271729,
                                39.18174077994108
                            ]
                        }
                    }]
                }
                
            },
            geoJsonLayer: {
                id: 'optimized-route',
                type: 'line',
                source: 'geojson-source',
                paint: {
                    'line-color': '#3887be',
                    'line-width': ['interpolate', ['linear'], ['zoom'], 12, 3, 22, 12]
                },
                
            },
           
        };
    },
    created() {
        this.mapbox = Mapbox;
        console.log(this.$store.state.coordinates);

        console.log(this.$store.state.optimizedRoute.trips[0].geometry);

        this.geoJsonSource.data.features.geometry = this.$store.state.optimizedRoute.trips[0].geometry;

        //this.geoJsonSource = this.getSourceFeatures(this.$store.state.optimizedRoute.trips[0].geometry);
        console.log(this.geoJsonSource);

        // this.map.on('load', () => {

        // }
        
    }

};
</script>

<style>

</style>