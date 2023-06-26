using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObject_SO_GameObject
    {
        public KitchenObject_SO kitchenObject_SO;
        public GameObject gameObject;
    }
    [SerializeField] private PlateBrothKitchenObject plateBrothKitchenObject;
    [SerializeField] private List<KitchenObject_SO_GameObject> kitchenObjectSOGameObjectList;


    private void Start()
    {
        plateBrothKitchenObject.OnIngredientAdded += PlateBrothKitchenObject_OnIngredientAdded;
        foreach (KitchenObject_SO_GameObject kitchenObjectSOGameObject in kitchenObjectSOGameObjectList)
        {
            kitchenObjectSOGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateBrothKitchenObject_OnIngredientAdded(object sender, PlateBrothKitchenObject.OnIngredientAddedEventsArgs e)
    {
        foreach(KitchenObject_SO_GameObject kitchenObjectSOGameObject in kitchenObjectSOGameObjectList)
        {
            if(kitchenObjectSOGameObject.kitchenObject_SO == e.kitchenObjectSO)
            {
                kitchenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
