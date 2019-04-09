using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace WcfContracts
{
    [ServiceContract(Name = "IMathService", Namespace = "https://samples.mathservice.com/ServiceModel/Relay/")]
    public interface IMathService
    {
        [OperationContract]
        int Add(int first, int second);

        [OperationContract]
        int Subtract(int first, int second);
    }


    public interface IMathServiceChannel : IMathService, IClientChannel { };
}
