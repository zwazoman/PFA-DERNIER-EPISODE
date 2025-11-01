using AYellowpaper.SerializedCollections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class CoreEventCenter : MonoBehaviour
{
    [SerializedDictionary("Name", "CoreEvent")]
    public SerializedDictionary<string, CoreEvent> coreEvents = new();

    public void InvokeEvent(string eventName, bool createEvent = false)
    {
        if(coreEvents.ContainsKey(eventName))
        {
            coreEvents[eventName].Event?.Invoke();
        }
        else if(createEvent)
        {
            CoreEvent coreEvent = new();
            coreEvents.Add(eventName, coreEvent);
        }
    }

    public void SubscribeToEvent(string eventName, UnityAction call = null)
    {
        if (coreEvents.ContainsKey(eventName))
        {
            coreEvents[eventName].Event.AddListener(call);
        }
    }
}


[Serializable]
public struct CoreEvent
{
    public UnityEvent Event;
    public int Slots;
    public int Lvl;
}


