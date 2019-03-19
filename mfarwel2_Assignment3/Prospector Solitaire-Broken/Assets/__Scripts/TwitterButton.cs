using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TwitterButton : MonoBehaviour
{
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";

    public Button buttonComponent;
  
    void Start ()
    {
        buttonComponent.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        ShareToTwitter("I'm playing Unity Solitaire! I just scored: " + ScoreManager.SCORE);
    }

    public void ShareToTwitter(string textToDisplay)
    {
        Application.OpenURL(TWITTER_ADDRESS +
                    "?text=" + WWW.EscapeURL(textToDisplay) +
                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }

}