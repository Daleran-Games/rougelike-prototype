using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class Collectable : MonoBehaviour
    {

        public int amount = 10;
        public Sprite depletedSprite;
        public bool destroyOnPickup = false;
        public float activeDelay = 0f;

        SpriteRenderer collectableRenderer;
        Collider2D collectableCollider;

        void Awake()
        {
            collectableRenderer = GetComponent<SpriteRenderer>();
            collectableCollider = GetComponent<Collider2D>();

            if (activeDelay > 0)
            {
                collectableCollider.enabled = false;
                StartCoroutine(DelayActivate(activeDelay));
            }
        }

        IEnumerator DelayActivate (float time)
        {
            yield return new WaitForSeconds(time);
            collectableCollider.enabled = true;
        }

        public int UseCollectable()
        {
            if (destroyOnPickup)
            {
                Destroy(this.gameObject);
                return amount;
            }else
            {
                collectableRenderer.sprite = depletedSprite;
                collectableCollider.enabled = false;
                enabled = false;
                return amount;
            }

        }
    }

}