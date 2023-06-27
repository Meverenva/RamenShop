using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenSlide : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToTween;

    private void Start()
    {
        foreach (GameObject obj in objectsToTween)
        {
            obj.transform.DOMoveY(.1f, 1f);
        }
    }
}
