using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios;

public class RepositorioTipo : IRepositorioTipo
{
    private readonly HotelContext _dbHotel;
    public RepositorioTipo(HotelContext dbHotel)
    {
        _dbHotel = dbHotel;
    }

    public void Add(Tipo t)
    {
        try
        {
            if (_dbHotel.Tipos.Any(p => p.Nombre.NombreTipo == t.Nombre.NombreTipo)) throw new TipoException("Ya existe un tipo con ese nombre");
            t.ValidarDatos();
            _dbHotel.Tipos.Add(t);
            _dbHotel.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Tipo BuscarPorNombre(string nombre)
    {
        try
        {
            return _dbHotel.Tipos.FirstOrDefault(p => p.Nombre.NombreTipo == nombre) ?? throw new BusquedaTipoException("No existe un tipo con ese nombre");

        }
        catch (Exception)
        {
            throw;
        }

    }


    public void Delete(int id)
    {
        try
        {
            Tipo tipo = FindById(id);
            _dbHotel.Tipos.Remove(tipo);
            _dbHotel.SaveChanges();
        }
        catch (Exception) { throw; }
    }

    public IEnumerable<Tipo> FindAll()
    {
        try
        {
            var tipos = _dbHotel.Tipos.ToList();
            if (tipos == null) throw new BusquedaTipoException("No hay tipos cargados");
            return tipos;
        }
        catch (Exception)
        {

            throw;
        }

    }

    public Tipo FindById(int id)
    {
        try
        {
            return _dbHotel.Tipos.Find(id) ?? throw new BusquedaTipoException("No hay ningun tipo con ese id");

        }
        catch (Exception)
        {

            throw;
        }
    }


    public void Update(int id, Tipo t)
    {
        try
        {
            t.ValidarDatos();
            _dbHotel.Tipos.Update(t);
            _dbHotel.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }



}
