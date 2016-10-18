namespace CoreBusinessObjects.Models
{
    public class Item : BaseClass
    {
        #region Properties

        public int FeatureId { get; set; }
        public int StoryId { get; set; }
        public int ItemId { get; set; }
        public int UserAssignedTo { get; set; }
        public double WorkLeft { get; set; }

        #endregion // Properties
    }
}
