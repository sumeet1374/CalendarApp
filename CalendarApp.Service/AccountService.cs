using CalendarApp.Db;
using CalendarApp.Model;
using CalendarApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarApp.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

        public  AccountService(IUnitOfWorkFactory unitOfWorkFactory, IRepository<AppUser> userRepository,IRepository<AppRole> roleRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
       

        public void ChangePassword(string userName, string newPassword)
        {
            throw new NotImplementedException();
        }

        public List<AppRole> GetRoleList()
        {
            using (var unitOfWOrk = _unitOfWorkFactory.Get())
            {
                _roleRepository.Context = unitOfWOrk;
                var roles = _roleRepository.Get(x =>  x.Deleted == false);
                return roles;
            }
        }
        public AppUser Login(string userName, string password)
        {
            using(var unitOfWork = _unitOfWorkFactory.Get())
            {
                _userRepository.Context = unitOfWork;
                var user = _userRepository.GetSingle(x => x.UserName == userName && x.Deleted == false);
                if (user == null)
                    throw new ValidationException("User name does not exists");

                var hashedInput = password.HashString(user.Salt); // Use the same salt value

                if(hashedInput != user.Password)
                    throw new ValidationException("Password does not match.");
                 user.Role =  user.Role; // Enable Lazy Loaded Object
                return user;
                
            }
        }

        public void Register(AppUser user)
        {
            using (var unitOfWOrk = _unitOfWorkFactory.Get())
            {
                _userRepository.Context = unitOfWOrk;
                _roleRepository.Context = unitOfWOrk;
                var roles = _roleRepository.Get(x => x.Id  == user.RoleId  && x.Deleted == false);
                if(roles == null || roles.Count == 0)
                {
                    throw new ValidationException($"Role  does not exists.");
                }
                var hash = user.Password.HashString();
                user.Password = hash.Item1;
                user.Salt = hash.Item2;
                var role = roles[0];
                user.Role = role;
                _userRepository.Add(user);
                unitOfWOrk.Commit();
            }
         
        }

        public bool UserNameExists(string userName)
        {
            using (var unitOfWOrk = _unitOfWorkFactory.Get())
            {
                _userRepository.Context = unitOfWOrk;
                var list = _userRepository.Get(x => x.UserName == userName && x.Deleted == false);
                if (list != null && list.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
