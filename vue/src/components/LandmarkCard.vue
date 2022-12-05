<template>
<!-- <router-link> -->
<div class="card">
    <div>
    <img class="img-location" src="" alt="">
    </div>
    <div>
    <h1>{{ landmark.name}}</h1>
    <p> {{landmark.description}}</p>
    </div>
    <div>
        <img class="img-icon" src="" alt="">
    </div>
</div>
<!-- </router-link> -->
</template>

<script>
export default {
    name: 'landmark-card',
    props: {
        landmark: Object
        }
}
</script>

<style>
.img-location{
    height:90px;
    width: 90px;
    background-color: chocolate;
    border-radius: 50px;
    overflow: hidden;
}
.card{
    padding-left: 15px;
    display: flex;
    align-items: center;
    margin: 50px auto;
    border-radius: 20px;
    height: 150px;
    width: 90%;
    background-color: cadetblue;
}

.img-icon{
    width: 20px;
    height: 20px;
    background-color:crimson;
    border-radius: 100px;
    overflow: hidden;
    
}

</style>