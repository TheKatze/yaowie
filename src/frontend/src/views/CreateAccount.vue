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
import { Vue, Component } from "vue-property-decorator";

@Component
export default class CreateAccount extends Vue {
  name = "";

  createAccount() {
    console.log("");
  }
}
</script>
