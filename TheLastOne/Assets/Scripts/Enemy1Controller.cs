using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    enum state { idle, chase }
    state states = state.idle;
    Vector3 torotate;
    [SerializeField] private float rotate;
    TimeController time;
    public GameObject objvf;
    public Transform objdetector;
    VisualField vf;
    [SerializeField] Transform player;
    [Range(1f, 20f)] [SerializeField] private float velocity;
    Animator anim;
    private int contanim = 0;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        player = player.GetComponent<Transform>();
        vf = objvf.GetComponent<VisualField>();
        objdetector = objdetector.GetComponent<Transform>();
        time = gameObject.AddComponent<TimeController>();
        time.totaltime = 1f;
        time.TurnOn();
        torotate.z = transform.rotation.eulerAngles.z;
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
            AnimationRotate();
            time.TurnOn();
        }
    }
    void Chasing()
    {
        anim.SetFloat("Vertical", DirectionVector().y);
        anim.SetFloat("Horizontal", DirectionVector().x);
        anim.SetFloat("Magnitude", DirectionVector().magnitude);
        if (vf.listvisibletarget.Count != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, vf.listvisibletarget[0].transform.position, Time.deltaTime * velocity);
        }
    }
    void States()
    {
        if (states == state.idle)
        {
            Rotate();
            if (vf.listvisibletarget.Count != 0)
            {
                states = state.chase;
            }
        }
        if (states == state.chase)
        {
            Chasing();
            if (vf.listvisibletarget.Count == 0)
            {
                states = state.idle;
                anim.SetFloat("Magnitude", 0);
            }
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
                vf.transform.rotation = Quaternion.Euler(0, 0, 0);
                objdetector.position =transform.localPosition + new Vector3(0.65f,0.75f,0);
                objdetector.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 1:
                anim.SetFloat("Horizontal", 0);
                anim.SetFloat("Vertical", 1);
                vf.transform.rotation = Quaternion.Euler(0, 0, 90);
                objdetector.rotation = Quaternion.Euler(0, 0, 180);
                objdetector.position = transform.localPosition + new Vector3(0, 1.8f, 0);
                break;
            case 2:
                anim.SetFloat("Horizontal", -1);
                anim.SetFloat("Vertical", 0);
                vf.transform.rotation = Quaternion.Euler(0, 0, 180);
                objdetector.rotation = Quaternion.Euler(0, 0, 270);
                objdetector.position = transform.localPosition + new Vector3(-0.8f, 0.75f, 0);
                break;
            case 3:
                anim.SetFloat("Horizontal", 0);
                anim.SetFloat("Vertical", -1);
                vf.transform.rotation = Quaternion.Euler(0, 0, 270);
                objdetector.rotation = Quaternion.Euler(0, 0, 0);
                objdetector.position = transform.localPosition + new Vector3(0, -0.34f, 0);
                break;
        }
        contanim++;
        if (contanim >= 4) { contanim = 0; }
    }
}
