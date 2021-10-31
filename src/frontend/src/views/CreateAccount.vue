<template>
  <v-card>
    <v-card-title> Create Account </v-card-title>
    <v-card-text>
      Just enter your name god damnit
      <v-text-field placeholder="Your name" v-model="name" />
    </v-card-text>
    <v-card-actions>
      <v-btn @click="createAccount"> Create </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import Api from "@/logic/Api";
import CryptoProvider from "@/logic/CryptoProvider";
import UserStore from "@/logic/UserStore";
import { Vue, Component } from "vue-property-decorator";

@Component
export default class CreateAccount extends Vue {
  name = "";

  async createAccount(): Promise<void> {
    if (!this.name) {
      return;
    }

    const user = await CryptoProvider.generateUser(this.name);

    if (!user) throw Error("wtf");

    await Api.createUser(user);
    await UserStore.add(user);
    await this.$router.push({ name: "Overview" });
  }
}
</script>
