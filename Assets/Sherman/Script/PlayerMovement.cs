using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody tank;

    [Header("Speed settings")]
    public float acceleration;
    public float tankRotationSpeed;
    public float turretRotationSpeed;
    public float turretBarrelRotationSpeed;
    public float speed;

    [Header("Turret Angle Limit")]
    public float barrelAngleMax;
    public float barrelAngleMin;

    [Header("Tank part")]
    public GameObject turret;
    public GameObject turretBarrel;

    [Header("Audio")]
    public AudioSource tank_idle;
    public AudioSource tank_full_engine;

    private float barrelAngle = 0f;
    private float inputVertical;
    public float inputVerticalCurrent;
    private Vector3 tankDirection;

    void Start()
    {
        tank = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputVerticalCurrent = Mathf.Lerp(inputVerticalCurrent, inputVertical, acceleration * Time.deltaTime);

        tankDirection = transform.forward * inputVerticalCurrent;

        //  Tank movement
        tankRotation();
        turretRotation();
    }

    private void FixedUpdate()
    {
        //  Tank movement
        tankMovement();
    }

    void tankMovement()
    {
        tank.MovePosition(tank.position + tankDirection * speed * Time.deltaTime);
    }

    void tankRotation()
    {
        //  Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(tank.position, transform.up, -tankRotationSpeed * Time.deltaTime);
        }
        //  Rotate Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(tank.position, transform.up, tankRotationSpeed * Time.deltaTime);
        }
    }

    void turretRotation()
    {
        //  Turret rotation to the Left.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turret.transform.RotateAround(turret.transform.position, transform.up, -turretRotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turret.transform.RotateAround(turret.transform.position, transform.up, turretRotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (barrelAngle > -40f)
            {
                turretBarrel.transform.Rotate(Vector3.right, -turretBarrelRotationSpeed * Time.deltaTime, Space.Self);
                barrelAngle -= 0.1f;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (barrelAngle < 25f)
            {
                turretBarrel.transform.Rotate(Vector3.right, turretBarrelRotationSpeed * Time.deltaTime, Space.Self);
                barrelAngle += 0.1f;
            }
                
        }
    }
}
