using System;
using test_crud.core.QueryFilters;
using test_crud.infrastructure.Interfaces;

namespace test_crud.infrastructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetUserPaginationUri(UserQueryFilter filters, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
