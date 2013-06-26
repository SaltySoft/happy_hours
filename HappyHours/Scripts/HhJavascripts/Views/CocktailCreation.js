define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_creation.html',
    'Models/Cocktail'
], function ($, _, Backbone, CocktailCreationTemplate, Cocktail) {
    var CocktailCreationView = Backbone.View.extend({
        tagName: "div",
        className: "cocktail_creation",
        initialize: function () {

        },
        init: function (app) {
            var base = this;

            base.app = app;

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;
            var template = _.template(CocktailCreationTemplate, {});
            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;
            var form = base.$el.find(".form_cocktail");
            form.submit(function () {
                base.$el.find(".form_container").hide();
                base.$el.find(".loader").show();

                var iframe = base.$el.find(".form_iframe");
                console.log("iframe : ", iframe);
                iframe.load(function () {
                    console.log("LOADED");
                    var object = JSON.parse(iframe.contents().find("pre").html());
                    var cocktail = new Cocktail(object);
                    console.log(cocktail);
                    base.app.router.navigate("#cocktail/" + cocktail.get("Id"), { trigger: true })
                });
            });
        }
    });

    return CocktailCreationView;
});