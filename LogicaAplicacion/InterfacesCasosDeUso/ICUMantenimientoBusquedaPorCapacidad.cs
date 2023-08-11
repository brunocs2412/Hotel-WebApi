﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCasosDeUso
{
    public interface ICUMantenimientoBusquedaPorCapacidad
    {
        public IEnumerable<DTOInfoMantenimiento> BuscarMantenimientosPorCapacidad(int capMin, int capMax);

    }
}