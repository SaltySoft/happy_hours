using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HhWcfService
{
    [ServiceContract]
    public interface IServiceClientHappyHours
    {
        //Users
        [OperationContract]
        List<HhDBO.User> GetListUser(int max);

        [OperationContract]
        List<HhDBO.User> GetUser(int id);

        [OperationContract]
        HhDBO.User CreateUser(HhDBO.User user);

        [OperationContract]
        bool DeleteUser(int id);

        [OperationContract]
        bool UpdateUser(HhDBO.User user);


        //Ingredients
        [OperationContract]
        List<HhDBO.Ingredient> GetListIngredient(int max);

        [OperationContract]
        HhDBO.Ingredient GetIngredient(int id);

        [OperationContract]
        HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient);

        [OperationContract]
        bool DeleteIngredient(int id);

        [OperationContract]
        bool UpdateIngredient(HhDBO.Ingredient ingredient);
    }
}
