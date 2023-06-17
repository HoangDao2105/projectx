using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CR_LoadGame(5));
    }

    IEnumerator CR_LoadGame(int sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("Main");
    }
}
