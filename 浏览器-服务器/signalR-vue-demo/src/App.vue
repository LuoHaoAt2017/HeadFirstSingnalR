<template>
  <div class="app"></div>
</template>

<script setup>
import { HubConnectionBuilder } from "@microsoft/signalr";

const connection = new HubConnectionBuilder().withUrl("http://localhost:5021/offers").build();

connection.on("SendOffersToUser", data => {
  console.table(data);
});

connection.start().then(() => {
  console.log("链接已经建立");
});

</script>

<style scoped></style>
