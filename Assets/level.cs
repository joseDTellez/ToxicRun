using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    public void mainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
}
