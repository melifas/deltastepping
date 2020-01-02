using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_stepping
{
    class Initialize
    {
        public const int delta = 3;

        static List<int> distanceAr = new List<int>(4);

        static List<int> bucketAr = new List<int>(getNumOfBuckets());

        public static int getNumOfBuckets()
        {
            if ((distanceAr.Count / delta) % 1 == 0)//true is an integer
            {
                return distanceAr.Count / delta;
            }
            else
            {
                return (distanceAr.Count - 1) / delta;
            }
        }

//----------------------------------initialize buckets-------------//
       public void bucketrs()
        {           
            for (int i = 0; i < bucketAr.Count; i++)
            {
                bucketAr[i] = getNumOfBuckets() - 1;
                bucketAr[0] = 0;

            }
        }
//-----------------------------------------------------------------------//
    }
}
