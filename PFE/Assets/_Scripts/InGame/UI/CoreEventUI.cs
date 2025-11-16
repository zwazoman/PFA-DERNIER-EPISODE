using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreEventUI : MonoBehaviour
{
    public event Action<CoreEventUI> OnClicked;

    [HideInInspector] public Core core;
    [HideInInspector] public CoreEvent coreEvent;

    [SerializeField] TMP_Text _eventName;
    [SerializeField] Image _eventImage;
    [SerializeField] Image _WCImage;

    public void SwapCoreEvent(CoreEvent newCoreEvent)
    {
        coreEvent = newCoreEvent;

        _eventName.text = coreEvent.eventName;
        _eventImage.sprite = coreEvent.sprite;
    }

    public void LinkWC(WC wc)
    {
        _WCImage.sprite = wc.WCData.sprite;
    }

    public void Click() => OnClicked?.Invoke(this);
}
