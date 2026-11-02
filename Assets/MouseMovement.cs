using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 200f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;
    public Transform playerBody;

    InputAction look;

    void Start()
    {
        look = InputSystem.actions.FindAction("Look");

    }

    // Update is called once per frame
    void Update()
    {
        // Getting mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        float lookX = look.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;
        float lookY = look.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;

        // Vertical rotation
        xRotation -= mouseY;
        xRotation -= lookY;
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation
        playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(Vector3.up * lookX);




    }
}