using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nova.Framework.Dependency;

namespace Nova.Framework.Actor.Component
{
    public class ActorComponent
    {
        protected virtual void Load(DependencyContainer dependencyContainer) { }
    }
}
