<template>
  <div>
    <balance-card title="Balance" :balance="500" />
    <v-divider />
    <v-row>
      <v-col cols="8">
        <v-text-field placeholder="Friend Key" v-model="friendKey" />
      </v-col>
      <v-col cols="4">
        <v-btn @click="addFriend">Add</v-btn>
      </v-col>
    </v-row>
    <v-list>
      <v-list-item
        v-for="user in users"
        :key="user.publicKey"
        :to="'./user/' + user.publicKey"
      >
        <v-list-item-title> {{ user.name }} </v-list-item-title>
      </v-list-item>
    </v-list>
  </div>
</template>

<script lang="ts">
import Api from "@/logic/Api";
import TransactionStore from "@/logic/TransactionStore";
import UserStore from "@/logic/UserStore";
import { Transaction } from "@/models/Transaction";
import { User } from "@/models/User";
import { Vue, Component } from "vue-property-decorator";
import BalanceCard from "../components/BalanceCard.vue";

@Component({
  components: { BalanceCard },
})
export default class Overview extends Vue {
  friendKey = "";

  users: User[] = [];
  transactions: Transaction[] = [];

  async mounted() {
    await this.refreshUsers();
  }

  async refreshTransactions() {
    this.transactions = await TransactionStore.list();
  }

  async addFriend() {
    const user = await Api.getUser(this.friendKey);

    if (!user) return;

    UserStore.add(user);
    await this.refreshUsers();
  }

  async refreshUsers(): Promise<void> {
    this.users = [];
    this.users = await UserStore.list();
  }
}
</script>
