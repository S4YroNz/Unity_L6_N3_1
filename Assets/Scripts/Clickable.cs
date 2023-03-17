using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private Chunk _chunkPrefab;
    [SerializeField] private Resources _resources;
    [SerializeField] private Renderer _cubeRenderer;

    private int _coinsPerClick = 1;

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
       // HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        Vector3 chunkPosition = transform.position;
        chunkPosition.y = 1.3f;
        Chunk newChunk = Instantiate(_chunkPrefab, chunkPosition, Quaternion.identity);
        newChunk.Init(_resources,_cubeRenderer, _hitEffectPrefab);
        newChunk.JumpOut();
       // hitEffect.Init(_coinsPerClick);
       
       StartCoroutine(HitAnimation());
    }

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

}
