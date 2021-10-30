<template>
  <div>
    <balance-card title="Balance" :balance="500" />
    <v-row>
      <v-col>
        <v-subheader> Recent </v-subheader>
      </v-col>
    </v-row>
    <v-divider />
  </div>
</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import BalanceCard from "../components/BalanceCard.vue";

@Component({
  components: { BalanceCard },
})
export default class Overview extends Vue {}
</script>
