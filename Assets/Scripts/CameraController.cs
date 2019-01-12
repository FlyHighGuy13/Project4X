using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    // Use this for initialization
    private float mouseSpeed = 35.0f;

    private int mScreenWidth;
    private int mScreenHeight;
    private const int mBoundary = 10;
    private const float mCameraZoomMax = 0f;
    private const float mCameraZoomMin = -15f;
    
    void Start()
    {
        mScreenWidth = Screen.width;
        mScreenHeight = Screen.height;
    }

    // Update is called once per frame
    public float mSpeed = 10.0f;
    void Update() {
        Vector3 currentPosition = transform.position;

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(new Vector3(mSpeed * Time.deltaTime, 0, 0));
        }
        
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(new Vector3(-mSpeed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(new Vector3(0, 0, -mSpeed * Time.deltaTime));
        }
        
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(new Vector3(0, 0, mSpeed * Time.deltaTime));
        }
        
        if ((Input.GetAxis("Mouse ScrollWheel") < 0) && currentPosition.y < mCameraZoomMax) {
            transform.position += new Vector3(0, 1, 0);
            transform.position -= new Vector3(0, 0, 1);
        }
        
        if ((Input.GetAxis("Mouse ScrollWheel") > 0) && currentPosition.y > mCameraZoomMin) {
            transform.position -= new Vector3(0, 1, 0);
            transform.position += new Vector3(0, 0, 1);
        }
        
        if (Input.GetKey(KeyCode.Mouse0)) {

            if (Input.GetAxis("Mouse X") > 0) {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed);
            }
            
            else if (Input.GetAxis("Mouse X") < 0) {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSpeed, 0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed);
            }
        }

        if (Application.isFocused) {

            if (Input.mousePosition.x > mScreenWidth - mBoundary) {
                transform.Translate(new Vector3(mSpeed * Time.deltaTime, 0, 0));
            }

            if (Input.mousePosition.x < mBoundary) {
                transform.Translate(new Vector3(-mSpeed * Time.deltaTime, 0, 0));
            }

            if (Input.mousePosition.y > mScreenHeight - mBoundary) {
                transform.Translate(new Vector3(0, 0, mSpeed * Time.deltaTime));
            }

            if (Input.mousePosition.y < mBoundary) {
                transform.Translate(new Vector3(0, 0, -mSpeed * Time.deltaTime));
            }
        }
    }
}

