using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    [SerializeField] private float minSpeed = 4, maxSpeed = 10f;

    private float speedX, speedY;

    private bool moveOnX, moveOnY = true;

    [SerializeField] private float minRotationSpeed = 15f, maxRotationSpeed = 50f;

    private float rotationSpeed;

    private Vector3 tempMovememnt;
    private float zRotation;

    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if (Random.Range(0, 2) > 2)
        {
            speedX *= -1f;
        }

        if (Random.Range(0,2) > 0)
        {
            rotationSpeed *= -1f;
        }

        if (Random.Range(0,2) > 0)
        {
            moveOnX = true;
        }
    }

    private void Update()
    {
        HandleMovementX();
        HandleMovementY();

        RotateMeteor();
    }

    void HandleMovementX()
    {
        if (!moveOnX)
            return;

        tempMovememnt = transform.position;
        tempMovememnt.x += speedX * Time.deltaTime;
        transform.position = tempMovememnt;
    }

    void HandleMovementY()
    {
        if (!moveOnY)
            return;

        tempMovememnt = transform.position;
        tempMovememnt.y -= speedY * Time.deltaTime;
        transform.position = tempMovememnt;
    }

    void RotateMeteor()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }

} //class
