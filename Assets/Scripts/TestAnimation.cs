using UnityEngine;
using DragonBones;

public class TestAnimation : MonoBehaviour
{
    //public Armature asd;
    void Start()
    {
        UnityFactory.factory.LoadDragonBonesData("DBProjectsnew/swMan_idle_04_ske");
        // DragonBones file path (without suffix)
        UnityFactory.factory.LoadTextureAtlasData("DBProjectsnew/swMan_idle_04_tex");
        //Texture atlas file path (without suffix)
        // Create armature. 
        var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Armature");


        // Input armature name
        // Play animation. 
        armatureComponent.animation.Play("swordMan_idle");
        // Change armatureposition. 
        armatureComponent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        //asd.animation.Play("SwordMan_idle");
    }
}