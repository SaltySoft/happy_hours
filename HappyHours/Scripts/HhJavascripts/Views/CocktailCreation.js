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

            base.$el.delegate(".form_cocktail input", "click", function () {
                var elt = $(this);
                console.log("click");
                elt.removeClass("error_submit");
            });

            var form = base.$el.find(".form_cocktail");
            form.submit(function () {
                base.$el.find(".form_container").hide();
                base.$el.find(".loader").show();

                if (base.checkTextFields()) {
                    base.formSubmission(function () {
                        base.$el.find(".loader").fadeOut(100);
                        base.$el.find(".form_container").show();
                    });
                }
                else {
                    base.$el.find(".loader").fadeOut(100);
                    base.$el.find(".form_container").show();
                }
            });
        },
        formSubmission:function (callback) {
            var base = this;
            var iframe = base.$el.find(".form_iframe");
            iframe.load(function () {
                var iframeHtml = iframe.contents().find("pre").html();
                if (iframeHtml !== undefined) {
                    var object = JSON.parse(iframeHtml);
                    var cocktail = new Cocktail(object);
                    base.app.router.navigate("#cocktail/" + cocktail.get("Id"), { trigger:true })
                }
            });

            if (callback)
                callback();
        },
        checkTextFields:function () {
            var base = this;
            var canSubmit = true;
            console.log("checkTextFields");
            if (base.$el.find("#creation_form_name").val() == "") {
                canSubmit = false;
                base.$el.find("#creation_form_name").addClass("error_submit");
            }
            if (base.$el.find("#creation_form_difficulty").val() == "") {
                canSubmit = false;
                base.$el.find("#creation_form_difficulty").addClass("error_submit");
            }
            if (base.$el.find("#creation_form_duration").val() == "") {
                canSubmit = false;
                base.$el.find("#creation_form_duration").addClass("error_submit");
            }
            if (base.$el.find("#creation_form_description").val() == "") {
                canSubmit = false;
                base.$el.find("#creation_form_description").addClass("error_submit");
            }
            if (base.$el.find("#creation_form_recipe").val() == "") {
                canSubmit = false;
                base.$el.find("#creation_form_recipe").addClass("error_submit");
            }
            return canSubmit;
        }
    });

    return CocktailCreationView;
});