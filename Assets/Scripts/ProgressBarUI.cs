using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image barImage;
    [SerializeField] private List<Image> barImages;


    private IHasProgress hasProgress;


    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if(hasProgress == null)
        {
            Debug.LogError("Przypisano zly GameObject do hasProgressGameObject. Musi miec komponent IHasProgress.");
        }
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progressNormalized;
        if(e.progressNormalized ==  0f || e.progressNormalized == 1f) {
            Hide();
        } else
        {
            Show();
        }
    }

    private void Show()
    {
        foreach(Image image in barImages) {
            image.DOFade(1, .5f);
        }
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        foreach (Image image in barImages)
        {
            image.DOFade(0, .5f);
        }
        gameObject.SetActive(false) ;
    }
}
