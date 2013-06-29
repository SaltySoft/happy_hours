define([
    'jquery',
    'underscore',
    'backbone',
    'Models/Cocktail',
    'text!Templates/cocktail_list.html',
    'Collections/Cocktails',
    'Views/CocktailListItem'
], function ($, _, Backbone, Cocktail, CocktailListTemplate, CocktailsCollection, CocktailListItemView) {
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

            if (base.app.quickSearchData !== undefined) {
                base.searchQuery = {
                    name:"",
                    ingredients:"",
                    difficulty:"1",
                    quick:"no",
                    alcohol:"no"
                };
                for (var k in base.app.quickSearchData) {
                    if (base.app.quickSearchData[k].name == "name")
                        base.searchQuery.name = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "ingredients")
                        base.searchQuery.ingredients = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "difficulty")
                        base.searchQuery.difficulty = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "quick")
                        base.searchQuery.quick = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "alcohol")
                        base.searchQuery.alcohol = base.app.quickSearchData[k].value;
                }

                $.ajax({
                    url:"/Cocktail/GetQuickSearchCocktails",
                    type:"get",
                    data:{
                        name:base.searchQuery.name,
                        ingredients:base.searchQuery.ingredients,
                        difficulty:base.searchQuery.difficulty,
                        quick:base.searchQuery.quick,
                        alcohol:base.searchQuery.alcohol
                    },
                    success:function (data, status) {
                        for (var k in data) {
                            var cocktail = new Cocktail(data[k]);
                            base.cocktails.add(cocktail);
                        }
                        base.updateList();
                    }
                });
            }
            else {
                base.cocktails.fetch({
                    success:function () {
                        base.updateList();
                    }
                });
            }
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

            if (base.cocktails.length == 0)
            {
                dom_list.append("Aucun cocktail n'a été trouvé!");
            }
        },
        registerEvents:function () {
            var base = this;

            $("#cocktails_button").click(function () {
                var elt = $(this);
                if (base.app.quickSearchData !== undefined) {
                    base.app.quickSearchData = undefined;
                    route = Backbone.history.fragment;
                    if ("#" + route == "#cocktails") {
                        base.app.router.navigate();
                    }
                    base.app.router.navigate("#cocktails", {trigger:true});
                }
            });
        }
    });

    return CocktailListView;
});