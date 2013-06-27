define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/search_panel.html'
], function ($, _, Backbone, SearchPanelTemplate) {
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
            var template = _.template(SearchPanelTemplate, {});
            base.$el.html(template);
        },
        registerEvents: function () {
            var base = this;

            base.$el.delegate(".quick_search_form", "submit", function () {
                var elt = $(this);
                base.app.quickSearchData = elt.serializeArray();
                route = Backbone.history.fragment;
                if ("#" + route == "#cocktails") {
                    base.app.router.navigate();
//                    app.router.navigate(route, true);
                }
                base.app.router.navigate("#cocktails", {trigger:true});
            });
        }
    });

    return SearchPanelView;
});