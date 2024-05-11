using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace Problemsolving;
public static class BinarySearch
{
    // get number of items that you can buy using binary search algorithim 
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
   
}