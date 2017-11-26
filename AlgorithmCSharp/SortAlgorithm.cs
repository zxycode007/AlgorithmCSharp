using System;
using System.Collections;
using System.Collections.Generic;

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
        int h = 1;   //间隔h子序列的
        while (h < n / 3)   //h取n/3
            h = 3 * n + 1;  //h第一个数
        while (h >= 1)
        {
            for (int i = h; i < n; i++)
            {
                for (int j = i; j >= h && Compare<T>(array[j], array[j - h]); j -= h)
                {
                    T tmp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = tmp;
                }

            }
            h = h / 3;
        }


    }
}

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
        partition<T>(a, low, high);
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
            while(Compare<T>(array[i++], v))
            {
                if(i==high)
                {
                    break;
                }
            }
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
