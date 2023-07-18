using Photon.Pun;
using PlayFab;
using Quest;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPun, IPunObservable
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject _cameraGameObject;
    [SerializeField] private Canvas _playerHPCanvas;
    [SerializeField] private TMP_Text _playerHPText;
    
    
    [SerializeField] private float startTimeBtwAtack;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;
    

    private Animator anim;
    private AudioSource source;
    
    private string animAttack = "attack";
    private float timeBtwAttack;
    
    private CanvasHPController _canvasHPController;

    private float _rotateSpeed = 2;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float runspeed = 10f;
    private float angleX = 0;
    private float angleY = 0;

    private int HP = 10;
    
    [SerializeField] private float gravity = -9.8f;
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private string run = "Run";
    private string isMove = "isMove";

    private Vector3 direction;
    private bool isRunning;



    float deltaX, deltaZ;

    
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(HP);
        }
        else
        {
            HP = (int)stream.ReceiveNext();
            _playerHPText.text = HP.ToString();
        }
    }

    private void Start()
    {

        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        
        _characterController = GetComponent<CharacterController>();

        _cameraGameObject.SetActive(photonView.IsMine);

        _playerHPCanvas.worldCamera = Camera.main;

        _canvasHPController = FindObjectOfType<CanvasHPController>();

        if (photonView.IsMine)
            _canvasHPController.ActionOnHPUpdate += OnHpUpdate;
    }

    private void OnDestroy()
    {
        _canvasHPController.ActionOnHPUpdate -= OnHpUpdate;
    }

    private void OnHpUpdate(int HPvalue)
    {
        HP = HPvalue;
        _playerHPText.text = HP.ToString();
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            UpdateController();
        }
        
    }

    private void UpdateController()
    {
        //move
        
        
        if (Input.GetButton(vertical) || Input.GetButton(horizontal))
        {
            anim.SetBool(isMove, true);
            deltaX = Input.GetAxis(horizontal) * (isRunning ? runspeed : speed);
            deltaZ = Input.GetAxis(vertical) * (isRunning ? runspeed : speed);

            direction = new Vector3(deltaX, 0, deltaZ);
            direction = Vector3.ClampMagnitude(direction, (isRunning ? runspeed : speed));
            direction.y = gravity;
            direction *= Time.deltaTime;
            direction = transform.TransformDirection(direction);
            _characterController.Move(direction);
        }
        else
        {
            anim.SetBool(isMove, false);
            source.Play();
        }
        

        //attack
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                anim.SetTrigger(animAttack);
                Collider[] enemies = Physics.OverlapSphere(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<Health>().Hit(damage);
                }
            }
            timeBtwAttack = startTimeBtwAtack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }


    public void Hit(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        PhotonNetwork.Destroy(gameObject);
        SceneManager.LoadScene(6);
    }
}
