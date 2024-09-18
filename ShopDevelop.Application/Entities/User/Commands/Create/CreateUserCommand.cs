using MediatR;

namespace ShopDevelop.Application.Entities.User.Commands.Create
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
