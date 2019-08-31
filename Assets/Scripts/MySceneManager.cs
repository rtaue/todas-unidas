using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MySceneManager : MonoBehaviour {
	public string automaticScene;
	public float timeToWait;
	void Start () {
		//se tiver escrito carrega automatico
		if (automaticScene.Length > 0 && timeToWait > 0) {
            //metodo q chama depoisde um tempo
			Invoke ("MyLoadScene", timeToWait);
		}
	}

	//sobrecarga sem parametro p/ o invoke
	public void MyLoadScene(){
		MyLoadScene (automaticScene);
	}

	//chama a cena de loading armazenando 
	//o nome da proxima cena
	public void MyLoadScene(string SceneToGo){
		unPause ();
		MainData.NextScene = SceneToGo;
		//SceneManager.LoadScene("Loading");
		Invoke("DelayLoad",0.5f); //delay para ouvir os efeitos
	}
	public void MyLoadSceneFast(string SceneToGo){
		unPause ();
		MainData.NextScene = SceneToGo;
		SceneManager.LoadScene("Loading");
	}

	void DelayLoad(){
		SceneManager.LoadScene("Loading");

	}
	public void Pause(){
		//deixa o tempodo jogo muuuuuito lento 
		Time.timeScale = 0.0001f;
	}
	public void unPause(){
		//volta o tempo para velocidade normal
		Time.timeScale = 1f;
	}

	public void Quit () {
		Application.Quit ();
	}
}
