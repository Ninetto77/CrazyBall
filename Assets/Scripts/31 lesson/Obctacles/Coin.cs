using UnityEngine;

public class Coin : MonoBehaviour
{
    public float TimeOfDeath = 0.1f;
    public int Bonuse = 10;
    [SerializeField] private ParticleSystem explosion;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            audioManager.PlaySound(GlobalStrings.COIN_SOUND_STRING);
            GameManager.OnSelectCoin?.Invoke(Bonuse);

            ExplodeCoin();

        }
    }

    private void ExplodeCoin()
    {
        explosion.gameObject.SetActive(true);
        explosion.Play();
        Destroy(this.gameObject, TimeOfDeath);
    }
}
