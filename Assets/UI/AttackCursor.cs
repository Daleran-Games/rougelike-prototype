using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.ElectricDreams;

namespace Dallib.CameraTools
{
    public class AttackCursor : MonoBehaviour
    {
        [SerializeField]
        Color32 defaultColor;
        [SerializeField]
        Color32 attackColor;

        SpriteRenderer cursorRenderer;
        GameObject player;

        private void Awake()
        {
            cursorRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
        }


        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = Vector3.MoveTowards(player.transform.position, mousePos, Vector3.Distance(player.transform.position, mousePos) * 0.5f);
            transform.position = new Vector3(newPos.x, newPos.y, 0f);
        }
    }
}
