﻿using MediatR;

namespace RenStore.Application.Entities.Product.Commands.Delete;

public class DeleteProductCommand : IRequest
{
    public Guid ProductId { get; set; }
}