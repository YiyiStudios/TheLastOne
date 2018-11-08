using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    enum STATE { IDLE, CHASE }
    STATE state = STATE.IDLE;
    Vector3 torotate;
    public float rotate;
    TimeController time;
  public  GameObject objvf;
    VisualField vf;

    public Transform player;
    [Range(1f, 20f)]
    public float velocity;
    Animator anim;
    int contanim = 0;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = player.GetComponent<Transform>();
        vf = objvf.GetComponent<VisualField>();
     // vf = GetComponentInChildren<VisualField>();
        time = gameObject.AddComponent<TimeController>();
        time.totaltime = 1.3f;
        time.TurnOn();
        torotate.z = transform.rotation.eulerAngles.z;
    }
    // Update is called once per frame
    void Update()
    {
        States();
        //       Animation_States();
    }
    void Rotate()
    {
        if (time.Finished())
        {
            time.Run();
            //  torotate.z += rotate;
            //  transform.rotation = Quaternion.Euler(torotate);
            AnimationRotate();
            time.TurnOn();
        }


    }
    void Chasing()
    {
        if (vf.listvisibletarget.Count != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, vf.listvisibletarget[0].transform.position, Time.deltaTime * velocity);
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
            if (vf.listvisibletarget.Count == 0)
            {
                state = STATE.IDLE;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.position = new Vector3(5.65f, 2.5f, 0);
        }
    }

    Vector2 DirectionVector()
    {
        return (player.position - transform.position).normalized;
    }


    void Animation_States(Vector2 mov)
    {
        anim.SetFloat("Horizontal", mov.x);
        anim.SetFloat("Vertical", mov.y);
        anim.SetFloat("Magnitude", mov.magnitude);
    }
    void AnimationRotate()
    {
        switch (contanim)
        {
            case 0:
                anim.SetFloat("Horizontal", 1);
                anim.SetFloat("Vertical", 0);
                //vf.viewAngle = vf.viewAngle + 45;
                break;
            case 1:
                anim.SetFloat("Horizontal", 0);
                anim.SetFloat("Vertical", 1);
              //  vf.viewAngle = vf.viewAngle + 90;
                break;
            case 2:
                anim.SetFloat("Horizontal", -1);
                anim.SetFloat("Vertical", 0);
               // vf.viewAngle = vf.viewAngle + 180;
                break;
            case 3:
                anim.SetFloat("Horizontal", 0);
                anim.SetFloat("Vertical", -1);
              //  vf.viewAngle = vf.viewAngle + 270;
                break;

        }
        contanim++;
    }
}
