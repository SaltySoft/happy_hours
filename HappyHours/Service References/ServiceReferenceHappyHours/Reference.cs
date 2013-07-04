﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18047
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HappyHours.ServiceReferenceHappyHours {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceHappyHours.IServiceClientHappyHours")]
    public interface IServiceClientHappyHours {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListUserResponse")]
        HhDBO.User[] GetListUser(int max);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListUserResponse")]
        System.Threading.Tasks.Task<HhDBO.User[]> GetListUserAsync(int max);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetUserResponse")]
        HhDBO.User[] GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetUserResponse")]
        System.Threading.Tasks.Task<HhDBO.User[]> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetUserByName", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetUserByNameResponse")]
        HhDBO.User GetUserByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetUserByName", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetUserByNameResponse")]
        System.Threading.Tasks.Task<HhDBO.User> GetUserByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/CreateUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/CreateUserResponse")]
        HhDBO.User CreateUser(HhDBO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/CreateUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/CreateUserResponse")]
        System.Threading.Tasks.Task<HhDBO.User> CreateUserAsync(HhDBO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/DeleteUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/DeleteUserResponse")]
        bool DeleteUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/DeleteUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/DeleteUserResponse")]
        System.Threading.Tasks.Task<bool> DeleteUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/UpdateUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/UpdateUserResponse")]
        bool UpdateUser(HhDBO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/UpdateUser", ReplyAction="http://tempuri.org/IServiceClientHappyHours/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(HhDBO.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListIngredientResponse")]
        HhDBO.Ingredient[] GetListIngredient(int max);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListIngredientResponse")]
        System.Threading.Tasks.Task<HhDBO.Ingredient[]> GetListIngredientAsync(int max);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetIngredientResponse")]
        HhDBO.Ingredient GetIngredient(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetIngredientResponse")]
        System.Threading.Tasks.Task<HhDBO.Ingredient> GetIngredientAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/CreateIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/CreateIngredientResponse")]
        HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/CreateIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/CreateIngredientResponse")]
        System.Threading.Tasks.Task<HhDBO.Ingredient> CreateIngredientAsync(HhDBO.Ingredient ingredient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/DeleteIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/DeleteIngredientResponse")]
        bool DeleteIngredient(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/DeleteIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/DeleteIngredientResponse")]
        System.Threading.Tasks.Task<bool> DeleteIngredientAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/UpdateIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/UpdateIngredientResponse")]
        bool UpdateIngredient(HhDBO.Ingredient ingredient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/UpdateIngredient", ReplyAction="http://tempuri.org/IServiceClientHappyHours/UpdateIngredientResponse")]
        System.Threading.Tasks.Task<bool> UpdateIngredientAsync(HhDBO.Ingredient ingredient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetRandomCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetRandomCocktailResponse")]
        HhDBO.Cocktail GetRandomCocktail();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetRandomCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetRandomCocktailResponse")]
        System.Threading.Tasks.Task<HhDBO.Cocktail> GetRandomCocktailAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListCocktailResponse")]
        HhDBO.Cocktail[] GetListCocktail(int max);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListCocktailResponse")]
        System.Threading.Tasks.Task<HhDBO.Cocktail[]> GetListCocktailAsync(int max);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetQuickSearchCocktails", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetQuickSearchCocktailsResponse")]
        HhDBO.Cocktail[] GetQuickSearchCocktails(HhDBO.SearchQuery searchQuery);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetQuickSearchCocktails", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetQuickSearchCocktailsResponse")]
        System.Threading.Tasks.Task<HhDBO.Cocktail[]> GetQuickSearchCocktailsAsync(HhDBO.SearchQuery searchQuery);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListCocktailEdited", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListCocktailEditedResponse")]
        HhDBO.Cocktail[] GetListCocktailEdited(int max, bool edited);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetListCocktailEdited", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetListCocktailEditedResponse")]
        System.Threading.Tasks.Task<HhDBO.Cocktail[]> GetListCocktailEditedAsync(int max, bool edited);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetCocktailResponse")]
        HhDBO.Cocktail GetCocktail(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/GetCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/GetCocktailResponse")]
        System.Threading.Tasks.Task<HhDBO.Cocktail> GetCocktailAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/CreateCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/CreateCocktailResponse")]
        HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/CreateCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/CreateCocktailResponse")]
        System.Threading.Tasks.Task<HhDBO.Cocktail> CreateCocktailAsync(HhDBO.Cocktail cocktail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/DeleteCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/DeleteCocktailResponse")]
        bool DeleteCocktail(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/DeleteCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/DeleteCocktailResponse")]
        System.Threading.Tasks.Task<bool> DeleteCocktailAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/UpdateCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/UpdateCocktailResponse")]
        bool UpdateCocktail(HhDBO.Cocktail cocktail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceClientHappyHours/UpdateCocktail", ReplyAction="http://tempuri.org/IServiceClientHappyHours/UpdateCocktailResponse")]
        System.Threading.Tasks.Task<bool> UpdateCocktailAsync(HhDBO.Cocktail cocktail);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceClientHappyHoursChannel : HappyHours.ServiceReferenceHappyHours.IServiceClientHappyHours, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClientHappyHoursClient : System.ServiceModel.ClientBase<HappyHours.ServiceReferenceHappyHours.IServiceClientHappyHours>, HappyHours.ServiceReferenceHappyHours.IServiceClientHappyHours {
        
        public ServiceClientHappyHoursClient() {
        }
        
        public ServiceClientHappyHoursClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClientHappyHoursClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClientHappyHoursClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClientHappyHoursClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public HhDBO.User[] GetListUser(int max) {
            return base.Channel.GetListUser(max);
        }
        
        public System.Threading.Tasks.Task<HhDBO.User[]> GetListUserAsync(int max) {
            return base.Channel.GetListUserAsync(max);
        }
        
        public HhDBO.User[] GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<HhDBO.User[]> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public HhDBO.User GetUserByName(string name) {
            return base.Channel.GetUserByName(name);
        }
        
        public System.Threading.Tasks.Task<HhDBO.User> GetUserByNameAsync(string name) {
            return base.Channel.GetUserByNameAsync(name);
        }
        
        public HhDBO.User CreateUser(HhDBO.User user) {
            return base.Channel.CreateUser(user);
        }
        
        public System.Threading.Tasks.Task<HhDBO.User> CreateUserAsync(HhDBO.User user) {
            return base.Channel.CreateUserAsync(user);
        }
        
        public bool DeleteUser(int id) {
            return base.Channel.DeleteUser(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteUserAsync(int id) {
            return base.Channel.DeleteUserAsync(id);
        }
        
        public bool UpdateUser(HhDBO.User user) {
            return base.Channel.UpdateUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(HhDBO.User user) {
            return base.Channel.UpdateUserAsync(user);
        }
        
        public HhDBO.Ingredient[] GetListIngredient(int max) {
            return base.Channel.GetListIngredient(max);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Ingredient[]> GetListIngredientAsync(int max) {
            return base.Channel.GetListIngredientAsync(max);
        }
        
        public HhDBO.Ingredient GetIngredient(int id) {
            return base.Channel.GetIngredient(id);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Ingredient> GetIngredientAsync(int id) {
            return base.Channel.GetIngredientAsync(id);
        }
        
        public HhDBO.Ingredient CreateIngredient(HhDBO.Ingredient ingredient) {
            return base.Channel.CreateIngredient(ingredient);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Ingredient> CreateIngredientAsync(HhDBO.Ingredient ingredient) {
            return base.Channel.CreateIngredientAsync(ingredient);
        }
        
        public bool DeleteIngredient(int id) {
            return base.Channel.DeleteIngredient(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteIngredientAsync(int id) {
            return base.Channel.DeleteIngredientAsync(id);
        }
        
        public bool UpdateIngredient(HhDBO.Ingredient ingredient) {
            return base.Channel.UpdateIngredient(ingredient);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateIngredientAsync(HhDBO.Ingredient ingredient) {
            return base.Channel.UpdateIngredientAsync(ingredient);
        }
        
        public HhDBO.Cocktail GetRandomCocktail() {
            return base.Channel.GetRandomCocktail();
        }
        
        public System.Threading.Tasks.Task<HhDBO.Cocktail> GetRandomCocktailAsync() {
            return base.Channel.GetRandomCocktailAsync();
        }
        
        public HhDBO.Cocktail[] GetListCocktail(int max) {
            return base.Channel.GetListCocktail(max);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Cocktail[]> GetListCocktailAsync(int max) {
            return base.Channel.GetListCocktailAsync(max);
        }
        
        public HhDBO.Cocktail[] GetQuickSearchCocktails(HhDBO.SearchQuery searchQuery) {
            return base.Channel.GetQuickSearchCocktails(searchQuery);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Cocktail[]> GetQuickSearchCocktailsAsync(HhDBO.SearchQuery searchQuery) {
            return base.Channel.GetQuickSearchCocktailsAsync(searchQuery);
        }
        
        public HhDBO.Cocktail[] GetListCocktailEdited(int max, bool edited) {
            return base.Channel.GetListCocktailEdited(max, edited);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Cocktail[]> GetListCocktailEditedAsync(int max, bool edited) {
            return base.Channel.GetListCocktailEditedAsync(max, edited);
        }
        
        public HhDBO.Cocktail GetCocktail(int id) {
            return base.Channel.GetCocktail(id);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Cocktail> GetCocktailAsync(int id) {
            return base.Channel.GetCocktailAsync(id);
        }
        
        public HhDBO.Cocktail CreateCocktail(HhDBO.Cocktail cocktail) {
            return base.Channel.CreateCocktail(cocktail);
        }
        
        public System.Threading.Tasks.Task<HhDBO.Cocktail> CreateCocktailAsync(HhDBO.Cocktail cocktail) {
            return base.Channel.CreateCocktailAsync(cocktail);
        }
        
        public bool DeleteCocktail(int id) {
            return base.Channel.DeleteCocktail(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteCocktailAsync(int id) {
            return base.Channel.DeleteCocktailAsync(id);
        }
        
        public bool UpdateCocktail(HhDBO.Cocktail cocktail) {
            return base.Channel.UpdateCocktail(cocktail);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateCocktailAsync(HhDBO.Cocktail cocktail) {
            return base.Channel.UpdateCocktailAsync(cocktail);
        }
    }
}
