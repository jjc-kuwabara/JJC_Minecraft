using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMaker : MonoBehaviour
{
    enum BLOCK_TYPE
    {
        eDirt,
        eWood,
        eLeaf,
        eNum
    }

    GameObject blockParent;

    private void Awake()
    {
        blockParent = GameObject.Find("BlockParent");
    }
    // Start is called before the first frame update
    void Start()
    {
        InitializeWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeWorld()
    {
        GameObject blockPrefab;
        GameObject blockInstance;

        blockPrefab = JJCMinecraft.jjcMinecraftSO.blockPrefabs[0];

        for (int z = JJCMinecraft.jjcMinecraftSO.worldMinZ; z <= JJCMinecraft.jjcMinecraftSO.worldMaxX; z++)
        {
            for (int y = JJCMinecraft.jjcMinecraftSO.worldMinY; y <= JJCMinecraft.jjcMinecraftSO.worldMaxY; y++)
            {
                for (int x = JJCMinecraft.jjcMinecraftSO.worldMinX; x <= JJCMinecraft.jjcMinecraftSO.worldMaxX; x++)
                {
                    blockInstance = Instantiate(blockPrefab);
                    blockInstance.transform.position = new Vector3(x, y, z);
                    blockInstance.transform.SetParent(blockParent.transform);
                }
            }
        }
    }
}
