using System.Collections.Generic;
using UnityEngine;

namespace utils
{
    public class GenericComponentSpawner<T> : MonoBehaviour where T : Component, new()
    {
        [Header("Components")]
        [SerializeField] private GameObject _prefab;

        [Header("Settings")]
        [SerializeField] private int _startQueueSize = 10;

        private List<T> _activeComponents = new List<T>();
        private PoolController<T> _queuedComponents;

        private bool _initialized = false;

        public void Initialize()
        {
            if (_initialized) return;
            _initialized = true;

            _queuedComponents = new PoolController<T>(_startQueueSize, prefab: _prefab);
        }

        public virtual void Spawn(Vector2 position, Vector2 direction)
        {
            T newParticleSystem = _queuedComponents.Dequeue();
            newParticleSystem.gameObject.SetActive(true);

            _activeComponents.Add(newParticleSystem);
        }
        public void DestroyAll()
        {
            for (int i = _activeComponents.Count - 1; i >= 0; i--)
            {
                Destroy(_activeComponents[i]);
            }
        }

        public virtual void Destroy(T component)
        {
            _activeComponents.Remove(component);
            _queuedComponents.Enqueue(component);

            component.gameObject.SetActive(false);
        }
    }
}
