<template>

  <MglMap
    :accessToken="accessToken"
    :mapStyle="mapStyle"
    :center="this.optimizedCoordinates[0]"
    :zoom="13"
  >
    <MglGeojsonLayer
      :sourceId="geoJsonSource.data.id"
      :source="geoJsonSource"
      layerId="myLayerId"
      :layer="geoJsonLayer"
    >
    <MglMarker>
        <MglPopup>
        </MglPopup>
        </MglMarker>
    </MglGeojsonLayer>
  </MglMap>
  
</template>

<script>
import Mapbox from "mapbox-gl";
import { MglMap, MglGeojsonLayer, MglMarker, MglPopup } from "vue-mapbox"; //MglGeojsonLayer

export default {
  name: "mapbox-map",
  components: {
    MglMap,
    MglGeojsonLayer,
    MglMarker,
    MglPopup
  },

//   methods: {
      
//   //     async onMapLoad(event) {
//   //         const asyncActions = event.component.asyncActions

//   //         const newParams = await asyncActions.flyTo({
//   //             center: this.$store.state.coordinates,
//   //             zoom: 9,
//   //             speed: 1
//   //         })
//   //         console.log(newParams)
//   //     }
//   },
  data() {
    return {
      accessToken:
        "pk.eyJ1IjoiZHJld3N3ZWV0IiwiYSI6ImNsYmgwM2kzdDBlb2MzcHFtZm8zajg2ZzIifQ.pDG4UufOD--ptSzeCeiPWA",
      mapStyle: "mapbox://styles/mapbox/streets-v11",
      geoJsonSource: {
        type: "geojson",
        data: {
          id: "test",
          type: "FeatureCollection",
          features: [
            {
              type: "Feature",

              geometry: {
                type: "LineString",
                coordinates: []
              },
              
            },
          ],
        },
      },
      geoJsonLayer: {
        type: "line",
        layout: {
            'line-join': 'round',
            'line-cap': 'round'
        },
        paint: {
          //"circle-color": "red",
          'line-color': 'red',
          'line-width': 5,
          'line-opacity': 0.75
        },
      },
    };
  },
  computed: {
      optimizedCoordinates() {
          let coordinatesArray = [];
          for (let i = 0; i < this.$store.state.optimizedRoute.trips[0].geometry.coordinates.length; i++) {
              coordinatesArray.push(this.$store.state.optimizedRoute.trips[0].geometry.coordinates[i]);
          }
          return coordinatesArray;
      }
  },
  mounted() {
    this.mapbox = Mapbox;
    console.log(this.$store.state.optimizedRoute.trips[0].geometry);
    console.log(this.optimizedCoordinates);
    this.geoJsonSource.data.features[0].geometry.coordinates = this.optimizedCoordinates;


    

    //this.geoJsonSource.data.features.geometry = this.$store.state.optimizedRoute.trips[0].geometry;

    // console.log(this.$store.state.coordinates);

    // console.log(this.$store.state.optimizedRoute.trips[0].geometry);

    // this.geoJsonSource.data.features.geometry = this.$store.state.optimizedRoute.trips[0].geometry;

    // //this.geoJsonSource = this.getSourceFeatures(this.$store.state.optimizedRoute.trips[0].geometry);
    // console.log(this.geoJsonSource);

    // // this.map.on('load', () => {

    // }
  },
//   updated() {
        
//   }
}

</script>

<style>
</style>