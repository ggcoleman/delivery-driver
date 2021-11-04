using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float steerSpeed = 300f;

    [SerializeField]
    float moveSpeed = 20f;

    [SerializeField]
    float slowSpeed = 15f;

    [SerializeField]
    float boostSpeed = 30f;

     [SerializeField]
    int irregularMovenmentDurationMs = 2000;



    bool isBoosting = false;
    bool isSlowed = false;


    Timer irregularMovementTimer;

    void Start()
    {
        irregularMovementTimer = new System.Timers.Timer(irregularMovenmentDurationMs);
        irregularMovementTimer.Elapsed += OnIrregularMovementElapsed;
        irregularMovementTimer.AutoReset = true;
        irregularMovementTimer.Enabled = true;
    }

    private void OnIrregularMovementElapsed(object sender, ElapsedEventArgs e)
    {
        isBoosting = false;
        isSlowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * ResolveMovementSpeed() * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "WorldObject")
        {
            Debug.Log("Bumped into world object");
            isSlowed = true;
            irregularMovementTimer.Start();
        }

        if (other.tag == "Boost")
        {
            Debug.Log("Boost hit!");
            isBoosting = true;
            irregularMovementTimer.Start();
        }
    }

    private float ResolveMovementSpeed()
    {
        if (isBoosting)
        {
            irregularMovementTimer.Start();
            return boostSpeed;
        }
        if (isSlowed)
        {            
            irregularMovementTimer.Start();
            return slowSpeed;
        }

        return moveSpeed;
    }
}
