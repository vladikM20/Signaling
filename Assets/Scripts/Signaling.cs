using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _duration;

    private Coroutine _smoothVolumeChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ThiefCheck(collision, 1f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ThiefCheck(collision, 0f);
    }

    private void ThiefCheck(Collider2D collision, float targetVolume)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            if (_smoothVolumeChange != null)
                StopCoroutine(_smoothVolumeChange);

            _smoothVolumeChange = StartCoroutine(SmoothVolumeChange(_audio.volume, targetVolume));
        }
    }

    private IEnumerator SmoothVolumeChange(float startVolume, float targetVolume)
    {
        float elapsed = 0;

        while (_audio.volume != targetVolume)
        {
            _audio.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / _duration);
            elapsed += Time.deltaTime;

            yield return null;
        }
    }
}
