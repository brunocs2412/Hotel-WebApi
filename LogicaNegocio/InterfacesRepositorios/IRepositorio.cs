using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios;

public interface IRepositorio<T> 
{
    void Add(T t);
    void Update(int id,T t);

    void Delete(int id);

    T FindById(int id);

    IEnumerable<T> FindAll();
}
