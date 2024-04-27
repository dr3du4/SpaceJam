using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public GameObject panel;
   public void startGame()
   {
      SceneManager.LoadScene("Main");
   }

   public void AboutGame()
   {
      panel.SetActive(true);
   }

   public void QuitePanel()
   {
      panel.SetActive(false);
   }
   
   
   public void quitGame()
   {
      
      Application.Quit();
        
      
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#endif

   }
}
