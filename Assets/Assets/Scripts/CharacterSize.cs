using UnityEngine;
using DG.Tweening;

public class CharacterSize : MonoBehaviour
{
    public float shrinkFactor = 0.5f; // Boyut küçültme faktörü
    public float duration = 1.0f;     // Boyut küçültme süresi

    private Vector3 originalScale;    // Orijinal boyut

    private bool hasShrunk = false;   // Boyut küçültüldü mü kontrol

    private void Start()
    {
        originalScale = transform.localScale; // Orijinal boyutu sakla
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Smaller") && !hasShrunk)
        {
            ShrinkCharacter(); // Trigger bölgesine girdiğinde karakteri küçült
        }
    }

    private void ShrinkCharacter()
    {
        // DOTween ile boyut küçültme animasyonu
        transform.DOScale(originalScale * shrinkFactor, duration)
            .OnComplete(() =>
            {
                // Boyut küçültme animasyonu tamamlandığında yapılacak işlem
                Debug.Log("Karakter boyutu küçültüldü!");
                hasShrunk = true; // Boyut küçültüldüğünde tekrar küçültmeyi engellemek için kontrolü ayarla
            });
    }
}
