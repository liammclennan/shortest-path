using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShortestPath.Core.Domain;

namespace ShortestPath.Test.Creators
{
    public class GraphMother
    {
        public static DirectedGraph ChannelDelanceyThornlandsBeckwith
        {
            get
            {
                return new DirectedGraph(new[]
                      {
                          PointMother.DelanceySt, PointMother.ChannelSt, PointMother.ThornlandsRd,
                          PointMother.BeckwithSt
                      });
            }
        }

        public static DirectedGraph DesMoines
        {
            get
            {
                return new DirectedGraph(new[] 
                        {
                            PointMother.USAPoints.LocustSt,PointMother.USAPoints.AshworthRd, PointMother.USAPoints.UniversityAve, PointMother.USAPoints.RaccoonSt, PointMother.USAPoints.ShawSt, PointMother.USAPoints.LocustSt 
                        });
            }
        }
    }
}
