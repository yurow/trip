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
                            CostSeconds = item.CostSeconds
                        };
                        segment.TripID = tc.TripId;
                        de.TripSegments.Add(segment);
                    }
                }
                Console.WriteLine(i);
            }
            return true;
        }
    }
}
