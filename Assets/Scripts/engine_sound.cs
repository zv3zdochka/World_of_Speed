using UnityEngine;

public class engine_sound : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;
    

    private bool isPlayingSound1;
    private bool isPlayingSound2;
    private bool isPlayingSound3;
    private bool isWaiting;

    private void Start()
    {
        sound1 = gameObject.AddComponent<AudioSource>();
        sound2 = gameObject.AddComponent<AudioSource>();
        

        sound1.clip = Resources.Load<AudioClip>("b_s");
        sound2.clip = Resources.Load<AudioClip>("a_s");
        

        sound1.loop = true;
        sound2.loop = true;
        

        isWaiting = true;
        isPlayingSound1 = false;
        isPlayingSound2 = false;
        isPlayingSound3 = false;

        StartCoroutine(PlayDelayedSound1());
    }

    private System.Collections.IEnumerator PlayDelayedSound1()
    {
        yield return new WaitForSeconds(1.3f); // Задержка в 2 секунды

        isWaiting = false;
        sound1.Play();
        isPlayingSound1 = true;
    }

    private void Update()
    {
        // Проверяем, нажаты ли кнопки WASD
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isSpacePressed = Input.GetKey(KeyCode.Space);

        // Если не нажата ни одна кнопка и не ожидается, играем звук 1
        if (!isWPressed  && !isSPressed  && !isSpacePressed && !isPlayingSound2 && !isPlayingSound3 && !isWaiting)
        {
            if (!isPlayingSound1)
            {
                sound1.Play();
                isPlayingSound1 = true;
            }
        }
        // Если нажата хотя бы одна кнопка WASD, играем звук 2
        else if ((isWPressed  || isSPressed ) && !isPlayingSound3)
        {
            if (!isPlayingSound2)
            {
                sound1.Stop();
                sound2.Play();
                isPlayingSound2 = true;
            }
        }
        // Если нажата кнопка Пробел, играем звук 3
        else if (isSpacePressed)
        {
            sound1.Stop();
            sound2.Stop();
            
            isPlayingSound3 = true;
        }
        // Если ни одна из вышеперечисленных кнопок не нажата, останавливаем все звуки и сбрасываем флаги
        else
        {
            sound1.Stop();
            sound2.Stop();
            
            isPlayingSound1 = false;
            isPlayingSound2 = false;
            isPlayingSound3 = false;
        }
    }
}
