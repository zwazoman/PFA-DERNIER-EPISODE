using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponHandler : PlayerScript
{
    [HideInInspector] public Core LeftWeaponCore;
    [HideInInspector] public Core RightWeaponCore;

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

        if(LeftWeaponCore != null)
            LeftWeaponCore.Activate();

        if(RightWeaponCore != null) 
            RightWeaponCore.Activate();
    }

    void LinkExistingCores()
    {
        LeftWeaponCore = _leftCoreSocket.GetComponentInChildren<Core>();
        RightWeaponCore = _rightCoreSocket.GetComponentInChildren<Core>();
    }


    public void LinkCore(Core newCore)
    {
        if (LeftWeaponCore == null)
        {
            LeftWeaponCore = newCore;
            PositionCore(_leftCoreSocket, newCore);
        }
        else if (RightWeaponCore == null)
        {
            RightWeaponCore = newCore;
            PositionCore(_rightCoreSocket, newCore);
        }
        else
            print("plus de place la team");
    }

    void PositionCore(Transform socket, Core core)
    {
        core.transform.parent = socket;
        core.transform.position = socket.position;
        core.transform.rotation = socket.rotation;
    }

    public void UnlinkLeftCore()
    {
        LeftWeaponCore.transform.parent = null;
        LeftWeaponCore = null;
    }

    public void UnlinkRightCore()
    {
        RightWeaponCore.transform.parent = null;
        RightWeaponCore = null;
    }

    #region Inputs

    public void HandleLeftCoreInputs(InputAction.CallbackContext ctx)
    {
        if (LeftWeaponCore == null)
            return;

        if (ctx.started)
            LeftWeaponCore.StartShooting();
        else if(ctx.canceled)
            LeftWeaponCore.StopShooting();

        _lastUsedCore = LeftWeaponCore;
    }

    public void HandleRightCoreInputs(InputAction.CallbackContext ctx)
    {
        if (RightWeaponCore == null)
            return;

        if (ctx.started)
            RightWeaponCore.StartShooting();
        else if (ctx.canceled)
            RightWeaponCore.StopShooting();

        _lastUsedCore = RightWeaponCore;
    }

    public void Reload(InputAction.CallbackContext ctx)
    {
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
        if (_lastUsedCore == null)
            ChooseReload();
        else
            _lastUsedCore.Reload();
        //tmp
    }

    #endregion
}
