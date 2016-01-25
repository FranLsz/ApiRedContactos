using System.Data.Entity.Infrastructure;
using DataModel.ViewModel;
using Repository.Model;

namespace Repository.Adapter
{
    public class ContactoAdapter : Adapter<Contacto, ContactoModel>
    {
        public override Contacto FromViewModel(ContactoModel model)
        {
            return new Contacto()
            {
                IdUsuario = model.IdUsuario,
                IdAmigo = model.IdAmigo
            };
        }

        public override ContactoModel FromModel(Contacto model)
        {
            return new ContactoModel()
            {
                IdUsuario = model.IdUsuario,
                IdAmigo = model.IdAmigo
            };
        }
    }
}