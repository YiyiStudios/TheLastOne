using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VisualField))]
public class VisualFieldEditor : Editor
{

    private void OnSceneGUI()
    {
        VisualField FV = (VisualField)target;

        Handles.color = Color.black;
        Handles.DrawWireArc(FV.transform.position, Vector3.forward, Vector3.right, 360, FV.viewRadius);

        Vector3 upLine = FV.Vector_Direction_Line(FV.viewAngle / 2);
        Vector3 dowmLine = FV.Vector_Direction_Line(-FV.viewAngle / 2);

        Handles.DrawLine(FV.transform.position, FV.transform.position + upLine * FV.viewRadius);
        Handles.DrawLine(FV.transform.position, FV.transform.position + dowmLine * FV.viewRadius);



    }

}
