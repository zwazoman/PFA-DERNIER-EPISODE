using UnityEngine;

public class C_Glock : ClassicCore
{
    public override void StartShootTrigger()
    {
        TriggerCoreEvent("CACA PARTOUT", SetupContext());
    }

    public override void StopShootTrigger()
    {
        TriggerCoreEvent("CHIASSE INFERNALE", SetupContext());
    }
}
