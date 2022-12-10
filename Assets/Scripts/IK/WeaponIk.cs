using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class HumanBone
{
    public HumanBodyBones bone;
    public float weight = 1.0f;
}

public class WeaponIk : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Transform _aimTransform;

    [SerializeField] private int _iterations = 10;
    [Range(0, 1)]
    [SerializeField] private float _weight = 1.0f;
    [SerializeField]private HumanBone[] _humanBones;

    private Transform[] _boneTransforms;

    private void Start()
    {
        Animator animator = GetComponent<Animator>();
        _boneTransforms = new Transform[_humanBones.Length];
        
        for (int i = 0; i < _boneTransforms.Length; i++)
        {
            _boneTransforms[i] = animator.GetBoneTransform(_humanBones[i].bone);
        }
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = _targetTransform.position;

        for (int i = 0; i < _iterations; i++)
        {
            for (int b = 0; b < _boneTransforms.Length; b++)
            {
                Transform bone = _boneTransforms[b];
                float boneWeight = _humanBones[b].weight * _weight;
                AimAtTarget(bone, targetPosition, boneWeight);
            }
        }
    }

    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        Vector3 aimDirection = _aimTransform.forward;
        Vector3 targetDirection = targetPosition - _aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        bone.rotation = blendedRotation * bone.rotation;
    }
}
