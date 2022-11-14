using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ejercicio2_2a.Models
{
    public class Signature
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Byte[] ArrayByteImage { get; set; }
    }
}
