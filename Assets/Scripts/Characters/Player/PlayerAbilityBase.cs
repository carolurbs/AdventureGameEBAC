using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityBase : MonoBehaviour
{
    protected Player player;
    protected Inputs inputs; 
    private void OnValidate()
    {
        if(player == null) player = GetComponent<Player>();
    }
    private void Start()
    {
        inputs=new Inputs();
        inputs.Enable();

        Init();
        OnValidate();
        RegisterListeners();
    }

    private void OnEnable()
    {
        if(inputs != null)
        inputs.Enable();
    }

    public void OnDisable()
    {
        inputs.Disable();
    }
    private void OnDestroy()
    {
        RemoveListeners();
    }
    protected virtual void Init()
    {

    }
    protected virtual void RegisterListeners()
    {

    }
    protected virtual void RemoveListeners()
    {

    }

}
