using Manager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Create(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task Remove(long id);
        Task<UserDTO> GetById(long id);
        Task<IList<UserDTO>> Get();
        Task<IList<UserDTO>> SearchByEmail(string email);
        Task<IList<UserDTO>> SearchByName(string name);
        Task<UserDTO> GetByEmail(string email);
    }
}
