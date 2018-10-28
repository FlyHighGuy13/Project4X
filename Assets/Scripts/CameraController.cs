using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    // Use this for initialization
    private float mouseSpeed = 35.0f;

    private int screenWidth;
    private int screenHeight;

    private const int Boundary = 50;
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    public float mSpeed = 10.0f;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(mSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-mSpeed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -mSpeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, mSpeed * Time.deltaTime));
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.position += new Vector3(0, 1, 0);
            transform.position -= new Vector3(0, 0, 1);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.position -= new Vector3(0, 1, 0);
            transform.position += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed);
            }
        }
        if (Application.isFocused)
        {
            if (Input.mousePosition.x > screenWidth - 10)
            {
                transform.Translate(new Vector3(mSpeed * Time.deltaTime, 0, 0));
            }

            if (Input.mousePosition.x < 10)
            {
                transform.Translate(new Vector3(-mSpeed * Time.deltaTime, 0, 0));
            }

            if (Input.mousePosition.y > screenHeight - 10)
            {
                transform.Translate(new Vector3(0, 0, mSpeed * Time.deltaTime));
            }

            if (Input.mousePosition.y < 10)
            {
                transform.Translate(new Vector3(0, 0, -mSpeed * Time.deltaTime));
            }
        }
    }
}

