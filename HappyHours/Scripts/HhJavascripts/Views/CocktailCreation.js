define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_creation.html',
    'Models/Cocktail'
], function ($, _, Backbone, CocktailCreationTemplate, Cocktail) {
    var CocktailCreationView = Backbone.View.extend({
        tagName:"div",
        className:"cocktail_creation",
        initialize:function () {
            var base = this;
        },
        init:function (app) {
            var base = this;
            base.app = app;

            base.render();
            base.registerEvents();
        },
        render:function () {
            var base = this;
            var template = _.template(CocktailCreationTemplate, {});
            base.$el.html(template);
        },
        registerEvents:function () {
            var base = this;
            var form = base.$el.find(".form_cocktail");
            form.submit(function () {
                base.$el.find(".form_container").hide();
                base.$el.find(".loader").show();

                base.formSubmission(function () {
                    base.$el.find(".loader").fadeOut(100);
                    base.$el.find(".form_container").show();
                });
            });
        },
        formSubmission:function (callback) {
            var base = this;

            var iframe = base.$el.find(".form_iframe");
            iframe.load(function () {
                console.log("iframe.contents()", iframe.contents());
                console.log("iframe.contents()find(pre)", iframe.contents().find("pre"));
                console.log("iframe.contents()find(pre).html()", iframe.contents().find("pre").html());

                var iframeHtml = iframe.contents().find("pre").html();
                if (iframeHtml !== undefined) {
                    var object = JSON.parse(iframe.contents().find("pre").html());
                    console.log("object", object);
                    var cocktail = new Cocktail(object);
                    console.log("cocktail", cocktail);
                    base.app.router.navigate("#cocktail/" + cocktail.get("Id"), { trigger:true })
                }
            });

            if (callback)
                callback();
        }
    });

    return CocktailCreationView;
});