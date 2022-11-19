using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly DatabaseContext _context;
    public GenericRepo(DatabaseContext context)
    {
        _context = context;
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public T? GetById(Guid? id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }
    public void Edit(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void SaveChange()
    {
        _context.SaveChanges();
    }

    
}
