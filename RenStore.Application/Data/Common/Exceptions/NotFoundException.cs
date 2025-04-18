﻿namespace RenStore.Application.Data.Common.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(Type name, object key)
        : base($"Entity \"{name}\" ({key}) not found.") { }
}