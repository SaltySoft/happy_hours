$(function () {
    // Genre Model
    var Genre = Backbone.Model.extend({
        url: function () {
            var base = '/StoreManager/GenreList/';
            if (this.isNew())
                return base;
            return base + (base.charAt(base.length - 1) == '/' ? '' : '/') + this.id;
        },
        initialize: function () {
            console.log('Genre Constructor Triggered');
        },
        defaults: {
            GenreId: 0,
            Name: 'Unknown',
            Description: 'Unknown'
        }
    });

    // Genre Collection
    var GenreCollection = Backbone.Collection.extend({
        model: Genre,
        url: '/StoreManager/GenreList/'
    });

    // Genre View - el returns the template enclosed within a tr
    var GenreView = Backbone.View.extend({
        template: _.template($('#Genre-Template').html()),
        tagName: "tr",
        initialize: function () {
            console.log('GenreView Constructor Triggered');
            this.model.bind('change', this.render, this);
            this.model.bind('remove', this.unrender, this);
        },
        render: function () {
            console.log('Rendering...');
            $(this.el).html(this.template(this.model.toJSON()));
            return this;
        },
        unrender: function () {
            console.log('Un-Rendering...');
            $(this.el).remove();
            return this;
        },
        events: {
            "click .Edit": 'EditGenre',
            "click .Delete": 'DeleteGenre'
        },
        EditGenre: function () {
            this.model.set({ Description: 'Unknown' });
            var self = this;
            this.model.save(this.model, {
                success: function () {
                    $("input:button", $(self.el)).button();
                }
            });
        },
        DeleteGenre: function () {
            this.model.destroy();
        }
    });

    // Actual App view
    var AppView = Backbone.View.extend({
        initialize: function () {
            this.collection.bind('add', this.AppendGenre, this);
        },
        el: '#Genre_Container',
        counter: 15,
        events: {
            "click #btnCreateNew": "AddNewGenre"
        },
        AddNewGenre: function () {
            console.log('Add Genre....');
            this.counter++;
            var newGenre = new Genre({ Name: 'Unknown ' + this.counter, Description: 'Damn ' + this.counter });
            this.collection.add(newGenre);
            newGenre.save(newGenre, {
                success: function () {
                    $("input:button", "#Genre_List").button();
                }
            });
        },
        AppendGenre: function (genre) {
            var genreView = new GenreView({ model: genre });
            $(this.el).find('table').append(genreView.render().el);
        },
        render: function () {
            if (this.collection.length > 0) {
                this.collection.each(this.AppendGenre, this);
            }
            $("input:button", "#Genre_List").button();
        }
    });

    var genres = new GenreCollection();
    var view = new AppView({ collection: genres });
    genres.fetch({
        success: function () {
            view.render();
        }
    });
});