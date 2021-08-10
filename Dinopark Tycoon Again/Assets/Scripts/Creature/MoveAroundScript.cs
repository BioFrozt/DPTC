using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using System.Diagnostics;
using System.Timers;

public class MoveAroundScript : MonoBehaviour
{

    public float xCenter;
    public float zCenter;
    public float radius;

    void FixedUpdate()
    {

        gameObject.transform.Translate(new Vector3(1, 0, 0) / 100);

        if (gameObject.transform.position.x > xCenter + radius)
            gameObject.transform.position = new Vector3(xCenter + radius, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.position.x < xCenter - radius)
            gameObject.transform.position = new Vector3(xCenter - radius, gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.position.z > zCenter + radius)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zCenter + radius);
        if (gameObject.transform.position.z < zCenter - radius)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zCenter - radius);

        checkTurning();
    }
  
    float turnStep = 0;
    int maxTurnTimeTicks = 100;
    int curTurnTimeTicks = 0;
    private static int nanoTime()
    {
        long nano = 10000L * Stopwatch.GetTimestamp();
        nano /= System.TimeSpan.TicksPerMillisecond;
        return (int)nano;
    }
    void checkTurning()
    {
        
        if (curTurnTimeTicks >= maxTurnTimeTicks)
        {
            turnStep = 5*(float)(new System.Random(nanoTime()).NextDouble() - 0.5f);
            curTurnTimeTicks = 0;
        }
        else
        {
            turn(turnStep);
            curTurnTimeTicks++;
        }
    }

    void turn(float deg)
    {
        gameObject.transform.Rotate(new Vector3(0, deg, 0));
    }

}
