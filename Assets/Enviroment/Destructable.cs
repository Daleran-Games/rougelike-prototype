﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public Sprite damagedSprite;
    public Sprite destroyedSprite;
    public AudioClip[] damageSounds;

    /*
    public ItemType loot;
    public int minLootAmount;
    public int maxLootAmount;
    */

    SpriteRenderer destructibleRenderer;
    Collider2D destructibleCollider;
    ConditionBehaviour condition;

    // Use this for initialization
    void Awake()
    {
        destructibleRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
        destructibleCollider = gameObject.GetRequiredComponent<Collider2D>();
        condition = gameObject.GetRequiredComponent<ConditionBehaviour>();
    }

    private void OnEnable()
    {
        condition.ConditionStatChange += OnTakeDamage;
    }

    private void OnDisable()
    {
        condition.ConditionStatChange -= OnTakeDamage;
    }

    void OnTakeDamage(int newValue, bool increase)
    {
        SoundManager.instance.RandomSFX(damageSounds);
        if (condition.Condition < condition.MaxCondition)
        {
            destructibleRenderer.sprite = damagedSprite;
        }
        if (condition.Condition <= 0)
        {
            destructibleRenderer.sprite = destroyedSprite;
            destructibleCollider.enabled = false;
            enabled = false;
        }
    }

}