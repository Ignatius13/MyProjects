using Curdoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curdoperations.irespo
{
    public  interface IReservation
    {
        List<resModel> GetAllDetails();
        string insert(resModel sx);
        string delete(int ReservationId);
        
        string update(resModel sx);
        List<SP_Getall_Result> sp_getall();
        //string sp_insert(SP_Getall_Result res);

    }
}
