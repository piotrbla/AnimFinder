using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float DistanceToAnimal = 2.2f;

    void Start()
    {
        print("First");
    }

    void Update()
    {
        var mouse = Input.mousePosition;
        var point = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, Camera.main.nearClipPlane));
        var rigidBody = GetComponent<Rigidbody2D>();
        float diffX = Math.Abs(point.x - rigidBody.position.x);
        float diffY = Math.Abs(point.y - rigidBody.position.y);
        if (diffX < DistanceToAnimal && diffY < DistanceToAnimal)
        {
            float forceX = DistanceToAnimal - diffX;
            float forceY = DistanceToAnimal - diffY;
            float newX = point.x < rigidBody.position.x
                ? rigidBody.position.x + forceX
                : rigidBody.position.x - forceX;
            float newY = point.y < rigidBody.position.y
                ? rigidBody.position.y + forceY
                : rigidBody.position.y - forceY;
            //print(point);
            //print(rigidBody);
            Vector2 newPosition = new Vector2(newX, newY);
            rigidBody.MovePosition(newPosition);
        }
    }
}

    