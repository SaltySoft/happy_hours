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
            console.log("base.app.quickSearchData", base.app.quickSearchData);
            base.render();
            base.registerEvents();
        },
        render:function () {
            var base = this;
            var template = _.template(CocktailListTemplate, {});
            base.$el.html(template);

            if (base.app.quickSearchData !== undefined) {
                var queryList = new Array();

                base.name = "";
                base.ingredients = "";
                base.difficulty = "1";
                base.duration = "1";
                base.alcohol = "no";

                for (var k in base.app.quickSearchData) {
                    if (base.app.quickSearchData[k].name == "name")
                        base.name = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "ingredients")
                        base.ingredients = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "difficulty")
                        base.difficulty = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "duration")
                        base.duration = base.app.quickSearchData[k].value;
                    if (base.app.quickSearchData[k].name == "alcohol")
                        base.alcohol = base.app.quickSearchData[k].value;
                }

                var difficulty =
                    $.ajax({
                        url:"/Cocktail/GetQuickSearchCocktails",
                        type:"get",
                        data:{
                            name:base.name,
                            ingredients:base.ingredients,
                            difficulty:base.difficulty,
                            duration:base.duration,
                            alcohol:base.alcohol
                        },
                        success:function (data, status) {
                            console.log("data", data);
//                        base.cocktails = data;
//                        base.updateList();
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
        },
        registerEvents:function () {
            var base = this;
        }
    });

    return CocktailListView;
});