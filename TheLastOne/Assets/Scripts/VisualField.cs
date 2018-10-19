using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualField : MonoBehaviour
{
    public float viewAngle;
    public float viewRadius;

    List<int> visibleTarget = new List<int>();

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.eulerAngles);
    }
    public Vector3 Vector_Direction_Line(float angle)
    {
        angle += transform.eulerAngles.z;
        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),
                            Mathf.Sin(angle * Mathf.Deg2Rad),
                            0);
    }


}
