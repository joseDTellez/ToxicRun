using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class DeathMenu : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;

    private Life playerLife;
    private void Start()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>();  //call to player by its tag
        playerLife.playerDeath += openMenu;                                            //submit the evento to player death

    }
    private void openMenu(object sender, EventArgs e)
    {
        deathMenu.SetActive(true);
    }
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void quit()
    {
        Application.Quit();
    }
    

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
