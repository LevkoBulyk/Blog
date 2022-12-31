﻿using Blog.Data;
using Blog.IRepositories;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Create(Article article)
        {
            foreach (var item in article.TextItems)
            {
                _context.ArticleTexts.Add(item);
            }
            foreach (var item in article.MediaItems)
            {
                _context.ArticleMedias.Add(item);
            }
            _context.Articles.Add(article);
            return Save();
        }

        public async Task<bool> Delete(int id)
        {
            var article = await _context.Articles.AsNoTracking().FirstAsync(a => a.Id == id);
            _context.Articles.Remove(article);

            foreach (var item in _context.ArticleTexts.AsNoTracking())
            {
                if (item.ArticleId == id)
                {
                    _context.ArticleTexts.Remove(item);
                }
            }

            foreach (var item in _context.ArticleMedias.AsNoTracking())
            {
                if (item.ArticleId == id)
                {
                    _context.ArticleMedias.Remove(item);
                }
            }

            return Save();
        }

        public async Task<IEnumerable<Article>> GetAllArticles()
        {
            var res = new List<Article>();

            foreach (var article in _context.Articles.AsNoTracking())
            {
                var a = await GetArticleById(article.Id);

                res.Add(a);
            }

            return res;
        }

        public async Task<IEnumerable<Article>> GetAllArticlesSorted()
        {
            return (await GetAllArticles()).OrderBy(a => a.LastEdition).ToList();
        }

        public async Task<Article> GetArticleById(int id)
        {
            var article = (await _context.Articles.FirstAsync(a => a.Id == id));

            foreach (var item in _context.ArticleMedias.AsNoTracking())
            {
                if (item.ArticleId == id)
                {
                    article.MediaItems.Add(item);
                }
            }

            foreach (var item in _context.ArticleTexts.AsNoTracking())
            {
                if (item.ArticleId == id)
                {
                    article.TextItems.Add(item);
                }
            }

            return article;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(Article article)
        {
            _context.Articles.Update(article);

            foreach (var item in article.TextItems)
            {
                _context.ArticleTexts.Update(item);
            }

            foreach (var item in article.MediaItems)
            {
                _context.ArticleMedias.Update(item);
            }

            return Save();
        }
    }
}
