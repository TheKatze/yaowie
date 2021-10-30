<template>
  <v-app>
    <v-app-bar app elevate-on-scroll>
      <v-app-bar-nav-icon @click="showDrawer = !showDrawer" />
      <v-toolbar-title> Yaowie </v-toolbar-title>
    </v-app-bar>

    <v-navigation-drawer app v-model="showDrawer">
      <v-list nav>
        <navigation-item to="/" icon="mdi-home" title="Overview" />
      </v-list>
    </v-navigation-drawer>

    <v-main app>
      <v-container fluid>
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import NavigationItem from "@/components/NavigationItem.vue";

@Component({
  components: {
    NavigationItem,
  },
})
export default class App extends Vue {
  public showDrawer = false;
}
</script>
