using ResEvi.Data.Entities;

namespace ResEvi.Data.DAO
{
    internal sealed class ContactDAO : AbstractDAO<Contact>
    {
        public ContactDAO(AppDbContext context) : base(context)
        {
        }
    }
}