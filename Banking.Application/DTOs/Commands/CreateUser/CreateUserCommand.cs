﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.DTOs.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreateUserResponse>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
