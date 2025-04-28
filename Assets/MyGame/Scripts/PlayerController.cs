using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _characterController;
    [SerializeField] private Transform _camera;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject pausePanel;

    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float runTransitSpeed = 5f;
    [SerializeField] private float turningSpeed = 2f;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float jumpHeight = 2f;

    private float verticalVelocity;
    private float speed;

    [Header("Input")]
    private float moveInput;
    private float turnInput;

    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        InputManagement();
        Movement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    private void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;                      // останавливаем игру
        Cursor.lockState = CursorLockMode.None;   // разблокируем курсор
        Cursor.visible = true;
        isPaused = true;
    }

    private void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;                      // возвращаем время
        Cursor.lockState = CursorLockMode.Locked; // блокируем курсор
        Cursor.visible = false;
        isPaused = false;
    }

    private void Movement()
    {
        GroundMovement();
        Turn();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3(turnInput, 0, moveInput);
        move = transform.TransformDirection(move);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("isRunning", true);
            speed = Mathf.Lerp(speed, runSpeed, runTransitSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("isRunning", false);
            speed = Mathf.Lerp(speed, walkSpeed, runTransitSpeed * Time.deltaTime);
        }

        move *= speed;

        move.y = VerticalForceCalculation();

        _characterController.Move(move * Time.deltaTime);
    }

    private void Turn()
    {
        if (Mathf.Abs(turnInput) < 0 || Mathf.Abs(moveInput) > 0)
        {
            Vector3 currentLookDirection = _camera.forward;
            currentLookDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turningSpeed);
        }
    }

    private float VerticalForceCalculation()
    {
        if (_characterController.isGrounded)
        {
            verticalVelocity = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                if (_animator.GetBool("isRunning"))
                    _animator.SetTrigger("JumpWhileRunning");
                else
                    _animator.SetTrigger("Jump");
                verticalVelocity = Mathf.Sqrt(jumpHeight * gravity * 2);
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        return verticalVelocity;
    }

    private void InputManagement()
    {
        _animator.SetFloat("verticalInput", moveInput);
        _animator.SetFloat("horizontalInput", turnInput);
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        _animator.SetBool("hasInput", Mathf.Abs(moveInput) > 0.01f || Mathf.Abs(turnInput) > 0.01f);
    }
}
