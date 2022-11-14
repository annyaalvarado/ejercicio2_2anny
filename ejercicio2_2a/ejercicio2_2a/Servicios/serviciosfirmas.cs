using ejercicio2_2a.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio2_2a.Servicios
{
    public class serviciosfirmas
    {
        public async Task<bool> saveSignatures(Signature signature)
    {
        var result = await App.DBase.insertUpdateSignature(signature);

        return (result > 0);

    }


    public async Task<List<Signature>> GetSignatures()
    {
        return await App.DBase.getListSignature();
    }


}
}

