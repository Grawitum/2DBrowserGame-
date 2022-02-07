using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : Element
{
    // Only this is necessary. Physics is doing the rest of work.
    // Callback called upon collision.

    void OnCollisionEnter() { app.Notify(Notification.BallHitGround, this); }
}
