using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HhDBO
{
    [DataContract]
    public class SearchQuery
    {
        #region variables
        private string _cocktail_name;
        private string _ingredients;
        private string _difficulty;
        private string _quick;
        private string _alcohol;
        #endregion

        #region getter / setter
        /// <summary>
        /// Cocktail_name
        /// </summary>
        [DataMember]
        public string Cocktail_name
        {
            get { return _cocktail_name; }
            set { _cocktail_name = value; }
        }

        /// <summary>
        /// Ingredients
        /// </summary>
        [DataMember]
        public string Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }
        /// <summary>
        /// Difficulty
        /// </summary>
        [DataMember]
        public string Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
        }
        /// <summary>
        /// Quick
        /// </summary>
        [DataMember]
        public string Quick
        {
            get { return _quick; }
            set { _quick = value; }
        }
        /// <summary>
        /// Alcohol
        /// </summary>
        [DataMember]
        public string Alcohol
        {
            get { return _alcohol; }
            set { _alcohol = value; }
        }
        #endregion
    }
}
