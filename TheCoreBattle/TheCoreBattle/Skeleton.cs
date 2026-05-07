using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoreBattle
{
    public class Skeleton : Character
    {
        public override string Name => "SKELETON";
        public override IAttack BasicAttack => throw new NotImplementedException();
        public Skeleton() : base(5, Team.Enemy) { }
    }
}
