<template>
  <v-card>
    <v-card-title> {{ title }} </v-card-title>
    <v-card-text>
      {{ balance }}
    </v-card-text>
  </v-card>
</template>

<script lang="ts">
import { Vue, Prop, Component } from "vue-property-decorator";

@Component
export default class BalanceCard extends Vue {
  @Prop({ required: true })
  title!: string;
  @Prop({ required: true })
  balance!: number;
}
</script>

<style></style>
