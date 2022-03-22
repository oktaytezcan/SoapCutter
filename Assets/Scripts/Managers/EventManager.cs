using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnSceneStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnSceneFinish = new UnityEvent();
    #endregion

    #region Soap Events
    public static UnityEvent OnSoapLayerCompleted = new UnityEvent();
    #endregion

    #region Button Events
    public static UnityEvent OnTapToPlayButtonPressed = new UnityEvent();
    public static UnityEvent OnNextLevelButtonPressed = new UnityEvent();
    public static UnityEvent OnRetryButtonPressed = new UnityEvent();
    #endregion
}
