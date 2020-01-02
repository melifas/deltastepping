using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_stepping
{
    class index
    {
        //--------------------------------------------------------------------------------//
        public const int delta = 3;
        public Nodes[] nodes = new Nodes[37];

        public int getNumOfBuckets()
        {
            if ((nodes.Length / delta) % 1 == 0)//true is an integer
            {
                return nodes.Length / delta;
            }
            else
            {
                return (nodes.Length - 1) / delta;
            }
        }
        //------------------------------------------------------------------------------//
        int delta;
        List<int> distanceArr;
        List<bool> activeArr;        
        List<int> weightArr;
        List<int> fromArr;
        List<int> toArr;
        List<int> bucketArray;

//------------------------------------------------------------------------------//
        public bool checkIfAnyNodeIsAtive() 
        {
            for (int i = 0; i < activeArr.Count; i++)
            {
                if (activeArr[i]==true)
                {
                    return true;
                }
            }
            return false;
        }
//------------------------------------------------------------------------------//
        public List<int> searchForEdges(int nodeIndex)
        {
            List<int> edgesIndex = new List<int>();
            for (int i = 0; i < edgesIndex.Count; i++)
            {
                if (nodeIndex == fromArr[i] || nodeIndex == toArr[i])
                {
                    edgesIndex.Add(i);
                }
            }
            return edgesIndex;
        }
//-----------------------------------------------------------------------------------------//

        public void ProcessBucket(int bucketNumber)
        {
            bool isTrue = true;
            while (isTrue)
            {
                isTrue = false;
                for (int i = 0; i < distanceArr.Count; i++)
                {
                    if (activeArr[i] && bucketArray[i] == bucketNumber)
                    {
                        isTrue = true;
                        RelaxNode(i,searchForEdges(i));
                    }
                }
            }
        }
//--------------------------------------------------------------------------------------------//

        public void RelaxNode(int index, List<int> edges)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                var j = edges[i];
                var n = fromArr[j] == index ? toArr[j] : fromArr[j];
                var newDistance = distanceArr[index] + weightArr[j];
                if (newDistance < distanceArr[n])
                {
                    distanceArr[n] = newDistance;
                    activeArr[n] = true;
                    bucketArray[n] = distanceArr[n] / delta;
                }
                activeArr[index] = false;
            }
        }
//---------------------------------------------------------------------------------------------------//
    }
}
