using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControleSakura2 : MonoBehaviour
{
    public static ControleSakura2 Instance { set; get; }

    private const float LANE_DISTANCE = 3f;
    private const float TURN_SPEED = 0.05f;
    public bool isRunning = false;
    private Animator anim;
    private CharacterController controller;
    public float jumpForce = 10.0f;
    public float gravity = 12.0f;
    private float verticalVelocity;
    private int desiredLane = 1;

    private float originalSpeed = 8.0f;
    private float speed = 8.0f;
    private float speedIncreaseLastTick;
    private float speedIncreaseTime = 2.5f;
    private float speedIncreaseAmount = 0.1f;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        speed = originalSpeed;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isRunning)
            return;

        if(Time.time - speedIncreaseLastTick > speedIncreaseTime)
        {
            speedIncreaseLastTick = Time.time;
            speed += speedIncreaseAmount;
            GameManager.Instance.UpdateModifier(speed - originalSpeed);
        }

        if (MobileSwipe.Instance.SwipeLeft)
            MoveLane(false);
        if (MobileSwipe.Instance.SwipeRight)
            MoveLane(true);

        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * LANE_DISTANCE;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * LANE_DISTANCE;

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;

        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded", isGrounded);

        if (IsGrounded())
        {
            verticalVelocity = -0.1f;
            
            if (MobileSwipe.Instance.SwipeUp)
            {
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

            if (MobileSwipe.Instance.SwipeDown)
            {
                verticalVelocity = -jumpForce;
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward,dir, TURN_SPEED);
        }
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x,(controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,controller.bounds.center.z),Vector3.down);
        Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);

        return (Physics.Raycast(groundRay, 0.2f + 0.1f));
    }

    public void OnStartRunning()
    {
        isRunning = true;
        anim.SetTrigger("StartRunning");
    }
    public void OnCorrectAtack()
    {
        isRunning = true;
    }
    public void OnWrongAtack()
    {
        anim.SetTrigger("Death");
    }

    public void CombatOn(GameObject Inimigo)
    {
        anim.SetTrigger("Waiting");
        isRunning = false;
        GameManager.Instance.isStarted = false;
        var component = Inimigo.GetComponent<EnemyComponent>();
        if (component != null)
        {
            component.OnClose();
        }
    }

    private void Crash()
    {
        anim.SetTrigger("Death");
        isRunning = false;
        GameManager.Instance.OnDeath();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Obstacle":
                Crash();
                break;
        }
        switch (hit.gameObject.tag)
        {
            case "Enemy":
                CombatOn(hit.gameObject);
                break;
        }
    }
}
