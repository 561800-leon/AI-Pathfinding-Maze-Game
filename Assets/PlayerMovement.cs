using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 20f;


    public float playerHealth = 100f;

    private Vector3 velocity;
    private bool isMoving;

    InputAction movement;

    InputAction jump;

    public Vector3 lastposition = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = InputSystem.actions.FindAction("Movement");
        jump = InputSystem.actions.FindAction("Jump");
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

       
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        velocity.y += -9.81f * Time.deltaTime;

       
        controller.Move(velocity * Time.deltaTime);

        lastposition = transform.position;
    }



    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}