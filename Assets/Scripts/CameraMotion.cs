using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private const float VELOCITY_SPEED = 0.05f;
    private float mSpeed;
    private float mAngularSpeed = 0.5f;
    private float mRotationAngle;
    private CharacterController mCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        mSpeed = 0f;
        mRotationAngle = 0f;

        mCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse x coordinate
        var mouseX = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W))
            mSpeed += VELOCITY_SPEED;
        if (Input.GetKey(KeyCode.S))
            mSpeed -= VELOCITY_SPEED;

        // sets sight direction by means of tranform rotate
        mRotationAngle += mouseX * mAngularSpeed * Time.deltaTime;
        transform.Rotate(0, mRotationAngle, 0);

        // Translate is one of tranformations that uses Vector3
        //transform.Translate(Vector3.forward * Time.deltaTime * mSpeed);

        // we shall use character controller to move and to stop if camera collides with another object
        var direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * mSpeed);
        mCharacterController.Move(direction);
    }
}
