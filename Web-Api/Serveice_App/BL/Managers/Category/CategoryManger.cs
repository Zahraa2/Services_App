using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL;

public class CategoryManger : ICategoryManger
{
    private readonly ICategoryRepo categoryRepo;
    public IMapper Mapper { get; }

    public CategoryManger(ICategoryRepo categoryRepo,IMapper mapper)
    {
        this.categoryRepo = categoryRepo;
        Mapper = mapper;
    }

   

    public void Add(CategoryWriteDTO category)
    {
        var repo =Mapper.Map<Category>(category);
        repo.Id = Guid.NewGuid();
        categoryRepo.Add(repo);
        categoryRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo =categoryRepo.GetById(id);
        if (repo != null)
        categoryRepo.Delete(repo);
    }

    public List<CategoryReadDTO> GetAll()
    {
        var repo = categoryRepo.GetAll();
        var DTO =Mapper.Map<List<CategoryReadDTO>>(repo);
        return DTO;
    }

    public CategoryReadDTO? GetByID(Guid id)
    {
        
        var repo =categoryRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO =Mapper.Map<CategoryReadDTO>(repo);
        return DTO;
    }

    public bool Update(CategoryWriteDTO category)
    {
        var repo = categoryRepo.GetById(category.Id);
        if (repo == null)
            return false;

        Mapper.Map(category, repo);
        categoryRepo.SaveChange();
        return true;
    }
    public List<String> GetAllNames()
    { 
        var repo = categoryRepo.GetAll();
        var DTO = Mapper.Map<List<CategoryReadDTO>>(repo);
        List<string> names = DTO.Select(x => x.Name).ToList();
        return names;
    }
}
