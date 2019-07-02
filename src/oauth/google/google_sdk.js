const google_sdk = {};

google_sdk.install = function install(Vue, options) {
    (function (d, s, id) {
        let js,
            gjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) {
            return;
        }
        js = d.createElement(s);
        js.id = id;
        js.src = "https://apis.google.com/js/api.js";
        gjs.parentNode.insertBefore(js, gjs);
        console.log("Loading Google SDK...");
    })(document, "script", "google-jssdk");
    window.gapi_onload = function () {
        gapi.load('auth2', function (){        
            Vue.gapi = gapi.auth2.init(options);
            window.dispatchEvent(new Event('GOOG_SDK_READY'));
        }); 
    };
};

import Vue from "vue";
Vue.use(google_sdk, {
    // clientId and scope are optional if auth is not required.
    'clientId': "598694976413-t3qat6cf9r4vh7gh24tvt7ebn66f5vu7.apps.googleusercontent.com",
    'scope': "profile"
});
