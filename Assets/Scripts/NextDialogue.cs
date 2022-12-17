using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextDialogue : MonoBehaviour
{
    public Button next_dia;
    private int curr_page = 0;
    [SerializeField] GameObject[] pages;

    public void Start() {
        // HingeJoint hinge = gameObject.GetComponentInChildren(typeof(HingeJoint)) as HingeJoint;
        next_dia = gameObject.GetComponentInChildren(typeof(Button)) as Button;
        if (next_dia == null) {
            //Debug.Log("null next_dia");
        }
        next_dia.onClick.AddListener(GoNext);
        //Debug.Log("Start Done");
    }

    void GoNext() {
        //Debug.Log("GoNext entered");
        curr_page++;
        if (curr_page >= pages.Length) {
            curr_page = 0;
        }
        foreach (GameObject p in pages) {
            if (p.GetComponentInChildren<PageNum>() != null && curr_page == p.GetComponentInChildren<PageNum>().GetOrd()) {
                p.SetActive(true);
            } else {
                //Debug.Log("deactivate");
                p.SetActive(false);
            }
        }
    }
}
