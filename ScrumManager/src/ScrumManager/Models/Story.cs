namespace CoreBusinessObjects.Models
{
    public class Story : BaseClass
    {
        #region Properties

        public int StoryId { get; set; }
        public int Priority { get; set; }
        public string AcceptanceCriteria { get; set; }

        #endregion // Properties
    }
}
