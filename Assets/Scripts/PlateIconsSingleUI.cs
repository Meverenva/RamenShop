using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateIconsSingleUI : MonoBehaviour
{
    [SerializeField] private Image image;

    public void SetKitchenObjectSO(KitchenObject_SO kitchenObjectSO)
    {
        image.sprite = kitchenObjectSO.sprite;
        Debug.Log("Ustawiam sprite na " + kitchenObjectSO.sprite);
    }
}
