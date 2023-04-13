using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JJC_Minecraft_SO", menuName = "ScriptableObjects/JJCMinecraftScriptableObject", order = 1)]
public class JJC_Minecraft_SO : ScriptableObject
{
    [Header("�u���b�NID�ɑΉ������u���b�N�̃v���n�u")]
    [SerializeField]
    public List<GameObject> blockPrefabs;

    [Header("1�`�����N��1�ӂ̃u���b�N��")]
    public int chunkBlockNum;
    [Header("X�����AZ�����ɉ��̃`�����N�����邩")]
    public int chunkNumX;
    public int chunkNumZ;

    [Header("�M�~�b�N - �h�A")]
    public float doorMoveSpeed;
    public float doorMinDegree;
    public float doorMaxDegree;
    [Header("�M�~�b�N - �S��")]
    public float prisonTimer;

}
