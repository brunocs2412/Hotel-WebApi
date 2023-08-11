using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAccesoDatos.Repositorios;

public class RepositorioCabania : IRepositorioCabania
{

    private readonly HotelContext _dbHotel;

    public RepositorioCabania(HotelContext HotelContext)
    {
        _dbHotel = HotelContext;
    }
 
    public IEnumerable<Cabania> BuscarHablitadas()
    {
        try
        {
             var cabanias =_dbHotel.Cabanias.Where(p => p.HabilitadoReservas.Equals(true)).
                                    Include(p => p.Tipo)
                                    .Include(p => p.Fotos)
                                    .ToList();

            if(cabanias.Count() == 0) throw new CabaniaException("No se encontraron cabañas habilitadas");

            return cabanias;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public IEnumerable<Cabania> BuscarPorCantMaxPersonas(int cantidad)
    {
        try
        {
            IEnumerable<Cabania> cabanias = _dbHotel.Cabanias.Where(p => p.CapacidadMaximaPersonas >= cantidad)
                                                        .Include(p => p.Fotos)
                                                        .Include(p => p.Tipo)
                                                        .ToList();
            if (cabanias.Count() == 0)
            {
                throw new CabaniaException("No se encontraron cabañas con esa cantidad de lugares");
            }

            return cabanias;
        }
        catch (Exception)
        {

            throw;
        }
       
    }

    public IEnumerable<Cabania> BuscarPorNombre(string nombre)
    {
        try
        {
            IEnumerable<Cabania> cabanias = _dbHotel.Cabanias.Where(p => p.Nombre.Nombre.Contains(nombre))
                                                             .Include(p => p.Fotos)
                                                             .Include(p => p.Tipo)
                                                             .ToList();
            if (cabanias.Count() == 0)
            {
                throw new CabaniaException("No se encontraron cabañas con ese nombre");
            }

            return cabanias;
        }
        catch (Exception) {

            throw;
        }
    }

    public IEnumerable<Cabania> BuscarPorTipo(int tipoId)
    {
        try
        {
            IEnumerable<Cabania> cabanias = _dbHotel.Cabanias.Where(p => p.Tipo.Id == tipoId)
                                                     .Include(p => p.Fotos)
                                                     .Include(p => p.Tipo)
                                                     .ToList();
            if (cabanias.Count() == 0)
            {
                throw new CabaniaException("No se encontraron cabañas de ese tipo");
            }

            return cabanias;
        }
        catch (Exception)
        {

            throw;
        }

    }

    public void Update(int id, Cabania cabania)
    {
        try
        {
            if (cabania == null) throw new UsuarioException("Todos los datos son obligatorios");
            cabania.ValidarDatos();


            _dbHotel.Cabanias.Update(cabania);
            _dbHotel.SaveChanges();
        }
        catch (CabaniaException ex)
        {
            throw ex;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Add(Cabania t)
    {
        try
        {
            if (_dbHotel.Cabanias.Any(p => p.Nombre.Nombre == t.Nombre.Nombre)) throw new CabaniaException("Ya existe una cabaña con ese nombre");
            if(_dbHotel.Cabanias.Any(p=>p.NumHabitacion == t.NumHabitacion)) throw new CabaniaException("Ya existe una cabaña con ese numero de habitacion");
            t.ValidarDatos();
            _dbHotel.Cabanias.Add(t);
            _dbHotel.SaveChanges();

            t.NumHabitacion = t.Id;
            _dbHotel.SaveChanges();
        }
        catch (Exception e)
        {

            throw;
        }

    }

    public IEnumerable<Cabania> FindAll()
    {
        try
        {
            var cabanias = _dbHotel.Cabanias.Include(f => f.Fotos)
                             .Include(f => f.Tipo).ToList();

            if (cabanias.Count() == 0) throw new CabaniaException("No se encontraron cabañas");

            return cabanias;
        }
        catch (Exception)
        {

            throw;
        }

    }

    public Cabania FindById(int id)
    {
        try
        {
            return _dbHotel.Cabanias.Include(c => c.Fotos)
                                    .Include(c=> c.Tipo)
                                    .FirstOrDefault(c => c.Id.Equals(id));

        }
        catch (CabaniaException ex)
        {

            throw ex;
        }
    }

    public void Delete(int id)
    {
        try
        {
            Cabania cabania = FindById(id);

            _dbHotel.Cabanias.Remove(cabania);
            _dbHotel.SaveChanges();
        }
        catch (CabaniaException ex)
        {

            throw ex;
        }
    }

    public string NuevoNombreFoto(Cabania cabania)
    {
        Cabania cabaniaConFotos = _dbHotel.Cabanias.Include(c => c.Fotos).FirstOrDefault(c => c.Id.Equals(cabania.Id));

        return cabaniaConFotos.SiguienteFotoYCambiarNombre(cabania.Nombre.Nombre);
    }

    public Cabania CabaniaConTodosSusMantenimientos(int CabaniaId)
    {
        try
        {
            return _dbHotel.Cabanias.Include(c => c.Mantenimientos).FirstOrDefault(c => c.Id.Equals(CabaniaId));
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public int ContarCuantosMantenimientosTieneUnaCabaniaEnUnDia(int CabaniaId, DateTime fecha)
    {
        try
        {
            return _dbHotel.Cabanias.Include(c => c.Mantenimientos).FirstOrDefault(c => c.Id.Equals(CabaniaId)).Mantenimientos.Count(m => m.Fecha.Date == fecha.Date);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public Cabania ListarMantenimientosRealizadosAUnaCabaniaEntreDosFechas(int Cabania, DateTime fecha1, DateTime fecha2)
    {
        try
        {
            var cabania = _dbHotel.Cabanias
                            .Include(c => c.Mantenimientos)
                            .FirstOrDefault(c => c.Id == Cabania);

            if (cabania == null) throw new CabaniaException("No se encontró la cabaña");

            cabania.Mantenimientos = cabania.Mantenimientos
                                .Where(m => m.Fecha.Date >= fecha1.Date && m.Fecha.Date <= fecha2.Date)
                                .OrderByDescending(m => m.Costo)
                                .ToList();

            if (cabania.Mantenimientos.Count() == 0) throw new MantenimientoException("No se encontraron mantenimientos en ese rango de fechas");

            return cabania;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public bool ValidarSiTipoEstaEnUso(int tipoId)
    {
        try
        {
            return _dbHotel.Cabanias.Any(p => p.Tipo.Id.Equals(tipoId));

        }
        catch (Exception)
        {

            throw;
        }
    }

    public void AddMantenimiento(Mantenimiento m) {
        try
        {
            Cabania c = FindById(m.CabaniaId);

            if (c != null)
            {
                //Valida como 3 maximo de mantenimientos por dia
                int contadorMantenimientos = ContarCuantosMantenimientosTieneUnaCabaniaEnUnDia(c.Id, m.Fecha);
                if (contadorMantenimientos >= 3) throw new MantenimientoException("No se puede realizar mas de 3 mantenimientos en un dia");
                if (m.Fecha > DateTime.Now.Date) throw new MantenimientoException("No se puede registrar mantenimientos con fecha superior a la de hoy");

                //Se agrega el mantenimiento a la cabaña seleccionada a la lista de mantenimientos y se actualiza la cabaña 
                List<Mantenimiento> mantenimientosCabania = c.Mantenimientos.ToList();
                m.ValidarDatos();
                mantenimientosCabania.Add(m);
                c.Mantenimientos = mantenimientosCabania;
                Update(m.CabaniaId, c);
            }
            else {
                throw new MantenimientoException("No se ha encontrado la cabaña seleccionada");
            }

        }
        catch (Exception)
        { 
            throw;
        }
    }

    public IEnumerable<Cabania> BuscarPorTipoYMonto(int monto)
    {
        try
        {
            var cabanias = _dbHotel.Cabanias
                    .Include(c => c.Tipo)
                    .Where(c => c.Tipo.CostoPorHuesped.Costo < monto && c.HabilitadoReservas && c.PoseeJacuzzi)
                    .Include(c => c.Fotos);

            if (cabanias.Count() == 0) throw new CabaniaException("No se encontraron cabanias menores a ese monto hablitadas y con jacuzzi");

            return cabanias;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public IEnumerable<object> BuscarMantenimientosPorCapacidadEInformacionDeQuienLoHizo(int capMin, int capMax)
    {
        try
        {
            //key seria el nombre del trabajador es lo que esta en el group by
            var mantenimientos = _dbHotel.Mantenimientos
                .Include(m => m.Cabania)
                .Where(m => m.Cabania.CapacidadMaximaPersonas >= capMin && m.Cabania.CapacidadMaximaPersonas <= capMax)
                .GroupBy(m => m.NombreTrabajador)
                .Select(m => new
                {
                    Nombre = m.Key,
                    MontoTotal = m.Sum(m => m.Costo)
                });

            if (mantenimientos.Count() == 0) throw new MantenimientoException("No se encontraron mantenimientos en ese rango de capacidad");

            return mantenimientos;

        }
        catch (Exception)
        {

            throw;
        }
    }
}
