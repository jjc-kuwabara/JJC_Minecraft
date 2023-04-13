using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    string _path;
    GameObject _playerObject;
    private void Awake()
    {
        _path = Path.Combine(Application.persistentDataPath, "SaveData.txt");
        _playerObject = GameObject.Find("PlayerArmature").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string GetPlayerPosition()
    {
        string playerPos =
            _playerObject.transform.position.x.ToString() + "," +
            _playerObject.transform.position.y.ToString() + "," +
            _playerObject.transform.position.z.ToString();
        return playerPos;
    }

    public void OnSave_SaveData()
    {
        string playerPos = GetPlayerPosition();
        File.WriteAllText(_path, playerPos);
        Debug.Log("Save to " + _path);
    }
    public void OnLoad_SaveData()
    {
        string playerPos;
        playerPos = File.ReadAllText(_path);
        string[] tempStr = playerPos.Split(',');

        float posX = float.Parse(tempStr[0]);
        float posY = float.Parse(tempStr[1]);
        float posZ = float.Parse(tempStr[2]);


        _playerObject.GetComponent<CharacterController>().enabled = false;
        _playerObject.transform.position = new Vector3(posX, posY, posZ);
        _playerObject.GetComponent<CharacterController>().enabled = true;

        Debug.Log("Load from " + _path);
    }
}
