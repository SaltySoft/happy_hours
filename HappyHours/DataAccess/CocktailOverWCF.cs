﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class CocktailOverWCF
    {
        private ServiceReferenceHappyHours.ServiceClientHappyHoursClient _client;

        public ServiceReferenceHappyHours.ServiceClientHappyHoursClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public CocktailOverWCF()
        {
            _client = new ServiceReferenceHappyHours.ServiceClientHappyHoursClient();
        }

        public HhDBO.Cocktail GetRandomCocktail()
        {
            try
            {
                HhDBO.Cocktail cocktail = _client.GetRandomCocktail();
                return cocktail;
            }
            catch (Exception)
            {
                return null;
            }
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
            catch (Exception)
            {
                return new List<HhDBO.Cocktail>();
            }
        }
        
        public List<HhDBO.Cocktail> GetQuickSearchCocktails(HhDBO.SearchQuery searchQuery)
        {
            try
            {
                List<HhDBO.Cocktail> cocktails = _client.GetQuickSearchCocktails(searchQuery).ToList();
                return cocktails;
            }
            catch (Exception)
            {
                return new List<HhDBO.Cocktail>();
            }
        }
        
        public List<HhDBO.Cocktail> GetListCocktailEdited(int max, bool edited)
        {
             try
             {
                  List<HhDBO.Cocktail> cocktails = _client.GetListCocktailEdited(max, edited).ToList();
                  foreach (HhDBO.Cocktail i in cocktails)
                  {
                      Debug.WriteLine(i.Name);
                  }
                  return cocktails;
             }
             catch (Exception)
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
            catch (Exception)
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
                throw ex;
            }
        }

        public bool UpdateIngrediend(HhDBO.Cocktail cocktail)
        {
            try
            {
                return _client.UpdateCocktail(cocktail);
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}