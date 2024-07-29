using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    // Strategy interface
    interface ISortStrategy
    {
        void Sort(List<int> list);
    }

    // Concrete strategy for Bubble Sort
    class BubbleSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Bubble Sort");
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        // Swap temp and list[i]
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }

    // Concrete strategy for Quick Sort
    class QuickSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Quick Sort");
            QuickSortRecursive(list, 0, list.Count - 1);
        }

        private void QuickSortRecursive(List<int> list, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(list, low, high);
                QuickSortRecursive(list, low, pi - 1);
                QuickSortRecursive(list, pi + 1, high);
            }
        }

        private int Partition(List<int> list, int low, int high)
        {
            int pivot = list[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
            int temp1 = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp1;
            return i + 1;
        }
    }

    // Concrete strategy for Merge Sort
    class MergeSort : ISortStrategy
    {
        public void Sort(List<int> list)
        {
            Console.WriteLine("Sorting using Merge Sort");
            MergeSortRecursive(list, 0, list.Count - 1);
        }

        private void MergeSortRecursive(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSortRecursive(list, left, mid);
                MergeSortRecursive(list, mid + 1, right);
                Merge(list, left, mid, right);
            }
        }

        private void Merge(List<int> list, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] L = new int[n1];
            int[] R = new int[n2];
            Array.Copy(list.ToArray(), left, L, 0, n1);
            Array.Copy(list.ToArray(), mid + 1, R, 0, n2);
            int i = 0, j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    list[k] = L[i];
                    i++;
                }
                else
                {
                    list[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                list[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                list[k] = R[j];
                j++;
                k++;
            }
        }
    }

    // Context class
    class SortContext
    {
        private ISortStrategy _sortStrategy;

        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void Sort(List<int> list)
        {
            _sortStrategy.Sort(list);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 34, 7, 23, 32, 5, 62 };

            SortContext context = new SortContext();

            // Using Bubble Sort
            context.SetSortStrategy(new BubbleSort());
            context.Sort(list);
            Console.WriteLine(string.Join(", ", list));

            list = new List<int> { 34, 7, 23, 32, 5, 62 };

            // Using Quick Sort
            context.SetSortStrategy(new QuickSort());
            context.Sort(list);
            Console.WriteLine(string.Join(", ", list));

            list = new List<int> { 34, 7, 23, 32, 5, 62 };

            // Using Merge Sort
            context.SetSortStrategy(new MergeSort());
            context.Sort(list);
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
