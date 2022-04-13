using UnityEngine;

namespace Quest
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float runspeed = 10f;
        [SerializeField] private float gravity = -9.8f;

        private string horizontal = "Horizontal";
        private string vertical = "Vertical";
        private string run = "Run";
        private string isMove = "isMove";

        private Vector3 direction;
        private bool isRunning;

        private Animator anim;

        float deltaX, deltaZ;
        private CharacterController _characterController;
        private void Start()
        {
            anim = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }
        void Update()
        {

            deltaX = Input.GetAxis(horizontal) * (isRunning ? runspeed : speed);
            deltaZ = Input.GetAxis(vertical) * (isRunning ? runspeed : speed);

            direction = new Vector3(deltaX, 0, deltaZ);
            direction = Vector3.ClampMagnitude(direction, (isRunning ? runspeed : speed));
            direction.y = gravity;
            direction *= Time.deltaTime;
            direction = transform.TransformDirection(direction);
            _characterController.Move(direction);

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