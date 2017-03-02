using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DaleranGames.ElectricDreams
{
    public delegate void PlayerEventHandler();

    public class Player : MovingObject
    {


        [Header("Movement Stats")]
        [SerializeField]
        protected float moveSpeed = 5f;
        public float moveCost = 1f;
        public AudioClip[] moveSounds;
        [Space()]

        [Header("Combat Stats")]
        public int damage = 1;
        public float attackTime = 0.5f;
        public float attackSpeed = 7f;
        public float attackCost = 2f;
        private float attackRange;
        [Space()]

        [Header("Repair Ability Stats")]
        public float repairTime = 2f;
        public int repairAmount = 4;
        public float repairCost = 10f;
        public Color32 repairColor;
        public AudioClip[] repairSounds;
        [Space()]

        [Header("Visual Stats")]
        public Color32 hitColor;
        public Color32 chargeColor;
        public AudioClip[] chargeSounds;
        public float hitTime = 1f;
        public float hitVelocity = 6f;



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

        public event PlayerEventHandler PlayerExitEvent;
        public event PlayerEventHandler PlayerDeathEvent;

        EnergyBehaviour playerEnergy;
        ConditionBehaviour playerCondition;
        SaveData save;
        bool isAttacking = false;

        protected virtual void Start()
        {
            playerEnergy = gameObject.GetRequiredComponent<EnergyBehaviour>();
            playerCondition = gameObject.GetRequiredComponent<ConditionBehaviour>();
            playerEnergy.EnergyStatChange += OnEnergyChange;
            playerCondition.ConditionStatChange += OnConditionChange;
            save = GameManager.Instance.Save;
            playerEnergy.Energy = save.SavedPlayerEnergy;
            playerCondition.Condition = save.SavedPlayerCondition;
            attackRange = attackSpeed * attackTime + 0.5f;

            base.Awake();
        }

        private void OnDestroy()
        {
            save.SavedPlayerEnergy = playerEnergy.Energy;
            save.SavedPlayerCondition = playerCondition.Condition;
            playerEnergy.EnergyStatChange -= OnEnergyChange;
            playerCondition.ConditionStatChange -= OnConditionChange;
        }

        // Update is called once per frame
        void Update()
        {
            if (ActionTimer > 0)
                ActionTimer -= Time.deltaTime;

        }

        public void MovePlayer (Vector2 direction)
        {
            if (!SoundManager.Instance.efxSource.isPlaying)
                SoundManager.Instance.RandomSFX(moveSounds);

            playerEnergy.Energy -= moveCost * Time.deltaTime;

            base.Move(direction, moveSpeed);
        }

        public void StopPlayer()
        {
            if (!isAttacking)
                base.Stop();
        }

        public void UseLeftAbility()
        {
            StartCoroutine(AttackAbility());
        }

        public void UseRightAbility()
        {
            RepairAbility();
        }

        IEnumerator AttackAbility()
        {

            objAnimator.SetTrigger("playerChop");
            playerEnergy.Energy -= attackCost;
            ActionTimer += attackTime;

            Vector2 attackDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            StartCoroutine(MoveOverTime(attackDirection, attackSpeed, attackTime));

            if (attackDirection.x > 0)
                objRenderer.flipX = false;
            else if (attackDirection.x < 0)
                objRenderer.flipX = true;

            isAttacking = true;

            objCollider.enabled = false;
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, attackDirection, attackRange);

            objCollider.enabled = true;

            yield return new WaitForSeconds(attackTime);

            if (hits.Length > 0)
            {
                foreach (RaycastHit2D h in hits)
                {

                    ConditionBehaviour cond = h.transform.gameObject.GetComponent<ConditionBehaviour>();

                    if (cond != null && cond.Condition > 0)
                        cond.Condition -= damage;
                }
            }

            isAttacking = false;

        }

        void RepairAbility()
        {
            if (playerEnergy.Energy > repairCost && playerCondition.Condition < playerCondition.MaxCondition)
            {
                ActionTimer += repairTime;
                playerEnergy.Energy -= repairCost;
                playerCondition.Condition += repairAmount;
                SoundManager.Instance.RandomSFX(repairSounds);
                StartCoroutine(FlashColor(repairColor));
            }

        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Exit")
            {
                PlayerExitEvent();

            }

            if (collision.gameObject.GetComponent<Collectable>() != null)
            {
                Collectable collect = collision.gameObject.GetComponent<Collectable>();
                int energyAdded = collect.UseCollectable();
                StartCoroutine(FlashColor(chargeColor));
                SoundManager.Instance.RandomSFX(chargeSounds);
                playerEnergy.Energy += energyAdded;
            }

        }

        public void OnEnergyChange(float change, bool increase)
        {
            if (increase)
            {

            }
            else
                CheckIfGameOver();
        }

        public void OnConditionChange(int change, bool increase)
        {
            if (increase)
            {

            }
            else
            {
                objAnimator.SetTrigger("playerHit");
                StartCoroutine(FlashColor(hitColor));
                CheckIfGameOver();
            }

        }

        private void CheckIfGameOver()
        {
            if (playerEnergy.Energy <= 0 || playerCondition.Condition <= 0)
            {
                SoundManager.Instance.musicSource.Stop();
                PlayerDeathEvent();
            }

        }

    }

}