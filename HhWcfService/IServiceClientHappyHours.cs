using HhDataLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HhWcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IServiceClientHappyHours" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceClientHappyHours
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        List<HhDataLayer.DBO.User> GetListUser(int max);

        [OperationContract]
        String Test();
    }
}
