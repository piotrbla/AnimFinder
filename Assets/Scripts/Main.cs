using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public double Tolerance = 0.02;

    void Start()
    {
        print("First");
    }

    void Update()
    {
        var mouse = Input.mousePosition;
        var point = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, Camera.main.nearClipPlane));
        var rigidBody = GetComponent<Rigidbody2D>();

        if (Input.mousePosition.x > 0)
        {
            print(Input.mousePosition);
            print(rigidBody.position);
            if (Math.Abs(point.x - rigidBody.position.x) > Tolerance)
            {
                Vector2 newPosition = new Vector2(point.x - 1, point.y);
                rigidBody.MovePosition(newPosition);
            }
        }
    }
}

    