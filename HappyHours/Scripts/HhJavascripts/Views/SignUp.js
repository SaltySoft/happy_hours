define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/user_sign_up.html'
], function ($, _, Backbone, SignUpTemplate) {
    var SignUpView = Backbone.View.extend({
        tagName: "div",
        className: "sign_up_view",
        initialize: function () {

        },
        init: function (app, mainview) {
            var base = this;
            base.app = app;
            base.mainview = mainview;

            base.render();
            base.registerEvents();
        },
        render: function () {
            var base = this;

            var template = _.template(SignUpTemplate, {});

            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;
            base.$el.delegate(".user_creation_form", "submit", function () {
                var form = $(this);
                $.post("/User/WsRest", form.serialize(), function (data, status) {
                    if (data.Username) {
                        console.log(base.$el.find("#form_username").val(), base.$el.find("#form_password").val());
                        base.mainview.loginUser(base.$el.find("#form_username").val(), base.$el.find("#form_password").val());
                    }
                });
            });

            base.app.events.on("user_connection", function () {
                base.app.show_message("Bienvenue, " + base.app.current_user.get("Username"));
                base.app.router.navigate("", {trigger: true});
            });
        }
    });

    return SignUpView;
});