using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    enum STATE { walkright,walkleft,walkUP,walkdown,idleup}
//    STATE state = STATE.DOWN;

    Animator anim;
    public bool isright=false;
    Rigidbody2D rg2;
    public  Vector2 mov;
    [Range(0, 20)]
    public float velocity;
    // Use this for initialization
    void Start()
    {
        rg2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement_Update();
        Animation_States();
    }
    private void FixedUpdate()
    {
        Movement_Fixed_Update();
    }

    #region Movement
    void Movement_Update()
    {
        mov = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
    void Movement_Fixed_Update()
    {
        rg2.MovePosition(rg2.position + mov * Time.deltaTime * velocity );
    }
    #endregion
    void Animation_States()
    {
        anim.SetFloat("Horizontal",mov.x);
        anim.SetFloat("Vertical",mov.y);
        anim.SetFloat("Magnitude",mov.magnitude);
    }


}
