using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    public Image leftPot, rightPot;

    public GameObject dialogueSet;
    public Text dialogueText, prologueText, nameText;
    public float typeSpeed = .1f;
    public bool skipPhase = false;
    public Image bg;

    public string x = "Halo namaku Wira";
    // Use this for initialization
    void Start()
    {
        Dialogue_Database.SetDatabase();

        StartCoroutine(Act1_Lvl1());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!skipPhase)
            {
                skipPhase = true;
            }
        }
    }
	//prolog
    IEnumerator TextScroll(string lineOfText, Text _theText)
    {
        skipPhase = false;
        dialogueSet.SetActive(false);
        prologueText.text = "";
        dialogueText.text = "";

        int letter = 0;
        _theText.text = "";

        while (letter < lineOfText.Length - 1 && !skipPhase)
        {
            _theText.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return null;
        _theText.text = lineOfText;
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

    }
	//dialog
    IEnumerator TextScroll(string _left, string _right, Side _side, string lineOfText, Text _theText)
    {
		rightPot.gameObject.SetActive (true);
		leftPot.gameObject.SetActive (true);

		if (_left == "") {
			leftPot.gameObject.SetActive (false);
		}

		if (_right == "") {
			rightPot.gameObject.SetActive (false);
		}

        skipPhase = false;
        dialogueSet.SetActive(true);
        prologueText.text = "";
        dialogueText.text = "";

        leftPot.sprite = Resources.Load<Sprite>("Dialog Char/" + _left);
        rightPot.sprite = Resources.Load<Sprite>("Dialog Char/" + _right);

        if (_side == Side.Left)
        {
            nameText.text = _left;
            rightPot.color = Color.gray;
            leftPot.color = Color.white;
        }
        else
        {
            nameText.text = _right;
            leftPot.color = Color.gray;
            rightPot.color = Color.white;
        }

        int letter = 0;
        _theText.text = "";

        while (letter < lineOfText.Length - 1 && !skipPhase)
        {
            _theText.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        _theText.text = lineOfText;

        yield return null;
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
    }
	//ganti gambar
    IEnumerator SlideshowImage(Sprite _nextImage)
    {
        dialogueSet.SetActive(false);
        prologueText.text = "";
        dialogueText.text = "";

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

    }

    IEnumerator Act1_Lvl1()
    {
		yield return StartCoroutine(TextScroll("Jakarta 2104, Profesor Dharma seorang jenuis peraih nobel fisika berhasil menciptakan sebuah mesin waktu. Mesin waktu ini berbentuk sebuah kristal bernama “Etherion” yang dibuat bersama dengan asistennya, Arjuna. Profesor berharap dengan adanya mesin waktu ini, ia dapat mengungkap detail sejarah yang telah terlupakan."
            , prologueText));

        Sprite nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 1 - Early");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return  StartCoroutine(TextScroll("Jakarta 2104,Laboratorium Profsor Dharma"
            , prologueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Left,
			"Prof, semua persiapan sudah selesai, kita dapat memulai uji coba kapanpun anda siap."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Right,
			"Kau yakin ingin menjadi tes subjek untuk uji coba mesin waktu ini, Arjuna? Kita dapat menggunakan Hanoman yang merupakan sebuah Artificial Intelligence untuk mengurangi bahaya jika terjadi kesalahan pada uji coba ini."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Left,
			"Saya sangat yakin prof, lagipula... jika uji coba ini berhasil, maka Kristal Etherion ini akan mampu kita gunakan untuk mengubah dunia. Selain itu, kita masih memerlukan Hanoman sebagai navigator saat uji coba ini berhasil, benarkan?"
            , dialogueText));
		
		yield return StartCoroutine(TextScroll("Hanoman", "Profesor Dharma", Side.Left,
			"Benar apa kata Arjuna. Semua sistem berjalan dengan baik dan kita dapat memulai uji coba ini kapan pun."
			, dialogueText));
		
		yield return StartCoroutine(TextScroll("Hanoman", "Profesor Dharma", Side.Left,
			"Baiklah kalau begitu. Kita akan memulai uji cobanya."
			, dialogueText));


        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 2 - Mid");
        yield return StartCoroutine(SlideshowImage(nextImage));

		yield return StartCoroutine(TextScroll("Hanoman", "Profesor Dharma", Side.Left,
			"Batalkan uji coba! Cepat batalkan! Hanoman aktifkan protokol pencegahan segera!"
			, dialogueText));

		yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Right,
			"Kristal Etherion tidak merespon apapun prof! Aktifkan override protocol!"
			, dialogueText));
		
		yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
			"Error… error… Program Pencegahan tidak dapat dibatalkan. Memulai inisiai perjalan waktu…."
			, dialogueText));

		yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Left,
			"Arjuna cepat lepaskan Kristal Etherion tersebut!"
			, dialogueText));

		yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Right,
			"argh!!!"
			, dialogueText));
		
        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 3 - Last");
        yield return StartCoroutine(SlideshowImage(nextImage));
	
		yield return StartCoroutine(TextScroll("", "Profesor Dharma", Side.Left,
			"Arjunaa!!!"
			, dialogueText));
      
    }
}

public enum Side
{
    Left,
    Right
}