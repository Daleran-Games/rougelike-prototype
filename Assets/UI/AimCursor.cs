using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaleranGames.ElectricDreams;

namespace Dallib.CameraTools
{
    public class AimCursor : MonoBehaviour
    {

        [SerializeField]
        Color32 defaultColor;
        [SerializeField]
        Color32 attackColor;

        SpriteRenderer cursorRenderer;

        private void Awake()
        {
            cursorRenderer = gameObject.GetRequiredComponent<SpriteRenderer>();
        }

        // Use this for initialization
        void Start()
        {
            Cursor.visible = false;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(newPos.x, newPos.y, 0f);
        }
    }
}

