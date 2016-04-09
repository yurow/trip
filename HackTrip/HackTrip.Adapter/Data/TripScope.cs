using HackTrip.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.Data
{
    public class TripScope
    {
        public bool NewTrip(TripDataModel model)
        {
            using (Database1Entities de = new Database1Entities())
            {
                TripCollection tc = new TripCollection();
                tc.Origin = model.Origin;
                tc.Topic = model.Topic;
                tc.Destination = model.Destination;
                de.TripCollections.Add(tc);
                var i = de.SaveChanges();

                if (model.Segments != null)
                {
                    foreach (var item in model.Segments)
                    {
                        TripSegment segment = new TripSegment()
                        {
                            Topic = item.Topic,
                            StartTime = item.StartTime,
                            SegmentType = item.SegmentType,
                            Posi = item.Posi,
                            Index = item.Index,
                            CostSeconds = item.CostSeconds,
                            Destination = item.Destination,
                            Distance = item.Distance,
                            Origin = item.Origin,
                           
                        };
                        segment.TripID = tc.TripId;
                        de.TripSegments.Add(segment);
                        de.SaveChanges();
                    }
                }
               
                Console.WriteLine(i);
            }
            return true;
        }

        public TripDataModel GetTrip(long tripId)
        {
            using (Database1Entities de = new Database1Entities())
            {
                IQueryable<TripCollection> trips = de.TripCollections.Where<TripCollection>(s => s.TripId == tripId);
                IQueryable<TripSegment> segments = de.TripSegments.Where<TripSegment>(s => s.TripID == tripId);
                var tc = trips.First();
                TripDataModel tm = new TripDataModel() { TripId = tripId, Origin = tc.Origin };
                tm.Segments = new List<SegmentDataModel>();
                foreach (var item in segments)
                {
                    tm.Segments.Add(new SegmentDataModel()
                    {
                        CostSeconds = item.CostSeconds,
                        Index = item.Index,
                        Posi = item.Posi,
                        SegmentID = item.SegmentID,
                        SegmentType = item.SegmentType,
                        StartTime = item.StartTime,
                        Topic = item.Topic,
                        TripID = item.TripID
                    });
                }
                return tm;
            }
        }
        public TripDataModel GetLastTripData()
        {
            using (Database1Entities de = new Database1Entities())
            {
                IQueryable<TripCollection> trips = de.TripCollections.Max<TripCollection>(s => Max(s.TripId));
                IQueryable<TripSegment> segments = de.TripSegments.Max<TripSegment>(s => Max(s.TripId));
                var tc = trips.First();
                TripDataModel tm = new TripDataModel() { TripId = tripId, Origin = tc.Origin };
                tm.Segments = new List<SegmentDataModel>();
                foreach (var item in segments)
                {
                    tm.Segments.Add(new SegmentDataModel()
                    {
                        CostSeconds = item.CostSeconds,
                        Index = item.Index,
                        Posi = item.Posi,
                        SegmentID = item.SegmentID,
                        SegmentType = item.SegmentType,
                        StartTime = item.StartTime,
                        Topic = item.Topic,
                        TripID = item.TripID
                    });
                }
                return tm;
            }
        }
    }
}
