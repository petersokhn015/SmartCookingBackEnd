using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class UserPreferences
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public List<Preferences> preferences { get; set; }
    }
}
