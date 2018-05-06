using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageColor : MonoBehaviour {


    public SpriteRenderer stage;
    Color original;

    private void Awake()
    {
        original = stage.color;
    }

    public void OnMouseOver()
    {
        stage.color = new Color32(249, 58, 58, 163);
    }

    public void OnMouseEnter()
    {
        stage.color = new Color32(249, 58, 58, 163);
    }

    public void OnMouseExit()
    {
        stage.color = original;

    }


    

}
