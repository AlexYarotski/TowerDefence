using UnityEngine;

[CreateAssetMenu(fileName = "ArrowSettings", menuName = "Settings/ArrowSettings", order = 0)]
public class ArrowSettings : ScriptableObject
{
    [SerializeField]
    private float _speed = 0;
    
    [SerializeField] 
    private float _damage = 0;

    public float Speed => _speed;
    public float Damage => _damage;
}
