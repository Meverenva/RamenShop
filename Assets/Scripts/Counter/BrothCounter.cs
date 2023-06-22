using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrothCounter : BaseCounter
{
    [SerializeField] private KitchenObject_SO brothKitchenObjectSO;
    [SerializeField] private KitchenObject_SO plateKitchenObjectSO;

    public override void Interact(PlayerController player)
    {
        if(player.GetKitchenObject().GetKitchenObjectSO() == plateKitchenObjectSO)
        {
            player.GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(brothKitchenObjectSO, player);
        }
    }
}
