public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
    // Plan:
    // 1. Create an array of doubles with the specified length to hold the results.
    // 2. Use a loop to iterate from 1 to the specified length (inclusive).
    // 3. In each iteration, calculate the multiple by multiplying the number with the current loop index (i).
    // 4. Store the calculated multiple in the corresponding index of the result array (i - 1).
    // 5. After the loop completes, return the result array containing the multiples.
    double[] result = new double[length];
        for (int i = 1; i <= length; i++)
        {
            result[i - 1] = number * i;
        }
        return result;
    } 
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem     // step by step before you write the code. The plan should be clear enough that it could
    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //plan:
        // 1. Check if the input list is null or empty, or if the amount is less than or equal to 0, or greater than the count of the list. If any of these conditions are true, return immediately as there is nothing to rotate.
        // 2. Use the GetRange method to extract the last 'amount' elements from the list and store them in a temporary list called 'rotatePart'.
        // 3. Remove the last 'amount' elements from the original list using the Remove         
        // 4. Insert the extracted 'rotatePart' at the beginning of the original list using the InsertRange method. 
        // 5. The original list is now rotated to the right by the specified amount.

        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        if (data == null || data.Count == 0 || amount <= 0 || amount > data.Count)
           // Nothing to rotate
            return; 
        List<int> rotatePart = data.GetRange(data.Count - amount, amount); // Get the part to rotate

        data.RemoveRange(data.Count - amount, amount); // Remove the part to rotate from the original list
        
        data.InsertRange(0, rotatePart); // Insert the rotated part at the beginning of
    }
}
