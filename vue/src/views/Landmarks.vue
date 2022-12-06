<template>
    <div class="landmark-page">
        <landmark-list></landmark-list>
        <landmark-map></landmark-map>
    </div>
  
</template>

<script>
import LandmarkList from '@/components/LandmarkList.vue';
import LandmarkMap from '@/components/LandmarkMap.vue';

export default {
    name: "landmarks",
    components: {LandmarkList, LandmarkMap},
}
</script>

<style>
.landmark-page{
    display: flex;
    justify-content: space-around;
    background-color: #f5f5f5;
    height: 85%;
    width: 75%;
    margin: auto;
    border-radius: 20px;
}

</style>