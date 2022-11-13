using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class PostManger : IPostManger
{
    private readonly IPostRepo PostRepo;
    public IMapper Mapper { get; }

    public PostManger(IPostRepo PostRepo, IMapper mapper)
    {
        this.PostRepo = PostRepo;
        Mapper = mapper;
    }



    public void Add(PostWriteDTO Post)
    {
        var repo = Mapper.Map<Post>(Post);
        repo.Id = Guid.NewGuid();
        PostRepo.Add(repo);
        PostRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = PostRepo.GetById(id);
        if (repo != null)
            PostRepo.Delete(repo);
    }

    public List<PostReadDTO> GetAll()
    {
        var repo = PostRepo.GetAll();
        var DTO = Mapper.Map<List<PostReadDTO>>(repo);
        return DTO;
    }

    public PostReadDTO? GetByID(Guid id)
    {
        var repo = PostRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<PostReadDTO>(repo);
        return DTO;
    }

    public bool Update(PostWriteDTO Post)
    {
        var repo = PostRepo.GetById(Post.Id);
        if (repo == null)
            return false;

        Mapper.Map(Post, repo);
        PostRepo.SaveChange();
        return true;
    }
}

