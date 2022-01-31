using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : Element
{
    // Handles the ball hit event
    public void OnBallGroundHit()
    {
        app.model.bounces++;
        Debug.Log("Bounce "+app.model.bounces);
        if (app.model.bounces >= app.model.winCondition)
        {
            app.view.player.enabled = false;
            app.view.player.GetComponent<Rigidbody>().isKinematic = true; // stops the ball
            OnGameComplete();
        }
    }

    // Handles the win condition
    public void OnGameComplete() { Debug.Log("Victory!!"); }

    public void OnNotification(string p_event_path, Object p_target, params object[] p_data)
    {
        //switch (p_event_path)
        //{
        //    case Notification.BallHitGround:
        //        app.model.bounces++;
        //        Debug.Log("Bounce "  +app.model.bounces);
        //        if (app.model.bounces >= app.model.winCondition)
        //        {
        //            app.view.player.enabled = false;
        //            app.view.player.GetComponent<Rigidbody>().isKinematic = true; // stops the ball
        //                                                                        // Notify itself and other controllers possibly interested in the event
        //            app.Notify(Notification.GameComplete, this);
        //        }
        //        break;

        //    case Notification.GameComplete:
        //        Debug.Log("Victory!!");
        //        break;
        //}
    }
}
