using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackTrip.Controllers.Models
{
    public class ResquestMap
    {
        public string CityId { get; set; }
        public List<MapBase> List { get; set; }

    }
    public class MapPostModel
    {
        public string CityId { get; set; }
        public List<string> SelectStateArray { get; set; }
    }
    public class MapBase
    {
        public string Lon { get; set; }
        public string Lat { get; set; }
    }
    public class MapDistance 
    {
        /// <summary>
        /// 距离（米）
        /// </summary>
        public double DistanceId { get; set; }
        /// <summary>
        /// POI ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 出发地
        /// </summary>
        public MapBase startItem { get; set; }
        /// <summary>
        /// 到达地
        /// </summary>
        public MapBase EndItem { get; set; }
        /// <summary>
        /// 时间（秒）
        /// </summary>
        public float Duration { get; set; }
    }

    public class Node
    {
        public string Id { get; set; }
        public MapBase Posi { get; set; }
    }
}