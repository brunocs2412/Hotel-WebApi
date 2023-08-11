﻿using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios;

public interface IRepositorioUsuario : IRepositorio<Usuario>
{
    public Usuario Login(string email, string password);   
}
