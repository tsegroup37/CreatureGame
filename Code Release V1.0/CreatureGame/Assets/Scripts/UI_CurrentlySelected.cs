using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CurrentlySelected : MonoBehaviour
{
    Controller ct;
    public Sprite[] ToolIcons;
    public Image image;
    int CurrentSprite;
    // Start is called before the first frame update
    void Start()
    {
        ct = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSprite = ct.ToolNumber;

        image.sprite = ToolIcons[CurrentSprite];
    }
}
