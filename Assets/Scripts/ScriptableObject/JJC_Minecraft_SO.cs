using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JJC_Minecraft_SO", menuName = "ScriptableObjects/JJCMinecraftScriptableObject", order = 1)]
public class JJC_Minecraft_SO : ScriptableObject
{
    [Header("ブロックIDに対応したブロックのプレハブ")]
    [SerializeField]
    public List<GameObject> blockPrefabs;

    [Header("1チャンクの1辺のブロック数")]
    public int chunkBlockNum;
    [Header("X方向、Z方向に何個のチャンクがあるか")]
    public int chunkNumX;
    public int chunkNumZ;

    [Header("ギミック - ドア")]
    public float doorMoveSpeed;
    public float doorMinDegree;
    public float doorMaxDegree;
    [Header("ギミック - 牢獄")]
    public float prisonTimer;

}
