using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class CoreEventCenter : MonoBehaviour
{
    [SerializeField] public SerializedDictionary<string, CoreEvent> coreEvents = new();

    public void InvokeEvent(string eventName)
    {
        if(coreEvents.ContainsKey(eventName))
        {
            coreEvents[eventName].Event?.Invoke();
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


