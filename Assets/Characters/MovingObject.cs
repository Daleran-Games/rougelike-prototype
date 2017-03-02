using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public abstract class MovingObject : MonoBehaviour
    {
        [Header("Moving Object Properties",order = -1)]
        [SerializeField]
        protected Collider2D objCollider;
        [SerializeField]
        protected Rigidbody2D objectRB;
        [SerializeField]
        protected SpriteRenderer objRenderer;
        [SerializeField]
        protected Animator objAnimator;

        // Use this for initialization
        protected virtual void Awake()
        {
            objCollider = gameObject.GetRequiredComponent<Collider2D>();
            objectRB = gameObject.GetRequiredComponent<Rigidbody2D>();
            objRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
            objAnimator = gameObject.GetRequiredComponent<Animator>();
        }

        protected virtual void Move(Vector2 direction, float velocity)
        {
 
            objectRB.velocity = direction.normalized * velocity;

            if (direction.x > 0)
                objRenderer.flipX = false;
            else if (direction.x < 0)
                objRenderer.flipX = true;
        }

        protected virtual void Stop()
        {
            Move(Vector2.zero, 0f);
        }

        protected virtual IEnumerator MoveOverTime (Vector2 direction, float velocity, float time)
        {
            objectRB.velocity = direction.normalized * velocity;
            yield return new WaitForSeconds(time);
            Stop();

        }

        protected virtual IEnumerator FlashColor(Color32 color)
        {
            objRenderer.color = color;
            yield return new WaitForSeconds(GameManager.Instance.Config.FlashTime);
            objRenderer.color = Color.white;
        }

        protected virtual IEnumerator SwitchToColor(Color32 color)
        {
            yield return new WaitForSeconds(GameManager.Instance.Config.FlashTime);
            objRenderer.color = color;
        }



    } 
}
