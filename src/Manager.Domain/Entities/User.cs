using System;
using System.Collections.Generic;
using System.Linq;
using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //EF
        protected User() {}
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _erros = new List<string>();
            Validate();
        }

        public void ChangeName(string name) 
        {
            Name = name;
            Validate();
        }   

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void ChangeEmail(string email) 
        {
            Email = email;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid) 
            {
                foreach (var error in validation.Errors)
                    _erros.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, pro favor corrija-os!", _erros);
            }

            return true;
        }
    }
}