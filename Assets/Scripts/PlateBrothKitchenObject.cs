using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBrothKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventsArgs> OnIngredientAdded;
    public class OnIngredientAddedEventsArgs : EventArgs
    {
        public KitchenObject_SO kitchenObjectSO;
    }


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
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventsArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
    }

    public List<KitchenObject_SO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
