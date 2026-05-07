using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoreBattle
{
    internal class Hero : Character
    {
        public override string Name => "PLAYER";
        public override IAttack BasicAttack => throw new NotImplementedException();
        public Hero() : base(25, Team.Player) { }
    }
}
