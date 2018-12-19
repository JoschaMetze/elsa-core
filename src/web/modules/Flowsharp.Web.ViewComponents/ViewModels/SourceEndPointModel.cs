namespace Flowsharp.Web.ViewComponents.ViewModels
{
    public class SourceEndPointModel
    {
        public SourceEndPointModel(string name, string activityId)
        {
            Name = name;
            ActivityId = activityId;
        }
        
        public string Name { get; }
        public string ActivityId { get; }
    }
}