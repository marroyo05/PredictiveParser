using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveParser
{
    internal class Token
    {
        public enum TokenType { INT, MUL, ADD, LP, RP, DOLLADOLLABILLYALL};
        internal TokenType type;
        internal string token;


        internal Token(TokenType TT,String S) {
            type = TT;
            token = S;
        }
    }
}
