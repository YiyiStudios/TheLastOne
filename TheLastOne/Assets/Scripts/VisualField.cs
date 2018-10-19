using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualField : MonoBehaviour
{
    public float viewAngle;
    public float viewRadius;

    public LayerMask maskTarget;

    public List<Transform> visibleTarget = new List<Transform>();

    // Update is called once per frame
    private void Update()
    {
        Visible_Target();
    }
    public Vector3 Vector_Direction_Line(float angle)
    {
        angle += transform.eulerAngles.z;
        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),
                            Mathf.Sin(angle * Mathf.Deg2Rad),
                            0);
    }
    void Visible_Target()
    {
        visibleTarget.Clear();
        visibleTarget.Capacity = 0;
        Collider2D coll = Physics2D.OverlapCircle(transform.position, viewRadius, maskTarget);
        if (coll)
        {
            Transform objetive = coll.transform;
            Vector2 vector_direction_objetive = (objetive.position - transform.position).normalized;
            if (Vector2.Angle(transform.right, vector_direction_objetive) < viewAngle / 2)
            {
                float distobjetive = Vector3.Distance(objetive.position, transform.position);
                if (Physics2D.Raycast(transform.position, vector_direction_objetive, distobjetive, maskTarget))
                {
                    visibleTarget.Add(objetive);
                }
            }
        }
    }
}



