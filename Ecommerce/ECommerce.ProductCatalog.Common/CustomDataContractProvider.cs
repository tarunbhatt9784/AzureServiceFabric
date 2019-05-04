using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.ProductCatalog.Model;
using Microsoft.ServiceFabric.Services.Remoting.V2;


namespace ECommerceProductCatalog.Common
{
    public class CustomDataContractProvider : IServiceRemotingMessageSerializationProvider
    {
        private readonly ServiceRemotingDataContractSerializationProvider provider;
        private readonly IEnumerable<Type> myTypes;

        public CustomDataContractProvider()
        {
            this.provider = new ServiceRemotingDataContractSerializationProvider();
            this.myTypes = new List<Type>()
            {
                typeof(Product)
            };
        }
        public IServiceRemotingMessageBodyFactory CreateMessageBodyFactory()
        {
            return this.provider.CreateMessageBodyFactory();
        }

        public IServiceRemotingRequestMessageBodySerializer CreateRequestMessageSerializer(Type serviceInterfaceType,
            IEnumerable<Type> requestBodyTypes)
        {
            var result = requestBodyTypes.Concat(this.myTypes);
            return this.provider.CreateRequestMessageSerializer(serviceInterfaceType, result);
        }

        public IServiceRemotingRequestMessageBodySerializer CreateRequestMessageSerializer(Type serviceInterfaceType, IEnumerable<Type> requestWrappedTypes, IEnumerable<Type> requestBodyTypes = null)
        {
            throw new NotImplementedException();
        }

       

        public IServiceRemotingResponseMessageBodySerializer CreateResponseMessageSerializer(Type serviceInterfaceType, IEnumerable<Type> responseWrappedTypes, IEnumerable<Type> responseBodyTypes = null)
        {
            var result = responseBodyTypes.Concat(this.myTypes);
            return this.provider.CreateResponseMessageSerializer(serviceInterfaceType, result);
        }
    }
}
