using System.Collections.Generic;

namespace test_crud.core.Entities
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string TxtDesc { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Security> Securities { get; }
    }
}