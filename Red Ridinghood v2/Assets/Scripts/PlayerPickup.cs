using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour {
    
    public Text countText;
    public GameObject background;
    public GameObject intro;
    public GameObject intro2;
    public GameObject poem;
    public GameObject ending;
    public GameObject pickupSound;
    public GameObject fusRoDah;

    private int count;
    private GameObject currentUI;
    private List<GameObject> uiPanelList = new List<GameObject>();

    
    private void Start () {
        //
        count = 0;
        SetCountText();
        uiPanelList.Add(background);
        uiPanelList.Add(intro);
        uiPanelList.Add(intro2);
        uiPanelList.Add(poem);
        uiPanelList.Add(ending);

        background.SetActive(true);
        currentUI = intro;
        currentUI.SetActive(true);
    }
	
	//dit stukje zorgt ervoor dat de pannels aan/uitgaan wanneer je linkermuisknop klikt
	private void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(currentUI);
            if (currentUI == intro)
            {
                intro.SetActive(false);
                currentUI = intro2;
                currentUI.SetActive(true);
            }
            else if (currentUI == intro2)
            {
                intro2.SetActive(false);
                currentUI = poem;
                currentUI.SetActive(true);
            }
            else if (currentUI == ending)
            {
                ending.SetActive(false);
                Instantiate(fusRoDah);
            }
            else
            {
                foreach (GameObject panel in uiPanelList)
                {
                    panel.SetActive(false);
                }
                currentUI = null;
            }
        }
    }
    //als je rigid body die van de bloem aanraakt pickt ie de bloem op en telt hem bij de
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            TurnOnPanel();
            Instantiate(pickupSound);
        }
    }
    //dit is de text die in het scherm verschijnt met het aantal verzamelde bloemen
    private void SetCountText()
    {
        countText.text = "Flowers: " + count.ToString();
    }
    // als er 3 bloemen zijn verzameld dan komt het laatste panel tevoorschijn
    private void TurnOnPanel()
    {
        if (count > 2)
        {
            background.SetActive(true);
            currentUI = ending;
            currentUI.SetActive(true);
        }
    }
}
