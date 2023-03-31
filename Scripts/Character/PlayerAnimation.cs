using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    string[] StaticDirection = { "Static N", "Static NW", "Static W", "Static SW", "Static S", "Static SE", "Static E", "Static NE" };
    string[] RunDirection = { "Run N", "Run NW", "Run W", "Run SW", "Run S", "Run SE", "Run E", "Run NE" };
    string[] StaticShootDirection = { "SStatic N", "SStatic NW", "SStatic W", "SStatic SW", "SStatic S", "SStatic SE", "SStatic E", "SStatic NE" };
    string[] RunShootDirection = { "SRun N", "SRun NW", "SRun W", "SRun SW", "SRun S", "SRun SE", "SRun E", "SRun NE" };

    [HideInInspector]public int lastDirection;

    public float animationResetTime;
    bool isRunning;

    public GameObject point;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 _direction)
    {
        string[] directionArray = null;
        if (_direction.magnitude < 0.2)
            isRunning = false;
        else
            isRunning = true;

        if (!isRunning)
            directionArray = StaticDirection;
        else
        {
            directionArray = RunDirection;
            lastDirection = this.GetComponent<CharacterDirection>().DirectionToIndex(_direction);
        }

        bool _isShooting = this.GetComponent<Weapon>().isShooting;
        //Debug.Log(_isShooting);
        if (_isShooting)
        {
            lastDirection = this.GetComponent<Weapon>().shootingDirection;
        }
        
        anim.Play(directionArray[lastDirection]);
        
    }

}
