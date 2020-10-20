using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyExcelLAB
{
    class LabCalculatorVisitor : CustomGrammarBaseVisitor<double>
    {

       

        public override double VisitCompileUnit(CustomGrammarParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(CustomGrammarParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }


        public override double VisitParenthesizedExpr(CustomGrammarParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitExponentialExpr(CustomGrammarParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            Debug.WriteLine("{0} ^ {1}", left, right);
            return System.Math.Pow(left, right);
        }
        
        public override double VisitUnaryPlus([NotNull] CustomGrammarParser.UnaryPlusContext context)
        {
            var left = WalkLeft(context);
            Debug.WriteLine("{0} ", left);
            return left;

        }
        public override double VisitUnaryMinus([NotNull] CustomGrammarParser.UnaryMinusContext context)
        {
            var left = WalkLeft(context);
            Debug.WriteLine("-{0} ", left);
            return -left;

        }
        


        public override double VisitUnaryExpr([NotNull] CustomGrammarParser.UnaryExprContext context)
        {
            var left= WalkLeft(context);
            if (context.operatorToken.Type == CustomGrammarLexer.INC)
            {
                Debug.WriteLine("{0} + 1", left);
                return left + 1;
            }
            else //LabCalculatorLexer.DEC
            {
                Debug.WriteLine("{0} - 1", left);
                return left - 1;
            }
        }

        public override double VisitMultiplicativeExpr([NotNull] CustomGrammarParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            if(right==0)
            {
                throw new DivideByZeroException();
            }

            if (context.operatorToken.Type == CustomGrammarLexer.MOD)
            {
                Debug.WriteLine("{0} % {1}", left, right);
                return left % right;
            }
            else //LabCalculatorLexer.DIV
            {
                Debug.WriteLine("{0} / {1}", left, right);
                return (int)left / (int)right;
            }


        }
        public override double VisitAdditiveExpr(CustomGrammarParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == CustomGrammarLexer.PLUS)
            {
                Debug.WriteLine("{0} + {1}", left, right);
                return left + right;
            }
            else //LabCalculatorLexer.SUBTRACT
            {
                Debug.WriteLine("{0} - {1}", left, right);
                return left - right;
            }
        }

        private double WalkLeft([NotNull]CustomGrammarParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CustomGrammarParser.ExpressionContext>(0));
        }

        private double WalkRight([NotNull] CustomGrammarParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<CustomGrammarParser.ExpressionContext>(1));
        }
    }
}
