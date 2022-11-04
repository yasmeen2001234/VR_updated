using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    public Button button;
    public Color wantedColor;
    Sprite FULLHP, LESSHP, LESSERHP, NOHP;
    // Start is called before the first frame update
    void Start()
    {
        FULLHP = Resources.Load<Sprite>("Untitled design.png");  //FULL
        LESSHP = Resources.Load<Sprite>("suit_life_meter_0");     //-1
        LESSERHP = Resources.Load<Sprite>("suit_life_meter_3");    //-2
        NOHP = Resources.Load<Sprite>("suit_life_meter_1");  //EMPTY

      
    }

    // Update is called once per frame
    void Update()
    {
      
        button.gameObject.GetComponent<Image>().sprite = FULLHP;
    }

    void ButtonChanger()
    {
        ColorBlock cb = button.colors;
        cb.normalColor = new Color(255, 8, 200);
        cb.highlightedColor = wantedColor;
        cb.selectedColor = wantedColor;
        button.colors = cb;
    }
}
