using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class Cocktail
    {
        private ServiceReferenceHappyHours.ServiceClientHappyHoursClient _client;

        public ServiceReferenceHappyHours.ServiceClientHappyHoursClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public Cocktail()
        {
            _client = new ServiceReferenceHappyHours.ServiceClientHappyHoursClient();
        }

        public List<HhDBO.Cocktail> GetListCocktail(int max)
        {
            try
            {
                List<HhDBO.Cocktail> cocktails = _client.GetListCocktail(max).ToList();
                foreach (HhDBO.Cocktail i in cocktails)
                {
                    Debug.WriteLine(i.Name);
                }
                return cocktails;
            }
            catch (Exception ex)
            {
                return new List<HhDBO.Cocktail>();
            }
        }

        public HhDBO.Cocktail GetCocktail(int id)
        {
            try
            {
                HhDBO.Cocktail cocktail = _client.GetCocktail(id);
                return cocktail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail)
        {
            try
            {
                return _client.CreateCocktail(cocktail);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateIngrediend(HhDBO.Cocktail cocktail)
        {
            try
            {
                return _client.UpdateCocktail(cocktail);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCocktail(int id)
        {
            try
            {
                return _client.DeleteCocktail(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}