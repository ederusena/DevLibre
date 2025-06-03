using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevLibre.Services
{
    public interface IConfigService
    {
        int GetValue();
    }

    public class ConfigService : IConfigService
    {
        private int _value;
        public int GetValue()
        {
            _value++;

            return _value;
        }
    }
}