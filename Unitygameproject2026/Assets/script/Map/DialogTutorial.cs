using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines.ExtrusionShapes;
using UnityEngine.UI;

public class DialogTutorial : MonoBehaviour
{
    public Text textLabel;
    public TextAsset textfile;
    public static bool playonce = true;
    public int index;
    public GameObject dialogCanvas, circle;
    private RectTransform rect;
    public GameObject self;

    List<string> textList = new List<string>();

    void Awake() {
        if (playonce)
        {
            GetextFormFile(textfile);
            rect = circle.GetComponent<RectTransform>();
        }
        else
        {
            self.SetActive(false);
        }
    }

    private void OnEnable()
    {
       textLabel.text = textList[index];
       index++;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && index == textList.Count -1)
        {
           gameObject.SetActive(false);
           index = 0;
           dialogCanvas.SetActive(false);
           circle.SetActive(false);
           playonce = false;
           return;
        }
        if (playonce) {
            if (Input.GetMouseButtonDown(0))
            {
                textLabel.text = textList[index];
                index++;
                if (index == 4)
                {
                    rect.localScale = new Vector3(1, 1, 1);
                    circle.SetActive(true);
                    rect.anchoredPosition = new Vector3(-850, 493, transform.position.z);
                }
                else
                    if (index == 5)
                {
                    rect.anchoredPosition = new Vector3(-666, 493, transform.position.z);
                }
                else
                    if (index == 6)
                {
                    rect.anchoredPosition = new Vector3(516, 493, transform.position.z);
                }
                else
                    if (index == 7)
                {
                    rect.anchoredPosition = new Vector3(712, 493, transform.position.z);
                }
                else
                    if (index == 8)
                {
                    rect.anchoredPosition = new Vector3(888, 493, transform.position.z);
                }
                else
                    if (index == 9)
                {
                    rect.anchoredPosition = new Vector3(-494, -43, transform.position.z);
                    rect.localScale = new Vector3(1.5f, 2.5f, 1);
                }
            }
        }
    }

    void GetextFormFile(TextAsset file) {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate) {
            textList.Add(line);
        }
    }
    
}
