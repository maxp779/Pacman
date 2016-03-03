using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartupScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Debug.Log("startup called");
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("mainGame");

    }
}
