using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoreBattle
{
    internal class TheUncodedOne : Character
    {
        public override string Name => "THE UNCODED ONE";
        public override IAttack BasicAttack => throw new NotImplementedException();
        public TheUncodedOne() : base(15, Team.Enemy) { }
    }
}
