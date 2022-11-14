using ejercicio2_2a.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2_2a.Servicios
{
    public class basededatos
    {
        readonly SQLiteAsyncConnection dbase;

        public basededatos(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            //Creacion de las tablas de la base de datos

            dbase.CreateTableAsync<Signature>(); //Creando la tabla Signature

        }

        #region OperacionesSignature
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateSignature(Signature Signature)
        {
            if (Signature.Id != 0)
            {
                return dbase.UpdateAsync(Signature);
            }
            else
            {
                return dbase.InsertAsync(Signature);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Signature>> getListSignature()
        {
            return dbase.Table<Signature>().ToListAsync();
        }

        public Task<Signature> getSignature(int id)
        {
            return dbase.Table<Signature>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteSignature(Signature Signature)
        {
            return dbase.DeleteAsync(Signature);
        }

        #endregion OperacionesSignature

    }
}
