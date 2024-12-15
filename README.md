# SignalEventDetection

Various signal measurements requires to detect and parametrize event in it. Mostly the threshold detection is widely
used, which is sufficient method to event detection. But for better event parametrization the more precise event start
within signal sometimes is needed. Thus, the Retegate.SignalEventDetection has been developed.

## Recommended usage

1) Detect raw events in signal via threshold detection
2) Use the detected events as input for the SignalEventDetection
3) Get the precise event start within the detected events

*Note: When none or empty signal provided, the ArgumentNullException is thrown. Signal with the range <0,1> is expected, otherwise ArgumentException is thrown.*

## Example

```C#
using Retegate.SignalEventDetection;

var eventStartSample = SignalEventDetection.GetIndexOfEventStart(inputData);
```

## Note
The mathematical principle behind the SignalEventDetection is based on the [Akaike Information Criterion (AIC)](https://en.wikipedia.org/wiki/Akaike_information_criterion). It is widely used in [Acoustic Emission (AE)](https://en.wikipedia.org/wiki/Acoustic_emission#:~:text=Acoustic%20emission%20(AE)%20is%20the,gradients%2C%20or%20external%20mechanical%20forces.) in [Non-Destructive Testing (NDT)](https://en.wikipedia.org/wiki/Nondestructive_testing) and also in seismology. (Personally I use it also for produced part detection within continuous image for visual quality check and for better automated histogram range choosing)

## License
Feel free to use this code in your projects (it is under [MIT licence](https://en.wikipedia.org/wiki/MIT_License)). If you have any questions, please contact me at [retegate@retegate.com](mailto:retegate@retegate.com)