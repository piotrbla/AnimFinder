using System;
using UnityEngine;

public class Main : MonoBehaviour
{
    public float DistanceToAnimal = 2.2f;

    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;
    void Start()
    {
        var pointMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        var pointMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        minX = pointMin.x + 2 * DistanceToAnimal;
        minY = pointMin.y + 2 * DistanceToAnimal;
        maxX = pointMax.x - 2 * DistanceToAnimal;
        maxY = pointMax.y - 2 * DistanceToAnimal;
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
            float forceX = diffX;
            float forceY = diffY;
            print("forceX " + forceX.ToString());
            print("forceY " + forceY.ToString());
            float newX = point.x < rigidBody.position.x
                ? rigidBody.position.x + forceX
                : rigidBody.position.x - forceX;
            float newY = point.y < rigidBody.position.y
                ? rigidBody.position.y + forceY
                : rigidBody.position.y - forceY;
            newX = Mathf.Clamp(newX, minX, maxX);
            newY = Mathf.Clamp(newY, minY, maxY);
            Vector2 newPosition = new Vector2(newX, newY);
            rigidBody.MovePosition(newPosition);
        }
    }
}

    