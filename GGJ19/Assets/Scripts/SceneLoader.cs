using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private static SceneLoader _instance;
    public static SceneLoader instance { get { return _instance; } private set { } }

    void Awake() {
        if (_instance == null) {
            _instance = this;
            Debug.Log("Instancia de SceneLoader criada");
        } else {
            Destroy(this.gameObject);
            Debug.Log("Instancia de SceneLoader já existe");
        }
    }
    
    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadCredts() {
        Debug.Log("Indo aos Creditos --- Sem funcao abaixo");
        SceneManager.LoadScene(2);
    }

    public void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame() {
        Debug.Log("Jogo Encerrado");
        Application.Quit();
    }
}
