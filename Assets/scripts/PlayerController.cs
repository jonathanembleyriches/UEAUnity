using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Input Settings")]
    public PlayerInput m_playerInput;

    private Vector2 m_currentMovementInput;
    private Vector3 m_currentMovement;

    private CharacterController m_characterController;
    private bool m_playerJumped = false;
    [SerializeField] private float m_jumpSpeed = 0.5f;
    [SerializeField] private float m_gravity = 2f;

    [SerializeField] private float m_moveSpeedWalk = 1f;
    [SerializeField] private float m_moveSpeedRun = 1.5f;
    [SerializeField] private float m_moveSpeedSprint = 2f;

    private float rotationSpeed = 1.0f;
    [SerializeField] private float rotationSpeedMouse = 1.0f;
    [SerializeField] private float rotationSpeedController = 1.0f;
    public Material bodyMaterial;
    public Animator m_animtaor;
    private int m_velocityZHash;
    private int m_velocityXHash;
    private bool m_isMovementPressed;
    private bool m_isRunPressed;
    private Vector2 m_currentRotationInput;
    private bool m_isRotationPressed;
    private float m_rotationAmount;
    private bool isCurrDeviceMouse;

    private Vector2 m_currentRot = new Vector2(0, 0);

    private void OnEnable()
    {
        //m_playerInput.CharacterControls.Enable();
    }

    private void OnDisable()
    {
        //m_playerInput.CharacterControls.Disable();
    }

    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
        m_velocityZHash = Animator.StringToHash("VelocityZ");
        m_velocityXHash = Animator.StringToHash("VelocityX");
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (!m_playerJumped && context.started)
        {
            m_playerJumped = true;
        }
    }

    public void onRun(InputAction.CallbackContext context)
    {
        m_isRunPressed = context.ReadValueAsButton();
    }

    public void OnControlsChanged()
    {
        bodyMaterial.color = Color.red;
        if (m_playerInput.currentControlScheme.Equals("Keyboard"))
        {
            rotationSpeed = rotationSpeedMouse;
            bodyMaterial.color = Color.red;
            isCurrDeviceMouse = true;
            m_currentRot = new Vector2(transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else
        {
            rotationSpeed = rotationSpeedController;
            bodyMaterial.color = Color.green;
            isCurrDeviceMouse = false;
        }
    }

    public void onMovementInput(InputAction.CallbackContext context)
    {
        m_currentMovementInput = context.ReadValue<Vector2>();
        m_currentMovement.x = m_currentMovementInput.x * m_moveSpeedSprint * Time.deltaTime;
        m_currentMovement.z = m_currentMovementInput.y * m_moveSpeedSprint * Time.deltaTime;

        m_isMovementPressed = m_currentMovementInput.x != 0 || m_currentMovementInput.y != 0;
    }

    public void onRotationInput(InputAction.CallbackContext context)
    {
        m_currentRotationInput = context.ReadValue<Vector2>();

        float deltaTimeMultiplier = isCurrDeviceMouse ? 1.0f : Time.deltaTime;
        m_isRotationPressed = m_currentRotationInput.x != 0 || m_currentRotationInput.y != 0;

        m_rotationAmount = m_currentRotationInput.x * rotationSpeed * deltaTimeMultiplier;
        m_currentRot += m_currentRotationInput * rotationSpeed * deltaTimeMultiplier;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    public float SpeedChangeRate = 10.0f;
    public float m_currXSpeed;
    public float m_currYSpeed;

    // Update is called once per frame
    private void Update()

    {
        float speedMulti;
        if (m_isRunPressed)
            speedMulti = 1.5f;
        else
            speedMulti = 1.0f;

        float xSpeed = Mathf.Clamp(m_currentMovementInput.x, -1f, 1f) * speedMulti;// * m_moveSpeedSprint;

        float zSpeed = Mathf.Clamp(m_currentMovementInput.y, -1f, 1f) * speedMulti;// * m_moveSpeedSprint;

        //handleRotation();
        m_currXSpeed = Mathf.Lerp(m_currXSpeed, xSpeed, Time.deltaTime * SpeedChangeRate);
        m_currYSpeed = Mathf.Lerp(m_currYSpeed, zSpeed, Time.deltaTime * SpeedChangeRate);
        m_animtaor.SetFloat(m_velocityXHash, m_currXSpeed);
        m_animtaor.SetFloat(m_velocityZHash, m_currYSpeed);
    }

    private float _rotationVelocity;

    private void FixedUpdate()
    {
        if (isCurrDeviceMouse)

            transform.rotation = Quaternion.Euler(0, m_currentRot.x, 0);
        else

            transform.Rotate(0, m_rotationAmount, 0);

        float speedMulti;
        if (m_isRunPressed)
            speedMulti = 4.5f;
        else
            speedMulti = 1.5f;

        Vector3 grav = new Vector3(0, 0, 0);

        grav.y = JumpingAndGravity();

        //m_characterController.Move(grav);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * m_currentMovementInput.y * Time.deltaTime * speedMulti;
        Vector3 right = transform.TransformDirection(Vector3.right) * m_currentMovementInput.x * Time.deltaTime * speedMulti;
        forward.y = 0;
        right.y = 0;
        //m_characterController.Move(forward);
        //m_characterController.Move(right);
        m_characterController.Move(forward + right + grav);
    }

    private float JumpingAndGravity()
    {
        float yVal = 0;
        if (m_playerJumped && m_characterController.isGrounded)
        {
            yVal = m_jumpSpeed;
            m_playerJumped = false;
        }
        else if (m_characterController.isGrounded)
        {
            yVal = -1 * Time.deltaTime;
        }
        else
        {
            yVal -= m_gravity * Time.deltaTime;
        }
        return yVal;
    }
}