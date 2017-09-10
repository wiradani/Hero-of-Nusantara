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

    public string x = "Halo namaku Xxx";
    // Use this for initialization
    void Start()
    {
        Dialogue_Database.SetDatabase();

        StartCoroutine(Act1_Lvl_Prolog());
        //StartCoroutine(Act1_Lvl_1());
        //StartCoroutine(Act1_Lvl_2());
        //StartCoroutine(Act1_Lvl_3());
        //StartCoroutine(Act1_Lvl_4());
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
        rightPot.gameObject.SetActive(true);
        leftPot.gameObject.SetActive(true);

        if (_left == "")
        {
            leftPot.gameObject.SetActive(false);
        }

        if (_right == "")
        {
            rightPot.gameObject.SetActive(false);
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

    IEnumerator Act1_Lvl_Prolog()
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
		
        yield return StartCoroutine(TextScroll("Hanoman", "Profesor Dharma", Side.Right,
                "Baiklah kalau begitu. Kita akan memulai uji cobanya."
			, dialogueText));


        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 2 - Mid");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Right,
                "Batalkan uji coba! Cepat batalkan! Hanoman aktifkan protokol pencegahan segera!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Left,
                "Kristal Etherion tidak merespon apapun prof! Aktifkan override protocol!"
			, dialogueText));
		
        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Error… error… Program Pencegahan tidak dapat dibatalkan. Memulai inisiai perjalan waktu…."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Left,
                "Arjuna cepat lepaskan Kristal Etherion tersebut!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Profesor Dharma", Side.Left,
                "argh!!!"
			, dialogueText));
		
        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Lab 3 - Last");
        yield return StartCoroutine(SlideshowImage(nextImage));
	
        yield return StartCoroutine(TextScroll("", "Profesor Dharma", Side.Right,
                "Arjunaa!!!"
			, dialogueText));
      
        nextImage = Resources.Load<Sprite>("Dialog Background/Hutan Rimba");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Ah... di-dimana ini? Jakarta? ...Sepertinya bukan… mungkinkah? Hanoman! Hanoman!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Memulai prosedur reboot… Check. Memulihkan sistem… Check. Memulai pengecekan… Check. Sistem darurat dijalankan… Activate."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Sistem Darurat? Mungkinkah Kristal Etherion ditanganku ini... berhasil melintasi waktu?"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Sistem di jalankan… Check, Tidak ada kerusakan berarti… Check. "
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Hanoman, dimana kita sekarang?"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Saat ini Kita berada di tahun 1893, Tepatnya Perkampungan di Jawa daerah Maja."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Perkampungan Daerah Maja?! Bi-bisakah kau mengatur Kristal Etherion ini untuk membawa kita kembali Ke masa depan?"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Negative... terdapat kebocoran energi. Kristal Etherion tidak dapat melompat langsung menuju tahun 2104. Memerlukan waktu lebih untuk melakukan proses pengisian ulang tenaga."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Hmm… kalau begitu, kita harus menunggu dulu beberapa saat di era ini, kah? ...Hanoman, dapatkah kau melakukan kontak dengan professor?"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Negative… tidak menemukan frekuensi yang sesuai."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Tahan! Siapa kau dan sedang apa disini?!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Left,
                "Stop! Kami hanya penduduk yang tersasar!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "“Stop”, apa itu? ...Yang lebih penting, pakaian kalian aneh sekali untuk seorang penduduk setempat, Jangan Bilang kalau kalian adalah mata-mata pasukan mongol!!!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Left,
                "Hah? Mongol? Maksudmu Mongolia? Eh… Tu-tunggu sebentar! Tahan dulu dan tolong turunkan tombak di tanganmu sebentar!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Mongol", Side.Right,
                "Itu Mereka, Pasukan majapahit! Cepat serang mereka!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Bahaya… Bahaya… kita harus pergi dari tempat ini, Arjuna!"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Eh? Tu-tunggu sebentar! Pasukan… Majapahit? Apa kalian pasukan Majapahit?"
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Benar, Kami adalah Pasukan kerajaan Majapahit."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Hanoman! Kita harus melindungi mereka! Aku tidak tahu mengapa dan aku tidak dapat memikirkan alasan yang tepat untuk saat ini... tapi aku punya perasaan buruk jika kita membiarkan pasukan yang sepertinya berasal dari Mongolia itu menangkap mereka ditempat seperti ini."
            , dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Kristal Etherion menunjukkan reaksi? Baiklah Arjuna, memulai protokol bertahan… Activate, Defense Protocol!"
            , dialogueText));


      
		Framework_GameManager.instance.GoToArena();
    }

    IEnumerator Act1_Lvl_2()
    {
        Sprite nextImage = Resources.Load<Sprite>("Dialog Background/Hutan Rimba");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Fiuh~, Hampir saja kita kalah~."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Terima kasih hai orang asing, Maafkan kami karena telah menuduhmu sebagai mata-mata musuh tanpa mendengarkan pendapatmu terlebih dahulu."
			, dialogueText));
		
        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Left,
                "Ah, Iya tidak apa-apa… walaupun aku tidak terlalu mengerti keadaan kalian saat ini, tapi menurutku wajar jika kalian merasa curiga terhadap orang asing dalam situasi seperti ini. Tapi… Bolehkah aku bertanya satu hal?"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Silahkan. Selama kami mampu menjawabnya, kami akan menjawab pertanyaanmu hai orang asing."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Left,
                "Sebenarnya... ini dimana dan kenapa pasukan mongolia menyerang kalian?"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "Mada! Mada! Apa kau baik-baik saja? ...dan siapa kau orang asing?!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "Paduka! Terima kasih atas perhatian Paduka raja. Tapi seperti yang Paduka lihat, Hamba baik baik saja. Semua ini berkat bantuan orang asing ini, kami berhasil selamat dari pasukan musuh."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "Hmm~ begitu, kah? Aku ucapkan terimakasih orang asing. Mada adalah salah satu prajurit terbaik kami di kerajaan ini."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Terima kasih Paduka, sebenarnya jika aku diperkenankan untuk bertanya... mengapa pasukan mongolia menyerang anda?"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "Oh ya? Jadi begitu, kah? Sepertinya kau datang dari negeri nan jauh di daerah Timur. Baiklah Kalau begitu, Biarkan aku menjelaskannya secara singkat kepadamu. Setelah kerajaan singasari jatuh dan kehilangan pengaruhnya, pasukan mongol berbalik dan menyerang kerajaan Majapahit ini."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Kerajaan... Majapahit? Ka-kalau begitu, Berarti anda adalah Raden Wijaya pendiri kerajaan Majapahit itu?!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "Maaf Paduka karena menyela pembicaraan Paduka saat ini tapi sebaiknya kita harus terus bergerak. Hamba rasa keadaan saat ini masih belum aman sampai kita tiba di wilayah ibu kota, Paduka."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Right,
                "Kau benar Mada, sebaiknya kita terus bergerak sebelum bala bantuin pasukan Mongol tiba."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Mongol", "Raden Wijaya", Side.Left,
                "Itu mereka! Jangan biarkan mereka melarikan diri!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Gawat! Paduka cepat pergi! Serahkan tempat ini padaku, aku akan menahan mereka untuk sementara!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "Menahan mereka? Sendirian? Apa kau yakin? Aku dapat membantumu--"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                " --Sebaiknya Paduka tetap menjaga jarak dan segera meninggalkan tempat ini! ...Tapi terimakasih karena telah mencemaskanku, namun biarkan aku sendiri yang menahan mereka. lagipula, apa jadinya jika ada peluru nyasar yang mengenai Paduka. "
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "“Peluru Nyasar”, Walaupun aku tidak tahu benda apa yang kau maksud, Tapi hamba setuju dengan pendapatnya, Paduka. Cepat kita pergi dari tempat ini, Paduka. Kalau tidak salah namamu itu… "
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Arjuna, itulah namaku."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Arjuna… nama yang bagus dan juga kuat, Bertahanlah dan pastikan kau kembali dengan selamat, kami akan menunggumu di ibu kota."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Apa kau yakin arjuna?"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Tentu saja aku yakin, lagi pula…  jika Raden Wijaya tidak selamat dari pertempuran ini, Maka Majapahit tidak akan pernah berdiri dan itu dapat membuat sejarah bergerak kearah yang tidak seharusnya, oleh karena itu, kupikir hanya kitalah yang dapat membantu mereka untuk saat ini."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Baiklah jika itu adalah pilihanmu, Arjuna. Memulai protokol bertahan… Activate, Defense Protocol!"
			, dialogueText));
	
    }

    IEnumerator Act1_Lvl_3()
    {
        Sprite nextImage = Resources.Load<Sprite>("Dialog Background/Hutan Rimba");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Sepertinya sudah tidak ada tanda-tanda musuh, kita harus segera menuju Ibu kota Majapahit."
			, dialogueText));
		
        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Kau benar Hanoman, aku rasa pasukan mongolia tidak akan menyerah begitu saja."
			, dialogueText));

        nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Istana Majapahit");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Arjuna, Syukurlah kau kembali dengan selamat! Ah! Kuucapkan terimakasih untuk bantuan yang kau berikan sebelumnya. Mari, akan kubawa kau untuk menemui Paduka raja."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Arjuna... Benar, kan?  Terima kasih banyak karena kau telah membantu prajuritku dan juga telah bersedia untuk menahan pasukan musuh sebelumnya sehingga kami berhasil tiba di ibu kota ini. Walaupun pertemuan pertama kita mungkin tidak begitu baik tapi biarkan aku memperkenalkan diri terlebih dahulu, Namaku adalah Raden Wijaya, raja dari kerajaan Majapahit dan ini adalah prajurit setiaku, Mada."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "Apa kau yakin, apa itu saja sudah cukup untukmu? mengingat apa yang telah kau lakukan terhadapku, tentu saja aku akan mengizinkanmu untuk beristirahat di istanaku ini hingga rasa lelahmu itu menghilang. Mada, Persiapkan kamar peristirahatkan untuk Arjuna. Pastikan kau menyiapkan kamar yang dapat membuat pikirannya damai dan menghilangkan rasa lelahnya."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Terimakasih Paduka."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "Paduka! Paduka! Gawat!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Right,
                "Ada apa prajurit ? Tenangkan dirimu sejenak."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Right,
                "Seluruh armada pasukan mongol sedang Menuju kearah istana dan dalam waktu dekat mereka akan tiba di Istana, Paduka!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "Apa?! Segera evakuasi warga! Utamakan perempuan dan anak anak terlebih dahulu! Bentuk benteng pertahanan disekitar istana dengan segera! ...Maaf Arjuna aku tahu kau lelah, tapi bisakah kau sekali lagi membantu ku?"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Tentu saja Paduka, saya bersedia membantu anda, lagi pula… hidangan yang Mada janjikan sebelumnya membuat saya ingin mencicipinya."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "Terima kasih Arjuna, prajurit! Apapun yang terjadi kita harus melindungi warga! Biarkan mereka masuk kedalam istana! Dan kita pertahankan kerajaan ini hingga titik darah penghabisan!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "Segera Paduka!"
			, dialogueText));
    }

    IEnumerator Act1_Lvl_4()
    {
        Sprite nextImage = Resources.Load<Sprite>("Dialog Background/BG Dialog Perkampungan Majapahit 2");
        yield return StartCoroutine(SlideshowImage(nextImage));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Right,
                "Arjuna! Apa Kita berhasil memukul mundur musuh? "
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Pengawal", Side.Left,
                "Fuhh ya kita berhasil, tapi hampir saja kita yang berhasil mereka kalahkan.\n"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Rakyat", "Raden Wijaya", Side.Right,
                "Argh!!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Rakyat", "Raden Wijaya", Side.Left,
                "Paduka! A-apa anda baik-baik saja?! Paduka lebih baik segera mundur, luka Paduka harus segera diobati!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Rakyat", "Raden Wijaya", Side.Right,
                "Tidak ! aku masih bisa bertahan , obati dulu luka yang lain"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Rakyat", "Raden Wijaya", Side.Left,
                "Paduka ! lihat itu …."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Rakyat", "Raden Wijaya", Side.Right,
                "Akhirnya... pemimpin musuh memilih untuk mengambil bagian dalam penyerangan ini."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Rakyat", "Raden Wijaya", Side.Left,
                "Paduka! Apa yang Paduka lakukan?! Jangan Bilang--! Paduka harus lebih mengkhawatirkan keadaan Paduka terlebih dahulu! Jika Paduka memaksakan diri, Paduka tidak akan mampu menghadapi pemimpin musuh dengan luka seperti itu."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Left,
                "Paduka, Paduka lebih baik segera mundur ke Istana, rakyat membutuhkan sosok seorang pemimpin dalam menghadapi situasi seperti ini, jika terjadi sesuatu terhadap Paduka, tidak hanya moral pasukan yang akan menurun, rakyat akan menjadi putus asa, dan pada akhirnya semua itu hanya akan berjalan sesuai dengan apa yang diinginkan oleh pasukan musuh."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Raden Wijaya", Side.Right,
                "K-kau benar Arjuna, baiklah kalau begitu, Mada! Kuserahkan baris pertahanan kepada mu."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Pengawal", "Raden Wijaya", Side.Left,
                "Siap paduka! Walaupun nyawa ini taruhannya, akan kupastikan tidak seorangpun pasukan musuh berhasil menerobos barisan pertahanan pasukan kita!"
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                "Hanoman, sepertinya kita harus mengeluarkan seluruh kemampuan kita."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Tapi Arjuna, energi yang dikumpulkan Kristal Etherion sudah siap untuk kembali ke masa depan."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Left,
                " Tidak apa Hanoman, bila Majapahit runtuh... tidak akan ada masa depan untuk kembali."
			, dialogueText));

        yield return StartCoroutine(TextScroll("Arjuna", "Hanoman", Side.Right,
                "Baik Arjuna, melepaskan seluruh energi pada Kristal Etherion… Activate, Etherion Protocol Overdrive!"
			, dialogueText));
    }
}

public enum Side
{
    Left,
    Right
}