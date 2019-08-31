using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public DialogueTrigger nextDialogue;

    public GameObject escolha;

    private Queue<string> sentences;

    private Queue<int> expressoes;

    public Expressao personagem;

    public Animator anima;

    public bool endScene = false;

    public string nextLevel;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
        expressoes = new Queue<int>();
	}

    public void StartDialogue(Dialogue dialogue)
    {

        if (personagem != null)
        {

            personagem.PersonagemAtivo();

        }
        

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();
        expressoes.Clear();

        foreach (string sentence in dialogue.sentences)
        {

            sentences.Enqueue(sentence);

        }

        foreach (int expressao in dialogue.expressoes)
        {

            expressoes.Enqueue(expressao);

        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {

            EndDialogue();
            
            return;

        }

        if (personagem != null)
        {

            personagem.nExpressao = expressoes.Dequeue();

            personagem.ChangeSprite();

        }

        if (anima != null)
        {

            anima.ResetTrigger("next");

        }

        

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {

        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {

            dialogueText.text += letter;
            yield return null;

        }

    }

    public void EndDialogue()
    {

        animator.SetBool("IsOpen", false);
        LoadNextScene();
        NextAction();
    }

    public void NextAction()
    {

        if (nextDialogue != null)
        {

            nextDialogue.TriggerDialogue();

        }
        if (escolha != null)
        {

            escolha.SetActive(true);

        }
        if (anima != null)
        {

            anima.SetTrigger("next");

        }

    }

    public void LoadNextScene()
    {

        if (endScene)
        {
            StartCoroutine(ChangeLevel());

            


        }

    }

    IEnumerator ChangeLevel()
    {

        float fadeTime = GameObject.Find("Fade").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(nextLevel);

    }
}
