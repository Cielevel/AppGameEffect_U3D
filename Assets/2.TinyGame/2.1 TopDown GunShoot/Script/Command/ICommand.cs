using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownGunShoot
{
    public abstract class ICommand
    {
        protected ICommand() { }

        public abstract void Execute();

        public abstract void Execute(GameActor actor);
    }
}