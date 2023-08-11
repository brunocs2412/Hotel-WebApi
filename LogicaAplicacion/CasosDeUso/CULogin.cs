using DTOs;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso
{
    public class CULogin : ICULogin
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CULogin(IRepositorioUsuario repo)
        {
            RepoUsuario = repo;
        }
        public DTOUsuario Login(string email, string password)
        {
            Usuario usu = RepoUsuario.Login(email, password);

            if (usu == null) return null;
  
            DTOUsuario dtoUsu = new DTOUsuario()
            {
                Email = usu.Email,
                Password = usu.Password
            };

            return dtoUsu;

        }
    }
}
