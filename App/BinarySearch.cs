using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

namespace Problemsolving;
public static class BinarySearch
{
   
    /// <summary>
    /// get number of items that you can buy using binary search algorithim 
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="maxcoins"></param>
    /// <returns></returns>
    public static int Get_Items_Count(int[] prices , int maxcoins)
    {
        Array.Sort(prices);
        int l = 0;
        int r = prices.Length-1;
        int ans = 0;
        int mid; 
        while (l <= r)
        {
            mid  = (l+r)/2;
            if (maxcoins>=prices[mid])
            {
                l=ans=mid+1;
             
            }
            else
            {
                r = mid - 1;
            }
        }
        return ans;
    }

    /// <summary>
    /// Get maximum median <paramref name="arr"/> represent the integers <paramref name="k"/> max count of one’s
    /// </summary>
    /// <remarks>
    /// this implemntation its time complixity = Knlog(n)
    /// </remarks>
    /// <param name="arr"></param>
    /// <param name="k"></param>
    /// <returns>maximum median</returns>
    public static int GetMaxmedianV1(int[] arr , int k)
    {
        Array.Sort(arr);
        
        int l = 0 , r  = arr.Length-1;
        int mid = (l + r) / 2;

        while (--k >= 0)
        {
            arr[mid]++;
            Array.Sort(arr);
        }

        return arr[mid];

    }


    /// <summary>
    /// Get maximum median <paramref name="arr"/> represent the integers <paramref name="k"/> max count of one’s
    /// </summary>
    /// <remarks>
    /// this implemntation its time complixity = nlog(n)
    /// </remarks>
    /// <param name="arr"></param>
    /// <param name="k"></param>
    /// <returns>maximum median</returns>
    public static int GetMaxmedianV2(int[] arr, int k )
    {
       bool can(int mid, int[] arr, int k)
        {
            int sum = 0;
            int i = (arr.Length - 1) / 2;
            while (i < arr.Length)
            {
                if (arr[i] < mid)
                    sum += mid - arr[i];
                i++;

            }
            return sum <= k;
        }

        Array.Sort(arr);
        var mid = (arr.Length - 1) / 2;
        var minMadient= arr[mid];
        var maxMadient = arr[mid] + k;
        var ans = -1;
        while(minMadient<=maxMadient)
        {
            mid = (maxMadient + minMadient) / 2;
            if (can(mid, arr, k))
            {
                minMadient = mid + 1;
                ans = mid;
            }
            else
                maxMadient = mid - 1;
        }
        return ans;
    }



    

    /// <summary>
    /// guess Smallest number achieve this condition v + v/<paramref name="k"/>+ v/<paramref name="k"/>^2 + v/<paramref name="k"/>^3 + ... +v/<paramref name="k"/>^p >= <paramref name="n"/> till v/<paramref name="k"/>^p equals Zero
    /// </summary>
    /// <remarks>
    /// this number is v which divided by <paramref name="k"/> every time 
    /// </remarks>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public static int  GuessV(int n , int k)
    {
         bool can(int mid, int n, int k)
        {
            int sum = mid;
            while (mid != 0)
            {
                sum += mid / k;
                mid /= k;
            }
            return sum >= n;
        }

        int l = 1, r = n;
        int ans = n;
        int mid; 
        while (l <= r)
        {
            mid = (l + r) / 2; 
            if (can(mid,n,k))
            {
                ans = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }

        }
        return ans; 
    }


    /// <summary>
    /// you have <paramref name="candiesamount"/> you have to destribute candies on the maximum number of childern on condition everyone get distinct amount  
    /// </summary>
    /// <param name="candiesamount"></param>
    /// <returns></returns>
    public static int whogetcandy(int candiesamount)
    {
        int l = 1,  r = candiesamount;
        int ans = 1;
        while (l <= r)
        {
            int mid = (l + r) / 2; 
            if (mid * (mid + 1)/2 <= candiesamount)
            {
                ans = mid;
                l = mid + 1; 
            }
            else
            {
                r = mid-1;
            }
        }
        return ans;
    }

}