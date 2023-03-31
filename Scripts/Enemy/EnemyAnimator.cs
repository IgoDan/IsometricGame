using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAnimator : MonoBehaviour
{
    Animator anim;

    string[] StaticDirection = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    string[] RunDirection = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    string[] StaticShootDirection = { "SStatic N", "SStatic NW", "SStatic W", "SStatic SW", "SStatic S", "SStatic SE", "SStatic E", "SStatic NE" };
    string[] RunShootDirection = { "SRun N", "SRun NW", "SRun W", "SRun SW", "SRun S", "SRun SE", "SRun E", "SRun NE" };

    int lastDirection;
    

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void EnemyDirection(Vector2 vel)
    {
        
        string[] directionArray = null;
        if (vel.magnitude <= 0.1)
            directionArray = StaticDirection;
        else
        {
            directionArray = RunDirection;
            lastDirection = FindObjectOfType<CharacterDirection>().DirectionToIndex(vel);
        }

        anim.Play(directionArray[lastDirection]);
        
    }

}
