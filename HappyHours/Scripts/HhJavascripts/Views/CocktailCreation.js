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
            var base = this;
        },
        init: function (app) {
            var base = this;
            base.app = app;

            base.render();
        },
        render: function () {
            var base = this;
            var template = _.template(CocktailCreationTemplate, {});
            base.$el.html(template);
            base.registerEvents();
        },
        registerEvents: function () {
            var base = this;
            $(document).ready(function () {
                base.$el.find("#creation_form_name").focus();
            });

            base.$el.delegate(".field", "change", function () {
                var elt = $(this);
                elt.removeClass("error_submit");
            });

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
        formSubmission: function (callback) {
            var base = this;
            var iframe = base.$el.find(".form_iframe");
            iframe.load(function () {
                console.log("Server responded");
                var iframeHtml = iframe.contents().find("pre").html();

                if (iframeHtml !== undefined) {
                    var object = JSON.parse(iframeHtml);
                    console.log(object);
                    if (object.status && object.status == "error") {
                        if (object.message === "unsufficient_rights") {
                            alert("Vous devez vous inscrire ou vous connecter pour ajouter un cocktail");
                        }
                        if (object.message === "invalid_data") {
                            base.$el.find(".field").removeClass("error_submit");
                            for (var k in object.data) {
                                base.$el.find(".field_" + object.data[k]).addClass("error_submit");
                            }
                        }
                    } else {
                        var cocktail = new Cocktail(object);
                        base.app.router.navigate("#cocktail/" + cocktail.get("Id"), { trigger: true })
                    }

                }
            });

            if (callback)
                callback();
        }
    });

    return CocktailCreationView;
});