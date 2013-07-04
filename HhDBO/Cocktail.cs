using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HhDBO
{
    [DataContract]
    public class Cocktail
    {
        #region variables
        private int _id;
        private string _name;
        private int _difficulty;
        private int _duration;
        private int _creator_id;
        private string _description;
        private string _recipe;
        private string _picture_url;
        private List<Ingredient> _ingredients;
        private int _edited;
        #endregion

        #region getter / setter
        /// <summary>
        /// id
        /// </summary>
        [DataMember]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// name
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// difficulty
        /// </summary>
        [DataMember]
        public int Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }

        /// <summary>
        /// creator
        /// </summary>
        [DataMember]
        public int Creator_Id
        {
            get { return _creator_id; }
            set { _creator_id = value; }
        }

        /// <summary>
        /// description
        /// </summary>
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// recipe
        /// </summary>
        [DataMember]
        public string Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }

        /// <summary>
        /// picture url
        /// </summary>
        [DataMember]
        public string Picture_Url
        {
            get { return _picture_url; }
            set { _picture_url = value; }
        }

        /// <summary>
        /// duration
        /// </summary>
        [DataMember]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        [DataMember]
        public List<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        [DataMember]
        public int Edited
        {
            get { return _edited; }
            set { _edited = value; }
        }

        #endregion
    }
}
