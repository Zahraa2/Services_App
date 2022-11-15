using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public interface IGenericRepo<T>
{
    List<T> GetAll();
    T? GetById(Guid? id);
    void Add(T entity);
    void Edit(T entity);
    void Delete(T entity);
    void SaveChange();
}
