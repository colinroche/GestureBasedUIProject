using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHintChanger : MonoBehaviour
{
    [SerializeField] Animation HintPanelAnim;
    [SerializeField] Animation[] HintTextAnim;
    [SerializeField] Animator panelAnimator;
    [SerializeField] Animator[] textAnimator;

    private int i = 0;

     void Start() 
     {
         InvokeRepeating("Tick", 10, 10);
     }
     void Tick() 
     {
        panelAnimator.Play("Default", -1, 0.0f);
        textAnimator[i].Play("Default", -1, 0.0f);
        HintPanelAnim.Play();
        HintTextAnim[0].Play();
        Debug.Log("Tick");
        i++;
     }
    public void GameHint()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            GameHint();
        }
        
    }
}
