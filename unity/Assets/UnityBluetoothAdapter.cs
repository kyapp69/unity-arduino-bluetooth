﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBluetoothAdapter : MonoBehaviour
{

    private const string JAVA_CLASS = "com.bluetooth.rutkoski.unitybluetoothadapter.UnityBluetoothAdapter";

    public static UnityBluetoothAdapter I;
    AndroidJavaObject ajo;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        if (ajo == null)
            ajo = new AndroidJavaObject(JAVA_CLASS);

        if (ajo != null)
            ajo.Call("getDefaultAdapter");
    }

    #region Bluetooth Hardware
    public virtual bool EnableBluetooth()
    {
        return ajo.Call<bool>("enable");
    }

    public virtual bool DisableBluetooth()
    {
        return ajo.Call<bool>("disable");
    }

    public virtual bool IsBluetoothEnabled()
    {
        return ajo.Call<bool>("isEnabled");
    }
    #endregion


    #region Android System
    public virtual string[] GetBoundDeviceNames()
    {
        return ajo.Call<string[]>("getBoundDeviceNames");
    }
    #endregion


    #region Discovery
    public virtual bool StartDiscovery()
    {
        return ajo.Call<bool>("startDiscovery");
    }

    public virtual bool CancelDiscovery()
    {
        return ajo.Call<bool>("cancelDiscovery");
    }

    public virtual bool IsDiscovering()
    {
        return ajo.Call<bool>("isDiscovering");
    }
    #endregion


    #region Nativ Connection Thread
    public virtual void Connect(string deviceName)
    {
        ajo.Call("connect", deviceName);
    }

    public virtual void Disconnect()
    {
        ajo.Call("disconnect");
    }
    #endregion


    public virtual void Send(string msg)
    {
        ajo.Call("send", msg);
    }


    #region Callbacks
    public virtual void OnDisconnect(string arg) { Debug.Log("BluetoothAdapter: " + arg, this); }

    public virtual void OnConnectionLost(string arg) { Debug.LogWarning("BluetoothAdapter: " + arg, this); }

    public virtual void OnConnected(string arg) { Debug.Log("BluetoothAdapter: " + arg, this); }

    public virtual void OnConnectionFailed(string arg) { Debug.LogWarning("BluetoothAdapter: " + arg, this); }

    public virtual void OnMsgReceived(string arg) { Debug.Log("BluetoothAdapter: " + arg, this); }

    public virtual void OnIOException(string arg) { Debug.LogError("BluetoothAdapter.OnIOException: " + arg, this); }
    #endregion
}
