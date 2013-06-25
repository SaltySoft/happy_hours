define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/main_view.html'
], function ($, _, Backbone, MainViewTemplate) {
    var MainView = Backbone.View.extend({
        tagName: "div",
            className: "main_view",
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
            var template = _.template(MainViewTemplate, {});

            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return MainView;
});