using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBrothKitchenObject : KitchenObject
{
    private List<KitchenObject_SO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObject_SO>();
    }
    public void AddIngredient(KitchenObject_SO kitchenObjectSO)
    {
        kitchenObjectSOList.Add(kitchenObjectSO);
    }
}
