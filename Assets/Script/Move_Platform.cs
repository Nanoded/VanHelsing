using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Platform : MonoBehaviour
{
    SliderJoint2D sj;
    JointMotor2D motor = new JointMotor2D();

    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SliderJoint2D>();
        motor.motorSpeed = 1;
        sj.motor = motor;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        motor.maxMotorTorque = 1;

        if (collision.name == "LeftTrigger")
            motor.motorSpeed = -1;

        if (collision.name == "RightTrigger")
            motor.motorSpeed = 1;

        sj.motor = motor;
    }
}
