define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/cocktail_list.html',
    'Collections/Cocktails',
    'Views/CocktailListItem'
], function ($, _, Backbone, CocktailListTemplate, CocktailsCollection, CocktailListItemView) {
    var CocktailListView = Backbone.View.extend({
        tagName:"div",
        className:"cocktail_list_view",
        initialize:function () {

        },
        init:function (app) {
            var base = this;
            base.app = app;

            base.cocktails = new CocktailsCollection();

            base.render();
            base.registerEvents();
        },
        render:function () {
            var base = this;
            var template = _.template(CocktailListTemplate, {});
            base.$el.html(template);
            base.cocktails.fetch({
                success:function () {
                    base.updateList();
                }
            });

        },
        updateList:function () {
            var base = this;
            var dom_list = base.$el.find(".cocktail_list");
            for (var k in base.cocktails.models) {
                var cocktail = base.cocktails.models[k];
                var cocktail_item_view = new CocktailListItemView(cocktail);
                dom_list.append(cocktail_item_view.$el);
                cocktail_item_view.init(base.app);
            }
        },
        registerEvents:function () {
            var base = this;
        }
    });

    return CocktailListView;
});