namespace test_crud.core.QueryFilters
{
    public class UserQueryFilter
    {
        public string? TxtUser { get; set; }
        public string? TxtName { get; set; }
        public string? TxtLastName { get; set; }
        public string? IdentityCardNum { get; set; }
        public int? RoleCode { get; set; }
        public int? IsActive { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
