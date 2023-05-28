using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    public AudioClip intro, loop;
    //the "intro" field is optional. If you don't want a intro for your song, just leave it blank

    void Start() {

        if (intro != null)
        {

            BGMController.Instance.PlayBGMWithIntro(intro, loop);
        }
        else
        {
            BGMController.Instance.PlayBGM(loop);
        }
    }
}
