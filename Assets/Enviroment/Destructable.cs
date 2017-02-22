using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public Sprite damagedSprite;
    public Sprite destroyedSprite;
    public int hitpoints = 4;
    public AudioClip[] damageSounds;

    /*
    public ItemType loot;
    public int minLootAmount;
    public int maxLootAmount;
    */

    SpriteRenderer destructibleRenderer;
    Collider2D destructibleCollider;

    // Use this for initialization
    void Awake()
    {
        destructibleRenderer = GetComponent<SpriteRenderer>();
        destructibleCollider = GetComponent<Collider2D>();
    }

    public void DamageObject(int loss)
    {
        SoundManager.instance.RandomSFX(damageSounds);
        destructibleRenderer.sprite = damagedSprite;
        hitpoints -= loss;
        if (hitpoints <= 0)
        {
            destructibleRenderer.sprite = destroyedSprite;
            destructibleCollider.enabled = false;
            enabled = false;
        }
    }
}
