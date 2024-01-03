using ResEvi.Data.Entities;

namespace ResEvi.Data.DAO
{
    internal sealed class RecordDAO : AbstractDAO<Record>
    {
        public RecordDAO(AppDbContext context) : base(context)
        {
        }
    }
}