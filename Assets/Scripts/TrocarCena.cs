using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
   public string SceneName;
   
    public void CarregarFase()
    {
        SceneManager.LoadScene(SceneName);
    }


    
}
