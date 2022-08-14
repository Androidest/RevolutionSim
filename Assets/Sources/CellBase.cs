using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimCore
{
    public class CellBase : MonoBehaviour
    {
        const float StopSpeed = 0.01f;
        float Friction;
        float Speed;
        float Acceleration;
        float _DirectionAngle;
        float DirectionAngle
        {
            get { return _DirectionAngle; }
            set
            {
                if (value > Math.PI) 
                    _DirectionAngle = value - Consts.TWO_PI;
                else if (value <= -Math.PI) 
                    _DirectionAngle = value + Consts.TWO_PI;
                else
                    _DirectionAngle = value;
            }
        }

        void Start()
        {
            Acceleration = 5f;
            Friction = -3f;
            Speed = 0;
            DirectionAngle = UnityEngine.Random.value * Consts.TWO_PI;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            var dt = Time.deltaTime;
            Speed += (Acceleration + Math.Sign(Speed) * Friction) * dt;
            if (Math.Abs(Speed) < StopSpeed)
                Speed = 0;

            var moveDist = Speed * dt;
            transform.position += new Vector3(
                (float)Math.Cos(DirectionAngle) * moveDist, 
                (float)Math.Sin(DirectionAngle) * moveDist, 
                0);
        }
    }
}