using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreEventCenter : MonoBehaviour
{
    [HideInInspector] public List<CoreEvent> coreEvents = new();
}


[Serializable]
public struct CoreEvent
{
    public Sprite sprite;
    public WCTypes Types;
    public UnityEvent triggerEvent;
}


