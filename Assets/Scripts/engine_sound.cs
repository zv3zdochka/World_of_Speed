using UnityEngine;

public class engine_sound : MonoBehaviour
{
    public AudioSource sound1;
    public AudioSource sound2;
    public AudioSource sound3;

    private bool isPlayingSound1;
    private bool isPlayingSound2;
    private bool isPlayingSound3;

    private void Start()
    {
        sound1 = gameObject.AddComponent<AudioSource>();
        sound2 = gameObject.AddComponent<AudioSource>();
        sound3 = gameObject.AddComponent<AudioSource>();

        sound1.clip = Resources.Load<AudioClip>("b_s");
        sound2.clip = Resources.Load<AudioClip>("a_s");
        sound3.clip = Resources.Load<AudioClip>("pip");

        // Начинаем корутину с задержкой
        StartCoroutine(PlayDelayedSound1());
    }

    private System.Collections.IEnumerator PlayDelayedSound1()
    {
        yield return new WaitForSeconds(1f); // Задержка в 1 секунду

        sound1.Play();
        isPlayingSound1 = true;
    }

    private void Update()
    {
        // Проверяем, нажаты ли кнопки WASD
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isAPressed = Input.GetKey(KeyCode.A);
        bool isSPressed = Input.GetKey(KeyCode.S);
        bool isDPressed = Input.GetKey(KeyCode.D);
        bool isSpacePressed = Input.GetKey(KeyCode.Space);

        // Если не нажата ни одна кнопка, играем звук 1
        if (!isWPressed && !isAPressed && !isSPressed && !isDPressed && !isSpacePressed && !isPlayingSound2 && !isPlayingSound3)
        {
            if (!isPlayingSound1)
            {
                sound1.Stop();
                sound1.Play();
                isPlayingSound1 = true;
            }
        }
        // Если нажата хотя бы одна кнопка WASD, играем звук 2
        else if ((isWPressed || isAPressed || isSPressed || isDPressed) && !isPlayingSound3)
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
            sound3.Play();
            isPlayingSound3 = true;
        }
        // Если ни одна из вышеперечисленных кнопок не нажата, останавливаем все звуки и сбрасываем флаги
        else
        {
            sound1.Stop();
            sound2.Stop();
            sound3.Stop();
            isPlayingSound1 = false;
            isPlayingSound2 = false;
            isPlayingSound3 = false;
        }
    }
}
