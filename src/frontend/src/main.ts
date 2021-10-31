import Vue from "vue";
import App from "./App.vue";
import "./registerServiceWorker";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import Api from "./logic/Api";
import { Axios } from "axios";
import UserStore from "./logic/UserStore";

Vue.config.productionTip = false;

vuetify.preset.theme.dark = true;

Api.initialize(
  new Axios({
    baseURL: "https://localhost:5001/",
    headers: { "Content-Type": "application/json" },
  })
);

async function start() {
  new Vue({
    router,
    store,
    vuetify,
    render: (h) => h(App),
  }).$mount("#app");

  if (!(await UserStore.me())) {
    await router.push({ name: "CreateAccount" });
  }
}

start();
