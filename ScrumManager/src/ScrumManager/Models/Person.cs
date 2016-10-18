using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBusinessObjects.Models
{
    public enum Roles
    {
        Developer = 1,
        ProductOwner = 2,
        ScrumMaster = 3,
        Test = 4
    }

    public class Person : BaseClass
    {
        #region Properties

        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        #endregion // Properties
    }
}
