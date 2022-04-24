using UnityEngine;

namespace Quest
{
    [RequireComponent(typeof(AudioSource))]
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float runspeed = 10f;
        [SerializeField] private float gravity = -9.8f;

        [SerializeField] private AudioSource source;
        [SerializeField] private float walkPitch = 1f;
        [SerializeField] private float runPitch = 1.25f;

        private string horizontal = "Horizontal";
        private string vertical = "Vertical";
        private string run = "Run";
        private string isMove = "isMove";

        private Vector3 direction;
        private bool isRunning;

        private Animator anim;

        float deltaX, deltaZ;
        private CharacterController _characterController;

        [SerializeField] private GameObject pausepanel;

        private void Start()
        {
            source = GetComponent<AudioSource>();
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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pausepanel.SetActive(true);
                Time.timeScale = 0;
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
                source.Play();
            }
            isRunning = Input.GetButton(run);

            
        }
    }
}