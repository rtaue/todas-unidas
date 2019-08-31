using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Expressao : MonoBehaviour {
    public Sprite[] expressao;
    public int nExpressao;
    Image img;

    public int indexNumberAtivo;

    public int indexNumberDesativo;

	// Use this for initialization
	void Start () {

        img = GetComponent<Image>();

	}

    private void Update()
    {
        indexNumberDesativo = transform.GetSiblingIndex();

        if (indexNumberDesativo < indexNumberAtivo)
        {

            img.CrossFadeColor(new Color32(116, 116, 116, 255), 1, false, false);

        }
    }

    public void ChangeSprite () {
        img.sprite = expressao[nExpressao];
	}

    public void PersonagemAtivo()
    {

        img.CrossFadeColor(new Color32(255, 255, 255, 255), 1, false, false);
        transform.SetAsLastSibling();
        indexNumberAtivo = transform.GetSiblingIndex();
    }


}
