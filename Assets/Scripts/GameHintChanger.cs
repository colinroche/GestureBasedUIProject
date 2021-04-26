using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHintChanger : MonoBehaviour
{
    public GameObject panel;
    public GameObject[] hints;
    [SerializeField] Animation HintPanelAnim;
    [SerializeField] Animation[] HintTextAnim;
    [SerializeField] Animator panelAnimator;
    [SerializeField] Animator[] textAnimator;

    private int i = 0;

     void Start() 
     {
        InvokeRepeating("Tick", 10, 10);
        panel.SetActive(false);
     }
     void Tick() 
    {
        panel.SetActive(true);
        hints[i].SetActive(true);
        panelAnimator.Play("Default", -1, 0.0f);
        textAnimator[i].Play("Default", -1, 0.0f);
        HintPanelAnim.Play();
        HintTextAnim[0].Play();
        Debug.Log("Tick");
        i++;
    }

   
}
