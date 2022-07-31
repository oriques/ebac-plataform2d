using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ecco.Core.Singleton;

public class VFXmanager : Singleton<VFXmanager>
{
   public enum VFXType
    {
        JUMP,
        VFX_2
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXbyType(VFXType vfxType, Vector3 position)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 5f);
                break; 
            }
        }
    }


}
[System.Serializable]
public class VFXManagerSetup
{
    public VFXmanager.VFXType vfxType;
    public GameObject prefab;
}