using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class main : MonoBehaviour
{
    [SerializeField] private GameObject newGame,loadGame,options;
    
    public InputField Game_name;
    public Text[] names;


    public void NewGameMenu(){
        newGame.SetActive(true);
        loadGame.SetActive(false);
    }
    public void loadGameMenu(){
        loadGame.SetActive(true);
        newGame.SetActive(false);
        string[] lines = System.IO.File.ReadAllLines ("Assets/files/savings.txt");
        lines[0].Split(",");
        lines[1].Split(",");
        lines[2].Split(",");
        names[0].text= lines[0].Split(",")[0]; 
        names[1].text= lines[0].Split(",")[1]; 
        names[2].text= lines[1].Split(",")[0]; 
        names[3].text= lines[1].Split(",")[1]; 
        names[4].text= lines[2].Split(",")[0]; 
        names[5].text= lines[2].Split(",")[1]; 
    }
    public void OptionsMenu(){
        options.SetActive(true);
        loadGame.SetActive(false);
        newGame.SetActive(false);
    }
    public void StartGame(){
        if(Game_name.text!=""){ 
            StreamWriter writer = new StreamWriter("Assets/files/game.txt", false);
            writer.WriteLine(Game_name.text+",1");
            writer.Close();
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
    public void LoadGame(int i){
            StreamWriter writer = new StreamWriter("Assets/files/game.txt", false);
            writer.WriteLine(names[2*i+0].text + ","+names[2*i+1].text);
            writer.Close();
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Quit(){
        Application.Quit();
    }
}
