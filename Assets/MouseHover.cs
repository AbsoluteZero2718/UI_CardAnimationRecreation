using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseHover : MonoBehaviour
{
   private Vector3 initialScale;

   private void OnMouseEnter()
    {
        IncreaseScale(true);
    }

    private void OnMouseExit()
    {
        IncreaseScale(false);
    }

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private void IncreaseScale(bool status)
    {
        Vector3 finalScale = initialScale;
        if (status)
            finalScale = initialScale * 1.1f;

        transform.DOScale(finalScale, 0.15f);
    }
}
