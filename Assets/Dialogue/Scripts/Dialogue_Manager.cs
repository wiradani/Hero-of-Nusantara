using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Text dialogueText, prologueText;
    public bool isTyping, readyToTheNextDialogue;
    public bool goToNextPhase;
    public float typeSpeed = .1f;

    public Image bg;

    public string x = "Halo namaku Wira";
    // Use this for initialization
    void Start()
    {
        Dialogue_Database.SetDatabase();

        StartCoroutine(Act1_Lvl1());
    }

    IEnumerator TextScroll(string lineOfText, Text _theText)
    {
        int letter = 0;
        _theText.text = "";
        isTyping = true;

        while (letter < lineOfText.Length - 1 && isTyping)
        {
            _theText.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        isTyping = false;
        _theText.text = lineOfText;
    }

    IEnumerator SlideshowImage(Sprite _nextImage)
    {
        goToNextPhase = false;
        while (bg.color.a > 0.01f)
        {
            bg.color = Color.Lerp(bg.color, Color.clear, .05f);
            yield return null;
        }
        bg.sprite = _nextImage;
        while (bg.color.a < 0.99f)
        {
            bg.color = Color.Lerp(bg.color, Color.white, .05f);
            yield return null;
        }
        goToNextPhase = true;
    }

    IEnumerator Act1_Lvl1()
    {
        StartCoroutine(TextScroll("Jakarta 2104, Profesor Dharma seorang jenuis peraih nobel fisika berhasil menciptakan sebuah mesin waktu. Mesin waktu ini berbentuk sebuah gelang bernama “Time Watch” yang dibuatnya bersama dengan asistennya, Arjuna. Profesor berharap dengan adanya mesin waktu ini, ia dapat mengungkap detail sejarah yang telah terlupakan"
            , prologueText));

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        isTyping = false;

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        prologueText.text = "";

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        Sprite nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 1 - Early");
        StartCoroutine(SlideshowImage(nextImage));

        while (!goToNextPhase)
        {
            yield return null;
        }

        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 2 - Mid");
        StartCoroutine(SlideshowImage(nextImage));

        while (!goToNextPhase)
        {
            yield return null;
        }

        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 3 - Last");
        StartCoroutine(SlideshowImage(nextImage));

        while (!goToNextPhase)
        {
            yield return null;
        }

        yield return null;
    }
}
