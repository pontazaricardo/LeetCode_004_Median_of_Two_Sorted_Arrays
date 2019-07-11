using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array01 = new int[] { 1, 2 };
            int[] array02 = new int[] { 3, 4};
            double median = FindMedianSortedArrays(array01, array02);
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int i = 0;
            int j = 0;

            int[] sorted = new int[nums1.Count() + nums2.Count()];
            int index = 0;

            while ((i < nums1.Count()) || (j < nums2.Count()))
            {
                index = i + j;

                if ((i < nums1.Count()) && (j < nums2.Count()))
                {
                    int nums1Pivot = nums1[i];
                    int nums2Pivot = nums2[j];

                    if (nums1Pivot < nums2Pivot)
                    {
                        sorted[index] = nums1Pivot;
                        i++;
                    }
                    else
                    {
                        sorted[index] = nums2Pivot;
                        j++;
                    }

                }
                else
                {
                    if (i == nums1.Count())
                    {
                        if (nums2.Count() > 0)
                        {
                            while (j < nums2.Count())
                            {
                                index = i + j;
                                sorted[index] = nums2[j];
                                j++;
                            }
                        }

                    }
                    else
                    {
                        if (nums1.Count() > 0)
                        {
                            while (i < nums1.Count())
                            {
                                index = i + j;
                                sorted[index] = nums1[i];
                                i++;
                            }
                        }

                    }
                }
            }

            //At this point, sorted has the sorted matrix. We proceed to calculate the median

            double median = 0;
            int positionMedianEntry1 = 0;
            int positionMedianEntry2 = 0;

            if ((nums1.Count() + nums2.Count()) % 2 == 1)
            {
                positionMedianEntry1 = (nums1.Count() + nums2.Count() - 1) / 2;
                positionMedianEntry2 = positionMedianEntry1;
            }
            else
            {
                positionMedianEntry1 = (nums1.Count() + nums2.Count()) / 2;
                positionMedianEntry2 = positionMedianEntry1 - 1;
            }

            median = (double)((double)(sorted[positionMedianEntry1] + sorted[positionMedianEntry2]) / (double)2);

            return median;
        }
    }
}
