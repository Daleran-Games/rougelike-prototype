using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using AdvancedInspector;
using System;

namespace DaleranGames
{
    public class Vector2IntEditor : FieldEditor
    {
        public override Type[] EditedTypes
        {
            get
            {
                return new Type[] { typeof(Vector2Int) };
            }
        }

        public override void Draw(InspectorField field, GUIStyle style)
        {
            float width = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = VECTOR_FIELD_WIDTH;

            GUILayout.BeginHorizontal();
            Vector2Int[] values = field.GetValues<Vector2Int>();

            int[] x = new int[values.Length];
            int[] y = new int[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                x[i] = values[i].x;
                y[i] = values[i].y;
            }

            int result;
            if (IntegerEditor.DrawInt("X", x, style, out result))
            {
                field.RecordObjects("Edit " + field.Name + " X");

                for (int i = 0; i < field.Instances.Length; i++)
                {
                    values[i].x = result;
                    field.SetValue(field.Instances[i], values[i]);
                }
            }

            if (IntegerEditor.DrawInt("Y", y, style, out result))
            {
                field.RecordObjects("Edit " + field.Name + " Y");

                for (int i = 0; i < field.Instances.Length; i++)
                {
                    values[i].y = result;
                    field.SetValue(field.Instances[i], values[i]);
                }
            }
            GUILayout.EndHorizontal();
            EditorGUIUtility.labelWidth = width;
        }
    }
}
