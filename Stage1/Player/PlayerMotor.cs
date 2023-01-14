using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public GameObject cube;
    public GameObject prefab;
    public Camera cam;
    public Camera subcam;
    private Animator ani;

    bool crouching = false;
    float crouchTimer = 1;
    bool lerpCrouch = false;
    bool sprinting = false;
    bool fire = false;
    bool map = false;
    [SerializeField] Data charManager;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //ani = GetComponent<Animator>();


    }

    private void Update()
    {
        for (int i = 0; i < charManager.s_players.Length; i++)
        {


            isGrounded = controller.isGrounded;
            if (lerpCrouch)
            {
                crouchTimer += Time.deltaTime;
                float p = crouchTimer / 1;
                p *= p;
                if (crouching)
                    controller.height = Mathf.Lerp(controller.height, 1, p);
                else
                    controller.height = Mathf.Lerp(controller.height, 2, p);
                if (p > 1)
                {
                    lerpCrouch = false;
                    crouchTimer = 0f;
                }
            }
        }
    }
        public void ProcessMove(Vector2 input)
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection.x = input.x;
            moveDirection.z = input.y;
            controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
            playerVelocity.y += gravity * Time.deltaTime;
            if (isGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = -2f;
            }
            controller.Move(playerVelocity * Time.deltaTime);
            if (input.x > 0 || input.y > 0)
            {
                ani.SetBool("isWalking", true);
            }
            else
            {
                ani.SetBool("isWalking", false);
            }

        }

        public void Jump()
        {
            if (isGrounded)
            {
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
        }

        public void Crouch()
        {
            crouching = !crouching;
            crouchTimer = 0;
            lerpCrouch = true;
        }

        public void Sprint()
        {
            sprinting = !sprinting;
            if (sprinting)
            {
                speed = 8;
                ani.SetBool("isRunning", true);
            }
            else
            {
                speed = 5;
                ani.SetBool("isRunning", false);
            }
        }

        public void Fire()
        {
            fire = !fire;
            Debug.Log("Fire");
            cube.SetActive(false);
            Ray r = new Ray(cam.transform.position, cam.transform.forward);

            Vector3 dir = r.GetPoint(1) - r.GetPoint(0);

            // position of spanwed object could be 'GetPoint(0).. 1.. 2' half random choice ;)
            GameObject bullet = Instantiate(prefab, r.GetPoint(5), Quaternion.Euler(0, 0, 0)); //LookRotation(dir)

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
            ani.SetTrigger("isThrowing");

        }

        public void Map()
        {
            map = !map;
            if (map)
            {
                cam.enabled = false;
                subcam.enabled = true;
            }
            if (!map)
            {
                cam.enabled = true;
                subcam.enabled = false;
            }

        }

    } 

