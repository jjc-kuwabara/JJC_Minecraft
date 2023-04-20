using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JJC_FieldType_SO", menuName = "ScriptableObjects/JJCFieldTypeScriptableObject", order = 2)]
public class JJC_FieldType_SO : ScriptableObject
{
    [SerializeField]
    public List<BlockMaker.BLOCK_TYPE> blockTypeIds;
}
