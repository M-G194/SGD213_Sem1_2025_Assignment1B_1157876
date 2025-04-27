using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTripleShot : WeaponBase {

    /// <summary>
    /// Shoot will spawn a three bullets, provided enough time has passed compared to our fireDelay.
    /// </summary>
    public override void Shoot() {
        // Get the current time
        float currentTime = Time.time;

        // If enough time has passed since our last shot compared to our fireDelay, spawn our bullet
        if (currentTime - lastFiredTime > fireDelay) {
            float x = -2f;
            // Create 3 bullets
            for (int i = 0; i < 3; i++) {
                // Create our bullet
                GameObject newBullet = Instantiate(bullet, bulletSpawnPoint.position, transform.rotation);
                // Set their direction
                newBullet.GetComponent<EngineBase>().initialVelocity = new Vector2(x + 2f * i, 5f);
            }

            // Update our shooting state
            lastFiredTime = currentTime;
        }
    }
}
