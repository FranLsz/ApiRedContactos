using System.Data.Entity;
using DataModel.ViewModel;
using Repository.Adapter;
using Repository.Model;
using Repository.Repository;

namespace ApiRedContactos.Repository
{
    public class ContactoRepository : EntityFrameworkRepository<Contacto, ContactoModel, ContactoAdapter>
    {
        public ContactoRepository(DbContext context) : base(context)
        {
        }
    }
}