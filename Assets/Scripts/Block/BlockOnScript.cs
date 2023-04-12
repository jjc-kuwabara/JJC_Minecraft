using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOnScript
{
    GameObject _baseObj;
    GameObject _modelObj;


    public void SetGameObject(GameObject baseObj)
    {
        _baseObj = baseObj;
        _modelObj = baseObj.transform.Find("BlockModel").gameObject;
    }

    public void SetEnable(bool isEnable)
    {
        if(_baseObj != null){
            _baseObj.SetActive(isEnable);
        }
    }
}
