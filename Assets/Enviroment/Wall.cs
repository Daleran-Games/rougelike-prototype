using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public Sprite DamagedSprite;
    public int Hitpoints = 4;
    public AudioClip chopSound1;
    public AudioClip chopSound2;

    SpriteRenderer Renderer;

	// Use this for initialization
	void Awake ()
    {
        Renderer = GetComponent<SpriteRenderer>();
	}
	
    public void DamageWall (int loss)
    {
        SoundManager.instance.RandomSFX(chopSound1, chopSound2);
        Renderer.sprite = DamagedSprite;
        Hitpoints -= loss;
        if (Hitpoints <= 0)
            gameObject.SetActive(false);
    }
	
}
