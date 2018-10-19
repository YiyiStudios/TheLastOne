using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rg2;
    Vector2 mov;
    [Range(0, 20)]
    public float velocity;

    // Use this for initialization
    void Start()
    {
        rg2 = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement_Update();
    }
    private void FixedUpdate()
    {
        Movement_Fixed_Update();
    }

    #region Movement
    void Movement_Update()
    {
        mov = new Vector2(Input.GetAxisRaw("Horizontal"),
                          Input.GetAxisRaw("Vertical")).normalized;
    }
    void Movement_Fixed_Update()
    {
        if (mov.x != 0 && mov.y == 0)
        {
            rg2.MovePosition(rg2.position + mov * Time.deltaTime * velocity * Vector2.right);
        }
        if (mov.y != 0 && mov.x == 0)
        {
            rg2.MovePosition(rg2.position + mov * Time.deltaTime * velocity * Vector2.up);
        }
    }
    #endregion
}
