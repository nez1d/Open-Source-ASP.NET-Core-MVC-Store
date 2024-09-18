using MediatR;
using ShopDevelop.Application.Interfaces;

namespace ShopDevelop.Application.Entities.User.Commands.Create
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context) => 
            _context = context;

        public async Task<Guid> Handle(CreateUserCommand command, 
             CancellationToken cancellationToken)
        {
            var user = new ShopDevelop.Domain.Models.User
            {
                Id = command.UserId,
                Login = command.Login,
                Email = command.Email,
                Password = command.Password,
                CreatingDate = DateTime.Now,
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveShangesAsync(cancellationToken);

            return user.Id;
        }
    }
}