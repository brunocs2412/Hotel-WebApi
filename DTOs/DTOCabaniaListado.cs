﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DTOCabaniaListado
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool PoseeJacuzzi { get; set; }
        public bool HabilitadoReservas { get; set; }
        public int NumHabitacion { get; set; }
        public int CapacidadMaximaPersonas { get; set; }
        public string? NombreFoto { get; set; }
        public string TipoNombre { get; set; }
        public double TipoCostoPorHuesped { get; set; }
    }
}
