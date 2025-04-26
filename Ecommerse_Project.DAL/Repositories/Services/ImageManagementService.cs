using Ecommerse_Project.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Repositories.Services
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider _fileProvider;

        public Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            throw new NotImplementedException();
        }

        public Task DeleteImageAsync(string src)
        {
            throw new NotImplementedException();
        }
    }
}
