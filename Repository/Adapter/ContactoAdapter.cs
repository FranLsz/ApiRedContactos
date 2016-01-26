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
                idUsuario = model.IdUsuario,
                idAmigo = model.IdAmigo,
                Fecha = model.Fecha
            };
        }

        public override ContactoModel FromModel(Contacto model)
        {
            return new ContactoModel()
            {
                IdUsuario = model.idUsuario,
                IdAmigo = model.idAmigo,
                Fecha = model.Fecha
            };
        }
    }
}