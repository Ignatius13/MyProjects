using Curdoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Curdoperations.irespo
{
    public class Resevec : IReservation
    {
            CRUDDBEntities sx = new CRUDDBEntities();
         public List<resModel>  GetAllDetails()
        {
            List<resModel> resList = sx.Reservations.Select(s => new resModel()
            {
                ReservationId= s.ReservationId,
                Hotel= s.Hotel,
                Arrival= s.Arrival,
                Departure= s.Departure,
                Type= s.Type,
                Guest= s.Guest,
                Price= s.Price,


            }).ToList<resModel>();
            return resList;

        }

        public List<SP_Getall_Result> sp_getall()
        {
            var abc=sx.SP_Getall().ToList<SP_Getall_Result>();
            return abc;
        }

        //public string sp_insert(SP_Getall_Result res)
        //{
        //    var abc = sx.SP_Insert(res.ReservationId, res.Hotel,res.Arrival.ToString(), res.Departure, res.Type, res.Guest, res.Price);
        //    return "inserted";
        //}

        string IReservation.delete(int ReservationId)
         {
            var edf = sx.Reservations.Where(a => a.ReservationId == ReservationId);
            if (edf != null)
            {
                sx.Reservations.Remove(edf.FirstOrDefault());
                sx.SaveChanges();
                return "Deleted";
            }
            return "not available";

        }

        string IReservation.insert(resModel em)
        {
            var abc = sx.Reservations.Where(i => i.ReservationId == em.ReservationId).FirstOrDefault();
            if (abc == null)
            {
                sx.Reservations.Add(new Reservation
                {
                    ReservationId = em.ReservationId,
                    Hotel = em.Hotel,
                    Arrival = em.Arrival,
                    Departure = em.Departure,
                    Type = em.Type,
                    Guest = em.Guest,
                    Price = em.Price,



                });
            
            sx.SaveChanges();
            return "inserted"; 
            }

            else
            {
                abc.ReservationId = em.ReservationId;
                abc.Hotel = em.Hotel;
                abc.Arrival = em.Arrival;
                abc.Departure = em.Departure;
                abc.Type = em.Type;
                abc.Guest = em.Guest;
                abc.Price = em.Price;

            }
            sx.SaveChanges();
            return "Updated";

        }
        

        string IReservation.update(resModel em)
        {
            var abc = sx.Reservations.Where(u => u.ReservationId == em.ReservationId).FirstOrDefault();
            if (abc != null)
            {
                abc.ReservationId = em.ReservationId;
                abc.Hotel = em.Hotel;
                abc.Arrival = em.Arrival;
                abc.Departure = em.Departure;
                abc.Type = em.Type;
                abc.Guest = em.Guest;
                abc.Price = em.Price;

            }
            sx.SaveChanges();
            return "Updated";
        }
    }
}


