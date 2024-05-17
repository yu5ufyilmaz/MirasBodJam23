using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Canvas canvas1;
    public Canvas canvas2;

    private void Start()
    {
        // İlk başta sadece birinci Canvas aktif olsun, diğeri pasif olsun
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
    }

    public void ToggleCanvas()
    {
        // Canvas 1'i kapat
        canvas1.gameObject.SetActive(false);

        // Canvas 2'yi aç
        canvas2.gameObject.SetActive(true);
    }
}
