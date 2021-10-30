<template>
  <v-list-item :to="to">
    <v-list-item-icon>
      <v-icon>{{ icon }}</v-icon>
    </v-list-item-icon>

    <v-list-item-content>
      <v-list-item-title>{{ title }}</v-list-item-title>
    </v-list-item-content>
  </v-list-item>
</template>

<script lang="ts">
import { Vue, Prop, Component } from "vue-property-decorator";

@Component
export default class NavigationItem extends Vue {
  @Prop({ required: true })
  to!: string;
  @Prop({ required: true })
  icon!: string;
  @Prop({ required: true })
  title!: string;
}
</script>

<style></style>
