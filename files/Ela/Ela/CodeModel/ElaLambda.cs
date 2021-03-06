﻿using System;
using System.Text;
using Ela.Parsing;

namespace Ela.CodeModel
{
    public sealed class ElaLambda : ElaEquation
    {
        internal ElaLambda(Token tok) : base(tok, ElaNodeType.Lambda)
        {
            
        }
        
        public ElaLambda() : this(null)
        {
            
        }

        internal override bool Safe()
        {
            return false;
        }

        internal override void ToString(StringBuilder sb, int ident)
        {
            sb.Append('\\');

            if (Left == null)
                sb.Append("<null>");
            else
            {
                if (Left.Type == ElaNodeType.Juxtaposition)
                {
                    var j = (ElaJuxtaposition)Left;
                    Format.PutInParens(j.Target, sb);

                    if (j.Parameters.Count > 0)
                        sb.Append(' ');

                    foreach (var p in j.Parameters)
                    {
                        Format.PutInParens(p, sb);
                        sb.Append(' ');
                    }
                }
                else
                {
                    Format.PutInParens(Left, sb);
                    sb.Append(' ');
                }
            }

            sb.Append("-> ");

            if (Right != null)
                Right.ToString(sb, 0);
            else
                sb.Append("<null>");
        }

        internal int GetParameterCount()
        {
            return Left.Type != ElaNodeType.Juxtaposition ? 1 : ((ElaJuxtaposition)Left).Parameters.Count + 1;
        }
    }
}
