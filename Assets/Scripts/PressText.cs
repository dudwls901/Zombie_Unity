using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PressText : MonoBehaviour{
    Text flashingText;
    //  Use this for initialization

    void Start()
    {
        flashingText = GetComponent<Text>();
        StartCoroutine(BlinkText());
    }
    public IEnumerator BlinkText()
    {
        //무한루프
        while (true)
        { 
            //코루틴을 이용해 0.7초 간격으로 텍스트를 지웠다가 넣어준다.
            flashingText.text = ""; 
            yield return new WaitForSeconds(.7f); 
            flashingText.text = "Press Any Key..."; 
            yield return new WaitForSeconds(.7f); 
        }
    }
}

