define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/user_sign_up.html'
], function ($, _, Backbone, SignUpTemplate) {
    var SignUpView = Backbone.View.extend({
        tagName:"div",
        className:"sign_up_view",
        initialize:function () {

        },
        init:function (app, mainview) {
            var base = this;
            base.app = app;
            base.mainview = mainview;

            base.render();
            base.registerEvents();
        },
        render:function () {
            var base = this;

            var template = _.template(SignUpTemplate, {});

            base.$el.html(template);
        },
        resetErrorMsgs:function () {
            var base = this;
            base.$el.find("#error_username").html("");
            base.$el.find("#error_email").html("");
            base.$el.find("#error_password").html("");
            base.$el.find("#error_message").html("");
        },
        registerEvents:function () {
            var base = this;
            base.$el.delegate(".user_creation_form", "submit", function () {
                var form = $(this);
                $.ajax({
                    url:"/User/WsRest",
                    type:"post",
                    data:form.serialize(),
                    success:function (data) {
//                        console.log(base.$el.find("#form_username").val(), base.$el.find("#form_password").val());
                        base.mainview.loginUser(base.$el.find("#form_username").val(), base.$el.find("#form_password").val());
                    },
                    error:function (object, status, data) {
                        base.resetErrorMsgs();
                        response = JSON.parse(object.responseText);
                        if (response.message == "missing_information") {
                            if (response.data.indexOf("Username") !== -1) {
                                base.$el.find("#error_username").html("Vous devez entrer un nom d'utilisateur.");
                            }
                            if (response.data.indexOf("Email") !== -1) {
                                base.$el.find("#error_email").html("Vous devez entrer un email.");
                            }
                            if (response.data.indexOf("Password") !== -1) {
                                base.$el.find("#error_password").html("Vous devez entrer un mot de passe.");
                            }
                        }
                        if (response.message === "already_existing") {
                            base.$el.find("#error_username").html("Il existe déjà un utilisateur portant ce nom.");
                        }
                        if (!response.message || response.message === "unknown_error") {
                            base.$el.find("#error_message").html("Une erreur inconnue s'est produite");
                        }

                        base.$el.find(".user_creation_form").addClass("error");
                    }
                });
            });

            base.app.events.on("user_connection", function () {
                base.app.show_message("Bienvenue, " + base.app.current_user.get("Username"));
                base.app.router.navigate("", {trigger:true});
            });
        }
    });

    return SignUpView;
});