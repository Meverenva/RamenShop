using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(PlayerController player)
    {
        if(player.HasKitchenObject())
        {
            if(player.GetKitchenObject().TryGetBrothPlate(out PlateBrothKitchenObject plateBrothKitchenObject)) {
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
