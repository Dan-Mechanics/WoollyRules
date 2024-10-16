using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CutTheSheep
{
    public class ScissorsCursor : MonoBehaviour
    {
        private Vector2 cursorPosition;

        private void Start()
        {
            Application.targetFrameRate = 300;
            Cursor.visible = false;
        }
    }
}