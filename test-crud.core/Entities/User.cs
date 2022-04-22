namespace test_crud.core.Entities
{
    public partial class User : BaseEntity
    {
        public string TxtUser { get; set; }
        public string TxtPassword { get; set; }
        public string TxtName { get; set; }
        public string TxtLastName { get; set; }
        public string IdentityCardNum { get; set; }
        public int? RoleCode { get; set; }
        public int? IsActive { get; set; }

        public virtual Role Role { get; set; }
    }
}
