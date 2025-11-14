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

        if(leftWeaponCore != null)
            leftWeaponCore.Activate();

        if(rightWeaponCore != null) 
            rightWeaponCore.Activate();
    }

    void LinkExistingCores()
    {
        leftWeaponCore = _leftCoreSocket.GetComponentInChildren<Core>();
        rightWeaponCore = _rightCoreSocket.GetComponentInChildren<Core>();
    }


    public async UniTask<bool> LinkCore(Core newCore)
    {
        //laisser uniquement le choice

        //if (leftWeaponCore == null)
        //{
        //    leftWeaponCore = newCore;
        //    PositionCore(_leftCoreSocket, newCore);
        //}
        //else if (rightWeaponCore == null)
        //{
        //    rightWeaponCore = newCore;
        //    PositionCore(_rightCoreSocket, newCore);
        //}
        //else
        //{
        //    print("plus de place la team");
        //    bool coreChanged = await main.uiMain.weaponMenu.OpenCoreChoiceMenu(newCore);
        //    if (!coreChanged)
        //        return false;
        //}

        return await main.uiMain.weaponMenu.OpenCoreChoiceMenu(newCore);
    }

    public void SwapLeftCore(Core newCore)
    {
        if (leftWeaponCore != null)
        {
            leftWeaponCore.pickup.Drop();
        }

        leftWeaponCore = newCore;
        PositionCore(_leftCoreSocket, newCore);

        OnCoreLink?.Invoke(leftWeaponCore, rightWeaponCore);
    }

    public void SwapRightCore(Core newCore)
    {
        if(rightWeaponCore != null)
        {
            rightWeaponCore.pickup.Drop();
        }

        rightWeaponCore = newCore;
        PositionCore(_rightCoreSocket, newCore);

        OnCoreLink?.Invoke(leftWeaponCore, rightWeaponCore);
    }

    void PositionCore(Transform socket, Core core)
    {
        core.transform.parent = socket;
        core.transform.position = socket.position;
        core.transform.rotation = socket.rotation;
    }

    #region Inputs

    public void HandleLeftCoreInputs(InputAction.CallbackContext ctx)
    {
        if (leftWeaponCore == null || !main.CheckActionmap(ctx.action.actionMap) || !canUseCores)
            return;

        if (ctx.started)
            leftWeaponCore.StartShooting();
        else if(ctx.canceled)
            leftWeaponCore.StopShooting();

        _lastUsedCore = leftWeaponCore;
    }

    public void HandleRightCoreInputs(InputAction.CallbackContext ctx)
    {
        if (rightWeaponCore == null || !main.CheckActionmap(ctx.action.actionMap) || !canUseCores)
            return;

        if (ctx.started)
            rightWeaponCore.StartShooting();
        else if (ctx.canceled)
            rightWeaponCore.StopShooting();

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
                _lastUsedCore.Reload();
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
