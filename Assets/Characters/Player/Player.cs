using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovingObject {

    public int damage = 1;
    public float RestartLevelDelay = 1f;
    public Text energyText;

    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;


    Animator playerAnimator;
    int enrgy;

    // Use this for initialization
    protected override void Start ()
    {
        playerAnimator = GetComponent<Animator>();
        enrgy = GameManager.instance.startingEnergy;
        energyText.text = "Energy: " + enrgy;
        base.Start();
	}

    private void OnDisable()
    {
        GameManager.instance.startingEnergy = enrgy;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!GameManager.instance.playersTurn) return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
            vertical = 0;

        if (horizontal != 0 || vertical != 0)
            AttemptMove<Destructable>(horizontal, vertical);
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        enrgy--;
        energyText.text = "Energy: " + enrgy;

        base.AttemptMove<T>(xDir, yDir);

        RaycastHit2D hit;

        if (Move(xDir,yDir, out hit))
        {
            SoundManager.instance.RandomSFX(moveSound1, moveSound2);
        }

        CheckIfGameOver();

        GameManager.instance.playersTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exit")
        {
            Invoke("Restart", RestartLevelDelay);
            enabled = false;
        }

        if (collision.gameObject.GetComponent<Collectable>() !=null)
        {
            Collectable collect = collision.gameObject.GetComponent<Collectable>();
            int energyAdded = collect.UseCollectable();
            enrgy += energyAdded;
            energyText.text = "Energy: " + enrgy + " +" + energyAdded;
        }

    }

    protected override void OnCantMove<T>(T component)
    {
        Destructable hitWall = component as Destructable;
        hitWall.DamageObject(damage);
        playerAnimator.SetTrigger("playerChop");
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseFood (int loss)
    {
        playerAnimator.SetTrigger("playerHit");
        enrgy -= loss;
        energyText.text = "Energy: " + enrgy + " -" + loss;
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (enrgy <= 0)
        {
            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop();
            GameManager.instance.GameOver();
        }
            
    }
}
