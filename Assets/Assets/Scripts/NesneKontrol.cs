using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class NesneKontrol : MonoBehaviour
{
    public GameObject nesne; // Kaybolacak nesne
    public float kaybetmeSuresi = 4.0f; // Nesnenin kaybolma süresi (örneğin 3 saniye)
    public VideoPlayer videoPlayer; // VideoPlayer bileşeni
    public string hedefSahneAdi; // Geçiş yapılacak hedef sahne adı

    private float gecenSureNesne = 0.0f;
    private bool nesneAktif = true;

    void Start()
    {
        videoPlayer.Stop();
        videoPlayer.targetCamera = Camera.main;
        videoPlayer.prepareCompleted += VideoHazir;
        videoPlayer.loopPointReached += VideoBitir;
    }

    void Update()
    {
        if (nesneAktif)
        {
            gecenSureNesne += Time.deltaTime;
            if (gecenSureNesne >= kaybetmeSuresi)
            {
                nesne.SetActive(false);
                nesneAktif = false;

                // Video başlat
                videoPlayer.Play();
            }
        }
    }

    void VideoHazir(VideoPlayer vp)
    {
        vp.Play();
        Debug.Log("Video Başladı");
    }

    void VideoBitir(VideoPlayer vp)
    {
        Debug.Log("Video Bitti");
        
        // Video tamamlandığında, başka bir sahneye geçiş yap
        SceneManager.LoadScene(hedefSahneAdi);
    }
}
