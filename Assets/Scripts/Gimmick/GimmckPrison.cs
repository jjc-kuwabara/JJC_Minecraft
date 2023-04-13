using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GimmckPrison : MonoBehaviour
{
    GameObject wallObject;
    GameObject triggerObject;
    Text timerText;
    bool isPrisonActive;
    float prisonTimer;

    public GameObject timerObject;


    private void Awake()
    {
        wallObject = transform.Find("Wall").gameObject;
        triggerObject = transform.Find("Trigger").gameObject;
        timerText = timerObject.transform.Find("Text").GetComponent<Text>();
        isPrisonActive = false;
        prisonTimer = 0.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        DisablePrison();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPrisonActive)
        {
            prisonTimer -= Time.deltaTime;
            if(prisonTimer < 0.0f)
            {
                prisonTimer = 0.0f;
            }
            timerText.text = "牢屋タイマ　残り " + prisonTimer.ToString("F2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            EnablePrison();
        }
    }

    private void EnablePrison()
    {
        triggerObject.SetActive(false);
        wallObject.SetActive(true);
        timerObject.SetActive(true);
        isPrisonActive = true;

        prisonTimer = JJCMinecraft.jjcMinecraftSO.prisonTimer;
        Invoke("DisablePrison", JJCMinecraft.jjcMinecraftSO.prisonTimer);
        Invoke("RefreshPrisonTrigger", JJCMinecraft.jjcMinecraftSO.prisonTimer * 2);
    }
    private void DisablePrison()
    {
        //triggerObject.SetActive(true);
        wallObject.SetActive(false);
        timerObject.SetActive(false);
        isPrisonActive = false;
    }

    private void RefreshPrisonTrigger()
    {
        triggerObject.SetActive(true);
    }
}
