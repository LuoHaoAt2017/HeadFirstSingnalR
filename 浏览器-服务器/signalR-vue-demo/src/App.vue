<template>
  <div class="app">
    <el-table :data="state.tableData" style="width: 100%">
      <el-table-column prop="date" label="日期" />
      <el-table-column prop="temperatureC" label="摄氏度" />
      <el-table-column prop="summary" label="简报" />
    </el-table>
  </div>
</template>

<script setup>
import { reactive, onMounted } from "vue";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { GetWeatherForecast } from "./apis/index";

const connection = new HubConnectionBuilder().withUrl("http://localhost:5021/offers").build();
connection.connectionId = "app1";
connection.on("PushWeatherForecastToUser", data => {
  state.tableData = data;
});

connection.start().then(() => {
  console.log("链接已经建立");
});

const state = reactive({
  tableData: []
});

onMounted(() => {
  GetWeatherForecast().then(function(res) {
    state.tableData = res;
  });
});

</script>

<style scoped></style>
