﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PriorityQueue<T> where T: IComparable<T> 
{

    List<T> data;


    public int Count { get { return data.Count; } }

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    public void Enqueue(T item)
    {
        data.Add(item);

        int childIndex = data.Count - 1;

        while(childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2;

            if(data[childIndex].CompareTo(data[parentIndex]) >= 0)
            {
                break;
            }

            T temp = data[childIndex];
            data[childIndex] = data[parentIndex];
            data[parentIndex] = temp;

            childIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        int lastindex = data.Count - 1;

        T frontItem = data[0];

        data[0] = data[lastindex];

        data.RemoveAt(lastindex);
        lastindex--;

        int parentIndex = 0;

        while (true)
        {

            int childIndex = parentIndex * 2 + 1;

            if(childIndex > lastindex)
            {
                break;
            }

            int rightChild = childIndex + 1;

            if(rightChild <= lastindex && data[rightChild].CompareTo(data[childIndex]) < 0)
            {
                childIndex = rightChild;
            }

            if(data[parentIndex].CompareTo(data[childIndex]) <= 0)
            {
                break;
            }

            T temp = data[parentIndex];
            data[parentIndex] = data[childIndex];
            data[childIndex] = temp;

            parentIndex = childIndex;

        }

        return frontItem;
    }

    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }

    public bool Contains(T item)
    {
        return data.Contains(item);
    }

    public List<T> ToList()
    {
        return data;
    }
}
