using ProFlow.Core.DAL.Entities.Base;

namespace ProFlow.Core.DAL.Entities
{
    public class Tag : AuditSqlServerEntity
    {
        public long WorkspaceId { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }

        public Tag(string color, string title) 
        { 
            Color = color;
            Title = title;
        }
    }
}
