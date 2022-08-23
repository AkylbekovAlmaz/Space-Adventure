using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMovement : MonoBehaviour
{
    [SerializeField] int minX = - 50;
    [SerializeField] int maxX = 50;
    [SerializeField] int minY = 10;
    [SerializeField] int maxY = 25;

    private Vector3 nextPosition;

    private float speed;

    private void Start()
    {
        SetRandomPosition();
    }

    private void Update()
    {
        MoveToPoint();
    }

    private void MoveToPoint()
    {
        if (transform.position == nextPosition)
            SetRandomPosition();
         else
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void SetRandomPosition()
    {
        speed = Random.Range(8, 24);

        nextPosition.x = Random.Range(minX, maxX);
        nextPosition.y = Random.Range(minY, maxY);
    }
}
