using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCSH
{
    public class PlayerConverter : JsonPlayerConverter<Player>
    {
        protected override Player Create(Type objectType, JObject jObject)
        {
            switch (jObject["Type"].Value<string>())
            {
                case "LabCHS.Machine":
                    return new Machine(jObject["Name"].ToString(), jObject["Symbol"].ToString()[0]);
                case "LabCHS.SmartMachine":
                    return new SmartMachine(jObject["Name"].ToString(), jObject["Symbol"].ToString()[0]);
            }
            return null;
        }
    }
}
