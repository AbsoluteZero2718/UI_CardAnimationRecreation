using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardScript : MonoBehaviour
{
    private SpriteRenderer rend;

    [SerializeField]
    private Sprite faceSprite, backSprite;
    private bool corourtineAllowed, faceUp;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = backSprite;
        corourtineAllowed = true;
        faceUp = false;
    }

    private void OnMouseDown()
    {
        if (corourtineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        corourtineAllowed = false;

        if (!faceUp)
        {
            for (float i = 0f; i <= 100f; i+= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, 1, 0f);
                if (i == 90f)
                {
                    rend.sprite = faceSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }

            transform.DOShakePosition(0.75f, 0.25f, 8, 2f);
        }

        else if (faceUp)
        {
            for (float i = 100f; i >= 0f;  i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, 1, 0f);
                if (i == 90f)
                {
                    rend.sprite = backSprite;
                }
                yield return new WaitForSeconds(0.01f);
            }

            
        }

        corourtineAllowed = true;

        faceUp = !faceUp;
    }
}
