using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUIManager : MonoBehaviour
{
   
    public void startButtonClicked()
    {
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

    public void exitButtonClicked()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
