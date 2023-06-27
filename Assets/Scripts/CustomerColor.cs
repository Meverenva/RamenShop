using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerColor : MonoBehaviour
{
    [SerializeField] Color32 color;
    public Color32 GetColor() {
        Debug.Log(color);
        return color; 
    }
}
