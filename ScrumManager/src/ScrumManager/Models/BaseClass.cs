using System;

namespace CoreBusinessObjects.Models
{
    public abstract class BaseClass
    {
        #region Properties

        public int ObjectId { get; set; }
        public string ShortCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int CreatorId { get; set; }
        public int ModifierId { get; set; }

        #endregion // Properties
    }
}
