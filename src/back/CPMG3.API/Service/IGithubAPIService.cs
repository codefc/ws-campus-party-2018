using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace CPMG3.API.Service
{
    public interface IGithubAPIService
    {
        [Get("/users/<SEU_USUARIO>/repos")]
        Task<List<object>> GetRepositories();
    }
}
