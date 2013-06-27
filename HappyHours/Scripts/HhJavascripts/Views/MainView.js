define([
    'jquery',
    'underscore',
    'backbone',
    'text!Templates/main_view.html',
    'Views/SearchPanel',
    'Views/CocktailList',
    'Views/CocktailFeatured',
    'Views/CocktailDetails',
    'Views/CocktailCreation',
    'Views/CocktailSearch'
], function ($, _, Backbone, MainViewTemplate, SearchPanelView, CocktailListView, CocktailFeaturedView, CocktailDetailsView, CocktailCreationView, CocktailSearchView) {
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
                routes:{
                    "":"featured_cocktail",
                    "cocktails":"cocktails",
                    "cocktail/:id":"show_cocktail",
                    "add_cocktail":"add_cocktail",
                    "search_cocktail":"search_cocktail"
                },
                featured_cocktail:function () {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail_featured_view = new CocktailFeaturedView();
                    base.$el.find("#sub_app_container").html(cocktail_featured_view.$el);
                    cocktail_featured_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                },
                cocktails:function () {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail_list_view = new CocktailListView();
                    base.$el.find("#sub_app_container").html(cocktail_list_view.$el);
                    cocktail_list_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                },
                search_cocktail:function () {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail_search_view = new CocktailSearchView();
                    base.$el.find("#sub_app_container").html(cocktail_search_view.$el);
                    cocktail_search_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                },
                add_cocktail:function () {
                    base.$el.find("#sub_app_container").hide();
                    var add_cocktail_view = new CocktailCreationView();
                    base.$el.find("#sub_app_container").html(add_cocktail_view.$el);
                    add_cocktail_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                },
                show_cocktail:function (id) {
                    base.$el.find("#sub_app_container").hide();
                    var show_cocktail_view = new CocktailDetailsView();
                    base.$el.find("#sub_app_container").html(show_cocktail_view.$el);
                    show_cocktail_view.init(base.app, id);
                    base.$el.find("#sub_app_container").fadeIn(200);
                }
            });

            app.router = new AppRouter();
        },
        render:function () {
            var base = this;
            var template = _.template(MainViewTemplate, {});
            base.$el.html(template);

            var searchPanelView = new SearchPanelView();
            base.$el.find("#search_panel").html(searchPanelView.$el);
            searchPanelView.init(base.app);
        },
        registerEvents:function () {
            var base = this;

            base.$el.delegate(".navigation-menu-container a", "click", function () {
                var elt = $(this);
                var list_items = base.$el.find(".navigation-menu-container li");
                list_items.each(function () {
                    $(this).removeClass('pure-menu-selected');
                });
                elt.closest("li").addClass('pure-menu-selected');
            });
        }
    });

    return MainView;
});