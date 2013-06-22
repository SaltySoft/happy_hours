using HhDataLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HhWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ServiceClientHappyHours" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ServiceClientHappyHours.svc ou ServiceClientHappyHours.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ServiceClientHappyHours : IServiceClientHappyHours
    {
        public void DoWork()
        {
            
        }

        public List<HhDataLayer.DBO.User> GetListUser(int max)
        {
            return HhDataLayer.BusinessManagement.User.GetListUser(max);
        }

        public String Test()
        {
            return "patate";
        }
    }
}
