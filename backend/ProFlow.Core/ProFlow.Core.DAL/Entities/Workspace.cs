using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.DAL.Entities
{
    public class Workspace : AuditSqlServerEntity
    {
        public string Title { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        public Workspace(string title) 
        { 
            Title = title;
        }
    }
}
