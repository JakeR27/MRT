﻿namespace MRT.Data.ResultModels;

public record Team : IModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}