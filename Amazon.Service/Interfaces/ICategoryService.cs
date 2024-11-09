using Amazon.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service.Interfaces
{
    public interface ICategoryService
    {
        public Task<Category> create();
    }
}
