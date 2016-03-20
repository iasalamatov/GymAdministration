using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAdministration
{
    class Factory
    {
        private static Repository _rep;

        public static Repository GetRepository()
        {
            if (_rep == null)
                _rep = new Repository();
            return _rep;
        }
    }
}
