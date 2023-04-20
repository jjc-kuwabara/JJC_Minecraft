using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaker : MonoBehaviour
{
    public enum BLOCK_TYPE
    {
        eDirt,
        eLeaf,
        eRawWood,
        eWood,
        eNum
    }

    GameObject blockParent;

    BlockChunk[] _blockChunk;


    private void Awake()
    {

        
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeWorld2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitializeWorld2()
    {
        blockParent = GameObject.Find("BlockParent");
        _blockChunk = new BlockChunk[JJCMinecraft.jjcMinecraftSO.chunkNumX * JJCMinecraft.jjcMinecraftSO.chunkNumZ];
        for (int z = 0; z < JJCMinecraft.jjcMinecraftSO.chunkNumZ; z++)
        {
            for (int x = 0; x < JJCMinecraft.jjcMinecraftSO.chunkNumX; x++)
            {
                int chunkIndex = z * JJCMinecraft.jjcMinecraftSO.chunkNumX + x;
                _blockChunk[chunkIndex] = new BlockChunk();
                _blockChunk[chunkIndex].SetBasePosition(new Vector3(0 + x * JJCMinecraft.jjcMinecraftSO.chunkBlockNum, 0, 0 + z * JJCMinecraft.jjcMinecraftSO.chunkBlockNum));
            }
        }

        for (int z = 0; z < JJCMinecraft.jjcMinecraftSO.chunkNumZ; z++)
        {
            for (int x = 0; x < JJCMinecraft.jjcMinecraftSO.chunkNumX; x++)
            {
                int chunkIndex = z * JJCMinecraft.jjcMinecraftSO.chunkNumX + x;
                _blockChunk[chunkIndex].InitializeBlock();
                _blockChunk[chunkIndex].SetBlockEnable(false);
            }
        }
    }

    public void SetCurrentChunk(int currentChunkIndex)
    {
        int currentX = currentChunkIndex % JJCMinecraft.jjcMinecraftSO.chunkNumX;
        int currentZ = currentChunkIndex / JJCMinecraft.jjcMinecraftSO.chunkNumX;


        for (int z = 0; z < JJCMinecraft.jjcMinecraftSO.chunkNumZ; z++)
        {
            for (int x = 0; x < JJCMinecraft.jjcMinecraftSO.chunkNumX; x++)
            {
                int chunkIndex = z * JJCMinecraft.jjcMinecraftSO.chunkNumX + x;

                /*
                if(chunkIndex == currentChunkIndex)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else
                {
                    _blockChunk[chunkIndex].SetBlockEnable(false);
                }
                */

                if (currentX == x && currentZ == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }else if (currentX + 1 == x && currentZ == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX - 1 == x && currentZ == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX + 1 == x && currentZ + 1 == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX - 1 == x && currentZ + 1 == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX + 1 == x && currentZ - 1 == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX - 1 == x && currentZ - 1 == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX == x && currentZ + 1 == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else if (currentX == x && currentZ - 1 == z)
                {
                    _blockChunk[chunkIndex].SetBlockEnable(true);
                }
                else
                {
                    _blockChunk[chunkIndex].SetBlockEnable(false);
                }
            }
        }
    }

    public static int GetChunkId(Vector3 position)
    {

        int chunkX = (int)(position.x / JJCMinecraft.jjcMinecraftSO.chunkBlockNum);
        int chunkZ = (int)(position.z / JJCMinecraft.jjcMinecraftSO.chunkBlockNum);
        int chunkId = chunkZ * JJCMinecraft.jjcMinecraftSO.chunkNumX + chunkX;
        return chunkId;
    }

    public const int INVALID_CHUNK_ID = -1;

}
