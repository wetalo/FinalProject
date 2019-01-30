using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusterGun : MonoBehaviour {


    enum BusterGunStates
    {
        isCooling,
        isCharging
    }

    BusterGunStates state;

    [Header("Gun Attributes")]
    [SerializeField]
    float chargeTime;
    [SerializeField]
    float coolTime;
    [SerializeField]
    float maxProjectileSizeMultiplier;

    float chargeTimer;
    float coolTimer;
    float currentProjectileSizeMultiplier;

    [Space]
    [Header("Projectile Attributes")]
    [SerializeField]
    GameObject projectilePrefab;
    GameObject projectileInstance;
    Vector3 initialProjectileScale;
    [SerializeField]
    float projectileSpeed;


    [Space]
    [Header("Gun Components")]
    [SerializeField]
    HandleTriggerZone triggerZone;
    [SerializeField]
    Transform muzzle;

    bool canFire = true;
    

    // Use this for initialization
    void Start () {
        state = BusterGunStates.isCooling;
        chargeTimer = 0f;
        coolTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        RunStates();
	}

    void RunStates()
    {
        if (state == BusterGunStates.isCooling)
        {
            if (TriggerPulled()  && triggerZone.isTouchingRightController && canFire)
            {
                BeginCharging();
            }
        }

        Charge();
        Cool();
    }

    void BeginCharging()
    {
        state = BusterGunStates.isCharging;
        projectileInstance = GameObject.Instantiate(projectilePrefab, muzzle.position, Quaternion.identity);
        projectileInstance.transform.parent = muzzle;
        chargeTimer = 0f;
        currentProjectileSizeMultiplier = 1.0f;
        initialProjectileScale = projectileInstance.transform.localScale;
    }

    void Charge()
    {
        if (state == BusterGunStates.isCharging)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer < chargeTime)
            {
                currentProjectileSizeMultiplier = 1.0f + ((maxProjectileSizeMultiplier - 1.0f) * chargeTimer / chargeTime);
                projectileInstance.transform.localScale = initialProjectileScale * currentProjectileSizeMultiplier;
            }
            if (!TriggerPulled() || !triggerZone.isTouchingRightController)
            {
                StopCharging();
            }
        }
    }

    void StopCharging()
    {
        projectileInstance.transform.parent = null;
        projectileInstance.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * projectileSpeed, ForceMode.Impulse);
        canFire = false;
        StartCooling();
    }

    void StartCooling()
    {
        state = BusterGunStates.isCooling;
        coolTimer = 0f;
    }

    void Cool()
    {
        if(state == BusterGunStates.isCooling)
        {
            coolTimer += Time.deltaTime;
            if(coolTimer > coolTime)
            {
                canFire = true;
            }
        }
    }

    void StopCooling()
    {

    }

    bool TriggerPulled()
    {
        return TouchHandler.TH.rightTouchPrimaryHandTriggerPulled &&
               TouchHandler.TH.rightTouchPrimaryIndexTriggerPulled &&
               TouchHandler.TH.leftTouchPrimaryHandTriggerPulled &&
               TouchHandler.TH.leftTouchPrimaryIndexTriggerPulled;
    }
}
