using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HhDBO
{
    [DataContract]
    public class Ingredient
    {
        #region variables
        private int _id;
        private string _name;
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
        #endregion
    }
}
