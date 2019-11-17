using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    Camera playerCamera;

    public float xMin = -60f;
    public float xMax = 60f;
    public float yMin = -360f;
    public float yMax = 360f;

    public float xSensitivity = 2f;
    public float ySensitivity = 2f;

    public float xRotation = 0f;
    public float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to keep it in the game window
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Input.GetAxisRaw("Mouse X") * ySensitivity;
        xRotation += Input.GetAxisRaw("Mouse Y") * xSensitivity;

        // Clamp to keep camera up/down rotation within a reasonable/realistic/wanted range
        xRotation = Mathf.Clamp(xRotation, xMin, xMax);

        playerCamera.transform.localEulerAngles = new Vector3(-xRotation, yRotation, 0);
        //Debug.Log("Camera forward" + playerCamera.transform.forward);

        // Unlock the cursor
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // Make cursor visible
            Cursor.visible = true;
        }
    }
}
