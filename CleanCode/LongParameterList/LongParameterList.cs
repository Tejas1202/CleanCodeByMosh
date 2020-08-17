
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    #region All the methods are containing long parameter list (Code smell sign)
    //public class LongParameterList
    //{
    //    public IEnumerable<Reservation> GetReservations(
    //       DateTime dateFrom, DateTime dateTo,
    //       User user, int locationId,
    //       LocationType locationType, int? customerId = null)
    //    {
    //        if (dateFrom >= DateTime.Now)
    //            throw new ArgumentNullException("dateFrom");
    //        if (dateTo <= DateTime.Now)
    //            throw new ArgumentNullException("dateTo");

    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<Reservation> GetUpcomingReservations(
    //        DateTime dateFrom, DateTime dateTo,
    //        User user, int locationId,
    //        LocationType locationType)
    //    {
    //        if (dateFrom >= DateTime.Now)
    //            throw new ArgumentNullException("dateFrom");
    //        if (dateTo <= DateTime.Now)
    //            throw new ArgumentNullException("dateTo");

    //        throw new NotImplementedException();
    //    }

    //    private static Tuple<DateTime, DateTime> GetReservationDateRange(DateTime dateFrom, DateTime dateTo, ReservationDefinition sd)
    //    {
    //        if (dateFrom >= DateTime.Now)
    //            throw new ArgumentNullException("dateFrom");
    //        if (dateTo <= DateTime.Now)
    //            throw new ArgumentNullException("dateTo");

    //        throw new NotImplementedException();
    //    }

    //    public void CreateReservation(DateTime dateFrom, DateTime dateTo, int locationId)
    //    {
    //        if (dateFrom >= DateTime.Now)
    //            throw new ArgumentNullException("dateFrom");
    //        if (dateTo <= DateTime.Now)
    //            throw new ArgumentNullException("dateTo");

    //        throw new NotImplementedException();
    //    }
    //}
    #endregion

    #region Refactored Code
    // Keeping the parameter limit no more than 3 by encapsulating related logical parameters into classes and passing them
    public class DateRange
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class ReservationsQuery
    {
        public DateRange DateRange { get; set; }
        public User User { get; set; }
        public int LocationId { get; set; }
        public LocationType LocationType { get; set; }
        public int CustomerId { get; set; }
    }

    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(ReservationsQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(ReservationsQuery query)
        {
            if (query.DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (query.DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange dateRange, ReservationDefinition sd)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange dateRange, int locationId)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }
    #endregion

    #region Supporting Code
    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
    #endregion
}