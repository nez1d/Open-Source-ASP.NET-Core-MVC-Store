﻿namespace ShopDevelop.Domain.Contracts.Users;

public class RegisterUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}