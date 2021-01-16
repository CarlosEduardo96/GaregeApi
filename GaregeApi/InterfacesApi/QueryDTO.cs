using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaregeApi.InterfaceDTOs
{
    /// <summary>
    /// Asigna los modelo acordado en la Querys
    /// <para> Crea los metodos para realizar las consultas <see cref="QueryDTO{ModelQueryData}"/> </para>
    /// </summary>
    /// <typeparam name="ModelQueryData"></typeparam>
    interface QueryDTO<ModelQueryData>
    {
        public ModelQueryData SelectById(int id);

        public List<ModelQueryData> Find(string search, int Colums);

        public List<ModelQueryData> SelectAll();

        public ModelQueryData Insert(ModelQueryData type);

        public ModelQueryData Update(ModelQueryData type);

        public ModelQueryData Delete(int id);
    }
}
