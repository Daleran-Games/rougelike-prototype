using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {

    //public float MoveTime = 0.1f;
    public LayerMask BlockingLayer;


    BoxCollider2D boxCollider;
    Rigidbody2D objectRB;
    protected float moveSpeed = 3f;

	// Use this for initialization
	protected virtual void Start ()
    {
        boxCollider = gameObject.GetRequiredComponent<BoxCollider2D>();
	}
	


    public virtual bool Move(float horizontal, float vertical, Vector2 mousePos)
    {


        return true;
    }


    
}
