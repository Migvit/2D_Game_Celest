using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    [Header("Movement")]
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float acceleration = 13f;
    [SerializeField] public float decceleration = 16f;
    [SerializeField] public float velPower = 0.96f;
    [SerializeField] public float accelInAir = 0.5f;
    [SerializeField] public float deccelInAir = 0.7f;
    public float lastOnGroundTime;
    bool doConserveMomentum;

    private Rigidbody2D rb;

    [Header("Jump")]
    [SerializeField] public int maxJumps = 1;
    [SerializeField] public float jumpForce = 10f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] public int jumpCount;
    [SerializeField] public float coyoteTime;
    [SerializeField] public float jumpInputBufferTime;
    [SerializeField] public float lastJumpedTime;
    [SerializeField] public float jumpCutMultiplier = 0.5f;
    [SerializeField] public float fallGravityMultiplier = 0.5f;
    [SerializeField] public float gravityScale = 1f;


    [Header("Dashing")]
    [SerializeField] public float dashSpeed = 20f;
    [SerializeField] public float dashDuration = 0.2f;
    [SerializeField] public int dashCount;
    [SerializeField] public int maxDash = 1;
    [SerializeField] public bool isDashing = false;
    [SerializeField] public bool canDash = true;
    private Vector2 dashDirection;
    private TrailRenderer trailRenderer;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumps;
        dashCount = maxDash;
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {

        #region TIMERS
        lastOnGroundTime -= Time.deltaTime;
        lastJumpedTime -= Time.deltaTime;
     
        #endregion

        if (isDashing) { return; }



        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                if (canDash && dashCount > 0)
                {
                    Debug.Log("dashing");
                    trailRenderer.emitting = true;
                    dashCount--;
                    StartCoroutine(Dash());
                }

            }

        

    }

        private void FixedUpdate()
        {
            Move();

            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravityScale * fallGravityMultiplier;
            }
            else
            {
                rb.gravityScale = gravityScale;
            }
        }

    void Move()
        {
        float moveInput = Input.GetAxis("Horizontal");
        float targetSpeed = moveInput * moveSpeed;
      
        #region Calculate AccelRate
        float accelRate;

            //Gets an acceleration value based on if we are accelerating (includes turning) 
            //or trying to decelerate (stop). As well as applying a multiplier if we're air borne.
            if (lastOnGroundTime > 0)
                accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
            else
                accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration * accelInAir : decceleration * deccelInAir;
        #endregion
       
        #region Conserve Momentum
        //We won't slow the player down if they are moving in their desired direction but at a greater speed than their maxSpeed
        if (doConserveMomentum && Mathf.Abs(rb.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(rb.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && lastOnGroundTime < 0)
        {
            //Prevent any deceleration from happening, or in other words conserve are current momentum
            //You could experiment with allowing for the player to slightly increae their speed whilst in this "state"
            accelRate = 0;
        }
        #endregion


        float speedDif = targetSpeed - rb.velocity.x;

        float movement = speedDif * accelRate;

        //Convert this to a vector and apply to rigidbody
        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

        void Jump()
        {
            if (Input.GetButtonDown("Jump") && jumpCount > 0 && lastJumpedTime < 0)
            {

                lastJumpedTime = jumpInputBufferTime;
            

                float force = jumpForce;
                if (rb.velocity.y < 0)
            
                force -= rb.velocity.y;

                rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                jumpCount--;

                
                // Notifica o cenário para rotacionar
                FindObjectOfType<ScenarioRotator>().RotateScene();
            }


        if (isGrounded)
            {
                jumpCount = maxJumps;
            }
        }
    

    #region COLLIDER CHECK
        void OnCollisionEnter2D (Collision2D collision)
            {
                if (collision.gameObject.CompareTag("Ground"))
                {
                    isGrounded = true;
                    canDash = true;
                    jumpCount = maxJumps;
                    dashCount = maxDash;
                    lastOnGroundTime = 0.1f;
            }
 
            // Detecta colisão com o objeto específico para "morrer"
            if (collision.gameObject.CompareTag("Hazard"))
                {
                    DieAndRespawn();
                }
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                canDash = true;
                dashCount = maxDash;

            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
                lastJumpedTime = coyoteTime;
            }
        }
    #endregion

        IEnumerator Dash()
        {
            canDash = false;
            isDashing = true;
            float originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = dashDirection.normalized * dashSpeed;
            yield return new WaitForSeconds(dashDuration);
            trailRenderer.emitting = false;
            rb.gravityScale = originalGravity;
            isDashing = false;
        }

        void DieAndRespawn()
        {
            // Lógica para "morrer" e respawnar
            Debug.Log("Player collided with hazard and will respawn.");
            FindObjectOfType<RespawnController>().TriggerRespawn();
        }

}


