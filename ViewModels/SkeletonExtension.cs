using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace IKinea.ViewModels
{
    public class SkeletonMath
    {
        public static SkeletonPoint Barycentric(params SkeletonPoint[] skeletonPoints)
        {
            SkeletonPoint bary = new SkeletonPoint();
            foreach (SkeletonPoint skeletonPoint in skeletonPoints)
            {
                bary.X += skeletonPoint.X;
                bary.Y += skeletonPoint.Y;
                bary.Z += skeletonPoint.Z;
            }
            bary.X /= (float)skeletonPoints.Length;
            bary.Y /= (float)skeletonPoints.Length;
            bary.Z /= (float)skeletonPoints.Length;

            return bary;
        }

        public static float Distance(SkeletonPoint skeletonPoint1, SkeletonPoint skeletonPoint2)
        {
            float x = skeletonPoint1.X - skeletonPoint2.X;
            float y = skeletonPoint1.Y - skeletonPoint2.Y;
            float z = skeletonPoint1.Z - skeletonPoint2.Z;
            float sq = x * x + y * y + z * z;
            return (float)Math.Sqrt((double)sq);
        }
    }
}
