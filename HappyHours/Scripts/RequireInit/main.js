requirejs.config({
    baseUrl: '/Scripts/HhJavascripts/',
    paths: sb_paths,
    shim: sb_shims
});

var apps = ["underscore", "backbone", "default"];

if (typeof app !== 'undefined') {
    apps.push(app);
}

$(document).ready(function () {
    requirejs(apps,
        function (_, Backbone,Defaults, App) {

            var defaults = Defaults;

            if (App) {
                App.initialize(defaults);
            }
        });
});