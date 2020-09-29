using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    interface IOfferOrderOrgnizer
    {
        IOrderedQueryable<Offer> OrderOffers(IQueryable<Offer> offers);
    }
    class OfferOrderOrgnizer : IOfferOrderOrgnizer
    {

        public IOrderedQueryable<Offer> OrderOffers(IQueryable<Offer> offers)
        {
            return offers.OrderBy(offer =>
                    offer.CustomerBrunch.Average(bo => bo.CustomerBrunches.Average(cbo => cbo.Rate)));
        }
    }
}
