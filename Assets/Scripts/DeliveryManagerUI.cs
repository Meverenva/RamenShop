using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private CustomerManager customerManager;
    [SerializeField] private Transform container;
    [SerializeField] private Transform recipeTemplate;

    private float recipeYEndValue = -1;


    private void Start()
    {
        customerManager.OnCustomerAssigned += CustomerManager_OnCustomerAssigned;
        customerManager.OnCustomerRemove += CustomerManager_OnCustomerRemove;
        UpdateVisual();
    }

    private void CustomerManager_OnCustomerRemove(object sender, CustomerManager.OnCustomerStateChangeEventArgs e)
    {
        foreach(Transform child in container)
        {
            if (child == recipeTemplate) continue;
            if (child.GetChild(1).GetComponent<Image>().color == e.recipeSOGameObject.gameObject.GetComponent<CustomerColor>().GetColor())
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

    private void CustomerManager_OnCustomerAssigned(object sender, CustomerManager.OnCustomerStateChangeEventArgs e)
    {
        Transform recipeTransform = Instantiate(recipeTemplate, container);
        recipeTransform.gameObject.SetActive(true);
        recipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(e.recipeSOGameObject.recipeSO);
        recipeTransform.GetChild(1).GetComponent<Image>().color = 
            e.recipeSOGameObject.gameObject.GetComponent<CustomerColor>().GetColor();
    }

    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }
    }
}
