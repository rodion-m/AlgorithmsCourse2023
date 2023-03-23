class BinarySearchExample
{
    
    //[3, 5, 7, 10]. target = 7
    static int BinarySearch(int[] arr, int target)
    {
        int leftIndex = 0;
        int rightIndex = arr.Length - 1; //3

        while (leftIndex <= rightIndex)
        {
            int midIndex = leftIndex + (rightIndex - leftIndex) / 2;

            if (arr[midIndex] == target)
            {
                return midIndex; // Target found
            }

            if (arr[midIndex] < target)
            {
                leftIndex = midIndex + 1; // Target is in the right half
            }
            else
            {
                rightIndex = midIndex - 1; // Target is in the left half
            }
        }

        return -1; // Target not found
    }

    public static void Main()
    {
        int[] sortedArray = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        int targetValue = 13;

        int result = BinarySearch(sortedArray, targetValue);

        if (result != -1)
        {
            Console.WriteLine($"Target value {targetValue} found at index {result}.");
        }
        else
        {
            Console.WriteLine($"Target value {targetValue} not found.");
        }
    }
}