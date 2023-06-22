using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBrothKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObject_SO> validKitchenObjectSOList;
    private List<KitchenObject_SO> kitchenObjectSOList;
     
    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObject_SO>();
    }
    public bool TryAddIngredient(KitchenObject_SO kitchenObjectSO)
    {
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        }
        if(kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            return false;
        } else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}
