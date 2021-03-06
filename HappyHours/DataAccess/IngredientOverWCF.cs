﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace HappyHours.DataAccess
{
    public class IngredientOverWCF
    {
        private ServiceReferenceHappyHours.ServiceClientHappyHoursClient _client;

        public ServiceReferenceHappyHours.ServiceClientHappyHoursClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public IngredientOverWCF()
        {
            _client = new ServiceReferenceHappyHours.ServiceClientHappyHoursClient();
        }

        public List<HhDBO.Ingredient> GetListIngredient(int max)
        {
            try
            {
                List<HhDBO.Ingredient> ingredients = _client.GetListIngredient(max).ToList();
                foreach (HhDBO.Ingredient i in ingredients)
                {
                    Debug.WriteLine(i.Name);
                }
                return ingredients;
            }
            catch (Exception)
            {
                return new List<HhDBO.Ingredient>();
            }
        }

        public HhDBO.Ingredient GetIngredient(int id)
        {
            try
            {
                HhDBO.Ingredient ingredient = _client.GetIngredient(id);
                return ingredient;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient)
        {
            try
            {
                return _client.CreateIngredient(ingredient);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateIngrediend(HhDBO.Ingredient ingredient)
        {
            try
            {
                return _client.UpdateIngredient(ingredient);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteIngredient(int id)
        {
            try
            {
                return _client.DeleteIngredient(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}