import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Overview from "../views/Overview.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: "/",
    name: "Overview",
    component: Overview,
  },
  {
    path: "/user/:key",
    name: "UserDetail",
    component: () =>
      import(/* webpackChunkName: "userDetail" */ "../views/UserDetail.vue"),
  },
  {
    path: "/createaccount/",
    name: "CreateAccount",
    component: () =>
      import(
        /* webpackChunkName: "createAccount" */ "../views/CreateAccount.vue"
      ),
  },
  {
    path: "/createtransaction/:key",
    name: "CreateTransaction",
    component: () =>
      import(
        /* webpackChunkName: "createTransaction" */ "../views/CreateTransaction.vue"
      ),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
