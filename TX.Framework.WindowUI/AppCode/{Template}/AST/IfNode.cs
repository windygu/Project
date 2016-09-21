#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Template
{
    internal class IfNode : ExpressionNode
    {
        private TokenNode _TrueNode;
        public TokenNode _FalseNode;

        public IfNode(TokenMatch tokenMatch)
            : base(tokenMatch)
        {
            _TrueNode = new TokenNode();
            _FalseNode = new TokenNode();
        }

        public override void Evaluate(IExpressionParser parser, ITemplateContext context, StringBuilder output)
        {
            bool result = context.ToBoolean(parser.Parse(this.Expression).Evaluate(context).Value);
            TokenNode node = result ? TrueNode : FalseNode;
            foreach (TokenNode n in node.ChildNodes)
            {
                n.Evaluate(parser, context, output);
            }
        }

        public static explicit operator IfNode(TokenMatch tokenMatch)
        {
            return new IfNode(tokenMatch);
        }

        public TokenNode TrueNode
        {
            get { return this._TrueNode; }
            set { this._TrueNode = value; }
        }

        public TokenNode FalseNode
        {
            get { return this._FalseNode; }
            set { this._FalseNode = value; }
        }
    }
}