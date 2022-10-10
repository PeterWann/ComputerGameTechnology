using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    GameObject[] digits = new GameObject[4];
    [SerializeField]
    GameObject codeCheck;

    private GameObject door;

    private readonly string[] digitValue = new string[4];
    private readonly string code = "6295";
    private string codeInput;

    private int counter = 0;

    private void Start()
    {
        codeCheck.GetComponent<TextMeshProUGUI>().text = "";
        door = GameObject.Find("door");

        ResetDigits();
    }

    private void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            digits[i].GetComponent<TextMeshProUGUI>().text = digitValue[i];
        }
    }

    public void AddDigit(string digit)
    {
        if (counter < 4)
        {
            if (digitValue[counter] == "")
            {
                digitValue[counter] = digit;
            }
            
            if (counter != 3)
            {
                counter++;
            }
        }
    }

    public void EraseDigit()
    {
        if (counter >= 0)
        {
            digitValue[counter] = "";

            if (counter > 0)
            {
                counter--;
            }
        }
    }

    public void Unlock()
    {
        if (counter == 3)
        {
            codeInput = "";
            foreach (string s in digitValue)
            {
                codeInput += s;
            }

            ResetDigits();
            counter = 0;

            if (codeInput == code)
            {
                door.GetComponent<Door>().OpenDoor();

                StartCoroutine(CodeCheckResult("CORRECT"));
            } else
            {
                StartCoroutine(CodeCheckResult("INCORRECT"));
            }
        }
    }

    public void ResetDigits()
    {
        for (int i = 0; i < 4; i++)
        {
            digitValue[i] = "";
        }
    }

    IEnumerator CodeCheckResult(string result)
    {
       
        codeCheck.GetComponent<TextMeshProUGUI>().text = result;

        yield return new WaitForSeconds(2);

        codeCheck.GetComponent<TextMeshProUGUI>().text = "";
    }
}
