using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChunk
{
    Vector3 _basePos;
    BlockOnScript[] blockPointerArray;

    public void SetBasePosition(Vector3 basePos)
    {
        _basePos = basePos;
    }

    public void InitializeBlock()
    {
        int arrayNum = JJCMinecraft.jjcMinecraftSO.chunkBlockNum * JJCMinecraft.jjcMinecraftSO.chunkBlockNum;
        blockPointerArray = new BlockOnScript[arrayNum];
        for (int i = 0; i < arrayNum; i++)
        {
            blockPointerArray[i] = new BlockOnScript();
        }

        GameObject blockParent = GameObject.Find("BlockParent");
        GameObject blockPrefab;
        GameObject blockInstance;

        blockPrefab = JJCMinecraft.jjcMinecraftSO.blockPrefabs[0];

        for (int z = 0; z < JJCMinecraft.jjcMinecraftSO.chunkBlockNum; z++)
        {
            for (int y = 0; y <= 0; y++)
            {
                for (int x = 0; x < JJCMinecraft.jjcMinecraftSO.chunkBlockNum; x++)
                {
                    blockInstance = Object.Instantiate(blockPrefab);
                    blockInstance.transform.position = new Vector3(_basePos.x + x, _basePos.y + y, _basePos.z + z);
                    blockInstance.transform.SetParent(blockParent.transform);

                    blockPointerArray[z * JJCMinecraft.jjcMinecraftSO.chunkBlockNum + x].SetGameObject(blockInstance);
                }
            }
        }
    }

    public void SetBlockEnable(bool isEnable)
    {
        for (int z = 0; z < JJCMinecraft.jjcMinecraftSO.chunkBlockNum; z++)
        {
            for (int y = 0; y <= 0; y++)
            {
                for (int x = 0; x < JJCMinecraft.jjcMinecraftSO.chunkBlockNum; x++)
                {
                    blockPointerArray[z * JJCMinecraft.jjcMinecraftSO.chunkBlockNum + x].SetEnable(isEnable);
                }
            }
        }
    }

}
