using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite alternateSprite;
    [SerializeField] Color fade;
    int process; const int NONE = 0, FADING_IN = 1, FADING_OUT = 2;
    int timer;
    private void Start()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
    }

    public void FadeIn()
    {
        if (TutorialManager.usingArrows && alternateSprite) { spriteRenderer.sprite = alternateSprite; }
        process = FADING_IN;
    }
    public void FadeOut()
    {
        process = FADING_OUT;
    }

    private void FixedUpdate()
    {
        if (process != NONE)
        {
            if (process == FADING_IN)
            {
                spriteRenderer.color += fade;
                if (spriteRenderer.color.a >= 1)
                {
                    spriteRenderer.color = Color.white;
                    process = NONE;
                }
            }
            else
            {
                spriteRenderer.color += fade;
                if (spriteRenderer.color.a <= 0)
                {
                    spriteRenderer.color = new Color(1,1,1,0);
                    process = NONE;
                }
            }
        }

        if (timer > 0)
        {
            if (timer == 1) { FadeOut(); }
            timer--;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 11) { FadeIn(); }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 11) { timer = 50; }
    }
}
