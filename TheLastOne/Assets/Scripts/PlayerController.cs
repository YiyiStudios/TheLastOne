﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
//    enum state { walkright,walkleft,walkUP,walkdown,idleup}
//    STATE state = STATE.DOWN;
    Animator anim;
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
        MovementUpdate();
        AnimationStates();    
    }
    private void FixedUpdate()
    {
        MovementFixedUpdate();
    }
    #region Movement
    void MovementUpdate()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
    void MovementFixedUpdate()
    {
        rg2.MovePosition(rg2.position + mov * Time.deltaTime * velocity );
    }
    #endregion
    void AnimationStates()
    {
        anim.SetFloat("Horizontal",mov.x);
        anim.SetFloat("Vertical",mov.y);
        anim.SetFloat("Magnitude",mov.magnitude);
    }

}
