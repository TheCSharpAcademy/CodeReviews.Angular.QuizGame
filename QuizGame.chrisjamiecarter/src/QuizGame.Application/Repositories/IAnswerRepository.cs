﻿using QuizGame.Domain.Entities;

namespace QuizGame.Application.Repositories;

/// <summary>
/// Defines the contract for performing CRUD operations on <see cref="Answer"/> entities in the
/// data store.
/// </summary>
public interface IAnswerRepository
{
    Task CreateAsync(Answer answer);
    Task DeleteAsync(Answer answer);
    Task<IReadOnlyList<Answer>> ReturnAsync();
    Task<Answer?> ReturnAsync(Guid id);
    Task<IReadOnlyList<Answer>> ReturnByQuestionIdAsync(Guid questionId);
    Task UpdateAsync(Answer answer);
}
