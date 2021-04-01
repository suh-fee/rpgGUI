using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


//handles setting button listeners, updating the current skill on screen, inc/dec stats
public class DropDown : MonoBehaviour
{
    public Dropdown dropDown;

    public GameObject smObj;
    statManager sm;


    public Button incButton;
    public Button decButton;
    public Button randButton;

    public Text currChoice;

    private void Awake()
    {

        //needed for inc/dec
        sm = smObj.GetComponent<statManager>();

        //set up all buttons
        incButton.onClick.AddListener(new UnityAction(incStat));
        decButton.onClick.AddListener(new UnityAction(decStat));
        randButton.onClick.AddListener(new UnityAction(sm.randomizeStats));
    }

    private void Update()
    {
        string strToSave;
        int selectedIndex = dropDown.value; //gets value from dropdown, sets the text to reflect that choice

        strToSave = dropDown.options[selectedIndex].text;
        currChoice.text = strToSave;
    }



    //only difference is what value they add to a score
    private void decStat()
    {
        sm.incStat(-1);
    }

    private void incStat()
    {
        sm.incStat(1);
    }


}