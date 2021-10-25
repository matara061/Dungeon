using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // Um array de aúdio, isso permite utilizar uma boa quantidade de aúdio através de uma única função

    public static AudioManager instance;
    void Awake() // Basicamente é a msm coisa que o void Star, contudo, a prioridade de execução sempre vai ser do Awake 
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) // agr entendi. Foreach é para percorrer as posições de memória do array. podemos dizer que a Letra S são os indices
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }
    public void Play(string name) // Caso o nome do aúdio ñ seja encontrado, vai dar um super hiper mega bug. Se atentar ao nome pré-definido do Som
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
