using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour {

    //public float MoveTime = 0.1f;
    public LayerMask BlockingLayer;


    BoxCollider2D boxCollider;
    Rigidbody2D objectRB;
    float inverseMoveTime;

	// Use this for initialization
	protected virtual void Start ()
    {
        boxCollider = gameObject.GetRequiredComponent<BoxCollider2D>();
        objectRB = gameObject.GetRequiredComponent<Rigidbody2D>();
        inverseMoveTime = 1f / GameManager.instance.turnDelay;
	}
	
    protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, BlockingLayer);
        boxCollider.enabled = true;

        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }

        return false;
    }

    protected virtual void AttemptMove<T> (int xDir, int yDir) where T: Component
    {
        RaycastHit2D hit;
        bool canMove = Move(xDir, yDir, out hit);

        if (hit.transform == null)
            return;

        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
            OnCantMove(hitComponent);
    }

    protected abstract void OnCantMove<T>(T component) where T : Component;

    protected IEnumerator SmoothMovement (Vector3 end)
    {
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 newPosition = Vector3.MoveTowards(objectRB.position, end, inverseMoveTime * Time.deltaTime);
            objectRB.MovePosition(newPosition);
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            yield return null;
        }
    }
    
}
