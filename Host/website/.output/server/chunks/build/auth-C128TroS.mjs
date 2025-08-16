import { d as defineNuxtRouteMiddleware, n as navigateTo } from './server.mjs';
import 'vue';
import '../_/nitro.mjs';
import 'node:http';
import 'node:https';
import 'node:events';
import 'node:buffer';
import 'node:fs';
import 'node:path';
import 'node:crypto';
import 'node:url';
import '../routes/renderer.mjs';
import 'vue-bundle-renderer/runtime';
import 'vue/server-renderer';
import 'unhead/server';
import 'devalue';
import 'unhead/utils';
import 'unhead/plugins';
import 'vue-router';

const auth = defineNuxtRouteMiddleware((to, from) => {
  const token = localStorage.getItem("access_token");
  if (!token) {
    return navigateTo("/login");
  }
});

export { auth as default };
//# sourceMappingURL=auth-C128TroS.mjs.map
