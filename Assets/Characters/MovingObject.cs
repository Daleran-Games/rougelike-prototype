using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {


    [SerializeField]
    protected float moveSpeed = 3f;

    protected Collider2D objCollider;
    Rigidbody2D objectRB;
    Vector2 objVelocity;

	// Use this for initialization
	protected virtual void Start ()
    {
        objCollider = gameObject.GetRequiredComponent<Collider2D>();
        objectRB = gameObject.GetRequiredComponent<Rigidbody2D>();
	}
	
    public virtual void Move(float horizontal, float vertical)
    {

        objVelocity.Set(horizontal, vertical);
        objVelocity = objVelocity.normalized * moveSpeed;
        objectRB.velocity = objVelocity;

    }


    
}
