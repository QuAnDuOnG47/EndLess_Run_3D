using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float horizontalSpeed = 4f;
    public float leftMax = -3f;
    public float rightMax = 3f;
    public bool isRunning;
    public float jumpForce = 5f;
    public bool isGrounded = true;   // kiểm tra có đang chạm đất không
    private Rigidbody rb;  
    public float groundCheckDistance = 0.2f; // khoảng cách tia ray để kiểm tra đất
    public LayerMask groundLayer;       // layer của mặt đất
    

    // Update is called once per frame

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    [System.Obsolete]
    void Update()
    {
        GroundCheck();
        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(AddDistance());
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > leftMax)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < rightMax)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed);
            }
        }
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
           Jump();
        }
    }

    IEnumerator AddDistance()
    {
        yield return new WaitForSeconds(0.7f);
        MasterInfor.distanceRun += 1;
        isRunning = false;
    }

    [System.Obsolete]
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // reset vận tốc Y
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    void GroundCheck()
    {
        bool hit = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    isGrounded = hit;

    // Debug line luôn hiện trong Scene view (ngay cả khi không chọn)
    Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, hit ? Color.green : Color.red);
    }

    // (Tuỳ chọn) Vẽ tia ray trong Scene để debug
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }
}
