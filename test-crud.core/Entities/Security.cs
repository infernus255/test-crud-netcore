namespace test_crud.core.Entities
{
    public class Security : BaseEntity
    {
        public string TxtUser { get; set; }
        public string TxtName { get; set; }
        public string TxtLastName { get; set; }
        public string TxtPassword { get; set; }
        public int RoleCode { get; set; }
        public virtual Role Role { get; set; }
    }
}
