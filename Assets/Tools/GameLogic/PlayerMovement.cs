using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DalLib;

namespace ProjectShooter
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5;

        [SerializeField]
        [ReadOnly]
        private Vector2 movement;

        [SerializeField]
        [ReadOnly]
        Vector2 aimPoint;
        [SerializeField]
        [ReadOnly]
        Vector2 playerToMouse;
        [SerializeField]
        [ReadOnly]
        float aimAngle;



        private Rigidbody2D playerRigidbody;
       
        // Use this for initialization
        void Start()
        {
            playerRigidbody = gameObject.GetRequiredComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
    
        }

        void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            Move(horizontalMovement, verticalMovement);
            Turning();

        }

        void Move(float h, float v)
        {
            // Set the movement vector based on the axis input.
            movement.Set(h, v);

            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed;

            // Move the player to it's current position plus the movement.
            playerRigidbody.AddForce(movement);
        }

        void Turning()
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            aimPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            playerToMouse = aimPoint - playerRigidbody.position;
            aimAngle = Mathf.Atan2(playerToMouse.y, playerToMouse.x) * Mathf.Rad2Deg;

            // Set the player's rotation to this new rotation.
            playerRigidbody.rotation = aimAngle - 90f;
            
        }
    }
}
