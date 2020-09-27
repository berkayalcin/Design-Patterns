using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handmade_Interpreter
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition,
            Subtraction
        }

        public Type OperationType;
        public IElement Left, Right;


        public int Value
        {
            get
            {
                switch (OperationType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Subtraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public class Token
    {
        public enum Type
        {
            Integer,
            Plus,
            Minus,
            LeftParentheses,
            RightParentheses,
        }

        public Type TokenType;
        public string Text;

        public Token(Type tokenType, string text)
        {
            TokenType = tokenType;
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        public override string ToString()
        {
            return $"{Text}";
        }
    }


    class Program
    {
        static List<Token> Lex(string input)
        {
            List<Token> result = new List<Token>();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Token.Type.LeftParentheses, "("));
                        break;
                    case ')':
                        result.Add(new Token(Token.Type.RightParentheses, ")"));
                        break;
                    default:
                        var sb = new StringBuilder(input[i].ToString());
                        for (int j = i + 1; j < input.Length; ++j)
                        {
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                ++i;
                            }
                            else
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                break;
                            }
                        }

                        break;
                }
            }

            return result;
        }

        static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.TokenType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }

                        break;
                    case Token.Type.Plus:
                        result.OperationType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.OperationType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.Type.LeftParentheses:

                        int j = i;

                        for (; j < tokens.Count; ++j)
                            if (tokens[j].TokenType == Token.Type.RightParentheses)
                                break;
                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subexpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = element;
                        }

                        i = j;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }


        static void Main(string[] args)
        {
            // ( 13 + 4 ) - ( 12 + 1 )
            string input = "(13+4)-(12+1)";

            var tokens = Lex(input);
            Console.WriteLine(string.Join('\t', tokens));

            var parsed = Parse(tokens);
            Console.WriteLine(parsed.Value);
        }
    }
}