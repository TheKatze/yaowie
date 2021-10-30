<template>
  <div>
    <balance-card :title="publicKey" :balance="500" />
  </div>
</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import BalanceCard from "../components/BalanceCard.vue";

@Component({
  components: { BalanceCard },
})
export default class UserDetail extends Vue {
  get publicKey(): string {
    return this.$route.params["key"];
  }
}
</script>
