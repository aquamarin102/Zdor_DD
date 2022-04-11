using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(Rigidbody))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float runspeed = 10f;
        [SerializeField] private float jumpForce = 10f;

        private string horizontal = "Horizontal";
        private string vertical = "Vertical";
        private string run = "Run";
        private string isMove = "isMove";
        private string Jump = "Jump";
        private bool isRunning;
        private bool _isGrounded;

        private Vector3 direction;

        private Animator anim;

        float deltaX, deltaZ;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();
        }
 
        void Update()
        {


            MovmentLogic();
            JumpLogic();
           

        }

        private void MovmentLogic()
        {
            deltaX = Input.GetAxis(horizontal) * (isRunning ? runspeed : speed);
            deltaZ = Input.GetAxis(vertical) * (isRunning ? runspeed : speed);
            direction = new Vector3(deltaX, 0, deltaZ);
            
            rb.AddForce(direction, ForceMode.VelocityChange);

        }
        private void JumpLogic()
        {
            if (_isGrounded)
            {
                if(Input.GetAxis(Jump) > 0)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }
        void OnCollisionEnter(Collision collision)
        {
            IsGroundedUpate(collision, true);
        }

        void OnCollisionExit(Collision collision)
        {
            IsGroundedUpate(collision, false);
        }
        private void IsGroundedUpate(Collision collision, bool value)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                _isGrounded = value;
            }
        }
        private void FixedUpdate()
        {

            if (Input.GetButton(vertical) || Input.GetButton(horizontal))
            {
                anim.SetBool(isMove, true);
            }
            else
            {
                anim.SetBool(isMove, false);
            }
            isRunning = Input.GetButton(run);
        }
    }
}