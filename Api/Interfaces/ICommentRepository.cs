﻿using Api.Helpers;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll(QueryObject query);
        Task<Comment> GetById(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment> DeleteAsync(Comment comment);
        Task<Comment> UpdateAsync(Comment comment);
        Task<bool> CommentExists(int id);
    }
}
