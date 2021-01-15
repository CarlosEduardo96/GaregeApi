using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaregeApi.InterfaceDTOs
{
    interface QueryDTO<ModelQueryData>
    {
        public ModelQueryData SelectById(int id);

        public ModelQueryData SelectByName(ModelQueryData type);

        public ModelQueryData Find(ModelQueryData type);

        public ModelQueryData Insert(ModelQueryData type);

        public ModelQueryData Update(ModelQueryData type);

        public ModelQueryData Delete(int id);
    }
}
