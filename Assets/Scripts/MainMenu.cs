using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;
    private bool stateOfCB;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            
            SceneManager.LoadScene("menu");
        }
    }
    public void PlayMaze()
    {
        if (colorblindMode.isOn == true)
        {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (colorblindMode.isOn == false)
        {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
