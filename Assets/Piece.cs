using UnityEngine;
using MilkShake;

public class Piece : MonoBehaviour 
{
    [SerializeField] private Transform[] groundCheck;
    private Rigidbody rb;
    bool isPlaced;

    const float fallSpeed = 5;
    const float groundCheckDistance = 0.2f;

    PieceSpawner pieceSpawner;

    private CameraController cameraController;

    [SerializeField] private ShakePreset shakePreset;
    [SerializeField] private AudioSource hit;

    public void Init(PieceSpawner pieceSpawner)
    {
        this.pieceSpawner = pieceSpawner;
    }

    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.isKinematic = !isPlaced;

        if(!isPlaced)
        {
            transform.position -= Vector3.up * Time.deltaTime * fallSpeed;

            Vector3 camForward = cameraController.GetCurrentCamPoint().forward;
            Vector3 camRight = cameraController.GetCurrentCamPoint().right;

            if(Input.GetKeyDown(KeyCode.W))
                transform.position += new Vector3(camForward.x, 0, camForward.z).normalized;
            if(Input.GetKeyDown(KeyCode.S))
                transform.position -= new Vector3(camForward.x, 0, camForward.z).normalized;
            if(Input.GetKeyDown(KeyCode.D))
                transform.position += new Vector3(camRight.x, 0, camRight.z).normalized;
            if(Input.GetKeyDown(KeyCode.A))
                transform.position -= new Vector3(camRight.x, 0, camRight.z).normalized;
        }

        if(transform.position.y < 0)
        {
            pieceSpawner.EndGame();
        }
        if(transform.position.y > 10 && isPlaced)
        {
            pieceSpawner.EndGame();
        }
    }

    void FixedUpdate()
    {
        foreach(Transform t in groundCheck)
        {
            if(Physics.Raycast(t.position, Vector3.down, groundCheckDistance) && !isPlaced)
            {
                isPlaced = true;
                pieceSpawner.SpawnPiece();
                Shaker.ShakeAll(shakePreset);
                hit.Play();
                rb.constraints = RigidbodyConstraints.FreezeAll;
                transform.position -= Vector3.up * groundCheckDistance;
            }
        }
    }

}