using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IPo
    {
        Task<Po> GetResult(string[] ingredients);
    }
}
