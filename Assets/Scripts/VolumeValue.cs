using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource _source;
    private float _musicVolume = 1f;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        _source.volume = _musicVolume;
    }
    /// <summary>
    /// Регулировка громкости
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        _musicVolume = volume;
    }
}
