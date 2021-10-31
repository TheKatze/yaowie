<template>
  <div>
    <balance-card :title="publicKey" :balance="500" />
    <v-divider />
    <v-row>
      <v-col cols="12">
        <v-text-field placeholder="moneeh" v-model="value" />
      </v-col>
    </v-row>
    <v-btn @click="createNewTransaction">New Transaction</v-btn>
  </div>
</template>

<script lang="ts">
import Api from "@/logic/Api";
import TransactionStore from "@/logic/TransactionStore";
import UserStore from "@/logic/UserStore";
import { Transaction } from "@/models/Transaction";
import { Vue, Component } from "vue-property-decorator";
import BalanceCard from "../components/BalanceCard.vue";

@Component({
  components: { BalanceCard },
})
export default class UserDetail extends Vue {
  value = "";
  userTransactions: Transaction[] = [];

  async mounted() {
    await this.refreshTransactions();
  }

  async refreshTransactions() {
    this.userTransactions = (await TransactionStore.list()).filter(
      (t) => t.receiver === this.publicKey || t.sender === this.publicKey
    );
  }

  get publicKey(): string {
    return this.$route.params["key"];
  }

  async createNewTransaction() {
    const me = await UserStore.me();
    await Api.createTransaction({
      value: +this.value,
      receiver: me!.publicKey,
      sender: this.publicKey,
    });
  }
}
</script>
