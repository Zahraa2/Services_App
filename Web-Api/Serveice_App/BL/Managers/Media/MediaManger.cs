using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class MediaManger : IMediaManger
{
    private readonly IMediaRepo MediaRepo;
    public IMapper Mapper { get; }

    public MediaManger(IMediaRepo MediaRepo, IMapper mapper)
    {
        this.MediaRepo = MediaRepo;
        Mapper = mapper;
    }



    public void Add(MediaWriteDTO Media)
    {
        var repo = Mapper.Map<Media>(Media);
        repo.Id = Guid.NewGuid();
        MediaRepo.Add(repo);
        MediaRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = MediaRepo.GetById(id);
        if (repo != null)
            MediaRepo.Delete(repo);
    }

    public List<MediaReadDTO> GetAll()
    {
        var repo = MediaRepo.GetAll();
        var DTO = Mapper.Map<List<MediaReadDTO>>(repo);
        return DTO;
    }

    public MediaReadDTO? GetByID(Guid id)
    {
        var repo = MediaRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = Mapper.Map<MediaReadDTO>(repo);
        return DTO;
    }

    public bool Update(MediaWriteDTO Media)
    {
        var repo = MediaRepo.GetById(Media.Id);
        if (repo == null)
            return false;

        Mapper.Map(Media, repo);
        MediaRepo.SaveChange();
        return true;
    }
}
