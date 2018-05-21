using Jorge.Inventory.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jorge.Inventory.Infrastructure.Messaging
{
    public class ContractUtil
    {


        #region Request 

        public static ContractRequest<TRequest> CreateRequest<TRequest>(TRequest dtoData)
            where TRequest : class
        {
            var toReturn = new ContractRequest<TRequest>
            {
                Data = dtoData,
            };

            return toReturn;
        }


        public static ContractRequest<BaseRequest> CreateBaseRequest()
        {
            var toReturn = new ContractRequest<BaseRequest>()
            {
                Data = new BaseRequest(),
            };

            return toReturn;
        }

        #endregion

        #region Response


        public static ContractResponse<TResponse> CreateResponse<TResponse, TRequest>(ContractRequest<TRequest> request, TResponse data)
            where TRequest : class
            where TResponse : class
        {
            if (request == null) request = new ContractRequest<TRequest>();
            return CreateResponse(request,  data , 0, 0);
        }


     

        public static ContractResponse<TResponse> CreateResponse<TResponse, TRequest>(ContractRequest<TRequest> request, TResponse data, long count, long countFilter)
            where TRequest : class
            where TResponse : class
        {

            return new ContractResponse<TResponse>
            {
                Data = data,
                ErrorMessages = new List<string> { "" },
                IsValid = true,
            };
        }

        #endregion

        #region InvalidReponse



        public static ContractResponse<TResponse> CreateInvalidResponse<TResponse>(TResponse data, string errorMessage)
            where TResponse : class
        {

            return new ContractResponse<TResponse>
            {
                Data = data,
                ErrorMessages = new List<string> { errorMessage },
                IsValid = false,
            };
        }


        public static ContractResponse<TResponse> CreateInvalidResponse<TResponse>(Exception ex, TResponse data)
            where TResponse : class
        {

            return new ContractResponse<TResponse>
            {
                Data = data,
                ErrorMessages = new List<string> { ex.Message },
                IsValid = false,
            };
        }

      


        public static ContractResponse<TResponse> CreateInvalidResponse<TResponse>(Exception ex)
            where TResponse : class
        {

            return new ContractResponse<TResponse>
            {
                Data =  default(TResponse),
                ErrorMessages = new List<string> { ex.Message },
                IsValid = false,
            };
        }

        public static ContractResponse<TResponse> CreateInvalidResponse<TResponse>(IEnumerable<BusinessRule> brokenRules, TResponse data )
            where TResponse : class
        {

            return new ContractResponse<TResponse>
            {
                Data = data,
                ErrorMessages = brokenRules.Select(b => b.Rule).ToList(),
                IsValid = false,
            };
        }

        #endregion

    }
}
