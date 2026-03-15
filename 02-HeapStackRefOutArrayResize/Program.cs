namespace _02_HeapStackRefOutArrayResize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5,};
            int[] nums = { 6, 7, 8, 9, 10, 11, 12};
            CustomArrResize(ref numbers, nums);
        }
    

    public static void CustomArrResize(ref int[] arr, params int[] numsarr)
    {
            int[] newArr = new int[arr.Length + numsarr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            for (int j = 0; j < numsarr.Length; j++)
            {
                 newArr[arr.Length + j] = numsarr[j];
            }

            for (int i = 0; i < newArr.Length; i++)
            {
                Console.WriteLine(newArr[i]);
            }
        }
    } 
}
