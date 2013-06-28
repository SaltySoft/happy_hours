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
            if (!base.app.current_user) {
                base.app.show_message("Vous devez être connecté");
                base.app.router.navigate("", {trigger:true});
            }
            base.render();
        },
        render:function () {
            var base = this;
            var template = _.template(CocktailCreationTemplate, {});
            base.$el.html(template);
            base.registerEvents();
        },
        registerEvents:function () {
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

            base.app.events.on("user_disconnection", function () {
                base.app.show_message("Vous devez être connecté pour ajouter un cocktail");
                base.app.router.navigate("", {trigger:true});
            });
        },
        formSubmission:function (callback) {
            var base = this;

            base.$el.delegate(".form_cocktail", "submit", function () {
                var cocktail = new Cocktail();
                console.log(cocktail);
                cocktail.set("Name", base.$el.find(".field_Name").val());
                cocktail.save({}, {
                    success:function () {
                        base.app.router.navigate("#cocktail/edit/" + cocktail.get("Id"), {
                            trigger:true
                        });
                    },
                    error:function (object, status, data) {

                        response = JSON.parse(data.xhr.responseText);
                        if (response.message === "unsufficient_rights") {
                            base.$el.find(".error_message").html("Vous devez vous inscrire ou vous connecter pour ajouter un cocktail");
                        }
                        if (response.message === "already_existing") {
                            base.$el.find(".error_message").html("Il existe déjà un cocktail sous ce nom");
                        }
                        if (response.message === "missing_information") {
                            base.$el.find(".error_message").html("Vous devez entrer un nom");
                        }
                        if (!response.message || response.message === "unknown_error") {
                            base.$el.find(".error_message").html("Une erreur inconnue s'est produite");
                        }
                        base.$el.find(".form_cocktail").addClass("error");
                    }
                });
            });

            if (callback)
                callback();
        }
    });

    return CocktailCreationView;
});