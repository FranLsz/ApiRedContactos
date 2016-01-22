﻿/*
The next code was generated by Repository Pattern Generator.
Be free to modify this file.

This extension was developed and designed by Francisco López Sánchez.
*/

using Repository.Model;
using DataModel.ViewModel;

namespace Repository.Adapter
{
    public class MensajeAdapter : Adapter<Mensaje, MensajeModel>
    {
        public override Mensaje FromViewModel(MensajeModel model)
        {
            return new Mensaje()
            {
                Id = model.Id,
                IdOrigen = model.IdOrigen,
                IdDestino = model.IdDestino,
                Asunto = model.Asunto,
                Contenido = model.Contenido,
                Leido = model.Leido,
                Fecha = model.Fecha
            };
        }

        public override MensajeModel FromModel(Mensaje model)
        {
            return new MensajeModel()
            {
                Id = model.Id,
                IdOrigen = model.IdOrigen,
                IdDestino = model.IdDestino,
                Asunto = model.Asunto,
                Contenido = model.Contenido,
                Leido = model.Leido,
                Fecha = model.Fecha
            };
        }
    }
}
