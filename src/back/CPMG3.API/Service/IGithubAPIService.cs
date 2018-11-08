using System;
using System.Collections.Generic;
using Refit;

namespace CPMG3.API.Service
{
    public interface IGithubAPI
    {
        [Get("/tanure/repos")]
        List<object> GetRepositories();
    }
}
