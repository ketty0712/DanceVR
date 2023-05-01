using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerEffect : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeAnchored()
    {
        rectTransform.anchoredPosition = new Vector2(0, 0);
        rectTransform.SetAsFirstSibling();
    
    }
}
