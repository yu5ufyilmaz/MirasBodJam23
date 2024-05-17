using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class SceneController : MonoBehaviour
{
    public void GoToCredits(string  name)
    {
        // "SecondScene" adlı sahneye geçiş yap
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        PhotonNetwork.Disconnect();
        Application.Quit();
    }
}
