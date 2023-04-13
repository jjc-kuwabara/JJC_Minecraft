using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JJC_Minecraft_SO", menuName = "ScriptableObjects/JJCMinecraftScriptableObject", order = 1)]
public class JJC_Minecraft_SO : ScriptableObject
{
    [SerializeField]
    public List<GameObject> blockPrefabs;

    [SerializeField]
    public int worldMinX;
    public int worldMaxX;
    public int worldMinY;
    public int worldMaxY;
    public int worldMinZ;
    public int worldMaxZ;

    public int chunkBlockNum;
    public int chunkNumX;
    public int chunkNumZ;

    [Header("�M�~�b�N�p�p�����[�^")]
    [Header("�M�~�b�N - �h�A")]
    public float doorMoveSpeed;
    public float doorMinDegree;
    public float doorMaxDegree;
    [Header("�M�~�b�N - �S��")]
    public float prisonTimer;

}
