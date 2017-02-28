using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

    public int damage = 1;
    public Sprite deadSprite;
    public Color32 deadColor;
    public Color32 hitColor;
    public float flashDuration = 0.2f;
    public AudioClip[] enemyAttacks;
    public AudioClip[] enemyHits;

    Animator enemyAnimator;
    Transform target;
    Collider2D enemyCollider;
    SpriteRenderer enemyRenderer;
    bool skipMove;

    ConditionBehaviour enemyCondition;

    private void Awake()
    {
        enemyAnimator = gameObject.GetRequiredComponent<Animator>();
        enemyCondition = gameObject.GetRequiredComponent<ConditionBehaviour>();
        enemyCollider = gameObject.GetRequiredComponent<Collider2D>();
        enemyRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
    }

    protected override void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
	}

    private void OnEnable()
    {
        //enemyCondition.ConditionStatChange += OnTakeDamage;
    }

    private void OnDisable()
    {
        //enemyCondition.ConditionStatChange -= OnTakeDamage;
    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            xDir = target.position.x > transform.position.x ? 1 : -1;
        }


    }

    /*
    protected void OnCantMove<T>(T component)
    {
        ConditionBehaviour hitObject = component as ConditionBehaviour;

        enemyAnimator.SetTrigger("wilderbotAttack");

        SoundManager.Instance.RandomSFX(enemyAttacks);

        if (hitObject.tag != "Enemy")
            hitObject.Condition -= damage;
    }

    public void OnTakeDamage (int amount, bool increase)
    {
        enemyAnimator.SetTrigger("wilderbotHit");
        SoundManager.Instance.RandomSFX(enemyHits);
        StartCoroutine(FlashColor(hitColor));

        if (enemyCondition.Condition <= 0)
        {
            enemyAnimator.enabled = false;
            enemyRenderer.sprite = deadSprite;
            StartCoroutine(SwitchToColor(deadColor));
            enemyCollider.enabled = false;
            enabled = false;
        }
    }
    */
    IEnumerator FlashColor (Color32 color)
    {
        enemyRenderer.color = color;
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.color = Color.white;
    }

    IEnumerator SwitchToColor (Color32 color)
    {
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.color = color;
    }

}
