using UnityEngine;

public class C_Glock : ClassicCore
{
    public override void StartShootTrigger()
    {
        foreach (string coreEvent in coreData.coreEvents.Keys)
        {
            print(coreEvent);
            coreData.coreEvents[coreEvent].triggerEvent.AddListener(GrosseChiasse);
        }
    }

    public override void StopShootTrigger()
    {
        CoreEventContext context = new();

        foreach (CoreEvent coreEvent in coreData.coreEvents.Values)
        {
            coreEvent.triggerEvent?.Invoke(context);
        }
    }

    void GrosseChiasse(CoreEventContext ctx) => print("Chiassux");
}
