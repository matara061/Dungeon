using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

	public Text nameText;
	public Text dialogueText;
	//public GameObject weapon;
	//public GameObject gun;
	public GameObject continueB;

	public Animator animator;

	private Queue<string> sentences;

	public static DialogueManager instance;
	void Awake() // Basicamente é a msm coisa que o void Star, contudo, a prioridade de execução sempre vai ser do Awake 
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
	}

		// Use this for initialization
		void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		FindObjectOfType<AudioManager>().Play("Click");
		animator.SetBool("IsOpen", true);

		//weapon.SetActive(false);
		//gun.SetActive(false);
		continueB.SetActive(true);
		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		FindObjectOfType<AudioManager>().Play("Click");
		animator.SetBool("IsOpen", false);
		continueB.SetActive(false);
		//weapon.SetActive(true);
		//gun.SetActive(true);
	}

}
