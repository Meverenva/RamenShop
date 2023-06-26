using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PlateCompleteVisual;

public class CustomerManager : MonoBehaviour
{
    [Serializable]
    public struct RecipeSO_GameObject
    {
        public RecipeSO recipeSO;
        public GameObject gameObject;
    }

    [SerializeField] private List<RecipeSO_GameObject> RecipeSOGameObjectList;
    [SerializeField] private List<GameObject> inactiveCustomersList;




    private void Start()
    {
        DeliveryManager.Instance.OnRecipeAdded += Instance_OnRecipeAdded;
        DeliveryManager.Instance.OnRecipeSuccess += Instance_OnRecipeSuccess;
        foreach(GameObject inactiveCustomer in inactiveCustomersList)
        {
            inactiveCustomer.gameObject.SetActive(false);
        }
    }

    private void Instance_OnRecipeSuccess(object sender, DeliveryManager.OnRecipeEventArgs e)
    {
       
        foreach(RecipeSO_GameObject recipeSOGameObject in RecipeSOGameObjectList)
        {
            if (recipeSOGameObject.recipeSO == e.recipeSO)
            {
                recipeSOGameObject.gameObject.SetActive(false);
                inactiveCustomersList.Add(recipeSOGameObject.gameObject);
                RecipeSOGameObjectList.Remove(recipeSOGameObject);
                break;
            }
        }
    }

    private void Instance_OnRecipeAdded(object sender, DeliveryManager.OnRecipeEventArgs e)
    {
        RecipeSO_GameObject recipeSOGameObject = new RecipeSO_GameObject();
        recipeSOGameObject.recipeSO = e.recipeSO;
        recipeSOGameObject.gameObject = inactiveCustomersList[0];
        recipeSOGameObject.gameObject.SetActive(true);
        inactiveCustomersList.RemoveAt(0);
        RecipeSOGameObjectList.Add(recipeSOGameObject);
    }
}
