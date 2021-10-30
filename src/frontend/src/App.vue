<template>
  <v-app>
    <v-app-bar app elevate-on-scroll>
      <v-app-bar-nav-icon v-if="isLoggedIn" @click="showDrawer = !showDrawer" />
      <v-toolbar-title> Yaowie </v-toolbar-title>
      <v-spacer />
      <v-chip :color="isConnected ? '' : 'error'">
        {{ isConnected ? "Connected" : "Offline" }}
      </v-chip>
    </v-app-bar>

    <v-navigation-drawer app v-model="showDrawer">
      <v-list nav>
        <navigation-item to="/" icon="mdi-home" title="Overview" />
        <navigation-item to="/settings" icon="mdi-cog" title="Settings" />
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
import UserStore from "./logic/UserStore";

@Component({
  components: {
    NavigationItem,
  },
})
export default class App extends Vue {
  isLoggedIn = false;

  async mounted() {
    this.isLoggedIn = !!(await UserStore.me());
  }

  public showDrawer = false;

  isConnected = true;
}
</script>
