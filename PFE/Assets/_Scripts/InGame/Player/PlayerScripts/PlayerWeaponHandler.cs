using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerWeaponHandler : PlayerScript
{
    #region Events

    public event Action<Core,Core> OnCoreLink;

    #endregion

    [HideInInspector] public Core leftWeaponCore;
    [HideInInspector] public Core rightWeaponCore;

    [HideInInspector] public bool canUseCores = true;

    Core _lastUsedCore;

    [Header("References")]
    [SerializeField] Transform _leftCoreSocket;
    [SerializeField] Transform _rightCoreSocket;

    [Header("Parameters")]
    [SerializeField] float _reloadHoldWindow = .5f;

    float _reloadTimer = 0f;

    private void Start()
    {
        LinkExistingCores();

        if (leftWeaponCore != null)
            leftWeaponCore.Equip(this); ;

        if (rightWeaponCore != null)
            rightWeaponCore.Equip(this);
    }

    void LinkExistingCores()
    {
        leftWeaponCore = _leftCoreSocket.GetComponentInChildren<Core>();
        rightWeaponCore = _rightCoreSocket.GetComponentInChildren<Core>();
    }


    public async UniTask<bool> LinkCore(Core newCore)
    {
        return await main.uiMain.weaponMenu.OpenCoreChoiceMenu(newCore);
    }

    public async UniTask<bool> LinkWC(WC newWC)
    {
        return await main.uiMain.weaponMenu.OpenCoreEventChoiceMenu(newWC);
    }

    public void SwapWC(WC newWC, CoreEvent coreEvent, Core linkedCore)
    {
        if (coreEvent.linkedWC != null)
            coreEvent.linkedWC.Deactivate();

        PositionWC(newWC, linkedCore);
        newWC.Activate(coreEvent, linkedCore);
    }

    public void SwapLeftCore(Core newCore)
    {
        if (leftWeaponCore != null)
        {
            leftWeaponCore.UnEquip();
        }

        leftWeaponCore = newCore;
        leftWeaponCore.Equip(this);
        PositionCore(_leftCoreSocket, newCore);

        OnCoreLink?.Invoke(leftWeaponCore, rightWeaponCore);
    }

    public void SwapRightCore(Core newCore)
    {
        if(rightWeaponCore != null)
        {
            rightWeaponCore.UnEquip();
        }

        rightWeaponCore = newCore;
        rightWeaponCore.Equip(this);
        PositionCore(_rightCoreSocket, newCore);

        OnCoreLink?.Invoke(leftWeaponCore, rightWeaponCore);
    }

    void PositionCore(Transform socket, Core core)
    {
        core.transform.parent = socket;
        core.transform.position = socket.position;
        core.transform.rotation = socket.rotation;
    }

    void PositionWC(WC wc, Core core)
    {
        Transform wcSocket = core.wcSpots.PickRandom();

        wc.transform.parent = wcSocket;
        wc.transform.position = wcSocket.position;
        wc.transform.rotation = wcSocket.rotation;
    }

    #region Inputs

    public void HandleLeftCoreInputs(InputAction.CallbackContext ctx)
    {
        if (leftWeaponCore == null || !main.CheckActionmap(ctx.action.actionMap) || !canUseCores)
            return;

        if (ctx.started)
            leftWeaponCore.StartShootTrigger();
        else if(ctx.canceled)
            leftWeaponCore.StopShootTrigger();

        _lastUsedCore = leftWeaponCore;
    }

    public void HandleRightCoreInputs(InputAction.CallbackContext ctx)
    {
        if (rightWeaponCore == null || !main.CheckActionmap(ctx.action.actionMap) || !canUseCores)
            return;

        if (ctx.started)
            rightWeaponCore.StartShootTrigger();
        else if (ctx.canceled)
            rightWeaponCore.StopShootTrigger();

        _lastUsedCore = rightWeaponCore;
    }

    public void Reload(InputAction.CallbackContext ctx)
    {
        if (!main.CheckActionmap(ctx.action.actionMap) || (rightWeaponCore != null && leftWeaponCore != null) || !canUseCores)
            return;

        if (_reloadTimer < _reloadHoldWindow)
        {
            if (_lastUsedCore == null)
                ChooseReload();
            else
                _lastUsedCore.ReloadTrigger();
        }
        else
            ChooseReload();

        _reloadTimer = 0;
    }

    void ChooseReload()
    {
        print("Reload choosen");


        //fenetre pour choisir quel core reload
        //if (_lastUsedCore == null)
        //    ChooseReload();
        //else
        //    _lastUsedCore.Reload();
        //tmp
    }

    #endregion
}
