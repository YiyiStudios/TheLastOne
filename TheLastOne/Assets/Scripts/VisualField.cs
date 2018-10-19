using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualField : MonoBehaviour {
    public float viewAngle;
    public float viewRadius;

    List<int> visibleTarget = new List<int>();



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
  public  Vector3 Vector_Direction_Line(float angle,bool coordGlobal)
    {
        if (!coordGlobal)
        {
            angle += transform.rotation.z;
        }

        return new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad),
                            Mathf.Sin(angle * Mathf.Deg2Rad),
                            0);
    }

}
