using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public bool turn_on = false;
    public float elapsedtime = 0;
    public float totaltime = 0;
    public void Run()
    {
        if (turn_on)
        {
            elapsedtime += Time.deltaTime;
            if (elapsedtime >= totaltime )
            {
                turn_on = false;
            }
        }Debug.Log(elapsedtime);
    }
    public void TurnOn()
    {
        if (totaltime > 0)
        {
            turn_on = true;
            elapsedtime = 0;
        }
    }
    public bool Finished()
    {
        return !turn_on;
    }
    private void Update()
    {
        Run();
    }
}
