using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL;

public class PostManger : IPostManager
{
    private readonly IPostRepo _postRepo;
    private readonly IMediaRepo _mediaRepo;
    private readonly IMapper _Mapper;

    public PostManger(IPostRepo PostRepo, IMapper mapper, IMediaRepo mediaRepo)
    {
        _postRepo = PostRepo;
        _Mapper = mapper;
        _mediaRepo = mediaRepo;
    }



    public void Add(PostWriteDTO Post)
    {
        var repo = _Mapper.Map<Post>(Post);
        repo.Id = Guid.NewGuid();
        _postRepo.Add(repo);
        _postRepo.SaveChange();
    }

    public void Delete(Guid id)
    {
        var repo = _postRepo.GetById(id);
        if (repo != null)
            _postRepo.Delete(repo);
    }

    public List<PostReadDTO> GetAll()
    {
        var repo = _postRepo.GetAll();
        var DTO = _Mapper.Map<List<PostReadDTO>>(repo);
        return DTO;
    }

    public PostReadDTO? GetByID(Guid id)
    {
        var repo = _postRepo.GetById(id);
        if (repo == null)
            return null;
        var DTO = _Mapper.Map<PostReadDTO>(repo);
        return DTO;
    }

    public bool Update(PostWriteDTO Post)
    {
        var repo = _postRepo.GetById(Post.Id);
        if (repo == null)
            return false;

        _Mapper.Map(Post, repo);
        _postRepo.SaveChange();
        return true;
    }

    public List<MediasforPost> GetPostsOfProvider(Guid providerId)
    {
        var posts = _postRepo.GetPostsOfProvider(providerId);
        List<MediasforPost> MediasforPost = new List<MediasforPost>();
        foreach(var post in posts)
        {
            var mediaForPost = _Mapper.Map<MediasforPost>(post);
            mediaForPost.Imgs = _mediaRepo.GetimgsOfPost(post.Id);
            MediasforPost.Add(mediaForPost);
        }

        return MediasforPost;
    }
}

