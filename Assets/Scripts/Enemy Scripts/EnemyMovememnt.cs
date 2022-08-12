using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovememnt : MonoBehaviour
{

    [SerializeField] private bool moveOnX, moveOnY;

    private float min_X, max_X;
    private float min_Y, max_Y;

    [SerializeField] private float moveSpeed = 8f;

    [SerializeField] private float horizontalMovementTreshold = 8f;
    [SerializeField] private float verticallMovementTreshold = 6f;

    private Vector3 tempMovement_Horizontal;
    private Vector3 tempMovement_Vertical;

    private bool moveLeft;
    private bool moveUp = false;

    private void Start()
    {
        min_X = transform.position.x - horizontalMovementTreshold;
        max_X = transform.position.x + horizontalMovementTreshold;

        max_Y = transform.position.y;
        min_Y = transform.position.y - verticallMovementTreshold;

        if (Random.Range(0, 2) > 2)
            moveLeft = true;

    }

    private void Update()
    {
        HandleEnemyMovememntHorizontal();
        HandleEnemyMovememntVertical();
    }

    private void HandleEnemyMovememntHorizontal()
    {

        if (!moveOnX)
            return;


        if (moveLeft)
        {
            tempMovement_Horizontal = transform.position;
            tempMovement_Horizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Horizontal;

            if (tempMovement_Horizontal.x < min_X)
                moveLeft = false;

        } else
        {
            tempMovement_Horizontal = transform.position;
            tempMovement_Horizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Horizontal;

            if (tempMovement_Horizontal.x > max_X)
                moveLeft = true;
        }


    }

    private void HandleEnemyMovememntVertical()
    {

        if(!moveOnY)
            return;

        if (moveUp)
        {

            tempMovement_Vertical = transform.position;
            tempMovement_Vertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Vertical;

            if (tempMovement_Vertical.y > max_Y)
                moveUp = false;

        }
        else
        {

            tempMovement_Vertical = transform.position;
            tempMovement_Vertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovement_Vertical;

            if (tempMovement_Vertical.y < min_Y)
                moveUp = true;

        }


    }

} //class
