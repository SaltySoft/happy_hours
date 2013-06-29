requirejs.config({
    baseUrl:'/Scripts/HhJavascripts/',
    paths:sb_paths,
    shim:sb_shims
});

var apps = ["jquery", "underscore", "backbone", "/Scripts/HhJavascripts/Models/User.js","Models/Cocktail", "default"];

if (typeof app !== 'undefined') {
    apps.push(app);
}
if (typeof String.prototype.startsWith != 'function') {
    // see below for better implementation!
    String.prototype.startsWith = function (str){
        return this.indexOf(str) == 0;
    };
}

$(document).ready(function () {
    requirejs(apps,
        function ($, _, Backbone, User, Cocktail, Defaults, App) {

            var defaults = Defaults;
            defaults.events = $.extend({}, Backbone.Events);
            $.ajax({
                url: "/User/CurrentUser",
                success: function (data, status) {
                    if (data.Id) {
                        console.log(User);
                        defaults.current_user = new User(data);
                        window.user = defaults.current_user;
                        window.Cocktail = Cocktail;
                    } else {
                        defaults.current_user = undefined;
                    }
                    if (App) {
                        App.initialize(defaults);
                    }
                }
            });

        });
});