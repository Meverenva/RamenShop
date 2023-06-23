using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public override void Interact(PlayerController player)
    {
        if(player.HasKitchenObject())
        {
            if(player.GetKitchenObject().TryGetBrothPlate(out PlateBrothKitchenObject plateBrothKitchenObject)) {
                DeliveryManager.Instance.DeliverRecipe(plateBrothKitchenObject);
                player.GetKitchenObject().DestroySelf();
            }
        }
    }
}
