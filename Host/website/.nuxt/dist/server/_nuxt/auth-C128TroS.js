import { d as defineNuxtRouteMiddleware, n as navigateTo } from "../server.mjs";
import "vue";
import "ofetch";
import "#internal/nuxt/paths";
import "D:/Project/PawnShop/Host/website/node_modules/hookable/dist/index.mjs";
import "D:/Project/PawnShop/Host/website/node_modules/unctx/dist/index.mjs";
import "D:/Project/PawnShop/Host/website/node_modules/h3/dist/index.mjs";
import "vue-router";
import "D:/Project/PawnShop/Host/website/node_modules/radix3/dist/index.mjs";
import "D:/Project/PawnShop/Host/website/node_modules/defu/dist/defu.mjs";
import "D:/Project/PawnShop/Host/website/node_modules/ufo/dist/index.mjs";
import "vue/server-renderer";
const auth = defineNuxtRouteMiddleware((to, from) => {
  const token = localStorage.getItem("access_token");
  if (!token) {
    return navigateTo("/login");
  }
});
export {
  auth as default
};
//# sourceMappingURL=auth-C128TroS.js.map
