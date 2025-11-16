using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMenu : PlayerScript
{
    [HideInInspector] bool menuOpened;

    [Header("References")]
    [SerializeField] CoreUi _leftCoreUi;
    [SerializeField] CoreUi _rightCoreUi;
    [SerializeField] CoreUi _newCoreUI;

    bool _leftSelected = false;
    bool _rightSelected = false;
    bool _leave = false;

    private void Start()
    {
        main.playerWeaponHandler.OnCoreLink += EditCores;

        _leftCoreUi.OnClicked += SelectLeft;
        _rightCoreUi.OnClicked += SelectRight;
    }

    void Activate()
    {
        gameObject.SetActive(true);
        main.SwapActionMapToUI();

        _leftCoreUi.gameObject.SetActive(true);
        _rightCoreUi.gameObject.SetActive(true);

        menuOpened = true;
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
        main.SwapActionMapToPlayer();

        _leftCoreUi.gameObject.SetActive(false);
        _rightCoreUi.gameObject.SetActive(false);

        menuOpened = false;
    }

    void EditCores(Core leftCore, Core rightCore)
    {
        if (leftCore != _leftCoreUi.core)
        {
            _leftCoreUi.SwapCore(leftCore);
        }
        if (rightCore != _rightCoreUi.core)
        {
            _rightCoreUi.SwapCore(rightCore);
        }
    }



    public async UniTask<bool> OpenCoreChoiceMenu(Core newCore)
    {
        Activate();
        _newCoreUI.gameObject.SetActive(true);


        newCore.gameObject.SetActive(true);

        _newCoreUI.SwapCore(newCore);

        while (!_leftSelected && !_rightSelected)
        {
            await UniTask.Yield();
        }

        Deactivate();
        _newCoreUI.gameObject.SetActive(false);

        if (_leftSelected)
        {
            main.playerWeaponHandler.SwapLeftCore(newCore);
            _leftSelected = false;
            return true;
        }
        if (_rightSelected)
        {
            main.playerWeaponHandler.SwapRightCore(newCore);
            _rightSelected = false;
            return true;
        }
        return false;
    }

    public async UniTask<bool> OpenCoreEventChoiceMenu()
    {
        main.SwapActionMapToUI();

        return false;
    }

    void SelectLeft() => _leftSelected = true;
    void SelectRight() => _rightSelected = true;


    public void OpenWeaponMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            print("open Ui");


            if (menuOpened)
                Deactivate();
            else
                Activate();
        }
    }
}
