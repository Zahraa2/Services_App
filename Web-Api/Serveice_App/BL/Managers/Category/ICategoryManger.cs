using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public interface ICategoryManger
{
    public List<CategoryReadDTO> GetAll();
    public CategoryReadDTO? GetByID(Guid id);
    public List<string> GetAllNames();
    public void Add(CategoryWriteDTO category);
    public bool Update(CategoryWriteDTO category);
    public void Delete(Guid id);
}
