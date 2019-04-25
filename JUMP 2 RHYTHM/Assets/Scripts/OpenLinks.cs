using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour {

	public void OpenSoundCloud()
    {
        Application.OpenURL("https://soundcloud.com/webbc99");
    }

    public void OpenPrivacyPolicy()
    {
        Application.OpenURL("https://sites.google.com/view/jump-2-rhythm-privacy-policy/home");
    }
}