using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaleranGames.ElectricDreams
{
    public class Enemy : MovingObject
    {
        [Header("Movement Stats")]
        [SerializeField]
        protected float moveSpeed = 4f;
        [Space()]

        [Header("Combat Stats")]
        public int damage = 1;
        public float attackTime = 0.5f;
        public float attackSpeed = 6f;
        private float attackRange;
        public AudioClip[] enemyAttacks;
        [Space()]

        [Header("Visual Stats")]
        public Sprite deadSprite;
        public Color32 deadColor;
        public Color32 hitColor;
        public AudioClip[] enemyHits;
        public float hitVelocity = 6f;
        public float hitTime = 1f;
        [Space()]

        [Header("Loot")]
        public GameObject lootDropObject;
        [Range(0f, 1f)]
        public float lootChance = 1f;

        protected Transform target;
        protected ConditionBehaviour enemyCondition;
        protected Vector2 movementVector = Vector2.zero;
        bool isAttacking = false;
        bool isBeingHit = false;


        float actionTimer = 0f;
        public float ActionTimer
        {
            get { return actionTimer; }
            private set
            {
                if (value < 0)
                    actionTimer = 0;
                else
                    actionTimer = value;
            }
        }

        protected virtual void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            enemyCondition = gameObject.GetRequiredComponent<ConditionBehaviour>();
            enemyCondition.ConditionStatChange += OnTakeDamage;
            attackRange = attackSpeed * attackTime + 0.5f;
            base.Awake();
        }

        protected virtual void OnDestroy()
        {
            enemyCondition.ConditionStatChange -= OnTakeDamage;
        }

        void Update()
        {
            if (ActionTimer > 0)
                ActionTimer -= Time.deltaTime;
        }

        public void FixedUpdate()
        {
            if(GameManager.Instance.CurrentState is PlayState)
            {
                Vector2 dirToTarget = (target.position - transform.position);

                if (!isBeingHit)
                    Move(dirToTarget, moveSpeed);
                
            }
        }


        protected void OnCollisionStay2D(Collision2D collision)
        {

            ConditionBehaviour cond = collision.gameObject.GetComponent<ConditionBehaviour>();

            if (collision.gameObject.tag != gameObject.tag && cond != null)
                StartCoroutine(Attack(collision.transform.position - transform.position));



        }

        IEnumerator Attack(Vector2 dir)
        {
            if (ActionTimer == 0)
            {
                ActionTimer += attackTime;
                objAnimator.SetTrigger("wilderbotAttack");
                SoundManager.Instance.RandomSFX(enemyAttacks);

                StartCoroutine(MoveOverTime(dir, attackSpeed, attackTime));


                if (dir.x > 0)
                    objRenderer.flipX = false;
                else if (dir.x < 0)
                    objRenderer.flipX = true;

                isAttacking = true;

                objCollider.enabled = false;
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, attackRange);
                objCollider.enabled = true;

                yield return new WaitForSeconds(attackTime);


                if (!isBeingHit)
                {
                    if (hits.Length > 0)
                    {
                        foreach (RaycastHit2D h in hits)
                        {

                            ConditionBehaviour cond = h.transform.gameObject.GetComponent<ConditionBehaviour>();

                            if (cond != null && cond.Condition > 0)
                                cond.Condition -= damage;
                        }
                    } 
                }

                isAttacking = false;

            }
        }



        public void OnTakeDamage(int amount, bool increase)
        {
            objAnimator.SetTrigger("wilderbotHit");
            SoundManager.Instance.RandomSFX(enemyHits);
            StartCoroutine(FlashColor(hitColor));
            objectRB.velocity = (transform.position - target.transform.position).normalized * hitVelocity;
            StartCoroutine(DamageStateTimer(hitTime));

            if (enemyCondition.Condition <= 0)
            {

                if (UnityEngine.Random.Range(0f, 1f) <= lootChance)
                {
                    GameObject loot = Instantiate(lootDropObject);
                    loot.transform.position = transform.position;
                    loot.gameObject.GetRequiredComponent<Rigidbody2D>().velocity = objectRB.velocity;
                }

                objAnimator.enabled = false;
                objRenderer.sprite = deadSprite;
                StartCoroutine(SwitchToColor(deadColor));
                gameObject.layer = LayerMask.NameToLayer("UnitTerrain");
                //objCollider.enabled = false;
                enabled = false;
            }
        }

        IEnumerator DamageStateTimer (float time)
        {
            isBeingHit = true;
            yield return new WaitForSeconds(time);

            isBeingHit = false;
        }



    }

}