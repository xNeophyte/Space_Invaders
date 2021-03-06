﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class CollidingLeftWallState : GridState
    {
        private Boolean alreadyMovedDown = false;

        public override void Handle(InvaderGrid pGrid)
        {
            pGrid.SetState(InvaderGridManager.State.NotCollingWithWall);
        }

        public override void Move(InvaderGrid pGrid)
        {
            if (this.alreadyMovedDown)
            {
                //Debug.WriteLine("Grid Colliding with Left Wall : Moving Right");
                pGrid.speedX = Math.Abs(pGrid.roStaticSpeedX);
                pGrid.speedY = 0.0f;

                this.Handle(pGrid);
                this.alreadyMovedDown = false;
            }
            else
            {
                //Debug.WriteLine("Grid Colliding with Left Wall : Moving Down");
                pGrid.speedX = 0.0f;
                pGrid.speedY = -Math.Abs(pGrid.roStaticSpeedY);
                this.alreadyMovedDown = true;

                SpeedUpGridMarchObserver pObserver = new SpeedUpGridMarchObserver(pGrid.speedUpMultiplier);
                DelayedObjectManager.Attach(pObserver);
            }
        }
    }
}
