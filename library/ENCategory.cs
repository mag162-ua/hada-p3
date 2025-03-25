using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        public string Name { get; set; }  // Nombre de la categoría

        public ENCategory(string name)
        {
            Name = name;
        }

        public bool Read(ENCategory en)
        {
            CADCategory bd=new CADCategory();
            return bd.Read(this);
        }

        // Método para obtener todas las categorías
        public List<ENCategory> ReadAll()
        {
            CADCategory bd = new CADCategory();
            return bd.ReadAll();
        }
    }
}
