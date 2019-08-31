using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public DialogueManager dialogueManager;

    public DialogueTrigger nextDialogue;

    public GameObject escolha;

    public Expressao personagem;

    public Animator anima;

    public bool endScene = false;

    public string nextLevel;

    private void Start()
    {
        if (personagem == null)
        {

            personagem = GetComponentInParent<Expressao>();

        }
    }

    public void TriggerDialogue()
    {

        dialogueManager.nextDialogue = nextDialogue;

        dialogueManager.escolha = escolha;

        dialogueManager.personagem = personagem;

        dialogueManager.anima = anima;

        dialogueManager.endScene = endScene;

        dialogueManager.nextLevel = nextLevel;

        dialogueManager.StartDialogue(dialogue);

    }

    
}
