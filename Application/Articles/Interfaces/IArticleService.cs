using Application.Articles.DTOs;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Articles.Interfaces
{
    public interface IArticleService: IService<Article, CreateArticleDTO,  UpdateArticleDTO>
    {
    }
}
