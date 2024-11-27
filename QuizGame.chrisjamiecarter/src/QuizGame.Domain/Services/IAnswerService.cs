﻿using QuizGame.Domain.Entities;

namespace QuizGame.Domain.Services;

/// <summary>
/// Defines the contract for a service that manages <see cref="Answer"/> entities.
/// </summary>
public interface IAnswerService
{
    Task<bool> CreateAsync(Answer answer);
    Task<bool> DeleteAsync(Answer answer);
    Task<IEnumerable<Answer>> ReturnAllAsync();
    Task<Answer?> ReturnByIdAsync(Guid id);
    Task<IEnumerable<Answer>> ReturnByQuestionIdAsync(Guid questionId);
    Task<bool> UpdateAsync(Answer answer);
}
