<template>
  <v-list-item>
    <v-list-item-title> {{ contact.name }} </v-list-item-title>
  </v-list-item>
</template>

<script lang="ts">
import { Vue, Prop, Component } from "vue-property-decorator";
import { User } from "@/models/User";

@Component
export default class Contact extends Vue {
  @Prop({ required: true })
  contact!: User;
}
</script>

<style></style>
