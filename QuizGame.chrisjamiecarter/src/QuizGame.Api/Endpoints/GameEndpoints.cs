﻿using Microsoft.AspNetCore.Mvc;
using QuizGame.Api.Contracts.V1;
using QuizGame.Domain.Entities;
using QuizGame.Domain.Services;

namespace QuizGame.Api.Endpoints;

/// <summary>
/// Defines endpoints for CRUD operations related to <see cref="Game"/>.
/// </summary>
public static class GameEndpoints
{
    public static async Task<IResult> CreateGameAsync([FromBody] GameCreateRequest request, [FromServices] IGameService service)
    {
        var entity = request.ToDomain();

        var created = await service.CreateAsync(entity);

        return created
            ? TypedResults.CreatedAtRoute(entity.ToResponse(), nameof(GetGameAsync), new { id = entity.Id })
            : TypedResults.BadRequest(new { error = "Unable to create game." });
    }

    public static async Task<IResult> GetGameAsync([FromRoute] Guid id, [FromServices] IGameService service)
    {
        var entity = await service.ReturnByIdAsync(id);

        return entity is null
            ? TypedResults.NotFound()
            : TypedResults.Ok(entity.ToResponse());
    }

    public static async Task<IResult> GetGamesAsync([FromServices] IGameService service)
    {
        var entities = await service.ReturnAllAsync();

        return TypedResults.Ok(entities.Select(x => x.ToResponse()));
    }

    public static async Task<IResult> GetPaginatedGamesAsync([FromServices] IGameService service,
                                                             [FromQuery] Guid? quizId = null,
                                                             [FromQuery] DateTime? from = null,
                                                             [FromQuery] DateTime? to = null,
                                                             [FromQuery] string? sort = null,
                                                             [FromQuery] int? index = null,
                                                             [FromQuery] int? size = null)
    {
        if (index < 0 || size < 1)
        {
            return TypedResults.BadRequest(new { error = "Invalid query parameters." });
        }

        var (totalRecords, gameRecords) = await service.ReturnPaginatedGames(quizId, from, to, sort, index, size);

        return TypedResults.Ok(new PaginatedGameResponse(totalRecords, gameRecords.Select(x => x.ToResponse()).ToList()));
    }
}
