﻿using Antlr4.Runtime;
using System;
using System.IO;

namespace SphereSharp.Tests
{
    public class FailTestErrorListener : BaseErrorListener
    {
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new Exception($"{line},{charPositionInLine} {msg}");
        }
    }
}
