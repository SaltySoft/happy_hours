﻿using System;
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
        List<HhDBO.User> GetListUser(int max);

        [OperationContract]
        List<HhDBO.User> GetUser(int id);

        [OperationContract]
        HhDBO.User CreateUser(HhDBO.User user);

        [OperationContract]
        bool DeleteUser(int id);

        [OperationContract]
        bool UpdateUser(HhDBO.User user);
    }
}
