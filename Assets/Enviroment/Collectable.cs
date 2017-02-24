using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	public int amount=10;
    public Sprite depletedSprite;

    SpriteRenderer collectableRenderer;
    Collider2D collectableCollider;

    public void Awake()
    {
        collectableRenderer = GetComponent<SpriteRenderer>();
        collectableCollider = GetComponent<Collider2D>();
    }


    public int UseCollectable ()
    {
        collectableRenderer.sprite = depletedSprite;
        collectableCollider.enabled = false;
        enabled = false;
        return amount;
    }
}
