using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(6);
        }
    }
}
