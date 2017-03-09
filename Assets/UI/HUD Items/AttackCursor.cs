using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.ElectricDreams;

namespace DaleranGames.UI
{
    public class AttackCursor : MonoBehaviour
    {
        [SerializeField]
        Color32 defaultColor;
        [SerializeField]
        Color32 attackColor;
        [SerializeField]
        [Range(0f,1f)]
        float distanceScaler = 1f;

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
            Cursor.visible = false;
            cursorRenderer.color = defaultColor;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (distanceScaler < 1)
            {
                Vector3 newPos = Vector3.MoveTowards(player.transform.position, mousePos, Vector3.Distance(player.transform.position, mousePos) * distanceScaler);
                transform.position = new Vector3(newPos.x, newPos.y, 0f);
            }
            else
                transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

            if (GameManager.Instance.Play.PlayerHighlightingTarget == true)
                cursorRenderer.color = attackColor;
            else
                cursorRenderer.color = defaultColor;
        }
    }
}
