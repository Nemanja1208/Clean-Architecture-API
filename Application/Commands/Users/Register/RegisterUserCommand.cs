using Application.Dtos.Users;
using Domain.Models.User;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<UserModel>
    {
        public RegisterUserCommand(UserCredentialsDto newUser)
        {
            NewUser = newUser;
        }

        public UserCredentialsDto NewUser { get; }
    }
}
