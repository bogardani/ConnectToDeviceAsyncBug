# ConnectToDeviceAsyncBug

ConnectToDeviceAsync hangs when device bluetooth is turned off

## Steps to reproduce
1. Clone https://github.com/bogardani/ConnectToDeviceAsyncBug.git
2. Put breakpoint on line ConnectToDeviceAsyncBug/MainPage.xaml.cs:37
3. Turn on device bluetooth
4. Run the application
5. Accept permission requests
6. Click button on UI
7. Turn off bluetooth when breakpoint is hit
8. Continue execution

## Expected behavior
ConnectToDeviceAsync throws exception or returns

## Actual behavior
ConnectToDeviceAsync hangs indefinitely

### Crashlog

n/a

## Configuration

**Version of the Plugin:** 3.0.0-beta.4

**Platform:** Android 13.0 (API 33)

**Device:** Samsung Galaxy A53 5G
