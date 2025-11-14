using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoreEventUI : MonoBehaviour
{
    CoreEvent _coreEvent;

    [SerializeField] TMP_Text _eventName;
    [SerializeField] Image _eventImage;
    [SerializeField] Image _WCImage;

    public void EditEvent(CoreEvent coreEvent)
    {
        _eventName.text = coreEvent.name;
        _eventImage.sprite = coreEvent.sprite;
    }
}
