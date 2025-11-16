using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class CoreUi : MonoBehaviour
{
    public event Action OnClicked;

    [HideInInspector] public Core core;

    [Header("References")]
    [SerializeField] TMP_Text _coreName;
    [SerializeField] Image _coreImage;
    [SerializeField] List<CoreEventUI> coreEventUis = new();

    public void SwapCore(Core newCore)
    {
        core = newCore;

        _coreName.text = core.coreData.coreName;
        _coreImage.sprite = core.coreData.sprite;

        //for(int i =0; i<core.eventCenter.coreEvents.Count; i++)
        //{
        //    coreEventUis[i].EditEvent(core.eventCenter.coreEvents[i]);
        //}
    }

    public void EmptyCore()
    {

    }

    public void Click()
    {
        OnClicked?.Invoke();
    }
}
