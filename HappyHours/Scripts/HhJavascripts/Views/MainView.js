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
    'Views/CocktailSearch',
    '/Scripts/HhJavascripts/Models/User.js',
    'Views/SignUp',
    'Views/Favorites',
    'Views/CocktailEdition',
    'Models/Cocktail'
], function ($, _, Backbone, MainViewTemplate, SearchPanelView, CocktailListView, CocktailFeaturedView, CocktailDetailsView, CocktailCreationView, CocktailSearchView, User, SignUpView, FavoritesView, CocktailEditionView, Cocktail) {
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
            base.current_view = undefined;

            var AppRouter = Backbone.Router.extend({
                routes:{
                    "":"featured_cocktail",
                    "cocktails":"cocktails",
                    "cocktail/:id":"show_cocktail",
                    "add_cocktail":"add_cocktail",
                    "sign_up":"sign_up",
                    "favorites":"favorites",
                    "cocktail/edit/:id":"edit_cocktail"
                },
                featured_cocktail:function () {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail_featured_view = new CocktailFeaturedView();
                    base.$el.find("#sub_app_container").html(cocktail_featured_view.$el);
                    cocktail_featured_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = cocktail_featured_view;
                },
                cocktails:function () {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail_list_view = new CocktailListView();
                    base.$el.find("#sub_app_container").html(cocktail_list_view.$el);
                    cocktail_list_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = cocktail_list_view;
                },
                add_cocktail:function () {
                    base.$el.find("#sub_app_container").hide();
                    var add_cocktail_view = new CocktailCreationView();
                    base.$el.find("#sub_app_container").html(add_cocktail_view.$el);
                    add_cocktail_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = add_cocktail_view;
                },
                show_cocktail:function (id) {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail = new Cocktail({Id: id});
                    var show_cocktail_view = new CocktailDetailsView(cocktail);
                    base.$el.find("#sub_app_container").html(show_cocktail_view.$el);
                    show_cocktail_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = show_cocktail_view;
                },
                favorites:function () {
                    base.$el.find("#sub_app_container").hide();
                    var favorites_view = new FavoritesView();
                    base.$el.find("#sub_app_container").html(favorites_view.$el);
                    favorites_view.init(base.app);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = favorites_view;
                },
                sign_up:function () {
                    base.$el.find("#sub_app_container").hide();
                    var sign_up_view = new SignUpView();
                    base.$el.find("#sub_app_container").html(sign_up_view.$el);
                    sign_up_view.init(base.app, base);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = sign_up_view;
                },
                edit_cocktail:function (id) {
                    base.$el.find("#sub_app_container").hide();
                    var cocktail_edition_view = new CocktailEditionView();
                    base.$el.find("#sub_app_container").html(cocktail_edition_view.$el);
                    cocktail_edition_view.init(base.app, id);
                    base.$el.find("#sub_app_container").fadeIn(200);
                    base.current_view = cocktail_edition_view;
                }
            });

            app.router = new AppRouter();
//            console.log(base.app.current_user);
        },
        loginUser:function (username, password) {
            var base = this;
            $.ajax({
                url:"/User/Login",
                method:"post",
                data:{
                    username:username,
                    password:password
                },
                success:function (data) {
                    if (data == "success") {
                        $.ajax({
                            url:"/User/CurrentUser",
                            success:function (data, status) {
                                if (data.Id) {
                                    base.app.current_user = new User(data);
                                    base.app.events.trigger("user_connection");
                                    base.$el.find(".connect").hide();
                                    base.$el.find(".disconnect").show();
                                    base.$el.find(".login_required").show();
                                    base.$el.find(".anonym_required").hide();
                                    base.$el.find(".disconnect .username").html(base.app.current_user.get("Username"));
                                    if (base.current_view) {
                                        base.current_view.init(base.app);
                                    }
                                } else {
                                    base.app.current_user = undefined;
                                    base.$el.find(".login_required").hide();

                                }
                            }
                        });
                    } else {
                        alert("Nous n'avons pas pu vous identifier. Veuillez vérifier vos nom d'utilisateur et mot de passe.");
                    }
                }
            });
        },
        disconnectUser:function () {
            var base = this;
            $.ajax({
                url:"/User/Logout",
                success:function () {
                    base.$el.find(".connect").show();
                    base.$el.find(".disconnect").hide();
                    base.$el.find(".login_required").hide();
                    base.$el.find(".anonym_required").show();
                    base.app.events.trigger("user_disconnection");
                    base.app.current_user = undefined;
                    if (base.current_view) {
                        base.current_view.init(base.app);
                    }
                }
            });
        },
        render:function () {
            var base = this;
            var template = _.template(MainViewTemplate, {
                current_user:base.app.current_user
            });

            base.$el.html(template);
            if (!base.app.current_user) {
                base.$el.find(".login_required").hide();
                base.$el.find(".anonym_required").show();
            } else {
                base.$el.find(".anonym_required").hide();
                base.$el.find(".login_required").show();
            }

            var searchPanelView = new SearchPanelView();
            base.$el.find("#search_panel").html(searchPanelView.$el);
            searchPanelView.init(base.app);
        },
        registerEvents:function () {
            var base = this;

            base.$el.delegate(".navigation_menu_container a", "click", function () {
                var elt = $(this);
                base.$el.find(".navigation_menu_container a").removeClass("pure-button");
                base.$el.find(".navigation_menu_container a").removeClass("pure-button-active");

                elt.addClass('pure-button');
                elt.addClass('pure-button-active');
            });

            if (base.app.current_user) {
                base.$el.find(".connect").hide();
                base.$el.find(".disconnect").show();
                base.$el.find(".disconnect .username").html(base.app.current_user.get("Username"));
            } else {
                base.$el.find(".connect").show();
                base.$el.find(".disconnect").hide();
            }

            base.$el.delegate(".disconnect_button", "click", function () {
                base.disconnectUser();
            });

            base.$el.delegate(".connect", "submit", function () {
                var form = $(this);
                base.loginUser(form.find("#login_username").val(), form.find("#login_password").val());
            });
        }
    });

    return MainView;
});