using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Renderer _clickableRenderer;
    private Renderer _renderer;
    private Rigidbody _rigitbody;
    private Transform _transform;
    private Resources _resources;
    private HitEffect _hitEffectPrefab;
    private int _coinsPerClick = 1;

    public void Init(Resources resources, Renderer cubeRenderer, HitEffect hitEffectPrefab)
    {
        _resources = resources;
        _hitEffectPrefab= hitEffectPrefab;
        _renderer = GetComponent<Renderer>();
        _renderer.material = cubeRenderer.material;

    }


    public void JumpOut()
    {
        _transform = GetComponent<Transform>();
        _rigitbody = GetComponent<Rigidbody>();
        _transform.Rotate(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        _rigitbody.AddForce(Random.Range(-100f,100f), 200f, Random.Range(-100f, 100f));

    }

    public void Hit()
    {
        _resources.CollectCoins(1, transform.position);
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
        Destroy(gameObject);
    }
}
