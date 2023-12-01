using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskАndProjectManagementSystem.Application.Common.Behaviours
{
    public class UnhandledExeptionBehaviour<TRequest, IResponse> : IPipelineBehavior<TRequest, IResponse> where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExeptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<IResponse> Handle(TRequest request, RequestHandlerDelegate<IResponse> next, CancellationToken cancellationToken)
        {
            try 
            {
               return await next();
            }
            catch (Exception ex) 
            {
                var requestName = typeof(TRequest).Name;
                
                _logger.LogError(ex, 
                    "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
               
                throw;
            }
        }
    }
}
