﻿using Sprache;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SphereSharp.Syntax
{
    public class ArgumentListSyntax : SyntaxNode
    {
        public static ArgumentListSyntax Empty { get; }
            = new ArgumentListSyntax(ImmutableArray<ArgumentSyntax>.Empty);

        public ImmutableArray<ArgumentSyntax> Arguments { get; }
        public _ArgumentSyntax[] _Arguments { get; }

        public ArgumentListSyntax(IEnumerable<_ArgumentSyntax> arguments)
        {
            _Arguments = arguments.ToArray();
        }

        public ArgumentListSyntax(ImmutableArray<ArgumentSyntax> arguments)
        {
            Arguments = arguments;
        }

        public static ArgumentListSyntax Parse(string src)
        {
            return ArgumentListParser.ArgumentList.Parse(src);
        }

        public static ArgumentListSyntax _Parse(string src) => ArgumentListParser._ArgumentList.Parse(src);

        public override void Accept(SyntaxVisitor visitor)
        {
            visitor.VisitArgumentList(this);
        }

        public override IEnumerable<SyntaxNode> GetChildNodes() => Arguments;

        public bool IsEmpty => Arguments.Length == 0;
    }
}
