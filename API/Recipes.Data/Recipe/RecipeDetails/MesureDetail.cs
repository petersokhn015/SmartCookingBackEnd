using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Data
{
    public class MesureDetail
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unitShort")]
        public string Unit { get; set; }

    }
}
