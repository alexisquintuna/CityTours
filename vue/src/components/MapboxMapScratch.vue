<template>
  <div class="map-container">
      <div id="map"></div>
  </div>
</template>

<script>
import mapboxgl from "mapbox-gl";

export default {
    mounted() {
        this.initMap();
    },
    data() {
        return {
            map: null,
            markers: [],
        };
    },
    computed: {
        ...mapState(["currentFeatures"]),
    },
    watch: {
        currentFeatures: {
            handler() {
                if (this.currentFeatures) {
                    this.resetMarkers();
                    this.updateMarkers();
                    console.log(this.currentFeatures)
                }
            },
            deep: true,
        },
    },
    methods: {
        resetMarkers() {
            this.markers.forEach((marker) => {
                marker.remove();
            });
            this.markers = [];
        },
        updateMarkers() {
            this.markers = this.currentFeatures.features.map((feature) => {
                const el = document.createElement("div");
                el.className = "marker";

                const popup = this.featurePopup(feature);
                return new mapboxgl.Marker(el).setLngLat(feature.geometry.coordinates).setPopup(popup).addTo(this.map);
            });
        },
        initMap() {
            mapboxgl.accessToken = "";
            this.map = new mapboxgl.Map({
                container: "map",
                style: "mapbox://styles/mapbox/streets-v11",
                center: [],
                zoom: 12,
            });
            this.map.on("load", () => {
                this.map.addControl(new mapboxgl.NavigationControl(), "top-right");
                this.map.addControl(
                    new mapboxgl.GeolocateControl({
                        positionOptions: {
                            enableHighAccuracy: true,
                        },
                        trackUserLocation: true,
                    }),
                    "top-right"
                );
                this.map.addControl(
                    new mapboxgl.ScaleControl({
                        maxWidth: 100,
                        unit: "metric",
                    })
                );

                if (this.markers.length > 0) {
                    this.resetMarkers();
                }

                if (this.currentFeatures) {
                    this.updateMarkers();
                }
            });
        }
    }

}
</script>

<style>

</style>