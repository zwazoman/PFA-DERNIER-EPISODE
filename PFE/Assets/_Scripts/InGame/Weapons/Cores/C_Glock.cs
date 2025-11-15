using UnityEngine;

public class C_Glock : ClassicCore
{
    public override void StartShootTrigger()
    {
        //foreach (var coreEvent in coreData.coreEvents)
        //{
        //    print(coreEvent.name);
        //    coreEvent.triggerEvent.AddListener(GrosseChiasse);
        //}
    }

    public override void StopShootTrigger()
    {
        foreach (var coreEvent in coreData.coreEvents)
        {
            coreEvent.triggerEvent?.Invoke();
        }
    }

    void GrosseChiasse() => print("Chiassux");
}
