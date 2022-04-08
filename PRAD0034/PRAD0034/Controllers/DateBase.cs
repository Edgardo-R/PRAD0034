using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRAD0034.Models;
using System.Threading.Tasks;

namespace PRAD0034.Controllers
{
    public static class DateBase
    {
        public static SQLiteAsyncConnection dbconexion;
        public static void Conexion(string dbpath)
        {
            dbconexion = new SQLiteAsyncConnection(dbpath);
            dbconexion.CreateTableAsync<Pagos>();
        }
        public static Task<List<Pagos>> ObtenerListaPagos()
        {
            return DateBase.dbconexion.Table<Pagos>().ToListAsync();
        }
        public static Task<int>AddPago(Pagos pago)
        {
            if(pago.Id_pago!=0)
            {
                return DateBase.dbconexion.UpdateAsync(pago);
            }
            else
            {
                return DateBase.dbconexion.InsertAsync(pago);
            }
        }
        public static Task<Pagos>ObtenerPago(int pid)
        {
            return DateBase.dbconexion.Table<Pagos>().Where(i => i.Id_pago == pid).FirstOrDefaultAsync();
        }
        public static Task<int>DelPago(Pagos pago)
        {
            return DateBase.dbconexion.DeleteAsync(pago);
        }
    }
}
