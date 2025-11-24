using UnityEngine;
using UnityEngine.SceneManagement;
public class scenechange : MonoBehaviour
{
    // Name of the scene to load
    public string scenename;

    public void Changescene()
    {
        SceneManager.LoadScene(scenename);
    }
}
