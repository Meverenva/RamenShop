using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
    public KitchenObject_SO input;
    public KitchenObject_SO output;
    public int cuttingProgressMax;
}
