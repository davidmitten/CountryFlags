import * as Vue from 'vue';
global.Vue = Vue;
global.VueCompilerDOM = Vue; // Explicitly provide VueCompilerDOM if needed
global.VueServerRenderer = undefined;