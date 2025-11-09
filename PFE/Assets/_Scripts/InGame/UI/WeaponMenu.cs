using Cysharp.Threading.Tasks;
using UnityEngine;

public class WeaponMenu : PlayerScript
{
    [Header("References")]
    [SerializeField] CoreUi _leftCoreUi;
    [SerializeField] CoreUi _rightCoreUi;

    private void Start()
    {
        main.playerWeaponHandler.OnCoreLink += EditCores;
    }

    void EditCores(Core leftCore, Core rightCore)
    {
        if(leftCore != _leftCoreUi.core)
        {
            _leftCoreUi.SwapCores(leftCore);
        }
        if(rightCore != _rightCoreUi.core)
        {
            _rightCoreUi.SwapCores(rightCore);
        }
    }

    public async UniTask<bool> OpenCoreChoiceMenu()
    {
        return false;
    }

    public async UniTask<bool> OpenCoreEventChoiceMenu()
    {
        return false;
    }

}
