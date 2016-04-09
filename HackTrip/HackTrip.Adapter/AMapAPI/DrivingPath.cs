using HackTrip.Adapter.AMapAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackTrip.Adapter.AMapAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class DrivingPath : QueryBase<PathResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin">经度在前，纬度在后，经度和纬度用","分割，经纬度小数点后不得超过6位。</param>
        /// <param name="destination">经度在前，纬度在后，经度和纬度用","分割，经纬度小数点后不得超过6位。</param>
        /// <param name="strategy">
        /// 0速度优先（时间）

//1费用优先（不走收费路段的最快道路）

//2距离优先

//3不走快速路

//4躲避拥堵

//5多策略（同时使用速度优先、费用优先、距离优先三个策略计算路径）

//6不走高速

//7不走高速且避免收费

//8躲避收费和拥堵

//9不走高速且躲避收费和拥堵
        /// 
        /// 
        /// 
        /// 
        /// </param>
        public DrivingPath(string origin, string destination, string strategy)
        {
            Push("origin", origin);
            Push("destination", destination);
            Push("strategy", strategy);
        }

        public DrivingPath(string origin, string destination, string originid, string destinationid, string strategy)
        {
            Push("origin", origin);
            Push("destination", destination);
            Push("originid", originid);
            Push("destinationid", destinationid);
            Push("strategy", strategy);
        }

        protected override string QueryURL
        {
            get
            {
                return "http://restapi.amap.com/v3/direction/driving";
            }
        }

    }
}
