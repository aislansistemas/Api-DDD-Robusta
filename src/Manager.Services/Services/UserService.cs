using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscNet.Cryptography.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRijndaelCryptography _rijndaelCryptography;
        public UserService(IMapper mapper, IUserRepository userRepository, IRijndaelCryptography rijndaelCryptography)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _rijndaelCryptography = rijndaelCryptography;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);
            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado com o email informado");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.ChangePassword(_rijndaelCryptography.Encrypt(user.Password));

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<IList<UserDTO>> Get()
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<IList<UserDTO>>(allUsers);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetById(long id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<IList<UserDTO>> SearchByEmail(string email)
        {
            var users = await _userRepository.SearchByEmail(email);

            return _mapper.Map<IList<UserDTO>>(users);
        }

        public async Task<IList<UserDTO>> SearchByName(string name)
        {
            var users = await _userRepository.SearchByName(name);

            return _mapper.Map<IList<UserDTO>>(users);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetById(userDTO.Id);
            if (userExists == null)
                throw new DomainException("Não existe nenhum usuário com o id informado!");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();
            user.ChangePassword(_rijndaelCryptography.Encrypt(user.Password));

            var userUpdated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }
    }
}
