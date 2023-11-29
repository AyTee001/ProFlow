namespace ProFlow.Core.DAL.Entities.Base
{
    public abstract class AuditSqlServerEntity : SqlServerEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }

    }
}
