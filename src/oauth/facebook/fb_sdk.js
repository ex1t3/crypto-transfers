const vue_fb = {}
vue_fb.install = function install(Vue, options) {
    (function(d, s, id){
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) {return};
        js = d.createElement(s);
        js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
        console.log('Loading Facebook SDK...');
    }(document, 'script', 'facebook-jssdk'));

    window.fbAsyncInit = function onSDKInit() {
        FB.init(options);
        FB.AppEvents.logPageView();
        Vue.FB = FB;
        window.dispatchEvent(new Event('FB_SDK_READY'));
    }
    Vue.FB = undefined;
}

import Vue from 'vue';

Vue.use(vue_fb, {
    appId: '204022623821507',
    cookie: true,
    xfbml: true,
    version: 'v2.9',
    status: true
});