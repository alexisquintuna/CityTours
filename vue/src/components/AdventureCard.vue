<template>
<div class="adventure-card">
    <div class="adv-bg">
        <div class="delete-btn-container">
            <button class="delete-btn">x</button>
        </div>
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
    height: 30rem;
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

.delete-btn-container{
    position: absolute;
    right: 1rem;
    top: 1rem;
    width: 2rem;
    height: 2rem;
}
.delete-btn{
    width:100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.288);
    color: rgb(253, 253, 253);
}

</style>