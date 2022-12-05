<template>
    <div>
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

</style>