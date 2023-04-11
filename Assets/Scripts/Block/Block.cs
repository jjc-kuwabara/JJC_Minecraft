using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameObject model;
    [SerializeField]
    Color defaultColor;
    private void Awake()
    {
        model = transform.Find("BlockModel").gameObject;
        defaultColor = model.GetComponent<Renderer>().material.color;
    }
    // Start is called before the first frame update
    void Start()
    {
        model.GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
