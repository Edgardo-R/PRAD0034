using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PRAD0034.Models
{
    public class Pagos
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pago { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] Photo_recibo { get; set; }
    }
}
