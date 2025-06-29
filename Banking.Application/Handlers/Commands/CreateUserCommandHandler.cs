using AutoMapper;
using Banking.Application.Common.Interfaces;
using Banking.Application.DTOs.Commands.CreateUser;
using Banking.Core.Entities.Identity;
using Banking.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Check if user already exists
        var existingUser = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingUser != null)
        {
            throw new InvalidOperationException($"User with email '{request.Email}' already exists.");
        }

        // Map command to entity
        var user = _mapper.Map<User>(request);

        // TODO: Password hashing will be implemented later
        user.PasswordHash = request.Password; // Temporary - will be hashed

        // Add user to database
        var createdUser = await _userRepository.AddAsync(user, cancellationToken);

        // Map entity to response
        return _mapper.Map<CreateUserResponse>(createdUser);
    }
}
