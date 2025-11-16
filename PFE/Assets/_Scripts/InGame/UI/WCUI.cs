using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WCUI : MonoBehaviour
{
    public event Action OnLinked;

    [Header("References")]
    [SerializeField] TMP_Text _wcName;
    [SerializeField] Image _wcImage;

    public void SwapWC(WC wc)
    {
        _wcName.text = wc.WCData.wcName;
        _wcImage.sprite = wc.WCData.sprite;
    }
}
