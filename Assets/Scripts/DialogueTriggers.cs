using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    public DialogueManager DManager;
    public GameSettings settingMan;
    //public CityStats cityStat;
    // Start is called before the first frame update
    void Start()
    {
        //if settings.useTut == true
        StartCoroutine(StartTut(1.0f));

    }

    public IEnumerator StartTut(float time)
    {
        yield return new WaitForSeconds(time);
        DManager.StartDialogue(DManager.tutdial[DManager.tutcount]);
        //yield return 0;
    }

    public void PlayTut()
    {
        DManager.StartDialogue(DManager.tutdial[DManager.tutcount]);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
