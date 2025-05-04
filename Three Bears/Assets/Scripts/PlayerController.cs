using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    public Camera PlayerCamera;
    public float WalkSpeed = 6f;
    public float RunSpeed = 12f;
    public float JumpPower = 7f;
    public float Gravity = 10f;
    public float MouseSensitive = 2f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 cameraRotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        UpdateMoveDirection();
        UpdateCameraTransform();
    }

    private void UpdateMoveDirection()
    {
        bool isRunning = false;
        float curSpeedX = (isRunning ? RunSpeed : WalkSpeed) * Input.GetAxis("Vertical");
        float curSpeedY = (isRunning ? RunSpeed : WalkSpeed) * Input.GetAxis("Horizontal");
        float movementDirectionY = moveDirection.y;
        moveDirection = (transform.forward * curSpeedX) + (transform.right * curSpeedY);

        if (Input.GetButton("Jump") && characterController.isGrounded)
            moveDirection.y = JumpPower;
        else
            moveDirection.y = movementDirectionY;

        if (!characterController.isGrounded)
            moveDirection.y -= Gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void UpdateCameraTransform()
    {
        cameraRotation.y += Input.GetAxisRaw("Mouse X") * MouseSensitive;
        cameraRotation.x -= Input.GetAxisRaw("Mouse Y") * MouseSensitive;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -90f, 90f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(cameraRotation.x, 0, 0);
        transform.rotation = Quaternion.Euler(0, cameraRotation.y, 0);
    }
}
