using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{ 
    enum STATE {IDLE,CHASE }
    STATE state = STATE.IDLE;
    Vector3 a;
    public float rotate;
    TimeController time;
    VisualField vf;

    // Use this for initialization
    void Start()
    {
        vf = GetComponent<VisualField>();
        time = gameObject.AddComponent<TimeController>();
        time.totaltime = 2f;
        time.TurnOn();
        a.z = transform.rotation.eulerAngles.z;
    }
    // Update is called once per frame
    void Update()
    {
        States();
    }
    void Rotate()
    {
        if (time.Finished())
        {
            time.Run();
            a.z += rotate;
            transform.rotation = Quaternion.Euler(a);
            time.TurnOn();
        }
    }
    void Chasing()
    {
        if (vf.listvisibletarget.Capacity != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, vf.listvisibletarget[0].transform.position, Time.deltaTime * 4);
        }
    }
    void States()
    {
        if (state == STATE.IDLE)
        {
            Rotate();
            if (vf.listvisibletarget.Count != 0)
            {
                state = STATE.CHASE;
            }
        }
        if (state == STATE.CHASE)
        {
            Chasing();
        }
        if (vf.listvisibletarget.Count==0)
        {
            state = STATE.IDLE;
        }
    }
}
