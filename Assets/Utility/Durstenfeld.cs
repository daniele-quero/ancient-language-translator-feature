using UnityEngine;

namespace AncientLanguageUtils
{
    public class Durstenfeld<T>
    {
        public static void shuffle(T[] array)
        {
            int l = array.Length;
            for (int i = l - 1; i >= 0; i--)
            {
                int j = Random.Range(0, i);
                swap(array, i, j);
            }
        }

        private static void swap(T[] array, int i, int j)
        {
            T el = array[i];
            array[i] = array[j];
            array[j] = el;
        }
    }
}
