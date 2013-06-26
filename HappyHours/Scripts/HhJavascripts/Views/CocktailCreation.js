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

                var cocktail = new Cocktail();
                var array = form.serializeArray();
                for (var k in array) {
                    cocktail.set(array[k].name, array[k].value);
                }
                base.$el.find(".form_container").hide();
                base.$el.find(".loader").show();
                cocktail.save({}, {
                    success: function () {
                        base.app.router.navigate("#cocktail/" + cocktail.get("Id"), {trigger: true});
                        console.log(cocktail);
                    }
                });
            });
        }
    });

    return CocktailCreationView;
});