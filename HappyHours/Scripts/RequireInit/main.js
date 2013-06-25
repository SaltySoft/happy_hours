requirejs.config({
    baseUrl: '/',
    paths: sb_paths,
    shim: sb_shims
});

var apps = ["underscore", "backbone"];

if (typeof app !== 'undefined') {
    apps.push(app);
}

$(document).ready(function () {
    requirejs(apps,
        function (_, Backbone, App) {
            if (App) {
                App.initialize();
            }
        });
});