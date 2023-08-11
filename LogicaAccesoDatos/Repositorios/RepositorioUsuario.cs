using LogicaAccesoDatos.BaseDatos;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAccesoDatos.Repositorios;

public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly HotelContext _dbHotel;

    public RepositorioUsuario(HotelContext HotelContext)
    {
        _dbHotel = HotelContext;
    }

    public void Add(Usuario t)
    {
        try
        {
            if(_dbHotel.Usuarios.Any(p => p.Email == t.Email)) throw new UsuarioException("Ya existe un usuario con ese email");
            t.ValidarDatos();
            _dbHotel.Usuarios.Add(t);
            _dbHotel.SaveChanges();
        }
        catch (UsuarioException ex)
        {
            throw ex;
        }
    }


    public void Delete(int id)
    {
        try
        {
            Usuario usuario = FindById(id) ?? throw new UsuarioException("No existe un usuario con ese id"); ;
            _dbHotel.Usuarios.Remove(usuario);
        }
        catch (UsuarioException ex)
        {

            throw ex;
        }

    }

    public IEnumerable<Usuario> FindAll()
    {
        throw new NotImplementedException();
    }

    public Usuario FindById(int id)
    {
        try
        {
            Usuario usuarioBuscado = _dbHotel.Usuarios.FirstOrDefault(p=>p.Id.Equals(id));
            if (usuarioBuscado == null) throw new UsuarioException("El usuario buscado no existe");
            return usuarioBuscado;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Usuario Login(string email, string password)
    {

        return _dbHotel.Usuarios.FirstOrDefault(p => p.Email.Equals(email) && p.Password.Equals(password));

    }

    public void Update(int id, Usuario t)
    {
        throw new NotImplementedException();
    }
}
