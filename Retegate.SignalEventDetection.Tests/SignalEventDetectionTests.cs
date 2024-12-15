using FluentAssertions;

namespace Retegate.SignalEventDetection.Tests;

public class SignalEventDetectionTests
{
    public static TheoryData<ICollection<double>, int> Data
    {
        get
        {
            var results = new TheoryData<ICollection<double>, int>();

            results.Add([
                    0.151066,
                    0.173807,
                    0.1055,
                    0.027213,
                    0.041373,
                    0.189999,
                    0.098555,
                    0.099085,
                    0.126002,
                    0.1362,
                    0.093381,
                    0.150037,
                    0.061778,
                    0.015427,
                    0.138863,
                    0.084875,
                    0.167347,
                    0.153679,
                    0.119495,
                    0.142266,
                    0.108057,
                    0.07953,
                    0.149315,
                    0.048677,
                    0.184865,
                    0.088834,
                    0.074379,
                    0.147804,
                    0.114352,
                    0.249843,
                    0.291439,
                    0.320265,
                    0.203071,
                    0.260403,
                    0.225237,
                    0.37747,
                    0.322908,
                    0.269381,
                    0.323341,
                    0.379237,
                    0.4392,
                    0.455602,
                    0.472371,
                    0.401526,
                    0.441768,
                    0.580915,
                    0.595819,
                    0.53659,
                    0.489534,
                    0.502985,
                    0.589794,
                    0.565389,
                    1,
                ],
                28);

            results.Add([
                    0.151066,
                    0.173807,
                    0.1055,
                    0.027213,
                    0.041373,
                    0.189999,
                    0.098555,
                    0.099085,
                    0.126002,
                    0.1362,
                    0.093381,
                    0.150037,
                    0.061778,
                    0.015427,
                    0.138863,
                    0.084875,
                    0.167347,
                    0.153679,
                    0.119495,
                    0.142266,
                    0.108057,
                    0.07953,
                    0.149315,
                    0.048677,
                    0.184865,
                    0.088834,
                    0.074379,
                    0.147804,
                    0.114352,
                    0.249843,
                    0.291439,
                    0.320265,
                    0.203071,
                    0.260403,
                    0.225237,
                    0.37747,
                    0.322908,
                    0.269381,
                    0.323341,
                    0.379237,
                    0.4392,
                    0.455602,
                    0.472371,
                    0.401526,
                    0.441768,
                    0.580915,
                    0.595819,
                    0.53659,
                    0.489534,
                    0.502985,
                    0.589794,
                    0.565389,
                    1,
                    0.151066,
                    0.173807,
                    0.1055,
                    0.027213,
                    0.041373,
                    0.189999,
                    0.098555,
                    0.099085,
                    0.126002,
                    0.1362,
                    0.093381,
                    0.150037,
                    0.061778,
                    0.015427,
                ],
                28);

            results.Add([
                    0.013439,
                    0.038819,
                    0.015558,
                    0.151129,
                    0.023516,
                    0.064086,
                    0.077708,
                    0.02222,
                    0.040083,
                    0.060455,
                    0.142763,
                    0.097552,
                    0.057065,
                    0.114344,
                    0.141153,
                    0.054306,
                    0.131,
                    0.083685,
                    0.133809,
                    0.093352,
                    0.155478,
                    0.029193,
                    0.048318,
                    0.044336,
                    0.156342,
                    0.126527,
                    0.173489,
                    0.134919,
                    0.161938,
                    0.174931,
                    0.141088,
                    0.217233,
                    0.238709,
                    0.154368,
                    0.197692,
                    0.209148,
                    0.284877,
                    0.223751,
                    0.358371,
                    0.36683,
                    0.286465,
                    0.403193,
                    0.444512,
                    0.36926,
                    0.51252,
                    0.48746,
                    0.487648,
                    0.540233,
                    0.416618,
                    0.494719,
                    0.535158,
                    0.627368,
                    1,
                ],
                30);

            results.Add([
                    0.5,
                    0.5,
                    0.5,
                ],
                0);

            results.Add([
                    1,
                    0.5
                ],
                0);

            return results;
        }
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void GetIndexOfEventStart_WithVariousValidData_ReturnsExpectedEventStartIndex(ICollection<double> inputData, int expectedIndex)
    {
        // Arrange and Act
        var result = SignalEventDetection.GetIndexOfEventStart(inputData);

        // Assert
        result.Should().Be(expectedIndex);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(new double[0])]
    public void GetIndexOfEventStart_WithNullOrEmptyData_ThrowsArgumentException(ICollection<double>? inputData)
    {
        // Arrange, Act
        var action = () => SignalEventDetection.GetIndexOfEventStart(inputData!);

        // Assert
        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void GetIndexOfEventStart_WithConstantData_ReturnsZero()
    {
        // Arrange
        var data = new double[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        // Act
        var result = SignalEventDetection.GetIndexOfEventStart(data);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void GetIndexOfEventStart_WithDecreasingData_ReturnsZero()
    {
        // Arrange
        var data = new[] { 1, 0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1 };

        // Act
        var result = SignalEventDetection.GetIndexOfEventStart(data);

        // Assert
        result.Should().Be(0);
    }

    [Theory]
    [InlineData(new[] { -0.1d, 1d })]
    [InlineData(new[] { 0d, 2d })]
    public void GetIndexOfEventStart_WithOutOfRangeData_ThrowsArgumentException(double[] inputData)
    {
        // Arrange, Act
        var action = () => SignalEventDetection.GetIndexOfEventStart(inputData);

        // Assert
        action.Should().ThrowExactly<ArgumentException>();
    }
}