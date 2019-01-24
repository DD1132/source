using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Requirements
    {

        private bool Revers = false;
        public bool revers { get => Revers; set => Revers = value; }
        private bool u_turn = false;
        public bool U_turn { get => u_turn; set => u_turn = value; }
        private bool Speed = false;
        public bool speed { get => Speed; set => Speed = value; }
        private bool Breks = false;
        public bool breks { get => Breks; set => Breks = value; }
        private bool Blinks = false;
        public bool blinks { get => Blinks; set => Blinks = value; }
        private bool mirrors = false;
        public bool Mirrors { get => mirrors; set => mirrors = value; }

        public override string ToString()
        {
            return "\nrevers: " + revers +
                "  U_turn: " + U_turn +
                "  speed: " + speed +
                "  breks: " + breks +
                "  blinks: " + blinks +
                "  Mirrors: " + Mirrors;
        }
        public Requirements Clone()
        {
            Requirements result = new Requirements
            {
                revers = this.revers,
                U_turn = this.U_turn,
                speed = this.speed,
                breks = this.breks,
                blinks = this.blinks,
                Mirrors = this.Mirrors

            };
            return result;
        }
    }

}