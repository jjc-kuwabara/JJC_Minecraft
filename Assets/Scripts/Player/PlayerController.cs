using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private int _animIDAttack;
    private GameObject playerCameraRoot;
    private GameObject attackCollision;

    [SerializeField]
    int currentChunkX;
    [SerializeField]
    int currentChunkZ;
    [SerializeField]
    int currentChunkId;
    private void Awake()
    {
        _animator= GetComponent<Animator>();
        _animIDAttack = Animator.StringToHash("Attack");
        playerCameraRoot = this.transform.Find("PlayerCameraRoot").gameObject;
        attackCollision = this.transform.Find("AttackCollision/AttackCollision000").gameObject;
        currentChunkId = BlockMaker.INVALID_CHUNK_ID;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool(_animIDAttack, true);
            //EnableAttackCollision();
        }
        else
        {
            _animator.SetBool(_animIDAttack, false);
            //DisableAttackCollision();
        }

        currentChunkX = (int)(this.transform.position.x / JJCMinecraft.jjcMinecraftSO.chunkBlockNum);
        currentChunkZ = (int)(this.transform.position.z / JJCMinecraft.jjcMinecraftSO.chunkBlockNum);

        int prevChunkId = currentChunkId;
        currentChunkId = BlockMaker.GetChunkId(this.transform.position);
        if (prevChunkId != currentChunkId)
        {
            JJCMinecraft.blockMaker.SetCurrentChunk(currentChunkId);
        }
    }

    public void EnableAttackCollision()
    {
        attackCollision.SetActive(true);
        Vector3 lookAtDir = playerCameraRoot.transform.position - Camera.main.transform.position;
        lookAtDir = lookAtDir.normalized;

        Vector3 attackCollisionPos = playerCameraRoot.transform.position + lookAtDir * 1.0f;

        attackCollision.transform.position = attackCollisionPos;  
    }

    public void DisableAttackCollision()
    {
        attackCollision.SetActive(false);
    }

}
