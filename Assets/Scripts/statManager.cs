using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statManager : MonoBehaviour
{
    string currStat;
    public Text currText;
    List<int> stats = new List<int>();

    public int HP;
    public int SP;

    public Text statString;


    // Start is called before the first frame update
    void Start()
    {
        // initializes all values for GUI system
        for (int i = 0; i < 6; i++)
        {
            stats.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //uses the current text choice to choose what stat is being looked at
        currStat = currText.text;

        //calculate stats on each frame, isn't efficient
        HP = stats[0] * 5 + stats[1] * 10;
        SP = stats[3] * 10 + stats[4] * 5;

        //ensures all stats are within range
        for (int i = 0; i < 6; i++)
        {
            if(stats[i] > 10)
            {
                stats[i] = 10;
            } else if(stats[i] < 0)
            {
                stats[i] = 0;
            }
        }


        updateStatStr();

    }

    //wanted more practice w/ switch cases
    public void incStat(int val) //while it's called incStat, also used for decrementing
    {
        switch (currStat)
        {
            case "Strength":
                stats[0] += val;
                break;
            case "Toughness":
                stats[1] += val;
                break;
            case "Dexterity":
                stats[2] += val;
                break;
            case "IQ":
                stats[3] += val;
                break;
            case "Power":
                stats[4] += val;
                break;
            case "Charm":
                stats[5] += val;
                break;
            default:
                Debug.Log("something broke");
                break;
        }
    }


    //used to randomize all stats
    public void randomizeStats()
    {

        for (int i = 0; i < 6; i++)
        {
            stats[i] = Random.Range(0,11); //to 11 bc casting to an int from a float rounds down
        }

    }

    //used for GUI text of all stats
    private void updateStatStr()
    {
        string newText = "";

        newText += "Stats:\nStrength: " + stats[0].ToString() + "\nToughness: " + stats[1].ToString() + "\nDexterity: " + stats[2].ToString() + "\nIQ: " + stats[3].ToString() + "\nPower: " + stats[4].ToString() + "\nCharm: " + stats[5].ToString();

        newText += "\n\nCalculated Stats\nHP: " + HP.ToString() + "\nSP: " + SP.ToString();

        statString.text = newText;

    }
}