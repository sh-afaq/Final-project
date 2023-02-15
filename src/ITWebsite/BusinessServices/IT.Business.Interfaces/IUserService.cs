﻿using IT.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Business.Interfaces
{
    public interface IUserService
    {
        public List<UserModel> GetAll();
        public List<UserModel> Search(string searchTerm);
        public void Add(UserModel model);
        public void Update(UserModel model);
        public void Delete(int id);
    }
}
