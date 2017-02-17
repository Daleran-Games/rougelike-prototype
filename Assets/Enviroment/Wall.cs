using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    public Sprite DamagedSprite;
    public int Hitpoints = 4;

    SpriteRenderer Renderer;

	// Use this for initialization
	void Awake () {
        Renderer = GetComponent<SpriteRenderer>();
	}
	
    public void DamageWall (int loss)
    {
        Renderer.sprite = DamagedSprite;
        Hitpoints -= loss;
        if (Hitpoints <= 0)
            gameObject.SetActive(false);
    }
	
}
