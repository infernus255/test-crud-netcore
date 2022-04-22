using System;
using test_crud.core.QueryFilters;

namespace test_crud.infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetUserPaginationUri(UserQueryFilter filter, string actionUrl);
    }
}