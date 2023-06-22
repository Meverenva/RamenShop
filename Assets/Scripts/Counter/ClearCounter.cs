using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{



    [SerializeField] private KitchenObject_SO kitchenObjectSO;



    public override void Interact(PlayerController player)  
    {
        if(!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        } else
        {
            if(player.HasKitchenObject())
            {
                if(player.GetKitchenObject().TryGetBrothPlate(out PlateBrothKitchenObject plateBrothKitchenObject))
                {
                    if(plateBrothKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
            } else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
