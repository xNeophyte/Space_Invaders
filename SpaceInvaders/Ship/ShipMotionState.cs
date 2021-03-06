﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShipMotionState
    {
        // state()
        public abstract void Handle(Ship pShip);

        // strategy()
        public abstract void MoveRight(Ship pShip);
        public abstract void MoveLeft(Ship pShip);
    }
}
