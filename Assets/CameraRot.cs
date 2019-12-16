using UnityEngine;
using System.Collections;

public class CameraRot : MonoBehaviour
{
    [SerializeField] private string MouseXInputName, MouseYInputName;
    [SerializeField] private float mouseSensivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;
    public void Awake()
    {
        LockKursor();
        xAxisClamp = 0;
    }
    private void LockKursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        CameraRotation();
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(MouseXInputName) * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis(MouseYInputName) * mouseSensivity * Time.deltaTime;
        xAxisClamp += mouseY;
        if (xAxisClamp>90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }
        transform.Rotate(Vector3.left * mouseY);
       playerBody.Rotate(Vector3.up * mouseX);
    }
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}