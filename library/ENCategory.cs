﻿using System;
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
        //public int Id { get; set; }  // Identificador de la categoría
        public ENCategory()
        {
            Name = "POR_DEFECTO";
            //Id = 0;
        }

        //public ENCategory(string name,int id)
        public ENCategory(string name)
        {
            Name = name;
            //Id = id;
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
