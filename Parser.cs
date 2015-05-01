using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictiveParser
{
    public static class Parser
    {
        //dicts
        private static Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>> EDict = new Dictionary<Token.TokenType,List<Func<Queue<Token>, bool>>>();
        private static Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>> XDict = new Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>>();
        private static Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>> TDict = new Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>>();
        private static Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>> YDict = new Dictionary<Token.TokenType, List<Func<Queue<Token>, bool>>>();


        private static Queue<Token> tokens = new Queue<Token>();

        //Delegates to Check Dictionary
        private static bool E(Queue<Token> t) 
        {
            if (!EDict.ContainsKey(t.First().type))
            {
                return false;
            }
            var EList = EDict[t.First().type];
            for (int i = 0; i < EList.Count; i++)
            {
                if (!EList[i](t))
                {
                    return false;
                }
            }
            if (tokens.First().token == "$") {
                return true; 
            }
            return false;
        }

        private static bool X(Queue<Token> t)
        {
            if (!XDict.ContainsKey(t.First().type))
            {
                return false;
            }
            var XList = XDict[t.First().type];
            for (int i = 0; i < XList.Count; i++)
            {
                if (!XList[i](t))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool T(Queue<Token> t)
        {
            if (!TDict.ContainsKey(t.First().type))
            {
                return false;
            }
            var TList = TDict[t.First().type];
            for (int i = 0; i < TList.Count; i++)
            {
                if (!TList[i](t))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Y(Queue<Token> t)
        {
            if (!YDict.ContainsKey(t.First().type))
            {
                return false;
            }
            var YList = YDict[t.First().type];
            for (int i = 0; i < YList.Count; i++)
            {
                if (!YList[i](t))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool Eps(Queue<Token> t)
        {
            return true;
        }

        private static bool Term(Queue<Token> t)
        {
            t.Dequeue();
            return true;
        }

        public static bool Validate(String input){
            tokens = Tokenize(input);
            if (tokens == null)
            {
                return false;
            }
            return E(tokens);
        }

        private static Queue<Token> Tokenize(String input){
            Queue<Token> t = new Queue<Token>();
            input = input.Replace(" ", "");

            int tmp;
            StringBuilder number = new StringBuilder();
            foreach(Char c in input)
            {
                if (Int32.TryParse(c.ToString(),out tmp))
                {
                    number.Append(c);
                    continue;
                }
                if (number.Length > 0)
                {
                    t.Enqueue(new Token(Token.TokenType.INT, number.ToString()));
                    number.Clear();
                }
                switch(c)
                {
                    case '*':
                        t.Enqueue(new Token(Token.TokenType.MUL, "*"));
                        break;
                    case '+':
                        t.Enqueue(new Token(Token.TokenType.ADD, "+"));
                        break;
                    case '(':
                        t.Enqueue(new Token(Token.TokenType.LP, "("));
                        break;
                    case ')':
                        t.Enqueue(new Token(Token.TokenType.RP, ")"));
                        break;
                    default:
                        return null;
                }
            }
            if (number.Length > 0)
            {
                t.Enqueue(new Token(Token.TokenType.INT, number.ToString()));
                number.Clear();
            }
            t.Enqueue(new Token(Token.TokenType.DOLLADOLLABILLYALL, "$"));
            return t;
        }
        static Parser (){
            //initialize dictionaries
            var list = new List<Func<Queue<Token>, bool>>();
            list.Add(T);
            list.Add(X);
            EDict.Add(Token.TokenType.INT, list);

            list = new List<Func<Queue<Token>, bool>>();
            list.Add(T);
            list.Add(X);
            EDict.Add(Token.TokenType.LP, list);

            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Term);
            list.Add(E);
            XDict.Add(Token.TokenType.ADD, list);
            
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Eps);
            XDict.Add(Token.TokenType.RP, list);
            
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Eps);
            XDict.Add(Token.TokenType.DOLLADOLLABILLYALL, list);
            
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Term);
            list.Add(Y);
            TDict.Add(Token.TokenType.INT, list);
       
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Term);
            list.Add(E);
            list.Add(Term);
            TDict.Add(Token.TokenType.LP, list);

            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Term);
            list.Add(T);
            YDict.Add(Token.TokenType.MUL, list);
                       
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Eps);
            YDict.Add(Token.TokenType.ADD, list);
            
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Eps);
            YDict.Add(Token.TokenType.RP, list);
            
            list = new List<Func<Queue<Token>, bool>>();
            list.Add(Eps);
            YDict.Add(Token.TokenType.DOLLADOLLABILLYALL, list);

        }

    }
}
