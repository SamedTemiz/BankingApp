using AutoMapper;
using Banking.Application.DTOs.Queries.GetByUserId;
using Banking.Core.Entities.Identity;
using Banking.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Handlers.Queries;

public class GetAllUsersQuery : IRequest<GetAllUsersResponse>
{
    // Pagination parameters can be added here later
}

public class GetAllUsersResponse
{
    public List<GetUserByIdResponse> Users { get; set; } = new();
    public int TotalCount { get; set; }
}

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        var userResponses = _mapper.Map<List<GetUserByIdResponse>>(users);

        return new GetAllUsersResponse
        {
            Users = userResponses,
            TotalCount = userResponses.Count
        };
    }
}
