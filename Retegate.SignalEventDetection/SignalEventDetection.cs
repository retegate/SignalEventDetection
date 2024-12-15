namespace Retegate.SignalEventDetection;

public static class SignalEventDetection
{
    /// <summary>
    /// Provides index of sample at which the event is detected to start. Such a value is computed using data from start of the enumeration til the maximum value only (the rest of the signal is ignored).
    /// Under the hood the Akaike information criteria (AIC) has been inspiration for the solution.
    /// </summary>
    /// <param name="data">Samples data</param>
    /// <returns>Index of sample where the event starting. When empty or null input provided, the ArgumentNullException is thrown.</returns>
    public static int GetIndexOfEventStart(ICollection<double> data)
    {
        if (data == null || data.Count == 0)
        {
            throw new ArgumentException("Data cannot be null or empty.");
        }

        var min = data.Min();
        var max = data.Max();

        if (min < 0d || max > 1d)
        {
            throw new ArgumentException("Data must be normalized to range [0, 1].");
        }

        var sumSquares = 0d;
        var count = 1;

        foreach (var item in data)
        {
            sumSquares += item * item;

            if (item == max)
            {
                break;
            }

            ++count;
        }

        var counter = 1;
        var summing = 0d;
        var minAicValue = double.MaxValue;
        var minAicIndex = 0;

        foreach (var item in data)
        {
            var value = item * item;
            summing += value;
            sumSquares -= value;

            var aicValue = counter * Math.Log(summing) + (count - counter + 1) * Math.Log(sumSquares);

            if (aicValue < minAicValue)
            {
                minAicValue = aicValue;
                minAicIndex = counter;
            }

            ++counter;

            if (counter > count)
            {
                break;
            }
        }

        return minAicIndex - 1;
    }
}