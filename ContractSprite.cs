using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractSprite : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public static bool change;

    private void Update()
    {
        if (change)
        {
            ChangeSprite();
        }
    }
    void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}
