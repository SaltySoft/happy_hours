define([
    'jquery',
    'underscore',
    'backbone'
], function ($, _, Backbone) {
    var SearchPanelView = Backbone.View.extend({
        tagName: "div",
        className: "search_panel",
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
        },
        registerEvents: function () {
            var base = this;
        }
    });

    return SearchPanelView;
});