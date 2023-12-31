﻿using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.EventArgs;

namespace ConnectToDeviceAsyncBug;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Permissions.RequestAsync<BluetoothPermission>();

        var tcs = new TaskCompletionSource();
        IDevice? device = null;
        void OnDiscovered(object? sender, DeviceEventArgs args)
        {
            device = args.Device;
            tcs.TrySetResult();
        }

        CrossBluetoothLE.Current.Adapter.DeviceDiscovered += OnDiscovered;

        Task.Run(async () => await CrossBluetoothLE.Current.Adapter.StartScanningForDevicesAsync());

        await tcs.Task;

        CrossBluetoothLE.Current.Adapter.DeviceDiscovered -= OnDiscovered;

        await CrossBluetoothLE.Current.Adapter.StopScanningForDevicesAsync();

        try
        { //Put breakpoint here and turn off device BT when hit
            await CrossBluetoothLE.Current.Adapter.ConnectToDeviceAsync(device, new Plugin.BLE.Abstractions.ConnectParameters(false, true));
        }
        catch
        {
            //Do nothing
        }
    }
}

