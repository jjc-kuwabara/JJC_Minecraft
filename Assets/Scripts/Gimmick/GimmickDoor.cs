using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickDoor : MonoBehaviour
{
    GameObject triggerObject;
    GameObject modelObject;
    GameObject hitCollision;

    enum E_STATE
    {
        eOPEN,
        eOPENING,
        eCLOSE,
        eCLOSING
    }
    [SerializeField]
    E_STATE eState;
    [SerializeField]
    float doorDegreeY;
    bool isClose;
    float doorOpenSpeed;
    float doorMinDegree;
    float doorMaxDegree;

    private void Awake()
    {
        triggerObject = transform.Find("Trigger").gameObject;
        modelObject = transform.Find("ModelRoot").gameObject;
        hitCollision = transform.Find("Collision").gameObject;
        eState = E_STATE.eCLOSE;
        isClose = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        doorOpenSpeed = JJCMinecraft.jjcMinecraftSO.doorMoveSpeed;
        doorMinDegree = JJCMinecraft.jjcMinecraftSO.doorMinDegree;
        doorMaxDegree = JJCMinecraft.jjcMinecraftSO.doorMaxDegree;
    }

    // Update is called once per frame
    void Update()
    {
        doorDegreeY = modelObject.transform.eulerAngles.y;
        switch (eState)
        {
            case E_STATE.eCLOSING:
                {
                    Vector3 doorEuler = modelObject.transform.eulerAngles;
                    if (doorMinDegree < doorEuler.y && doorEuler.y < (doorMaxDegree + 2.0f))
                    {
                        modelObject.transform.eulerAngles = new Vector3(doorEuler.x, doorEuler.y - doorOpenSpeed * Time.deltaTime, doorEuler.z);
                    }
                    else
                    {
                        modelObject.transform.eulerAngles = new Vector3(doorEuler.x, doorMinDegree, doorEuler.z);
                        eState = E_STATE.eCLOSE;
                    }
                }
                break;
            case E_STATE.eOPENING:
                {
                    Vector3 doorEuler = modelObject.transform.eulerAngles;
                    if ((doorMinDegree - 2.0f) < doorEuler.y && doorEuler.y < doorMaxDegree)
                    {
                        modelObject.transform.eulerAngles = new Vector3(doorEuler.x, doorEuler.y + doorOpenSpeed * Time.deltaTime, doorEuler.z);
                    }
                    else
                    {
                        modelObject.transform.eulerAngles = new Vector3(doorEuler.x, doorMaxDegree, doorEuler.z);
                        eState = E_STATE.eOPEN;
                    }
                }
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            DoorMove();
        }
    }

    private void DoorMove()
    {
        if (isClose)
        {
            DoorOpen();
        }
        else
        {
            DoorClose();
        }
    }

    private void DoorOpen()
    {
        isClose = false;
        eState = E_STATE.eOPENING;
        hitCollision.SetActive(false);
    }
    private void DoorClose()
    {
        isClose = true;
        eState = E_STATE.eCLOSING;
        hitCollision.SetActive(true);
    }
}
