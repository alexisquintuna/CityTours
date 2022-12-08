<template>
<div class="adventure-card">
    <div class="adv-bg">
        <h1>Barcelona Trip</h1>
    </div>
</div>
</template>

<script>
export default {
    name:"adventure-card"
}
</script>

<style>
.adventure-card{
    color: white;
    position: relative;
    background-color: rgb(119, 95, 63);
    height: 35rem;
    width: 22%;
    border-radius: 20px;
    background-image: url("https://globalgrasshopper.com/wp-content/uploads/2020/09/The-best-places-to-vist-in-Ecuador.jpg");
}
.adv-bg{
    height: 100%;
    width: 100%;
    border-radius: 20px;
    background-image: linear-gradient(to bottom, rgba(247, 247, 247, 0), rgb(0, 0, 0));
}
.adv-bg:hover{
    background-image: linear-gradient(to bottom, rgba(0, 0, 0, 0), rgba(0, 0, 0, 0));
    transition: 300ms;
    cursor: pointer;
}

.adv-card-img{
    height: 100%;
    width:100%;
    background-size: cover;
            background-position: 50% 10%;

}

.adv-bg> h1 {
    font-size: 38px;
    position: absolute;
    bottom: 2rem;
    left: 1rem;
}

</style>