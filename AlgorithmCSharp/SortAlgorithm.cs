using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
///  //插入排序
/// </summary>
public class Insertion
{
    public static bool Compare<T>(T a, T b)
    {
        return true;
    }
    //插入排序
    public static void sort<T>(List<T> array)
    {
        int n = array.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j > 0 && Compare<T>(array[j], array[j - 1]); j--)
            {
                T tmp = array[j];
                array[j] = array[j - 1];
                array[j - 1] = tmp;
            }
        }
    }
}

//冒泡排序
//和插入排序比，插入排序可跳出循环
public class Bubble
{
    public static bool Compare<T>(T a, T b)
    {
        return true;
    }
    public static void sort<T>(List<T> array)
    {
        int n = array.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j<n-i ; j++)
            {
                if(Compare<T>(array[j],array[j + 1]))
                {
                    T tmp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = tmp;
                }
               
            }
        }
    }
}

/// <summary>
/// 希尔排序
/// 就是分成n段的插入排序
/// </summary>
public class Shell
{
    public static bool Compare<T>(T a, T b)
    {
        return true;
    }
    //插入排序
    public static void sort<T>(List<T> array)
    {
        int n = array.Count;
        int h = 1;   //子序列的间隔数
        while (h < n / 3)   //h取n/3
            h = 3 * h + 1;  //增加h，至n/3左右    
        while (h >= 1)
        {
            for (int i = h; i < n; i++)
            {
                //对子序列进行排序
                for (int j = i; j >= h && Compare<T>(array[j], array[j - h]); j -= h)
                {
                    T tmp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = tmp;
                }

            }
            //不断递归
            h = h / 3;
        }


    }
}

/// <summary>
/// 快速排序
/// </summary>
 public class Quick
{
    public static bool Compare<T>(T a, T b)
    {
        return true;
    }

    public static void sort<T>(List<T> array)
    {
        sort(array, 0, array.Count - 1);
    }

    public static void sort<T>(List<T> a,  int low, int high)
    {
        if (high <= low)
            return;
        int j = 0;
        //1、先从数列中取出一个数作为基准数
        //2、分区过程，将比这个数大的数全放到它的右边，小于或等于它的数全放到它的左边
        //3、再对左右区间重复第二步，直到各区间只有一个数
        j= partition<T>(a, low, high);
        sort(a, low, j - 1);
        sort(a, j + 1, high);
    }

    public static int partition<T>(List<T> array, int low, int high)
    {
        //将数组分为[low, i-1] i [i+1, high]
        int i = low, j = high + 1;
        T v = array[low];

        while(true)
        {
            //从左右边界同时扫描，求出
            //从左边界开始
            while(Compare<T>(array[++i], v))
            {
                if(i==high)
                {
                    break;
                }
            }
            //从右边界开始
            while (Compare<T>(v, array[--j]))
            {
                if (j == low)
                {
                    break;
                }
            }
            if(i>=j)
            {
                //结束
                break;
            }
            //交换i,j
            T t = array[i];
            array[i] = array[j];
            array[j] = t;

        }
        T tmp = array[low];
        array[low] = array[j];
        array[j] = tmp;
        return j;

    }
}
