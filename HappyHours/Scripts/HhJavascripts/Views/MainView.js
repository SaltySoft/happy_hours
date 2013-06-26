define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/main_view.html',
    'Views/CocktailList',
    'Views/CocktailFeatured',
    'Views/CocktailDetails',
    'Views/CocktailCreation',
    'Views/CocktailSearch'
], function ($, _, Backbone, MainViewTemplate, CocktailListView, CocktailFeaturedView, CocktailDetailsView, CocktailCreationView, CocktailSearchView) {
    var MainView = Backbone.View.extend({
        tagName:"div",
        className:"main_view",
        initialize:function () {

        },
        init:function (app) {
            var base = this;

            base.app = app;
            base.render();
            base.registerEvents();

            var AppRouter = Backbone.Router.extend({
                routes: {
                    "":"featured_cocktail",
                    "cocktails": "cocktails",
                    "cocktail/:id": "show_cocktail",
                    "add_cocktail" : "add_cocktail",
                    "search_cocktail" : "search_cocktail"
                },
                cocktails:function () {
                    var cocktail_list = new CocktailListView();
                    base.$el.find("#sub_app_container").html(cocktail_list.$el);
                    cocktail_list.init(base.app);
                },
                show_cocktail: function (id) {
                    var show_cocktail_view = new CocktailDetailsView();
                    base.$el.find("#sub_app_container").html(show_cocktail_view.$el);
                    show_cocktail_view.init(base.app, id);
                },
                add_cocktail: function () {
                    var add_cocktail_view = new CocktailCreationView();
                    base.$el.find("#sub_app_container").html(add_cocktail_view.$el);
                    add_cocktail_view.init(base.app);
                },
                featured_cocktail:function () {
                    var cocktail_featured_view = new CocktailFeaturedView();
                    base.$el.find("#sub_app_container").html(cocktail_featured_view.$el);
                    cocktail_featured_view.init(base.app);
                },
                search_cocktail:function () {
                    var cocktail_search_view = new CocktailSearchView();
                    base.$el.find("#sub_app_container").html(cocktail_search_view.$el);
                    cocktail_search_view.init(base.app);
                }
            });

            app.router = new AppRouter();
        },
        render:function () {
            var base = this;
            var template = _.template(MainViewTemplate, {});

            base.$el.html(template);
        },
        registerEvents:function () {
            var base = this;
        }
    });

    return MainView;
});