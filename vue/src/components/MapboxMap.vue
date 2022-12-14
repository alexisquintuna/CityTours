<template>
  <MglMap :accessToken="accessToken" :mapStyle="mapStyle" :center="this.$store.state.coordinates" :zoom=13 :key="this.$store.state.coordinates">

      <!-- <MglGeojsonLayer :source="geoJsonSource" layerId="myLayer" :layer="geoJsonlayer" /> -->
      <MglMarker v-for="landmark in this.$store.state.landmarks" v-bind:key="landmark.xid" :coordinates="landmark.point" color="blue" v-on:mouseover="togglePopup">
          <MglPopup :anchor="top-right" ref="popup">
              
                  <div>{{landmark.name}}</div>
              
          </MglPopup>
      </MglMarker>
  </MglMap>

</template>

<script>
import Mapbox from "mapbox-gl";
//import mapboxgl from "mapbox-gl";
import {MglMap, MglMarker, MglPopup} from "vue-mapbox"; //MglPopup

export default {
    name: "mapbox-map",
    components: {
        MglMap,
        MglMarker,
        MglPopup
    },
//     watch: {
//     show() {
//       if (!this.show) {
//         if (this.$refs.popup) { this.$refs.popup.remove(); }
//       } else if (this.$refs.popup) { this.$refs.popup.addTo(this.map); }
//     },
//   },

   methods: {
       togglePopup() {
           if (this.MglPopup.isOpen() ) {
               this.MglPopup.remove();
           }
           else {
               this.MglPopup.addTo(this.map);
           }
       }
    // mapLoaded(e) {
    //   e.map.on('mouseenter', MglMarker, (event) => {
    //     e.map.getCanvas().style.cursor = 'pointer';
    //     const coordinates = event.features[0].geometry.coordinates.slice();
    //     const content = event.features[0].properties.name;

    //     // Ensure that if the map is zoomed out such that multiple
    //     // copies of the feature are visible, the popup appears
    //     // over the copy being pointed to.
    //     while (Math.abs(event.lngLat.lng - coordinates[0]) > 180) {
    //       coordinates[0] += event.lngLat.lng > coordinates[0] ? 360 : -360;
    //     }
    //     this.popupCoordinates = coordinates;
    //     this.popupContent = content;
    //     this.$refs.popup.addTo(e.map); // not the best way to do this
    //   });
    //   e.map.on('mouseleave', MglMarker, () => {
    //     e.map.getCanvas().style.cursor = '';
    //     this.$refs.popup.remove(); // not the best way to do this
    //   });
    // },
  
    },
    data() {
        return {
            accessToken: 'pk.eyJ1IjoiZHJld3N3ZWV0IiwiYSI6ImNsYmgwM2kzdDBlb2MzcHFtZm8zajg2ZzIifQ.pDG4UufOD--ptSzeCeiPWA',
            mapStyle: "mapbox://styles/mapbox/streets-v11",
            coordinates: []
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
    mounted() {
        this.mapbox = Mapbox;
        console.log(this.$store.state.coordinates)
        // eslint-disable-next-line no-undef
        // let popup = new mapboxgl.Popup({
        //     closeButton: false,
        //     closeOnClick: false
        // });

        // this.mapbox.on("mouseenter", MglMarker, function (e) {
        //     this.mapbox.getCanvas().style.cursor = "pointer";

        //     let coordinates = MglMarker.coordinates;
        //     while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
        //         coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        //     }

        //     popup
        //     .setLngLat(coordinates)
        //     .addTo(this.mapbox);
        // })

        // this.mapbox.on("mouseleave", MglMarker, function() {
        //     this.mapbox.getCanvas().style.cursor = "";
        //     popup.remove();
        // });

        
        
    },


};
</script>

<style>

</style>