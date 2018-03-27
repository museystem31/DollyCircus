using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class puzzleManager : MonoBehaviour
{

    string[] desserts = { "macaron", "tart", "waffle", "brownie", "cheese", "shortbread" };
    string[] names = { "eve", "venie", "liuwen", "muhua", "elita", "cecile" };
    string[] tricks = { "unicycle", "ballet", "taming", "dart", "swing", "tightrope" };
    public static Doll[] puzzleAnswerKey;
    public static Doll[] playerAnswer;
    [SerializeField]
    private GameObject solvedPanel;

    [SerializeField]
    private GameObject hintBtn;

    [SerializeField]
    private GameObject doubleCheckPanel;

    [SerializeField]
    private Text hint;

    public AudioClip newHint;

    static private int hintNum;
    public AudioClip puzzleSolvedSound;

    public GameObject unknownBtn;

    public GameObject trickPane;
    public GameObject namePane;
    public GameObject dessertPane;


    void Awake()
    {
        puzzleAnswerKey = new Puzzle().getPuzzleAnswer();
        //Debug.Log("This is the answer key: ");
        //printAnswer(puzzleAnswerKey);

        createNewPlayerAnswer();
        solvedPanel.gameObject.SetActive(false);
        hintBtn.gameObject.SetActive(false);
        doubleCheckPanel.gameObject.SetActive(false);

        hintNum = 0;
        resetAllAnswers();



        //Debug.Log("This is the player's answer, with length of " + playerAnswer.Length + ": ");
        //printAnswer(playerAnswer);

    }

    private void createNewPlayerAnswer()
    {
        playerAnswer = new Doll[6];
        Doll liuwen = new Doll("0", "0", "0");
        Doll venie = new Doll("1", "1", "1");
        Doll eve = new Doll("2", "2", "2");
        Doll elita = new Doll("3", "3", "3");
        Doll muhua = new Doll("4", "4", "4");
        Doll cecile = new Doll("5", "5", "5");
        playerAnswer[0] = eve;
        playerAnswer[1] = venie;
        playerAnswer[2] = liuwen;
        playerAnswer[3] = muhua;
        playerAnswer[4] = elita;
        playerAnswer[5] = cecile;
    }

    // print the answer key in console for debug to ensure puzzle is created
    public void printAnswer(Doll[] dolls)
    {
        for (int i = 0; i < dolls.Length; i++)
        {
            string name = dolls[i].getName();
            string dessert = dolls[i].getDessert();
            string trick = dolls[i].getTrick();
            Debug.Log("doll name is " + name + " likes " + dessert + " does " + trick);
        }
    }

    public void addAnswer()
    {
        if (!(transform.childCount == 0) && (transform.gameObject.name.ToString().Length > 4))
        {
            removeAnswer();
            string answer = transform.GetChild(0).name.ToString();
            string answerCategory = getItemCategory(answer);
            string parentSlot = transform.name.ToString();
            Debug.Log(parentSlot);

            int dollNumber = findWhoseBox(parentSlot);
            setValue(playerAnswer[dollNumber], answerCategory, answer);
            printAnswer(playerAnswer);

            readyForHint(playerAnswer);

            if (isSolved())
            {
                Debug.Log("you solved the riddle");
                solvedPanel.gameObject.SetActive(true);
                SoundManager.instance.playSingle("effectSource", puzzleSolvedSound);

            }
            else
            {
                Debug.Log("keeping solving...");
            }
        }

    }

    public void removeAnswer()
    {
        string answer = transform.GetChild(0).name.ToString();
        Debug.Log(answer);
        string answerCategory = getItemCategory(answer);

        if (answerCategory == "name")
        {
            for (int i = 0; i < playerAnswer.Length; i++)
            {
                if (playerAnswer[i].getName() == answer)
                {
                    playerAnswer[i].setName("remove");
                    Debug.Log("just removed " + playerAnswer[i]);
                }
            }
        }
        else if (answerCategory == "dessert")
        {
            for (int i = 0; i < playerAnswer.Length; i++)
            {
                if (playerAnswer[i].getDessert() == answer)
                {
                    playerAnswer[i].setDessert("remove");
                }
            }
        }
        else if (answerCategory == "trick")
        {
            for (int i = 0; i < playerAnswer.Length; i++)
            {
                if (playerAnswer[i].getTrick() == answer)
                {
                    playerAnswer[i].setTrick("remove");
                }
            }
        }


    }

    public bool isSolved()
    {
        Doll tempDoll1;
        Doll tempDoll2;
        for (int i = 0; i < puzzleAnswerKey.Length; i++)
        {
            //compare name of i
            tempDoll1 = puzzleAnswerKey[i];
            tempDoll2 = playerAnswer[i];
            //Debug.Log("is " + tempDoll1.getName() + " equal to " + tempDoll2.getName() + " ?");
            //Debug.Log("is " + tempDoll1.getDessert() + " equal to " + tempDoll2.getDessert() + " ?");
            //Debug.Log("is " + tempDoll1.getTrick() + " equal to " + tempDoll2.getTrick() + " ?");

            if ((tempDoll1.getName() != tempDoll2.getName()) ||
                (tempDoll1.getDessert() != tempDoll2.getDessert()) ||
                (tempDoll1.getTrick() != tempDoll2.getTrick()))
            {
                return false;
            }
        }
        return true;
    }

    public int findWhoseBox(string slot)
    {
        if (slot.Contains("eve"))
        {
            return 0;
        }
        else if (slot.Contains("venie"))
        {
            return 1;
        }
        else if (slot.Contains("liuwen"))
        {
            return 2;
        }
        else if (slot.Contains("muhua"))
        {
            return 3;
        }
        else if (slot.Contains("elita"))
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }

    public void setValue(Doll doll, string answerCategory, string answer)
    {
        if (answerCategory == "name")
        {
            doll.setName(answer);
        }
        else if (answerCategory == "dessert")
        {
            doll.setDessert(answer);
        }
        else
        {
            doll.setTrick(answer);
        }
    }

    string getItemCategory(string itemName)
    {
        for (int i = 0; i < desserts.Length; i++)
        {
            if (itemName == desserts[i])
            {
                return "dessert";
            }
        }

        for (int i = 0; i < names.Length; i++)
        {
            if (itemName == names[i])
            {
                return "name";
            }
        }
        for (int i = 0; i < tricks.Length; i++)
        {
            if (itemName == tricks[i])
            {
                return "trick";
            }
        }
        return "";
    }

    public void generateHint(int hintNum)
    {
        if (hintNum == 1)
        {
            hintBtn.gameObject.SetActive(true);
            unknownBtn.gameObject.SetActive(false);
            hint.text = "Um...two of the dolls at the back already have desserts.";
            SoundManager.instance.playSingle("dubSource", newHint);

        }
        else if (hintNum == 2)
        {
            hint.text = "What is the name of the doll with wheatish skin?";
            SoundManager.instance.playSingle("effectSource", newHint);
        }
    }

    public void readyForHint(Doll[] playerAnswer)
    {
        //Debug.Log("checking if ready for hint");
        //Debug.Log("right now the hintNum is " + hintNum);
        if ((hintNum == 0) && (playerAnswer[1].getDessert() == "tart") && (playerAnswer[2].getDessert() == "waffle"))
        {
            //Debug.Log("entering first hint if");
            hintNum = 1;
            //Debug.Log(hintNum);
            generateHint(hintNum);
        }
        else if ((hintNum == 1) && (playerAnswer[2].getName() == "liuwen") && (playerAnswer[0].getName() == "eve"))
        {
            //Debug.Log("entering second hint if");
            hintNum = 2;
            //Debug.Log(hintNum);
            generateHint(hintNum);
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void resetAllAnswers()
    {
        GameObject[] allBoxes = GameObject.FindGameObjectsWithTag("Box");
        //Debug.Log(allBoxes[0].name);

        for (int i = 0; i < allBoxes.Length; i++)
        {
            for (int j = 0; j < allBoxes[i].transform.childCount; j++)
            {
                GameObject parentSlot = allBoxes[i].transform.GetChild(j).gameObject;
                //Debug.Log(parentSlot.name);
                if (parentSlot.transform.childCount == 1)
                {
                    Transform targetItem = parentSlot.transform.GetChild(0);
                    string itemCategory = getItemCategory(targetItem.name.ToString());
                    Debug.Log(targetItem.name);
                    Debug.Log(itemCategory);
                    if (itemCategory == "dessert")
                    {
                        GameObject[] allPossibleSlots = new GameObject[6];
                        for (int x = 0; x < dessertPane.transform.childCount; x++)
                        {
                            allPossibleSlots[x] = dessertPane.transform.GetChild(x).gameObject;
                        }
                        for (int k = 0; k < allPossibleSlots.Length; k++)
                        {
                            if (allPossibleSlots[k].transform.childCount == 0)
                            {
                                targetItem.SetParent(allPossibleSlots[k].transform);
                            }
                        }
                    }
                    else if (itemCategory == "name")
                    {
                        GameObject[] allPossibleSlots = new GameObject[6];
                        for (int x = 0; x < namePane.transform.childCount; x++)
                        {
                            allPossibleSlots[x] = namePane.transform.GetChild(x).gameObject;
                        }
                        for (int k = 0; k < allPossibleSlots.Length; k++)
                        {
                            if (allPossibleSlots[k].transform.childCount == 0)
                            {
                                targetItem.SetParent(allPossibleSlots[k].transform);
                            }
                        }

                    }
                    else
                    {
                        GameObject[] allPossibleSlots = new GameObject[6];
                        for (int x = 0; x < trickPane.transform.childCount; x++)
                        {
                            allPossibleSlots[x] = trickPane.transform.GetChild(x).gameObject;
                        }
                        for (int k = 0; k < allPossibleSlots.Length; k++)
                        {
                            if (allPossibleSlots[k].transform.childCount == 0)
                            {
                                targetItem.SetParent(allPossibleSlots[k].transform);
                            }
                        }

                    }
                }
            }
        }
        createNewPlayerAnswer();
        printAnswer(playerAnswer);
        hintNum = 0;
        hintBtn.SetActive(false);
        unknownBtn.SetActive(true);
    }





}
